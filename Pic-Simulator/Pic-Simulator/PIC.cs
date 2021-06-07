using System;
using System.Collections.Generic;
using System.Text;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public class PIC
    {
        public delegate void GUIUpdateEventHandler(object sender, UpdateEventArgs<byte> e);

        public event GUIUpdateEventHandler UpdateGUI;

        protected virtual void OnStepGUIUpdate(UpdateEventArgs<byte> e)
        {
            GUIUpdateEventHandler handler = UpdateGUI;
            handler?.Invoke(this, e);
        }

        public static int MAX_DATAMEM_SIZE = 256;
        public static int MAX_PROGMEM_SIZE = 8192;

        public ProgramMemory progMem;
        public DataMemory dataMem;

        public DataField wReg{ get; private set; }

        private UInt16 _pc;
        public UInt16 pc { 
            get 
            {
                return _pc;
            } 
            set 
            {
                _pc = value;
                this.dataMem?.Set((byte)RegisterAddress.PCL, (byte)value);
            } 
        }

        public Stack<UInt16> stack;

        public int clock { get; private set; }

        public int prevClock { get; private set; }

        public int tmr0Inhibit;

        public int timerClock;


        public PIC()
        {
            Init();
        }

        private void Init() 
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();
            this.wReg = new DataField();
            this.pc = 0;

            this.stack = new Stack<UInt16>(8);

            this.clock = 0;
            this.prevClock = 0;
            this.tmr0Inhibit = 0;
            this.timerClock = 0;

            this.dataMem.Set(1, true, 255);
            this.dataMem.Set(3, 24);
            this.dataMem.Set(5, true, 31);
            this.dataMem.Set(6, true, 255);

        }

        public bool Step(bool updateGUI)
        {
            prevClock = clock;
            if (CheckInterrupt()) 
            {
                if (updateGUI) { OnStepGUIUpdate(new UpdateEventArgs<byte>()); }
                return true;
            }

            UInt16 data = CodeExecution.Fetch();

            if (data == UInt16.MaxValue) return false; //end of code has been reached

            this.pc++; //increment pc after fetch

            CodeExecution.Instruction instruction = CodeExecution.Decode(data);

            bool success = CodeExecution.Execute(instruction, data);


            //refresh gui after
            if (updateGUI) { OnStepGUIUpdate(new UpdateEventArgs<byte>()); }

            return success;
        }

        public void Reset()
        {
            Init();
        }

        bool CheckInterrupt()
        {
            if (dataMem.GetFlag((byte)RegisterAddress.INTCON, 7))
            {
                //TMR0 INTERRUPT
                if(dataMem.GetFlag((byte)RegisterAddress.INTCON, 2) && dataMem.GetFlag((byte)RegisterAddress.INTCON, 5))
                {
                    Interrupt();
                    return true;
                }
                //EXTERNAL INTERRUPT
                else if (dataMem.GetFlag((byte)RegisterAddress.INTCON, 1) && dataMem.GetFlag((byte)RegisterAddress.INTCON, 4))
                {
                    Interrupt();
                    return true;
                }
                //PORT RB INTERRUPT
                else if (dataMem.GetFlag((byte)RegisterAddress.INTCON, 0) && dataMem.GetFlag((byte)RegisterAddress.INTCON, 3))
                {
                    Interrupt();
                    return true;
                }
            }
            return false;
        }

        void Interrupt()
        {
            dataMem.ClearFlag((byte)RegisterAddress.INTCON, 7);

            CodeExecution.Execute(CodeExecution.Instruction.CALL, 0b_00100000_00000100);

        }

        public void DoClockTicks(bool source)
        {
            clock++;
            if (tmr0Inhibit > 0)
            {
                tmr0Inhibit--;
                return;
            }
            else if (!dataMem.GetFlag((byte)RegisterAddress.OPTION, true, 5) && !source)
            {
                timerClock++;
                UpdateTimer();
            }
            else if (dataMem.GetFlag((byte)RegisterAddress.OPTION, true, 5) && source)
            {
                timerClock++;
                UpdateTimer();
            }

        }

        public void UpdateTimer()
        {
            bool prescalerAssignment = dataMem.GetFlag((byte)RegisterAddress.OPTION, true, 3);
            if (this.timerClock % dataMem.GetPrescaler(prescalerAssignment) == 0)
            {
                this.timerClock = 0;
                if (!prescalerAssignment)
                {
                    byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                    //set T0IF interrupt
                    if(oldValue == byte.MaxValue) { dataMem.SetFlag((byte)RegisterAddress.INTCON, 2); }
                    dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
                    tmr0Inhibit = 0;
                }
            }
            if (prescalerAssignment)
            {
                this.timerClock = 0;
                byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                if (oldValue == byte.MaxValue) { dataMem.SetFlag((byte)RegisterAddress.INTCON, 2); }
                dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
                tmr0Inhibit = 0;
            }
        }
    }
}

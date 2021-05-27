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

        public DataField WDT { get; private set; }

        public Stack<UInt16> stack;

        public int clock { get; private set; }

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
            this.WDT = new DataField();

            this.stack = new Stack<UInt16>(8);

            this.clock = 0;
            this.tmr0Inhibit = 0;
            this.timerClock = 0;

            this.dataMem.Set(1, true, 255);
            this.dataMem.Set(3, 24);
            this.dataMem.Set(5, true, 31);
            this.dataMem.Set(6, true, 255);

        }

        public bool Step(bool updateGUI)
        {
            UInt16 data = CodeExecution.Fetch();

            if (data == UInt16.MaxValue) return false; //end of code has been reached

            this.dataMem.SetPC((UInt16)(this.dataMem.GetPC() + 1)); //increment pc after fetch

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

        public void DoClockTicks()
        {
            clock ++;
            if (tmr0Inhibit > 0)
            {
                tmr0Inhibit--;
                return;
            }
            else
            {
                timerClock++;
                UpdateTimer();
            }
        }

        public void UpdateTimer()
        {
            //TODO: FIX ON TEST PROGRAM 7
            //TODO: CLEAR TMR0 on?

            if (!dataMem.GetFlag((byte)RegisterAddress.OPTION, true, 5)) //TMR0 assigned to CLOCK
            {
                bool prescalerAssignment = dataMem.GetFlag((byte)RegisterAddress.OPTION, true, 3);
                if (this.timerClock % dataMem.GetPrescaler(prescalerAssignment) == 0)
                {
                    this.timerClock = 0;
                    if (!prescalerAssignment)
                    {
                        byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                        dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
                    }
                }
                else if (prescalerAssignment)
                {
                    this.timerClock = 0;
                    byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                    dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
                }
            }
            else //TMR0 assigned to RB4/T0CKI
            {
                //TODO
            }
        }
    }
}

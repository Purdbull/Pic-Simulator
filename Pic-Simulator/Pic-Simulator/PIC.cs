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

        public int Clock { get; private set; }


        public PIC()
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();
            this.wReg = new DataField();
            this.WDT = new DataField();

            this.stack = new Stack<UInt16>(8);

            this.Clock = 0;
    }

        public bool Step(bool updateGUI)
        {
            UInt16 data = CodeExecution.Fetch();

            if (data == UInt16.MaxValue) return false; //end of code has been reached

            this.dataMem.SetPC((UInt16)(this.dataMem.GetPC() + 1)); //increment pc after fetch

            CodeExecution.Instruction instruction = CodeExecution.Decode(data);

            bool success = CodeExecution.Execute(instruction, data);

            Clock++;

            UpdateTimer();

            //refresh gui after
            if (updateGUI) { OnStepGUIUpdate(new UpdateEventArgs<byte>()); }

            return success;
        }

        public void Continue()
        {
            //TODO: continuously step and stop at breakpoints
        }

        public void Run()
        {
            //TODO: continuously step without stopping at breakpoints
        }

        public void UpdateTimer()
        {
            bool prescalerAssignment = dataMem.GetFlag((byte)RegisterAddress.OPTION, 3);
            if (this.Clock % dataMem.GetPrescaler(prescalerAssignment) == 0)
            {
                if (prescalerAssignment)
                {
                    this.WDT.Increment();
                }
                else
                {
                    byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                    dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
                }
            }
            else if (prescalerAssignment)
            {
                byte oldValue = dataMem.Get((byte)RegisterAddress.TMR0, false);
                dataMem.Set((byte)RegisterAddress.TMR0, false, (byte)(oldValue + 1));
            }
        }
    }
}

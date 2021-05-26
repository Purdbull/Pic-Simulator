using System;
using System.Collections.Generic;
using System.Text;

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

        public Stack<UInt16> stack;

        public int quarzCycles;


        public PIC()
        {
            Init();
        }

        private void Init() 
        {
            this.progMem = new ProgramMemory();
            this.dataMem = new DataMemory();
            this.wReg = new DataField();

            this.stack = new Stack<UInt16>(8);

            this.quarzCycles = 0;

            this.dataMem.Set(5, true, 255);
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

        public void Continue()
        {
            //TODO: continuously step and stop at breakpoints
        }

        public void Run()
        {
            //TODO: continuously step without stopping at breakpoints
        }
    }
}

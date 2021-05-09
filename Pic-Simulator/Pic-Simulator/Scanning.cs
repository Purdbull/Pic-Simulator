using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pic_Simulator
{
    public static class Scanning
    {
        public static int Scan(string code, ProgramMemory pMemory)
        {
            StringReader reader = new StringReader(code);
            string line;
            int codeIndex = -1;
            UInt16 instructionIndex = 0;
            UInt16 instruction;
            while ((line = reader.ReadLine()) != null)
            {
                codeIndex++;
                //remove all characters after the 9th, leaving only the instructions
                try
                {
                    line = line.Remove(9);
                    if (line.Equals("         ")) continue; //line did not contain an instruction in the first 9 chars
                }
                catch (Exception)
                {
                    continue;
                }

                //split up instruction index and code
                string[] substr = line.Split(" ");

                //convert hex intruction code string to decimal byte
                instruction = Convert.ToUInt16(substr[1], 16);

                //convert instruction index string to byte
                instructionIndex = Convert.ToUInt16(substr[0]);

                //set the line of progMem at index instructionIndex to key codeIndex and value instruction
                pMemory.SetLine(instructionIndex, (UInt16)codeIndex, instruction);
            }

            return instructionIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pic_Simulator
{
    public static class Scanning
    {
        public static void Scan(string code, ProgramMemory pMemory)
        {
            StringReader reader = new StringReader(code);
            string line;
            int codeIndex = 0;
            while ((line = reader.ReadLine()) != null)
            {
                codeIndex++;
                if (line.Equals("\n")) continue;
                //remove all characters after the 9th, leaving only the instructions
                line.Remove(9);
                string[] substr = line.Split(" ");
                UInt16 instruction = ParseInstruction(substr[1]);
                UInt16 byteIndex = Convert.ToUInt16(codeIndex);
                pMemory.SetLine(codeIndex, byteIndex, instruction);
            }
        }

        public static UInt16 ParseInstruction(string strInstruction)
        {
            return Convert.ToUInt16(strInstruction, 16);
        }
    }
}

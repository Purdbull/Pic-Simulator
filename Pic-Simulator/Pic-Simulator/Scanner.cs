using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pic_Simulator
{
    static class Scanning
    {
        public static void Scan(string code, ProgramMemory pMemory)
        {
            StringReader reader = new StringReader(code);
            string line;
            int codeIndex = 0;
            while ((line = reader.ReadLine()) != null)
            {
                codeIndex++;
                if (line.Equals("")) continue;
                //remove all characters after the 9th, leaving only the instructions
                line.Remove(9);
                string[] substr = line.Split(" ");
                byte instruction = parseInstruction(substr[1]);
                byte byteIndex = Convert.ToByte(codeIndex);
                pMemory.SetLine(codeIndex, byteIndex, instruction);
            }
        }

        public static byte parseInstruction(string strInstruction)
        {
            return byte.Parse(strInstruction, System.Globalization.NumberStyles.HexNumber);
        }
    }
}

﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static ExtensionMethods.Extensions;

namespace Pic_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
                    }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void btn_OpenFile_Click(object sender, EventArgs eventArgs)
        {
            OpenFileDialog ofd = new OpenFileDialog{ Filter = "LST files (*.LST)|*.LST" };
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rtext_Code.Text = File.ReadAllText(ofd.FileName);
                    lbl_Code.Text = ofd.FileName;
                }
            } 
            catch (IOException exception)
            {
                MessageBox.Show("Unable to open requested file: \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                if (File.Exists(lbl_Code.Text))
                {
                    File.WriteAllText(lbl_Code.Text, rtext_Code.Text);
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog{ Filter = "LST files (*.LST)|*.LST" };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, rtext_Code.Text);
                        lbl_Code.Text = saveFileDialog.FileName;
                    }
                }
            }
            catch(IOException exception)
            {
                MessageBox.Show("Unable to save changes: \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog{ Filter = "LST files (*.LST)|*.LST" };
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, rtext_Code.Text);
                    lbl_Code.Text = saveFileDialog.FileName;
                }
            }
            catch(IOException exception)
            {
                MessageBox.Show("Unable to save the new file: \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {
        //    int firstCharIndex = rtext_Code.GetFirstCharIndexOfCurrentLine();
        //    int currentLine = rtext_Code.GetLineFromCharIndex(firstCharIndex);
        //    string currentLineText = rtext_Code.Lines[currentLine];
        //
        //    rtext_Code.Select(firstCharIndex, currentLineText.Length);
        //    if (!rtext_Code.SelectionBackColor.Equals(Color.Red))
        //    {
        //        rtext_Code.SelectionBackColor = Color.AliceBlue;
        //    }
        }

        private void rtext_Code_DoubleClick(object sender, EventArgs e)
        {
            if (!(rtext_Code.TextLength == 0))
            {
                int firstCharIndex = rtext_Code.GetFirstCharIndexOfCurrentLine();
                int clickedLineIndex = rtext_Code.GetLineFromCharIndex(firstCharIndex);
                string clickedLineText = rtext_Code.Lines[clickedLineIndex];

                if (!clickedLineText.StartsWith(' '))
                {
                    rtext_Code.Select(firstCharIndex, clickedLineText.Length);
                    if (!rtext_Code.SelectionBackColor.Equals(Color.Red))
                    {
                        Program.pic.breakpoints.Add(clickedLineIndex);
                        rtext_Code.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        Program.pic.breakpoints.Remove(clickedLineIndex);
                        rtext_Code.SelectionBackColor = Color.White;
                    }
                }
            }
        }

        private void btn_Debug_Click(object sender, EventArgs e)
        {
            string code = rtext_Code.Text;
            int instructionCount = Scanning.Scan(code, Program.pic.progMem); //instructionCount is 0-indexed
            Program.pic.progMem.SetLine(++instructionCount, UInt16.MaxValue, UInt16.MaxValue); //set line of progMem after the last instruction to special value
            ExecuteCode(true);
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            //TODO: CURRENTLY STOPS AT SAME BREAKPOINT
            Program.pic.Step();
            ExecuteCode(true);
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            Program.pic.Step();
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            string code = rtext_Code.Text;
            int instructionCount = Scanning.Scan(code, Program.pic.progMem); //instructionCount is 0-indexed
            Program.pic.progMem.SetLine(++instructionCount, UInt16.MaxValue, UInt16.MaxValue); //set line of progMem after the last instruction to special value
            ExecuteCode(false);
        }

        private void ExecuteCode(bool enableBreakpoints)
        {
            //If breakpoints are enabled and the current line has a breakpoint set, stop the code execution
            //else, continue
            //TODO: DO WHILE LOOP
            while (!(IsBreakpoint(Program.pic.progMem.GetKeyAtIndex(Program.pic.pc.GetValue())) && enableBreakpoints))
            {
                //int currentLine = Program.pic.progMem.GetKeyAtIndex(Program.pic.pc.GetValue());
                //int firstCharIndex = rtext_Code.GetFirstCharIndexFromLine(currentLine);
                //string lineText = rtext_Code.Lines[currentLine];
                //rtext_Code.Select(firstCharIndex, lineText.Length);
                //rtext_Code.SelectionBackColor = Color.LightGreen;

                //Step() returns false when end of code has been reached or an error has been encountered
                if (!Program.pic.Step()) return;
            }
        }

        private bool IsBreakpoint(int lineNr)
        {
            return Program.pic.breakpoints?.Contains(lineNr) ?? false;
        }

        //local methods

        public void RefreshMemoryGUI() //TODO: IMPLEMENT AND CALL ON MEMORY VALUE CHANGE
        {

        }

    }
}

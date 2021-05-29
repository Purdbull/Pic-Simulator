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
using System.Threading;

namespace Pic_Simulator
{
    public partial class Form1 : Form
    {
        readonly int RELEVANT_CHAR_NUMBER = 9;

        private bool threadKillRequest = false;

        public List<int> breakpoints = new List<int>();

        public Form1()
        {
            InitializeComponent();
            UpdateMemoryGUI();
            UpdatePortButtons();
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

        private void btn_OpenFile_Click(object sender, EventArgs eventArgs)
        {
            OpenFileDialog ofd = new OpenFileDialog{ Filter = "LST files (*.LST)|*.LST" };
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rtext_Code.Text = File.ReadAllText(ofd.FileName);
                    lbl_Code.Text = ofd.FileName;

                    FinalizePIC();
                    Initialize();
                }
            } 
            catch (IOException exception)
            {
                MessageBox.Show("Unable to open requested file: \n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Save_Click(object sender, EventArgs eventArgs)
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

        private void btn_SaveAs_Click(object sender, EventArgs eventArgs)
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
                    rtext_Code.Select(firstCharIndex, RELEVANT_CHAR_NUMBER); //mark the first 9 chars as breakpoint e.g "0001 3011"
                    if (!rtext_Code.SelectionBackColor.Equals(Color.Red))
                    {
                        this.breakpoints.Add(clickedLineIndex);
                        rtext_Code.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        this.breakpoints.Remove(clickedLineIndex);
                        rtext_Code.SelectionBackColor = Color.White;
                    }
                }
            }
        }

        private void btn_Debug_Click(object sender, EventArgs e)
        {
            Initialize();
            ExecuteCode(true);
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (!Program.pic.Step(updateGUI: false)) return;
            ExecuteCode(true);
            DisableButtons(new List<Button>() { btn_Continue });
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            threadKillRequest = true;
            FinalizePIC();
            WriteDebugOutput("Debugging stopped!");
            DisableButtons(new List<Button>() { btn_Step, btn_Continue, btn_Stop });
            EnableButtons(new List<Button>() { btn_Save, btn_SaveAs, btn_OpenFile, btn_Run, btn_Debug });
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            Program.pic.Step(updateGUI: true);
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            this.breakpoints = new List<int>();
            Initialize();
            ExecuteCode(false);
        }

        private void ExecuteCode(bool enableBreakpoints)
        {
            WriteDebugOutput("Running...");
            //If breakpoints are enabled and the current line has a breakpoint set, stop the code execution
            //else, continue
            Thread codeExecutorThread = new Thread(() =>
            {
                
                this.Invoke((MethodInvoker)delegate {
                    threadKillRequest = false;
                    EnableButtons(new List<Button>() { btn_Stop });
                    DisableButtons(new List<Button>() { btn_Save, btn_SaveAs, btn_OpenFile, btn_Run, btn_Debug, btn_Step });
                });
                    while (!(IsBreakpoint(Program.pic.progMem.GetKeyAtIndex(Program.pic.pc)) && enableBreakpoints))
                    {
                        if (threadKillRequest)
                        {
                            threadKillRequest = false;
                            return;
                        }
                        //Step() returns false when end of code has been reached or an error has been encountered
                        if (!Program.pic.Step(updateGUI: false))
                        {
                            btn_Stop.Invoke((MethodInvoker)delegate
                            {
                                btn_Stop_Click(this, new EventArgs());
                            });
                            return;
                        } //return on end of code reached
                    }
                this.Invoke((MethodInvoker)delegate {
                    EnableButtons(new List<Button>() { btn_Step, btn_Continue, btn_Stop });
                    //Update memory GUI and line marker after hitting a breakpoint
                    UpdateGUI(this, new UpdateEventArgs<byte>());
                    WriteDebugOutput("Breakpoint Hit");
                });
            });
            codeExecutorThread.Start();
        }

        private bool IsBreakpoint(int lineNr)
        {
            return this.breakpoints?.Contains(lineNr) ?? false;
        }

        //local methods

        public void MarkLine(UInt16 pc)
        {

            Unmark();

            UInt16 codeLine = Program.pic.progMem.GetKeyAtIndex(pc);
            if (codeLine == UInt16.MaxValue) return;
            int firstCharIndex = rtext_Code.GetFirstCharIndexFromLine(codeLine);
            string lineText = rtext_Code.Lines[codeLine];
            rtext_Code.Select(firstCharIndex + RELEVANT_CHAR_NUMBER, lineText.Length - RELEVANT_CHAR_NUMBER);
            rtext_Code.SelectionBackColor = Color.LightGreen;
        }

        public void Unmark()
        {
            //clear previous line marking
            int lineIndex = 0;
            foreach (string line in rtext_Code.Lines)
            {
                int charIndex = rtext_Code.GetFirstCharIndexFromLine(lineIndex);
                rtext_Code.Select(charIndex + RELEVANT_CHAR_NUMBER, line.Length - RELEVANT_CHAR_NUMBER);
                rtext_Code.SelectionBackColor = Color.White;
                lineIndex++;
            }
        }

        public void UpdateMemoryGUI()
        {
            //TODO: maybe populate table from the end for performance reasons
            tlp_Bank0.Visible = false;
            tlp_Bank0.SuspendLayout();

            tlp_Bank1.Visible = false;
            tlp_Bank1.SuspendLayout();

            tlp_SpecialRegisters.Visible = false;
            tlp_SpecialRegisters.SuspendLayout();

            ClearTLP(ref tlp_Bank0);
            ClearTLP(ref tlp_Bank1);
            ClearTLP(ref tlp_SpecialRegisters);


            InitializeTLP(ref tlp_Bank0);
            InitializeTLP(ref tlp_Bank1);
            InitializeTLP(ref tlp_SpecialRegisters);

            for (int row = 0; row < PIC.MAX_DATAMEM_SIZE / 2; row++)
            {
                tlp_Bank0.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexKeyAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_Bank0.RowCount);
                tlp_Bank0.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexValueAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_Bank0.RowCount);

                tlp_Bank0.RowStyles.Add(new RowStyle());

                tlp_Bank0.RowCount++;
            }


            for (int row = PIC.MAX_DATAMEM_SIZE / 2; row < PIC.MAX_DATAMEM_SIZE; row++)
            {
                tlp_Bank1.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexKeyAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_Bank1.RowCount);
                tlp_Bank1.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexValueAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_Bank1.RowCount);

                tlp_Bank1.RowStyles.Add(new RowStyle());

                tlp_Bank1.RowCount++;
            }

            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "W-Reg", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Program.pic.wReg.GetAsBinaryValue(), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());
            tlp_SpecialRegisters.RowCount++;

            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "FSR", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Program.pic.dataMem.GetBinaryValueAtIndex(4), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());
            tlp_SpecialRegisters.RowCount++;


            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "PC", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Convert.ToString(Program.pic.pc), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());
            tlp_SpecialRegisters.RowCount++;

            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "PCL", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Program.pic.dataMem.GetBinaryValueAtIndex(2), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());
            tlp_SpecialRegisters.RowCount++;

            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "PCLATCH", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Program.pic.dataMem.GetBinaryValueAtIndex(10), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());
            tlp_SpecialRegisters.RowCount++;

            tlp_SpecialRegisters.Controls.Add(new Label() { Text = "STATUS", TextAlign = ContentAlignment.MiddleCenter }, 0, tlp_SpecialRegisters.RowCount);
            tlp_SpecialRegisters.Controls.Add(new Label() { Text = Program.pic.dataMem.GetBinaryValueAtIndex(3), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_SpecialRegisters.RowCount);

            tlp_SpecialRegisters.RowStyles.Add(new RowStyle());


            tlp_Bank0.ResumeLayout();
            tlp_Bank0.Visible = true;
            tlp_Bank1.ResumeLayout();
            tlp_Bank1.Visible = true;
            tlp_SpecialRegisters.ResumeLayout();
            tlp_SpecialRegisters.Visible = true;
        }

        private void ClearTLP(ref TableLayoutPanel table)
        {

            foreach(Control control in table.Controls)
            {
                control.Dispose();
            }
            table.Controls.Clear();
            table.RowCount = 1;
        }

        private void InitializeTLP(ref TableLayoutPanel table)
        {
            table.RowCount = 1;
            table.RowStyles.Add(new RowStyle());
        }

        private void UpdatePortButtons()
        {
            List<Button> RAButtons = new List<Button> {btn_RA0, btn_RA1, btn_RA2, btn_RA3, btn_RA4 };
            int index = 0;
            foreach(Button btn in RAButtons)
            {
                if(Program.pic.dataMem.GetFlag(5, false, index))
                {
                    if (!Program.pic.dataMem.GetFlag(5, true, index) && index != 4)  //RA4 can only produce an active 0
                    {
                        btn.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    if (!Program.pic.dataMem.GetFlag(5, true, index))
                    {
                        btn.BackColor = Color.Tomato;
                    }
                }

                if(Program.pic.dataMem.GetFlag(5, true, index))
                {
                    btn.Enabled = true;
                }
                else
                {
                    btn.Enabled = false;
                }

                index++;
            }

            List<Button> RBButtons = new List<Button> { btn_RB0, btn_RB1, btn_RB2, btn_RB3, btn_RB4, btn_RB5, btn_RB6, btn_RB7 };
            index = 0;
            foreach (Button btn in RBButtons)
            {
                if (Program.pic.dataMem.GetFlag(6, false, index))
                {
                    if (!Program.pic.dataMem.GetFlag(6, true, index))
                    {
                        btn.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    if (!Program.pic.dataMem.GetFlag(6, true, index))
                    {
                        btn.BackColor = Color.Tomato;
                    }
                }

                if (Program.pic.dataMem.GetFlag(6, true, index))
                {
                    btn.Enabled = true;
                }
                else
                {
                    btn.Enabled = false;
                }

                index++;
            }
        }

        public void UpdateGUI(object sender, UpdateEventArgs<byte> e)
        {
            UInt16 line = Program.pic.pc;
            MarkLine(line);
            UpdateMemoryGUI();
            UpdatePortButtons();
        }

        

        public void WriteDebugOutput(string message)
        {
            rtext_Output.Text = message;
        }

        public void FinalizePIC()
        {
            //clean up after finishing code execution
            Unmark();
            Program.pic.Reset();
            UpdateGUI(this, new UpdateEventArgs<byte>());
            Unmark();
        }

        public void ResetPortButtonColors()
        {
            List<Button> RAButtons = new List<Button> { btn_RA0, btn_RA1, btn_RA2, btn_RA3, btn_RA4 };
            foreach (Button btn in RAButtons)
            {
                btn.BackColor = Color.LightGray;
            }

            List<Button> RBButtons = new List<Button> { btn_RB0, btn_RB1, btn_RB2, btn_RB3, btn_RB4, btn_RB5, btn_RB6, btn_RB7 };

            foreach (Button btn in RBButtons)
            {
                btn.BackColor = Color.LightGray;
            }
        }

        public void Initialize()
        {
            Program.pic.UpdateGUI -= this.UpdateGUI;
            Program.pic.UpdateGUI += this.UpdateGUI;

            string code = rtext_Code.Text;
            Scanning.Scan(code, Program.pic.progMem); //instructionCount is 0-indexed

            ResetPortButtonColors();
        }

        public void DisableButtons(List<Button> btns)
        {
            foreach(Button btn in btns)
            {
                btn.Enabled = false;
            }
        }

        public void EnableButtons(List<Button> btns)
        {
            foreach (Button btn in btns)
            {
                btn.Enabled = true;
            }
        }

        private void RA4_Click(object sender, EventArgs e)
        {
            if (btn_RA4.BackColor == Color.LightGreen)
            {
                btn_RA4.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 4); //Clearing RA4  
            }
            else
            {
                btn_RA4.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 4); //Setting RA4
            }
            UpdateMemoryGUI();
        }

        private void btn_RA3_Click(object sender, EventArgs e)
        {
            if (btn_RA3.BackColor == Color.LightGreen)
            {
                btn_RA3.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 3); //Clearing RA3  
            }
            else
            {
                btn_RA3.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 3); //Setting RA3
            }
            UpdateMemoryGUI();
        }

        private void btn_RA2_Click(object sender, EventArgs e)
        {
            if (btn_RA2.BackColor == Color.LightGreen)
            {
                btn_RA2.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 2); //Clearing RA2
            }
            else
            {
                btn_RA2.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 2); //Setting RA2
            }
            UpdateMemoryGUI();
        }

        private void btn_RA1_Click(object sender, EventArgs e)
        {
            if (btn_RA1.BackColor == Color.LightGreen)
            {
                btn_RA1.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 1); //Clearing RA1
            }
            else
            {
                btn_RA1.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 1); //Setting RA1
            }
            UpdateMemoryGUI();
        }

        private void btn_RA0_Click(object sender, EventArgs e)
        {
            if (btn_RA0.BackColor == Color.LightGreen)
            {
                btn_RA0.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 0); //Clearing RA0
            }
            else
            {
                btn_RA0.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 0); //Setting RA0
            }
            UpdateMemoryGUI();
        }

        private void btn_RB0_Click(object sender, EventArgs e)
        {
            if (btn_RB0.BackColor == Color.LightGreen)
            {
                btn_RB0.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 0); //Clearing RB0  
            }
            else
            {
                btn_RB0.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 0); //Setting RB0
            }
            UpdateMemoryGUI();
        }

        private void btn_RB1_Click(object sender, EventArgs e)
        {
            if (btn_RB1.BackColor == Color.LightGreen)
            {
                btn_RB1.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 1); //Clearing RB1
            }
            else
            {
                btn_RB1.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 1); //Setting RB1
            }
            UpdateMemoryGUI();
        }

        private void btn_RB2_Click(object sender, EventArgs e)
        {
            if (btn_RB2.BackColor == Color.LightGreen)
            {
                btn_RB2.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 2); //Clearing RB2
            }
            else
            {
                btn_RB2.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 2); //Setting RB2
            }
            UpdateMemoryGUI();
        }

        private void btn_RB3_Click(object sender, EventArgs e)
        {
            if (btn_RB3.BackColor == Color.LightGreen)
            {
                btn_RB3.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 3); //Clearing RB3
            }
            else
            {
                btn_RB3.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 3); //Setting RB3
            }
            UpdateMemoryGUI();
        }

        private void btn_RB4_Click(object sender, EventArgs e)
        {
            if (btn_RB4.BackColor == Color.LightGreen)
            {
                btn_RB4.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 4); //Clearing RB4
            }
            else
            {
                btn_RB4.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 4); //Setting RB4
            }
            //Set PORT RB INTERRUPT
            Program.pic.dataMem.SetFlag((byte)RegisterAddress.INTCON, 0);
            UpdateMemoryGUI();
        }

        private void btn_RB5_Click(object sender, EventArgs e)
        {
            if (btn_RB5.BackColor == Color.LightGreen)
            {
                btn_RB5.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 5); //Clearing RB5
            }
            else
            {
                btn_RB5.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 5); //Setting RB5
            }
            //Set PORT RB INTERRUPT
            Program.pic.dataMem.SetFlag((byte)RegisterAddress.INTCON, 0);
            UpdateMemoryGUI();
        }

        private void btn_RB6_Click(object sender, EventArgs e)
        {
            if (btn_RB6.BackColor == Color.LightGreen)
            {
                btn_RB6.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 6); //Clearing RB6
            }
            else
            {
                btn_RB6.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 6); //Setting RB6
            }
            //Set PORT RB INTERRUPT
            Program.pic.dataMem.SetFlag((byte)RegisterAddress.INTCON, 0);
            UpdateMemoryGUI();
        }

        private void btn_RB7_Click(object sender, EventArgs e)
        {
            if (btn_RB7.BackColor == Color.LightGreen)
            {
                btn_RB7.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(6, false, 7); //Clearing RB7
            }
            else
            {
                btn_RB7.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(6, false, 7); //Setting RB7
            }
            //Set PORT RB INTERRUPT
            Program.pic.dataMem.SetFlag((byte)RegisterAddress.INTCON, 0);
            UpdateMemoryGUI();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

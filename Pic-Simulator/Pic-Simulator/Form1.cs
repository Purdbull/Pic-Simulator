using System;
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
                    Program.pic = new PIC();
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
            Finalize();
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
                    while (!(IsBreakpoint(Program.pic.progMem.GetKeyAtIndex(Program.pic.dataMem.GetPC())) && enableBreakpoints))
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
            tlp_Bank1.Visible = false;
            tlp_Bank1.SuspendLayout();

            tlp_Bank2.Visible = false;
            tlp_Bank2.SuspendLayout();

            ClearTLP(ref tlp_Bank1);
            ClearTLP(ref tlp_Bank2);


            InitializeTLP(ref tlp_Bank1);
            InitializeTLP(ref tlp_Bank2);

            for (int row = 0; row < PIC.MAX_DATAMEM_SIZE / 2; row++)
            {
                tlp_Bank1.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexKeyAtIndex(row)}, 0, tlp_Bank1.RowCount);
                tlp_Bank1.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexValueAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_Bank1.RowCount);

                tlp_Bank1.RowStyles.Add(new RowStyle());

                tlp_Bank1.RowCount++;
            }


            for (int row = PIC.MAX_DATAMEM_SIZE / 2; row < PIC.MAX_DATAMEM_SIZE; row++)
            {
                tlp_Bank2.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexKeyAtIndex(row) }, 0, tlp_Bank2.RowCount);
                tlp_Bank2.Controls.Add(new Label() { Text = Program.pic.dataMem.GetHexValueAtIndex(row), TextAlign = ContentAlignment.MiddleCenter }, 1, tlp_Bank2.RowCount);

                tlp_Bank2.RowStyles.Add(new RowStyle());

                tlp_Bank2.RowCount++;
            }

            tlp_Bank1.ResumeLayout();
            tlp_Bank1.Visible = true;
            tlp_Bank2.ResumeLayout();
            tlp_Bank2.Visible = true;
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
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    btn.BackColor = Color.Tomato;
                }
                index++;
            }
        }

        public void UpdateGUI(object sender, UpdateEventArgs<byte> e)
        {
            UInt16 line = Program.pic.dataMem.GetPC();
            MarkLine(line);
            UpdateMemoryGUI();
            UpdatePortButtons();
        }

        public void ResetPIC()
        {
            Program.pic = new PIC();
        }

        public void WriteDebugOutput(string message)
        {
            rtext_Output.Text = message;
        }

        public void Finalize()
        {
            //clean up after finishing code execution
            Unmark();
            ResetPIC();

        }

        public void Initialize()
        {
            Program.pic.UpdateGUI += this.UpdateGUI;

            string code = rtext_Code.Text;
            int instructionCount = Scanning.Scan(code, Program.pic.progMem); //instructionCount is 0-indexed
            Program.pic.progMem.SetLine(++instructionCount, UInt16.MaxValue, UInt16.MaxValue); //set line of progMem after the last instruction to special value
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
                Program.pic.dataMem.ClearFlag(5, false, 3); //Clearing RA4  
            }
            else
            {
                btn_RA3.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 3); //Setting RA4
            }
            UpdateMemoryGUI();
        }

        private void btn_RA2_Click(object sender, EventArgs e)
        {
            if (btn_RA2.BackColor == Color.LightGreen)
            {
                btn_RA2.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 2); //Clearing RA4  
            }
            else
            {
                btn_RA2.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 2); //Setting RA4
            }
            UpdateMemoryGUI();
        }

        private void btn_RA1_Click(object sender, EventArgs e)
        {
            if (btn_RA1.BackColor == Color.LightGreen)
            {
                btn_RA1.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 1); //Clearing RA4  
            }
            else
            {
                btn_RA1.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 1); //Setting RA4
            }
            UpdateMemoryGUI();
        }

        private void btn_RA0_Click(object sender, EventArgs e)
        {
            if (btn_RA0.BackColor == Color.LightGreen)
            {
                btn_RA0.BackColor = Color.Tomato;
                Program.pic.dataMem.ClearFlag(5, false, 0); //Clearing RA4  
            }
            else
            {
                btn_RA0.BackColor = Color.LightGreen;
                Program.pic.dataMem.SetFlag(5, false, 0); //Setting RA4
            }
            UpdateMemoryGUI();
        }
    }
}

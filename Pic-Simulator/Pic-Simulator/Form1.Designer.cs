
namespace Pic_Simulator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.rtext_Code = new System.Windows.Forms.RichTextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chckBx_TimerActive = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_Continue = new System.Windows.Forms.Button();
            this.btn_Debug = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.rtext_Output = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1225, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Code.Location = new System.Drawing.Point(498, 5);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(106, 20);
            this.lbl_Code.TabIndex = 1;
            this.lbl_Code.Text = "C:\\newFile.txt";
            this.lbl_Code.Click += new System.EventHandler(this.label1_Click);
            // 
            // rtext_Code
            // 
            this.rtext_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtext_Code.Location = new System.Drawing.Point(498, 29);
            this.rtext_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtext_Code.Name = "rtext_Code";
            this.rtext_Code.Size = new System.Drawing.Size(629, 807);
            this.rtext_Code.TabIndex = 4;
            this.rtext_Code.Text = " ";
            this.rtext_Code.Click += new System.EventHandler(this.richTextBox2_Click);
            this.rtext_Code.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            this.rtext_Code.DoubleClick += new System.EventHandler(this.rtext_Code_DoubleClick);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(103, 147);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(94, 27);
            this.textBox16.TabIndex = 0;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(3, 167);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(94, 27);
            this.textBox17.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chckBx_TimerActive);
            this.groupBox1.Location = new System.Drawing.Point(263, 563);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(229, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // chckBx_TimerActive
            // 
            this.chckBx_TimerActive.AutoSize = true;
            this.chckBx_TimerActive.Location = new System.Drawing.Point(45, 25);
            this.chckBx_TimerActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chckBx_TimerActive.Name = "chckBx_TimerActive";
            this.chckBx_TimerActive.Size = new System.Drawing.Size(72, 24);
            this.chckBx_TimerActive.TabIndex = 0;
            this.chckBx_TimerActive.Text = "Active";
            this.chckBx_TimerActive.UseVisualStyleBackColor = true;
            this.chckBx_TimerActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(14, 563);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(229, 275);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special Function Registers";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1135, 29);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(225, 808);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(217, 775);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bank 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 767);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(217, 775);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bank 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(211, 767);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button20);
            this.groupBox3.Controls.Add(this.button19);
            this.groupBox3.Controls.Add(this.button18);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button17);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.button15);
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Controls.Add(this.button13);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(14, 392);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(478, 163);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "I/O Pins";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(414, 99);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(35, 29);
            this.button20.TabIndex = 0;
            this.button20.Text = "button20";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(373, 99);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(35, 29);
            this.button19.TabIndex = 0;
            this.button19.Text = "button19";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(331, 99);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(35, 29);
            this.button18.TabIndex = 0;
            this.button18.Text = "button18";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(291, 99);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 29);
            this.button8.TabIndex = 0;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(99, 99);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(35, 29);
            this.button17.TabIndex = 0;
            this.button17.Text = "button17";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(139, 99);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(35, 29);
            this.button16.TabIndex = 0;
            this.button16.Text = "button16";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(181, 99);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(35, 29);
            this.button15.TabIndex = 0;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(222, 29);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(35, 29);
            this.button14.TabIndex = 0;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(291, 29);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(35, 29);
            this.button13.TabIndex = 0;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(331, 29);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(35, 29);
            this.button12.TabIndex = 0;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(373, 29);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(35, 29);
            this.button11.TabIndex = 0;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(414, 29);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 29);
            this.button10.TabIndex = 0;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(222, 99);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(35, 29);
            this.button9.TabIndex = 0;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "PORTB";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "PORTA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(1, 1);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(107, 29);
            this.btn_OpenFile.TabIndex = 8;
            this.btn_OpenFile.Text = "Open File";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(125, 1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(106, 29);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Stop);
            this.groupBox4.Controls.Add(this.btn_Step);
            this.groupBox4.Controls.Add(this.btn_Continue);
            this.groupBox4.Controls.Add(this.btn_Debug);
            this.groupBox4.Controls.Add(this.btn_Run);
            this.groupBox4.Location = new System.Drawing.Point(0, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 76);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Code Execution";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(55, 27);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(52, 29);
            this.btn_Stop.TabIndex = 8;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(277, 27);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(57, 29);
            this.btn_Step.TabIndex = 8;
            this.btn_Step.Text = "Step";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // btn_Continue
            // 
            this.btn_Continue.Location = new System.Drawing.Point(184, 27);
            this.btn_Continue.Name = "btn_Continue";
            this.btn_Continue.Size = new System.Drawing.Size(87, 29);
            this.btn_Continue.TabIndex = 8;
            this.btn_Continue.Text = "Continue";
            this.btn_Continue.UseVisualStyleBackColor = true;
            this.btn_Continue.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // btn_Debug
            // 
            this.btn_Debug.Location = new System.Drawing.Point(113, 27);
            this.btn_Debug.Name = "btn_Debug";
            this.btn_Debug.Size = new System.Drawing.Size(63, 29);
            this.btn_Debug.TabIndex = 8;
            this.btn_Debug.Text = "Debug";
            this.btn_Debug.UseVisualStyleBackColor = true;
            this.btn_Debug.Click += new System.EventHandler(this.btn_Debug_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(6, 27);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(43, 29);
            this.btn_Run.TabIndex = 8;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // rtext_Output
            // 
            this.rtext_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtext_Output.Location = new System.Drawing.Point(3, 23);
            this.rtext_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtext_Output.Name = "rtext_Output";
            this.rtext_Output.ReadOnly = true;
            this.rtext_Output.Size = new System.Drawing.Size(472, 77);
            this.rtext_Output.TabIndex = 4;
            this.rtext_Output.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtext_Output);
            this.groupBox5.Location = new System.Drawing.Point(14, 283);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(478, 103);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Debugger Output";
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Location = new System.Drawing.Point(246, 1);
            this.btn_SaveAs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(94, 29);
            this.btn_SaveAs.TabIndex = 12;
            this.btn_SaveAs.Text = "Save as..";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.button21_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 843);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtext_Code);
            this.Controls.Add(this.lbl_Code);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Pic-Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.RichTextBox rtext_Code;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chckBx_TimerActive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Button btn_Debug;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox rtext_Output;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.Button btn_Run;
    }
}


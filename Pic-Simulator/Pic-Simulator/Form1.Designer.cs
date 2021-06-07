
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlp_SpecialRegisters = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tlp_Bank0 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tlp_Bank1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_RB0 = new System.Windows.Forms.Button();
            this.btn_RB1 = new System.Windows.Forms.Button();
            this.btn_RB2 = new System.Windows.Forms.Button();
            this.btn_RB3 = new System.Windows.Forms.Button();
            this.btn_RB7 = new System.Windows.Forms.Button();
            this.btn_RB6 = new System.Windows.Forms.Button();
            this.btn_RB5 = new System.Windows.Forms.Button();
            this.btn_RA4 = new System.Windows.Forms.Button();
            this.btn_RA3 = new System.Windows.Forms.Button();
            this.btn_RA2 = new System.Windows.Forms.Button();
            this.btn_RA1 = new System.Windows.Forms.Button();
            this.btn_RA0 = new System.Windows.Forms.Button();
            this.btn_RB4 = new System.Windows.Forms.Button();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbl_TimePassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_Clock = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.rtext_Code.DetectUrls = false;
            this.rtext_Code.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtext_Code.Location = new System.Drawing.Point(498, 29);
            this.rtext_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtext_Code.Name = "rtext_Code";
            this.rtext_Code.Size = new System.Drawing.Size(629, 807);
            this.rtext_Code.TabIndex = 4;
            this.rtext_Code.Text = " ";
            this.rtext_Code.WordWrap = false;
            this.rtext_Code.Click += new System.EventHandler(this.richTextBox2_Click);
            this.rtext_Code.TextChanged += new System.EventHandler(this.rtext_Code_TextChanged);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tlp_SpecialRegisters);
            this.groupBox2.Location = new System.Drawing.Point(14, 563);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(229, 275);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special Function Registers";
            // 
            // tlp_SpecialRegisters
            // 
            this.tlp_SpecialRegisters.ColumnCount = 2;
            this.tlp_SpecialRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_SpecialRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_SpecialRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_SpecialRegisters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlp_SpecialRegisters.Location = new System.Drawing.Point(3, 24);
            this.tlp_SpecialRegisters.Name = "tlp_SpecialRegisters";
            this.tlp_SpecialRegisters.RowCount = 7;
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_SpecialRegisters.Size = new System.Drawing.Size(223, 247);
            this.tlp_SpecialRegisters.TabIndex = 13;
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
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tlp_Bank0);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(217, 775);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bank 0";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tlp_Bank0
            // 
            this.tlp_Bank0.AutoScroll = true;
            this.tlp_Bank0.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_Bank0.ColumnCount = 2;
            this.tlp_Bank0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Bank0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp_Bank0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Bank0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlp_Bank0.Location = new System.Drawing.Point(3, 4);
            this.tlp_Bank0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlp_Bank0.Name = "tlp_Bank0";
            this.tlp_Bank0.RowCount = 1;
            this.tlp_Bank0.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Bank0.Size = new System.Drawing.Size(211, 767);
            this.tlp_Bank0.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tlp_Bank1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(217, 775);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bank 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tlp_Bank1
            // 
            this.tlp_Bank1.AutoScroll = true;
            this.tlp_Bank1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_Bank1.ColumnCount = 2;
            this.tlp_Bank1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Bank1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp_Bank1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Bank1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tlp_Bank1.Location = new System.Drawing.Point(3, 4);
            this.tlp_Bank1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlp_Bank1.Name = "tlp_Bank1";
            this.tlp_Bank1.RowCount = 1;
            this.tlp_Bank1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Bank1.Size = new System.Drawing.Size(211, 767);
            this.tlp_Bank1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_RB0);
            this.groupBox3.Controls.Add(this.btn_RB1);
            this.groupBox3.Controls.Add(this.btn_RB2);
            this.groupBox3.Controls.Add(this.btn_RB3);
            this.groupBox3.Controls.Add(this.btn_RB7);
            this.groupBox3.Controls.Add(this.btn_RB6);
            this.groupBox3.Controls.Add(this.btn_RB5);
            this.groupBox3.Controls.Add(this.btn_RA4);
            this.groupBox3.Controls.Add(this.btn_RA3);
            this.groupBox3.Controls.Add(this.btn_RA2);
            this.groupBox3.Controls.Add(this.btn_RA1);
            this.groupBox3.Controls.Add(this.btn_RA0);
            this.groupBox3.Controls.Add(this.btn_RB4);
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
            // btn_RB0
            // 
            this.btn_RB0.Location = new System.Drawing.Point(424, 97);
            this.btn_RB0.Name = "btn_RB0";
            this.btn_RB0.Size = new System.Drawing.Size(46, 29);
            this.btn_RB0.TabIndex = 0;
            this.btn_RB0.Text = "RB0";
            this.btn_RB0.UseVisualStyleBackColor = true;
            this.btn_RB0.Click += new System.EventHandler(this.btn_RB0_Click);
            // 
            // btn_RB1
            // 
            this.btn_RB1.Location = new System.Drawing.Point(373, 97);
            this.btn_RB1.Name = "btn_RB1";
            this.btn_RB1.Size = new System.Drawing.Size(45, 29);
            this.btn_RB1.TabIndex = 0;
            this.btn_RB1.Text = "RB1";
            this.btn_RB1.UseVisualStyleBackColor = true;
            this.btn_RB1.Click += new System.EventHandler(this.btn_RB1_Click);
            // 
            // btn_RB2
            // 
            this.btn_RB2.Location = new System.Drawing.Point(319, 97);
            this.btn_RB2.Name = "btn_RB2";
            this.btn_RB2.Size = new System.Drawing.Size(47, 29);
            this.btn_RB2.TabIndex = 0;
            this.btn_RB2.Text = "RB2";
            this.btn_RB2.UseVisualStyleBackColor = true;
            this.btn_RB2.Click += new System.EventHandler(this.btn_RB2_Click);
            // 
            // btn_RB3
            // 
            this.btn_RB3.Location = new System.Drawing.Point(269, 97);
            this.btn_RB3.Name = "btn_RB3";
            this.btn_RB3.Size = new System.Drawing.Size(43, 29);
            this.btn_RB3.TabIndex = 0;
            this.btn_RB3.Text = "RB3";
            this.btn_RB3.UseVisualStyleBackColor = true;
            this.btn_RB3.Click += new System.EventHandler(this.btn_RB3_Click);
            // 
            // btn_RB7
            // 
            this.btn_RB7.Location = new System.Drawing.Point(56, 97);
            this.btn_RB7.Name = "btn_RB7";
            this.btn_RB7.Size = new System.Drawing.Size(48, 29);
            this.btn_RB7.TabIndex = 0;
            this.btn_RB7.Text = "RB7";
            this.btn_RB7.UseVisualStyleBackColor = true;
            this.btn_RB7.Click += new System.EventHandler(this.btn_RB7_Click);
            // 
            // btn_RB6
            // 
            this.btn_RB6.Location = new System.Drawing.Point(111, 97);
            this.btn_RB6.Name = "btn_RB6";
            this.btn_RB6.Size = new System.Drawing.Size(45, 29);
            this.btn_RB6.TabIndex = 0;
            this.btn_RB6.Text = "RB6";
            this.btn_RB6.UseVisualStyleBackColor = true;
            this.btn_RB6.Click += new System.EventHandler(this.btn_RB6_Click);
            // 
            // btn_RB5
            // 
            this.btn_RB5.Location = new System.Drawing.Point(162, 97);
            this.btn_RB5.Name = "btn_RB5";
            this.btn_RB5.Size = new System.Drawing.Size(46, 29);
            this.btn_RB5.TabIndex = 0;
            this.btn_RB5.Text = "RB5";
            this.btn_RB5.UseVisualStyleBackColor = true;
            this.btn_RB5.Click += new System.EventHandler(this.btn_RB5_Click);
            // 
            // btn_RA4
            // 
            this.btn_RA4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_RA4.Location = new System.Drawing.Point(215, 29);
            this.btn_RA4.Name = "btn_RA4";
            this.btn_RA4.Size = new System.Drawing.Size(47, 29);
            this.btn_RA4.TabIndex = 0;
            this.btn_RA4.Text = "RA4";
            this.btn_RA4.UseVisualStyleBackColor = false;
            this.btn_RA4.Click += new System.EventHandler(this.RA4_Click);
            // 
            // btn_RA3
            // 
            this.btn_RA3.Location = new System.Drawing.Point(269, 29);
            this.btn_RA3.Name = "btn_RA3";
            this.btn_RA3.Size = new System.Drawing.Size(44, 29);
            this.btn_RA3.TabIndex = 0;
            this.btn_RA3.Text = "RA3";
            this.btn_RA3.UseVisualStyleBackColor = true;
            this.btn_RA3.Click += new System.EventHandler(this.btn_RA3_Click);
            // 
            // btn_RA2
            // 
            this.btn_RA2.Location = new System.Drawing.Point(319, 29);
            this.btn_RA2.Name = "btn_RA2";
            this.btn_RA2.Size = new System.Drawing.Size(48, 29);
            this.btn_RA2.TabIndex = 0;
            this.btn_RA2.Text = "RA2";
            this.btn_RA2.UseVisualStyleBackColor = true;
            this.btn_RA2.Click += new System.EventHandler(this.btn_RA2_Click);
            // 
            // btn_RA1
            // 
            this.btn_RA1.Location = new System.Drawing.Point(373, 29);
            this.btn_RA1.Name = "btn_RA1";
            this.btn_RA1.Size = new System.Drawing.Size(45, 29);
            this.btn_RA1.TabIndex = 0;
            this.btn_RA1.Text = "RA1";
            this.btn_RA1.UseVisualStyleBackColor = true;
            this.btn_RA1.Click += new System.EventHandler(this.btn_RA1_Click);
            // 
            // btn_RA0
            // 
            this.btn_RA0.Location = new System.Drawing.Point(424, 29);
            this.btn_RA0.Name = "btn_RA0";
            this.btn_RA0.Size = new System.Drawing.Size(46, 29);
            this.btn_RA0.TabIndex = 0;
            this.btn_RA0.Text = "RA0";
            this.btn_RA0.UseVisualStyleBackColor = true;
            this.btn_RA0.Click += new System.EventHandler(this.btn_RA0_Click);
            // 
            // btn_RB4
            // 
            this.btn_RB4.Location = new System.Drawing.Point(215, 97);
            this.btn_RB4.Name = "btn_RB4";
            this.btn_RB4.Size = new System.Drawing.Size(47, 29);
            this.btn_RB4.TabIndex = 0;
            this.btn_RB4.Text = "RB4";
            this.btn_RB4.UseVisualStyleBackColor = true;
            this.btn_RB4.Click += new System.EventHandler(this.btn_RB4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "PORTB";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 35);
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
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            this.groupBox4.Size = new System.Drawing.Size(341, 76);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Code Execution";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(55, 27);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(53, 29);
            this.btn_Stop.TabIndex = 8;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Step
            // 
            this.btn_Step.Enabled = false;
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
            this.btn_Continue.Enabled = false;
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
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbl_TimePassed);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txb_Clock);
            this.groupBox6.Location = new System.Drawing.Point(263, 563);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Size = new System.Drawing.Size(229, 133);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Clock";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbl_TimePassed
            // 
            this.lbl_TimePassed.AutoSize = true;
            this.lbl_TimePassed.Location = new System.Drawing.Point(14, 67);
            this.lbl_TimePassed.Name = "lbl_TimePassed";
            this.lbl_TimePassed.Size = new System.Drawing.Size(36, 20);
            this.lbl_TimePassed.TabIndex = 1;
            this.lbl_TimePassed.Text = "0 μs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mhz";
            // 
            // txb_Clock
            // 
            this.txb_Clock.Location = new System.Drawing.Point(14, 27);
            this.txb_Clock.Name = "txb_Clock";
            this.txb_Clock.Size = new System.Drawing.Size(74, 27);
            this.txb_Clock.TabIndex = 0;
            this.txb_Clock.Text = "1.000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 843);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtext_Code);
            this.Controls.Add(this.lbl_Code);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Pic-Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.RichTextBox rtext_Code;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tlp_Bank0;
        private System.Windows.Forms.TableLayoutPanel tlp_Bank1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Button btn_Debug;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_RB7;
        private System.Windows.Forms.Button btn_RB6;
        private System.Windows.Forms.Button btn_RB5;
        private System.Windows.Forms.Button btn_RA4;
        private System.Windows.Forms.Button btn_RA3;
        private System.Windows.Forms.Button btn_RA2;
        private System.Windows.Forms.Button btn_RA1;
        private System.Windows.Forms.Button btn_RA0;
        private System.Windows.Forms.Button btn_RB4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_RB0;
        private System.Windows.Forms.Button btn_RB1;
        private System.Windows.Forms.Button btn_RB2;
        private System.Windows.Forms.Button btn_RB3;
        private System.Windows.Forms.RichTextBox rtext_Output;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.TableLayoutPanel tlp_SpecialRegisters;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbl_TimePassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_Clock;
    }
}


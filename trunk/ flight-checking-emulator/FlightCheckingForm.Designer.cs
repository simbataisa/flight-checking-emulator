namespace FlightCheckingEmulator
{
    partial class FlightCheckingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sortDurationOpt = new System.Windows.Forms.CheckBox();
            this.prologBtn = new System.Windows.Forms.Button();
            this.checkFlightBtn = new System.Windows.Forms.Button();
            this.directFlightOpt = new System.Windows.Forms.CheckBox();
            this.checkFlightWeekdayListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkFlightDepartCmb = new System.Windows.Forms.ComboBox();
            this.checkFlightToCmb = new System.Windows.Forms.ComboBox();
            this.checkFlightFromCmb = new System.Windows.Forms.ComboBox();
            this.chkFlighLabelDepart = new System.Windows.Forms.Label();
            this.chkFlighLabelTo = new System.Windows.Forms.Label();
            this.chkFlighLabelFrom = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.planBtn = new System.Windows.Forms.Button();
            this.visitPlanReturnCmb = new System.Windows.Forms.ComboBox();
            this.visitPlanStartCmb = new System.Windows.Forms.ComboBox();
            this.visitPlanLabelReturn = new System.Windows.Forms.Label();
            this.visitPlanLabelStart = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.visitPlanPlacesListBox = new System.Windows.Forms.CheckedListBox();
            this.visitPlanOriginCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.resultPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.resultPanel);
            this.splitContainer1.Size = new System.Drawing.Size(724, 375);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(724, 103);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Yellow;
            this.tabPage1.Controls.Add(this.sortDurationOpt);
            this.tabPage1.Controls.Add(this.prologBtn);
            this.tabPage1.Controls.Add(this.checkFlightBtn);
            this.tabPage1.Controls.Add(this.directFlightOpt);
            this.tabPage1.Controls.Add(this.checkFlightWeekdayListBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.checkFlightDepartCmb);
            this.tabPage1.Controls.Add(this.checkFlightToCmb);
            this.tabPage1.Controls.Add(this.checkFlightFromCmb);
            this.tabPage1.Controls.Add(this.chkFlighLabelDepart);
            this.tabPage1.Controls.Add(this.chkFlighLabelTo);
            this.tabPage1.Controls.Add(this.chkFlighLabelFrom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(716, 77);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check Flight";
            // 
            // sortDurationOpt
            // 
            this.sortDurationOpt.AutoSize = true;
            this.sortDurationOpt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortDurationOpt.Location = new System.Drawing.Point(591, 3);
            this.sortDurationOpt.Name = "sortDurationOpt";
            this.sortDurationOpt.Size = new System.Drawing.Size(123, 20);
            this.sortDurationOpt.TabIndex = 26;
            this.sortDurationOpt.Text = "Sort By Duration";
            this.sortDurationOpt.UseVisualStyleBackColor = true;
            // 
            // prologBtn
            // 
            this.prologBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prologBtn.Location = new System.Drawing.Point(591, 27);
            this.prologBtn.Name = "prologBtn";
            this.prologBtn.Size = new System.Drawing.Size(97, 26);
            this.prologBtn.TabIndex = 25;
            this.prologBtn.Text = "Prolog";
            this.prologBtn.UseVisualStyleBackColor = true;
            this.prologBtn.Click += new System.EventHandler(this.prologBtn_Click);
            // 
            // checkFlightBtn
            // 
            this.checkFlightBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFlightBtn.Location = new System.Drawing.Point(459, 27);
            this.checkFlightBtn.Name = "checkFlightBtn";
            this.checkFlightBtn.Size = new System.Drawing.Size(97, 26);
            this.checkFlightBtn.TabIndex = 24;
            this.checkFlightBtn.Text = "Check Flight";
            this.checkFlightBtn.UseVisualStyleBackColor = true;
            this.checkFlightBtn.Click += new System.EventHandler(this.checkFlightBtn_Click);
            // 
            // directFlightOpt
            // 
            this.directFlightOpt.AutoSize = true;
            this.directFlightOpt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directFlightOpt.Location = new System.Drawing.Point(459, 3);
            this.directFlightOpt.Name = "directFlightOpt";
            this.directFlightOpt.Size = new System.Drawing.Size(128, 20);
            this.directFlightOpt.TabIndex = 23;
            this.directFlightOpt.Text = "Direct Flight Only";
            this.directFlightOpt.UseVisualStyleBackColor = true;
            // 
            // checkFlightWeekdayListBox
            // 
            this.checkFlightWeekdayListBox.FormattingEnabled = true;
            this.checkFlightWeekdayListBox.Location = new System.Drawing.Point(314, 0);
            this.checkFlightWeekdayListBox.Name = "checkFlightWeekdayListBox";
            this.checkFlightWeekdayListBox.Size = new System.Drawing.Size(120, 64);
            this.checkFlightWeekdayListBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Weekdays";
            // 
            // checkFlightDepartCmb
            // 
            this.checkFlightDepartCmb.FormattingEnabled = true;
            this.checkFlightDepartCmb.Location = new System.Drawing.Point(97, 55);
            this.checkFlightDepartCmb.Name = "checkFlightDepartCmb";
            this.checkFlightDepartCmb.Size = new System.Drawing.Size(121, 21);
            this.checkFlightDepartCmb.TabIndex = 19;
            // 
            // checkFlightToCmb
            // 
            this.checkFlightToCmb.FormattingEnabled = true;
            this.checkFlightToCmb.Location = new System.Drawing.Point(97, 29);
            this.checkFlightToCmb.Name = "checkFlightToCmb";
            this.checkFlightToCmb.Size = new System.Drawing.Size(121, 21);
            this.checkFlightToCmb.TabIndex = 18;
            // 
            // checkFlightFromCmb
            // 
            this.checkFlightFromCmb.FormattingEnabled = true;
            this.checkFlightFromCmb.Location = new System.Drawing.Point(97, 3);
            this.checkFlightFromCmb.Name = "checkFlightFromCmb";
            this.checkFlightFromCmb.Size = new System.Drawing.Size(121, 21);
            this.checkFlightFromCmb.TabIndex = 17;
            // 
            // chkFlighLabelDepart
            // 
            this.chkFlighLabelDepart.AutoSize = true;
            this.chkFlighLabelDepart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlighLabelDepart.Location = new System.Drawing.Point(6, 55);
            this.chkFlighLabelDepart.Name = "chkFlighLabelDepart";
            this.chkFlighLabelDepart.Size = new System.Drawing.Size(78, 16);
            this.chkFlighLabelDepart.TabIndex = 16;
            this.chkFlighLabelDepart.Text = "Depart Time";
            // 
            // chkFlighLabelTo
            // 
            this.chkFlighLabelTo.AutoSize = true;
            this.chkFlighLabelTo.Location = new System.Drawing.Point(65, 29);
            this.chkFlighLabelTo.Name = "chkFlighLabelTo";
            this.chkFlighLabelTo.Size = new System.Drawing.Size(20, 13);
            this.chkFlighLabelTo.TabIndex = 15;
            this.chkFlighLabelTo.Text = "To";
            // 
            // chkFlighLabelFrom
            // 
            this.chkFlighLabelFrom.AutoSize = true;
            this.chkFlighLabelFrom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlighLabelFrom.Location = new System.Drawing.Point(46, 3);
            this.chkFlighLabelFrom.Name = "chkFlighLabelFrom";
            this.chkFlighLabelFrom.Size = new System.Drawing.Size(38, 16);
            this.chkFlighLabelFrom.TabIndex = 14;
            this.chkFlighLabelFrom.Text = "From";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Yellow;
            this.tabPage2.Controls.Add(this.planBtn);
            this.tabPage2.Controls.Add(this.visitPlanReturnCmb);
            this.tabPage2.Controls.Add(this.visitPlanStartCmb);
            this.tabPage2.Controls.Add(this.visitPlanLabelReturn);
            this.tabPage2.Controls.Add(this.visitPlanLabelStart);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.visitPlanPlacesListBox);
            this.tabPage2.Controls.Add(this.visitPlanOriginCmb);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(716, 77);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Visit Plan";
            // 
            // planBtn
            // 
            this.planBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planBtn.Location = new System.Drawing.Point(606, 6);
            this.planBtn.Name = "planBtn";
            this.planBtn.Size = new System.Drawing.Size(97, 28);
            this.planBtn.TabIndex = 28;
            this.planBtn.Text = "Start Plan";
            this.planBtn.UseVisualStyleBackColor = true;
            this.planBtn.Click += new System.EventHandler(this.planBtn_Click);
            // 
            // visitPlanReturnCmb
            // 
            this.visitPlanReturnCmb.FormattingEnabled = true;
            this.visitPlanReturnCmb.Location = new System.Drawing.Point(462, 32);
            this.visitPlanReturnCmb.Name = "visitPlanReturnCmb";
            this.visitPlanReturnCmb.Size = new System.Drawing.Size(121, 21);
            this.visitPlanReturnCmb.TabIndex = 27;
            // 
            // visitPlanStartCmb
            // 
            this.visitPlanStartCmb.FormattingEnabled = true;
            this.visitPlanStartCmb.Location = new System.Drawing.Point(462, 4);
            this.visitPlanStartCmb.Name = "visitPlanStartCmb";
            this.visitPlanStartCmb.Size = new System.Drawing.Size(121, 21);
            this.visitPlanStartCmb.TabIndex = 26;
            // 
            // visitPlanLabelReturn
            // 
            this.visitPlanLabelReturn.AutoSize = true;
            this.visitPlanLabelReturn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitPlanLabelReturn.Location = new System.Drawing.Point(387, 32);
            this.visitPlanLabelReturn.Name = "visitPlanLabelReturn";
            this.visitPlanLabelReturn.Size = new System.Drawing.Size(64, 16);
            this.visitPlanLabelReturn.TabIndex = 25;
            this.visitPlanLabelReturn.Text = "Return on";
            // 
            // visitPlanLabelStart
            // 
            this.visitPlanLabelStart.AutoSize = true;
            this.visitPlanLabelStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitPlanLabelStart.Location = new System.Drawing.Point(387, 3);
            this.visitPlanLabelStart.Name = "visitPlanLabelStart";
            this.visitPlanLabelStart.Size = new System.Drawing.Size(54, 16);
            this.visitPlanLabelStart.TabIndex = 24;
            this.visitPlanLabelStart.Text = "Start on";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(193, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Places";
            // 
            // visitPlanPlacesListBox
            // 
            this.visitPlanPlacesListBox.FormattingEnabled = true;
            this.visitPlanPlacesListBox.Location = new System.Drawing.Point(253, 3);
            this.visitPlanPlacesListBox.Name = "visitPlanPlacesListBox";
            this.visitPlanPlacesListBox.Size = new System.Drawing.Size(120, 64);
            this.visitPlanPlacesListBox.TabIndex = 22;
            // 
            // visitPlanOriginCmb
            // 
            this.visitPlanOriginCmb.FormattingEnabled = true;
            this.visitPlanOriginCmb.Items.AddRange(new object[] {
            "Singapore",
            "London",
            "Edinburgh",
            "Greece",
            "Paris",
            "Rome"});
            this.visitPlanOriginCmb.Location = new System.Drawing.Point(53, 3);
            this.visitPlanOriginCmb.Name = "visitPlanOriginCmb";
            this.visitPlanOriginCmb.Size = new System.Drawing.Size(121, 21);
            this.visitPlanOriginCmb.TabIndex = 18;
            this.visitPlanOriginCmb.SelectedIndexChanged += new System.EventHandler(this.planOrigin_SelectedIndexChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Origin";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(716, 77);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shortest Flight Route";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // resultPanel
            // 
            this.resultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultPanel.Location = new System.Drawing.Point(0, 3);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(721, 254);
            this.resultPanel.TabIndex = 0;
            // 
            // FlightCheckingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 375);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FlightCheckingForm";
            this.Text = "Flight Checking Emulator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox checkFlightWeekdayListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox checkFlightDepartCmb;
        private System.Windows.Forms.ComboBox checkFlightToCmb;
        private System.Windows.Forms.ComboBox checkFlightFromCmb;
        private System.Windows.Forms.Label chkFlighLabelDepart;
        private System.Windows.Forms.Label chkFlighLabelTo;
        private System.Windows.Forms.Label chkFlighLabelFrom;
        private System.Windows.Forms.CheckBox directFlightOpt;
        private System.Windows.Forms.Button prologBtn;
        private System.Windows.Forms.Button checkFlightBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox visitPlanOriginCmb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox visitPlanPlacesListBox;
        private System.Windows.Forms.Label visitPlanLabelStart;
        private System.Windows.Forms.Label visitPlanLabelReturn;
        private System.Windows.Forms.Button planBtn;
        private System.Windows.Forms.ComboBox visitPlanReturnCmb;
        private System.Windows.Forms.ComboBox visitPlanStartCmb;
        private System.Windows.Forms.FlowLayoutPanel resultPanel;
        private System.Windows.Forms.CheckBox sortDurationOpt;
    }
}
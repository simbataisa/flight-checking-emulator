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
            this.sortByDuration = new System.Windows.Forms.CheckBox();
            this.prologBtn = new System.Windows.Forms.Button();
            this.checkFlightBtn = new System.Windows.Forms.Button();
            this.directFlightOption = new System.Windows.Forms.CheckBox();
            this.checkedListBoxDays = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkFlightComboBoxDepart = new System.Windows.Forms.ComboBox();
            this.chkFlightComboBoxTo = new System.Windows.Forms.ComboBox();
            this.chkFlightComboBoxFrom = new System.Windows.Forms.ComboBox();
            this.chkFlighLabelDepart = new System.Windows.Forms.Label();
            this.chkFlighLabelTo = new System.Windows.Forms.Label();
            this.chkFlighLabelFrom = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxVisitPlanReturnOn = new System.Windows.Forms.ComboBox();
            this.comboBoxVisitPlanStartOn = new System.Windows.Forms.ComboBox();
            this.visitPlanLabelReturn = new System.Windows.Forms.Label();
            this.visitPlanLabelStart = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.visitPlanChkListBoxPlaces = new System.Windows.Forms.CheckedListBox();
            this.visitPlanComboBoxOrigin = new System.Windows.Forms.ComboBox();
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 404);
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
            this.tabControl1.Size = new System.Drawing.Size(784, 111);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Yellow;
            this.tabPage1.Controls.Add(this.sortByDuration);
            this.tabPage1.Controls.Add(this.prologBtn);
            this.tabPage1.Controls.Add(this.checkFlightBtn);
            this.tabPage1.Controls.Add(this.directFlightOption);
            this.tabPage1.Controls.Add(this.checkedListBoxDays);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkFlightComboBoxDepart);
            this.tabPage1.Controls.Add(this.chkFlightComboBoxTo);
            this.tabPage1.Controls.Add(this.chkFlightComboBoxFrom);
            this.tabPage1.Controls.Add(this.chkFlighLabelDepart);
            this.tabPage1.Controls.Add(this.chkFlighLabelTo);
            this.tabPage1.Controls.Add(this.chkFlighLabelFrom);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 84);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check Flight";
            // 
            // sortByDuration
            // 
            this.sortByDuration.AutoSize = true;
            this.sortByDuration.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortByDuration.Location = new System.Drawing.Point(608, 9);
            this.sortByDuration.Name = "sortByDuration";
            this.sortByDuration.Size = new System.Drawing.Size(123, 20);
            this.sortByDuration.TabIndex = 26;
            this.sortByDuration.Text = "Sort By Duration";
            this.sortByDuration.UseVisualStyleBackColor = true;
            // 
            // prologBtn
            // 
            this.prologBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prologBtn.Location = new System.Drawing.Point(608, 35);
            this.prologBtn.Name = "prologBtn";
            this.prologBtn.Size = new System.Drawing.Size(97, 28);
            this.prologBtn.TabIndex = 25;
            this.prologBtn.Text = "Prolog";
            this.prologBtn.UseVisualStyleBackColor = true;
            // 
            // checkFlightBtn
            // 
            this.checkFlightBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFlightBtn.Location = new System.Drawing.Point(476, 35);
            this.checkFlightBtn.Name = "checkFlightBtn";
            this.checkFlightBtn.Size = new System.Drawing.Size(97, 28);
            this.checkFlightBtn.TabIndex = 24;
            this.checkFlightBtn.Text = "Check Flight";
            this.checkFlightBtn.UseVisualStyleBackColor = true;
            this.checkFlightBtn.Click += new System.EventHandler(this.checkFlightBtn_Click);
            // 
            // directFlightOption
            // 
            this.directFlightOption.AutoSize = true;
            this.directFlightOption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directFlightOption.Location = new System.Drawing.Point(476, 9);
            this.directFlightOption.Name = "directFlightOption";
            this.directFlightOption.Size = new System.Drawing.Size(128, 20);
            this.directFlightOption.TabIndex = 23;
            this.directFlightOption.Text = "Direct Flight Only";
            this.directFlightOption.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxDays
            // 
            this.checkedListBoxDays.FormattingEnabled = true;
            this.checkedListBoxDays.Location = new System.Drawing.Point(314, 0);
            this.checkedListBoxDays.Name = "checkedListBoxDays";
            this.checkedListBoxDays.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxDays.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Weekdays";
            // 
            // chkFlightComboBoxDepart
            // 
            this.chkFlightComboBoxDepart.FormattingEnabled = true;
            this.chkFlightComboBoxDepart.Location = new System.Drawing.Point(97, 59);
            this.chkFlightComboBoxDepart.Name = "chkFlightComboBoxDepart";
            this.chkFlightComboBoxDepart.Size = new System.Drawing.Size(121, 22);
            this.chkFlightComboBoxDepart.TabIndex = 19;
            // 
            // chkFlightComboBoxTo
            // 
            this.chkFlightComboBoxTo.FormattingEnabled = true;
            this.chkFlightComboBoxTo.Location = new System.Drawing.Point(97, 31);
            this.chkFlightComboBoxTo.Name = "chkFlightComboBoxTo";
            this.chkFlightComboBoxTo.Size = new System.Drawing.Size(121, 22);
            this.chkFlightComboBoxTo.TabIndex = 18;
            // 
            // chkFlightComboBoxFrom
            // 
            this.chkFlightComboBoxFrom.FormattingEnabled = true;
            this.chkFlightComboBoxFrom.Location = new System.Drawing.Point(97, 3);
            this.chkFlightComboBoxFrom.Name = "chkFlightComboBoxFrom";
            this.chkFlightComboBoxFrom.Size = new System.Drawing.Size(121, 22);
            this.chkFlightComboBoxFrom.TabIndex = 17;
            // 
            // chkFlighLabelDepart
            // 
            this.chkFlighLabelDepart.AutoSize = true;
            this.chkFlighLabelDepart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlighLabelDepart.Location = new System.Drawing.Point(6, 59);
            this.chkFlighLabelDepart.Name = "chkFlighLabelDepart";
            this.chkFlighLabelDepart.Size = new System.Drawing.Size(78, 16);
            this.chkFlighLabelDepart.TabIndex = 16;
            this.chkFlighLabelDepart.Text = "Depart Time";
            // 
            // chkFlighLabelTo
            // 
            this.chkFlighLabelTo.AutoSize = true;
            this.chkFlighLabelTo.Location = new System.Drawing.Point(65, 31);
            this.chkFlighLabelTo.Name = "chkFlighLabelTo";
            this.chkFlighLabelTo.Size = new System.Drawing.Size(19, 14);
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
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.comboBoxVisitPlanReturnOn);
            this.tabPage2.Controls.Add(this.comboBoxVisitPlanStartOn);
            this.tabPage2.Controls.Add(this.visitPlanLabelReturn);
            this.tabPage2.Controls.Add(this.visitPlanLabelStart);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.visitPlanChkListBoxPlaces);
            this.tabPage2.Controls.Add(this.visitPlanComboBoxOrigin);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 84);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Visit Plan";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(655, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 30);
            this.button1.TabIndex = 28;
            this.button1.Text = "Start Plan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxVisitPlanReturnOn
            // 
            this.comboBoxVisitPlanReturnOn.FormattingEnabled = true;
            this.comboBoxVisitPlanReturnOn.Location = new System.Drawing.Point(511, 34);
            this.comboBoxVisitPlanReturnOn.Name = "comboBoxVisitPlanReturnOn";
            this.comboBoxVisitPlanReturnOn.Size = new System.Drawing.Size(121, 22);
            this.comboBoxVisitPlanReturnOn.TabIndex = 27;
            // 
            // comboBoxVisitPlanStartOn
            // 
            this.comboBoxVisitPlanStartOn.FormattingEnabled = true;
            this.comboBoxVisitPlanStartOn.Location = new System.Drawing.Point(511, 4);
            this.comboBoxVisitPlanStartOn.Name = "comboBoxVisitPlanStartOn";
            this.comboBoxVisitPlanStartOn.Size = new System.Drawing.Size(121, 22);
            this.comboBoxVisitPlanStartOn.TabIndex = 26;
            // 
            // visitPlanLabelReturn
            // 
            this.visitPlanLabelReturn.AutoSize = true;
            this.visitPlanLabelReturn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitPlanLabelReturn.Location = new System.Drawing.Point(436, 34);
            this.visitPlanLabelReturn.Name = "visitPlanLabelReturn";
            this.visitPlanLabelReturn.Size = new System.Drawing.Size(64, 16);
            this.visitPlanLabelReturn.TabIndex = 25;
            this.visitPlanLabelReturn.Text = "Return on";
            // 
            // visitPlanLabelStart
            // 
            this.visitPlanLabelStart.AutoSize = true;
            this.visitPlanLabelStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitPlanLabelStart.Location = new System.Drawing.Point(436, 3);
            this.visitPlanLabelStart.Name = "visitPlanLabelStart";
            this.visitPlanLabelStart.Size = new System.Drawing.Size(54, 16);
            this.visitPlanLabelStart.TabIndex = 24;
            this.visitPlanLabelStart.Text = "Start on";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Places";
            // 
            // visitPlanChkListBoxPlaces
            // 
            this.visitPlanChkListBoxPlaces.FormattingEnabled = true;
            this.visitPlanChkListBoxPlaces.Location = new System.Drawing.Point(287, 3);
            this.visitPlanChkListBoxPlaces.Name = "visitPlanChkListBoxPlaces";
            this.visitPlanChkListBoxPlaces.Size = new System.Drawing.Size(120, 79);
            this.visitPlanChkListBoxPlaces.TabIndex = 22;
            // 
            // visitPlanComboBoxOrigin
            // 
            this.visitPlanComboBoxOrigin.FormattingEnabled = true;
            this.visitPlanComboBoxOrigin.Items.AddRange(new object[] {
            "Singapore",
            "London",
            "Edinburgh",
            "Greece",
            "Paris",
            "Rome"});
            this.visitPlanComboBoxOrigin.Location = new System.Drawing.Point(60, 3);
            this.visitPlanComboBoxOrigin.Name = "visitPlanComboBoxOrigin";
            this.visitPlanComboBoxOrigin.Size = new System.Drawing.Size(121, 22);
            this.visitPlanComboBoxOrigin.TabIndex = 18;
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
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 84);
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
            this.resultPanel.Size = new System.Drawing.Size(781, 282);
            this.resultPanel.TabIndex = 0;
            // 
            // FlightCheckingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 404);
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
        private System.Windows.Forms.CheckedListBox checkedListBoxDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox chkFlightComboBoxDepart;
        private System.Windows.Forms.ComboBox chkFlightComboBoxTo;
        private System.Windows.Forms.ComboBox chkFlightComboBoxFrom;
        private System.Windows.Forms.Label chkFlighLabelDepart;
        private System.Windows.Forms.Label chkFlighLabelTo;
        private System.Windows.Forms.Label chkFlighLabelFrom;
        private System.Windows.Forms.CheckBox directFlightOption;
        private System.Windows.Forms.Button prologBtn;
        private System.Windows.Forms.Button checkFlightBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox visitPlanComboBoxOrigin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox visitPlanChkListBoxPlaces;
        private System.Windows.Forms.Label visitPlanLabelStart;
        private System.Windows.Forms.Label visitPlanLabelReturn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxVisitPlanReturnOn;
        private System.Windows.Forms.ComboBox comboBoxVisitPlanStartOn;
        private System.Windows.Forms.FlowLayoutPanel resultPanel;
        private System.Windows.Forms.CheckBox sortByDuration;
    }
}
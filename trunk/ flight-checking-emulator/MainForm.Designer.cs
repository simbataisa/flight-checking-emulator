/*
 * Created by SharpDevelop.
 * User: Fu Yong
 * Date: 2/21/2009
 * Time: 12:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TravelPlanner
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.comboBoxTime = new System.Windows.Forms.ComboBox();
            this.checkedListBoxDays = new System.Windows.Forms.CheckedListBox();
            this.checkBoxDirectFlightOnly = new System.Windows.Forms.CheckBox();
            this.buttonCheckFlight = new System.Windows.Forms.Button();
            this.buttonProlog = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonVisitPlan = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxVisitPlanReturnOn = new System.Windows.Forms.ComboBox();
            this.comboBoxVisitPlanStartOn = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPlace3 = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace2 = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace1 = new System.Windows.Forms.ComboBox();
            this.comboBoxVisitPlanOrigin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxWorldTravelOrigin = new System.Windows.Forms.ComboBox();
            this.comboBoxWorldTravelStartOn = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonWorldTravelPlan = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainContainer.IsSplitterFixed = true;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.tableLayoutPanelRight);
            this.mainContainer.Size = new System.Drawing.Size(790, 356);
            this.mainContainer.SplitterDistance = 217;
            this.mainContainer.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonExit, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.61491F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.385093F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(215, 354);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(209, 318);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(201, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check Flights";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFrom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBoxDays, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDirectFlightOnly, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonCheckFlight, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonProlog, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 285);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "From: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "To: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Depart Time: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 140);
            this.label4.TabIndex = 3;
            this.label4.Text = "Week Days: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxFrom.Location = new System.Drawing.Point(81, 3);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(111, 22);
            this.comboBoxFrom.TabIndex = 4;
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(81, 30);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(111, 22);
            this.comboBoxTo.TabIndex = 5;
            // 
            // comboBoxTime
            // 
            this.comboBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTime.FormattingEnabled = true;
            this.comboBoxTime.Location = new System.Drawing.Point(81, 57);
            this.comboBoxTime.Name = "comboBoxTime";
            this.comboBoxTime.Size = new System.Drawing.Size(111, 22);
            this.comboBoxTime.TabIndex = 6;
            // 
            // checkedListBoxDays
            // 
            this.checkedListBoxDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxDays.CheckOnClick = true;
            this.checkedListBoxDays.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxDays.FormattingEnabled = true;
            this.checkedListBoxDays.Location = new System.Drawing.Point(81, 84);
            this.checkedListBoxDays.Name = "checkedListBoxDays";
            this.checkedListBoxDays.Size = new System.Drawing.Size(111, 124);
            this.checkedListBoxDays.TabIndex = 7;
            this.checkedListBoxDays.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxDaysItemCheck);
            // 
            // checkBoxDirectFlightOnly
            // 
            this.checkBoxDirectFlightOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDirectFlightOnly.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDirectFlightOnly.Location = new System.Drawing.Point(81, 224);
            this.checkBoxDirectFlightOnly.Name = "checkBoxDirectFlightOnly";
            this.checkBoxDirectFlightOnly.Size = new System.Drawing.Size(111, 25);
            this.checkBoxDirectFlightOnly.TabIndex = 8;
            this.checkBoxDirectFlightOnly.Text = "Direct Flight Only";
            this.checkBoxDirectFlightOnly.UseVisualStyleBackColor = true;
            // 
            // buttonCheckFlight
            // 
            this.buttonCheckFlight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCheckFlight.Location = new System.Drawing.Point(99, 256);
            this.buttonCheckFlight.Name = "buttonCheckFlight";
            this.buttonCheckFlight.Size = new System.Drawing.Size(75, 24);
            this.buttonCheckFlight.TabIndex = 1;
            this.buttonCheckFlight.Text = "Check";
            this.buttonCheckFlight.UseVisualStyleBackColor = true;
            this.buttonCheckFlight.Click += new System.EventHandler(this.ButtonCheckFlightClick);
            // 
            // buttonProlog
            // 
            this.buttonProlog.Location = new System.Drawing.Point(3, 255);
            this.buttonProlog.Name = "buttonProlog";
            this.buttonProlog.Size = new System.Drawing.Size(72, 24);
            this.buttonProlog.TabIndex = 9;
            this.buttonProlog.Text = "Prolog";
            this.buttonProlog.UseVisualStyleBackColor = true;
            this.buttonProlog.Click += new System.EventHandler(this.ButtonPrologClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(201, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Visit Plan";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.buttonVisitPlan, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxVisitPlanReturnOn, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxVisitPlanStartOn, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxPlace3, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxPlace2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxPlace1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxVisitPlanOrigin, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(195, 285);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonVisitPlan
            // 
            this.buttonVisitPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVisitPlan.Location = new System.Drawing.Point(102, 234);
            this.buttonVisitPlan.Name = "buttonVisitPlan";
            this.buttonVisitPlan.Size = new System.Drawing.Size(75, 22);
            this.buttonVisitPlan.TabIndex = 12;
            this.buttonVisitPlan.Text = "Plan";
            this.buttonVisitPlan.UseVisualStyleBackColor = true;
            this.buttonVisitPlan.Click += new System.EventHandler(this.ButtonPlanClick);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 22);
            this.label10.TabIndex = 11;
            this.label10.Text = "Return on: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxVisitPlanReturnOn
            // 
            this.comboBoxVisitPlanReturnOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxVisitPlanReturnOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisitPlanReturnOn.FormattingEnabled = true;
            this.comboBoxVisitPlanReturnOn.Location = new System.Drawing.Point(83, 187);
            this.comboBoxVisitPlanReturnOn.Name = "comboBoxVisitPlanReturnOn";
            this.comboBoxVisitPlanReturnOn.Size = new System.Drawing.Size(111, 22);
            this.comboBoxVisitPlanReturnOn.TabIndex = 5;
            // 
            // comboBoxVisitPlanStartOn
            // 
            this.comboBoxVisitPlanStartOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxVisitPlanStartOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisitPlanStartOn.FormattingEnabled = true;
            this.comboBoxVisitPlanStartOn.Location = new System.Drawing.Point(83, 165);
            this.comboBoxVisitPlanStartOn.Name = "comboBoxVisitPlanStartOn";
            this.comboBoxVisitPlanStartOn.Size = new System.Drawing.Size(111, 22);
            this.comboBoxVisitPlanStartOn.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Start on: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPlace3
            // 
            this.comboBoxPlace3.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxPlace3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlace3.FormattingEnabled = true;
            this.comboBoxPlace3.Location = new System.Drawing.Point(83, 111);
            this.comboBoxPlace3.Name = "comboBoxPlace3";
            this.comboBoxPlace3.Size = new System.Drawing.Size(111, 22);
            this.comboBoxPlace3.TabIndex = 3;
            // 
            // comboBoxPlace2
            // 
            this.comboBoxPlace2.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxPlace2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlace2.FormattingEnabled = true;
            this.comboBoxPlace2.Location = new System.Drawing.Point(83, 84);
            this.comboBoxPlace2.Name = "comboBoxPlace2";
            this.comboBoxPlace2.Size = new System.Drawing.Size(111, 22);
            this.comboBoxPlace2.TabIndex = 2;
            // 
            // comboBoxPlace1
            // 
            this.comboBoxPlace1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxPlace1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlace1.FormattingEnabled = true;
            this.comboBoxPlace1.Location = new System.Drawing.Point(83, 57);
            this.comboBoxPlace1.Name = "comboBoxPlace1";
            this.comboBoxPlace1.Size = new System.Drawing.Size(110, 22);
            this.comboBoxPlace1.TabIndex = 1;
            // 
            // comboBoxVisitPlanOrigin
            // 
            this.comboBoxVisitPlanOrigin.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxVisitPlanOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisitPlanOrigin.FormattingEnabled = true;
            this.comboBoxVisitPlanOrigin.Location = new System.Drawing.Point(83, 30);
            this.comboBoxVisitPlanOrigin.Name = "comboBoxVisitPlanOrigin";
            this.comboBoxVisitPlanOrigin.Size = new System.Drawing.Size(111, 22);
            this.comboBoxVisitPlanOrigin.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 27);
            this.label8.TabIndex = 9;
            this.label8.Text = "Place 3: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Place 2: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 27);
            this.label6.TabIndex = 7;
            this.label6.Text = "Place 1: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 27);
            this.label5.TabIndex = 6;
            this.label5.Text = "Origin: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(201, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "World Travel";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.75258F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.24742F));
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxWorldTravelOrigin, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxWorldTravelStartOn, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.buttonWorldTravelPlan, 1, 8);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 9;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(195, 285);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Origin: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxWorldTravelOrigin
            // 
            this.comboBoxWorldTravelOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorldTravelOrigin.FormattingEnabled = true;
            this.comboBoxWorldTravelOrigin.Location = new System.Drawing.Point(84, 47);
            this.comboBoxWorldTravelOrigin.Name = "comboBoxWorldTravelOrigin";
            this.comboBoxWorldTravelOrigin.Size = new System.Drawing.Size(107, 22);
            this.comboBoxWorldTravelOrigin.TabIndex = 1;
            // 
            // comboBoxWorldTravelStartOn
            // 
            this.comboBoxWorldTravelStartOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorldTravelStartOn.FormattingEnabled = true;
            this.comboBoxWorldTravelStartOn.Location = new System.Drawing.Point(84, 91);
            this.comboBoxWorldTravelStartOn.Name = "comboBoxWorldTravelStartOn";
            this.comboBoxWorldTravelStartOn.Size = new System.Drawing.Size(107, 22);
            this.comboBoxWorldTravelStartOn.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 22);
            this.label12.TabIndex = 2;
            this.label12.Text = "Start on: ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonWorldTravelPlan
            // 
            this.buttonWorldTravelPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonWorldTravelPlan.Location = new System.Drawing.Point(100, 222);
            this.buttonWorldTravelPlan.Name = "buttonWorldTravelPlan";
            this.buttonWorldTravelPlan.Size = new System.Drawing.Size(75, 16);
            this.buttonWorldTravelPlan.TabIndex = 4;
            this.buttonWorldTravelPlan.Text = "Plan";
            this.buttonWorldTravelPlan.UseVisualStyleBackColor = true;
            this.buttonWorldTravelPlan.Click += new System.EventHandler(this.ButtonWorldTravelPlanClick);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(3, 327);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(209, 24);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.AutoScroll = true;
            this.tableLayoutPanelRight.AutoSize = true;
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 2;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(567, 354);
            this.tableLayoutPanelRight.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(790, 356);
            this.Controls.Add(this.mainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Planner";
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button buttonProlog;
		private System.Windows.Forms.ComboBox comboBoxVisitPlanStartOn;
		private System.Windows.Forms.ComboBox comboBoxVisitPlanReturnOn;
		private System.Windows.Forms.ComboBox comboBoxVisitPlanOrigin;
		private System.Windows.Forms.ComboBox comboBoxWorldTravelStartOn;
		private System.Windows.Forms.ComboBox comboBoxWorldTravelOrigin;
		private System.Windows.Forms.Button buttonVisitPlan;
		private System.Windows.Forms.Button buttonWorldTravelPlan;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ComboBox comboBoxPlace1;
		private System.Windows.Forms.ComboBox comboBoxPlace2;
		private System.Windows.Forms.ComboBox comboBoxPlace3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
		private System.Windows.Forms.Button buttonCheckFlight;
		private System.Windows.Forms.CheckBox checkBoxDirectFlightOnly;
		private System.Windows.Forms.ComboBox comboBoxFrom;
		private System.Windows.Forms.ComboBox comboBoxTo;
		private System.Windows.Forms.ComboBox comboBoxTime;
		private System.Windows.Forms.CheckedListBox checkedListBoxDays;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.SplitContainer mainContainer;
	}
}

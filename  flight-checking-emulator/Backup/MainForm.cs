
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using System.Data;

namespace TravelPlanner
{
	/// <summary>
	/// Description of TravelPlanner.
	/// </summary>
	public partial class MainForm : Form
	{
		TravelPlanner tp;
		MyDataGrid[] dataGrids;

		enum ErrorType { NoFlights };
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			try {
				tp = new TravelPlanner();
				InitializeControls();
			}
			catch(System.IO.FileNotFoundException e) {
				MessageBox.Show("Flight database is not found!",
				                "Database missing",
				                MessageBoxButtons.OK);
			}
		}
		
		private void InitializeControls() {
			foreach(Node<String,Flight> node in tp.Routes.Nodes)
			{
				comboBoxFrom.Items.Add(node.Value);
				comboBoxTo.Items.Add(node.Value);
				
				comboBoxVisitPlanOrigin.Items.Add(node.Value);
				comboBoxWorldTravelOrigin.Items.Add(node.Value);
				comboBoxPlace1.Items.Add(node.Value);
				comboBoxPlace2.Items.Add(node.Value);
				comboBoxPlace3.Items.Add(node.Value);
			}
			
			for(int i = 0; i <= TimeSlot.SlotCount; i++)
			{
				comboBoxTime.Items.Add(new TimeSlot(i));
			}

			{
				string[] dayNames = DayOfWeek.GetNames(typeof(DayOfWeek));
				checkedListBoxDays.Items.Add("Alldays");
				for(int i = 0; i < dayNames.Length; i++)
				{
					checkedListBoxDays.Items.Add(dayNames[i]);
					comboBoxVisitPlanStartOn.Items.Add(dayNames[i]);
					comboBoxVisitPlanReturnOn.Items.Add(dayNames[i]);
					comboBoxWorldTravelStartOn.Items.Add(dayNames[i]);
				}
			}
			
			comboBoxFrom.SelectedIndex = comboBoxFrom.Items.IndexOf("Singapore");
			comboBoxTime.SelectedIndex = 0;
			
			for(int i = 0; i < checkedListBoxDays.Items.Count; i++)
			{
				checkedListBoxDays.SetItemChecked(i, true);
			}
			
			checkBoxDirectFlightOnly.Checked = true;
		}
		
		private FlightConstraint GetCheckFlightConstraint()
		{
			FlightConstraint con = new FlightConstraint();
			con.Origin = (string)comboBoxFrom.SelectedItem;
			con.Destination = (string)comboBoxTo.SelectedItem;
			con.TimeSlot = (TimeSlot)comboBoxTime.SelectedItem;
			
			foreach(Object obj in checkedListBoxDays.CheckedItems) {
				string s = obj as string;
				con.Days.Set(tp.DayIndex(s), true);
			}
			
			con.DirectFlightOnly = checkBoxDirectFlightOnly.Checked;
			con.IsReturnTrip = false;
			con.FlightOnArrivalDay = true;
			
			return con;
		}
		
		
		private FlightConstraint GetVisitPlanConstraint()
		{
			FlightConstraint con = new FlightConstraint();
			con.Origin = (string)comboBoxVisitPlanOrigin.SelectedItem;
			con.Destination = con.Origin;
			con.TimeSlot = new TimeSlot(0);
			
			con.DirectFlightOnly = false;
			con.IsReturnTrip = true;
			con.FlightOnArrivalDay = false;
			
			con.Days[tp.DayIndex(comboBoxVisitPlanStartOn.SelectedItem as String)] = true;
			
			con.ReturnDay = tp.DayIndex(comboBoxVisitPlanReturnOn.SelectedItem as String);
			
			con.Places[0] = comboBoxPlace1.SelectedItem as String;
			con.Places[1] = comboBoxPlace2.SelectedItem as String;
			con.Places[2] = comboBoxPlace3.SelectedItem as String;
			
			return con;
		}
		
		void ButtonCheckFlightClick(object sender, EventArgs e)
		{
			// Check whether destination has been selected
			if ( comboBoxTo.SelectedIndex == -1 )
			{
				MessageBox.Show("Please select an destination...",
				                "Destination missing",
				                MessageBoxButtons.OK);
				return;
			}
			
			FlightConstraint con = GetCheckFlightConstraint();
			List<List<String>> results = tp.CheckFlights(con);
			
			tableLayoutPanelRight.Controls.Clear();
			
			if( results.Count == 0 )
			{
				MessageBox.Show("Sorry. There are no flights available under conditions specified.", 
				                "No Flights",
				                MessageBoxButtons.OK);
				return;
			}
			
			ShowRoutes(results);
		}
		
		private void ShowSequences(List<List<String>> seqs)
		{
			int count = 0;
			foreach(List<String> s in seqs)
			{
				Label seqLabel = new Label();
				String text = "";
				for(int i = 0; i < s.Count; i++)
				{
					text += s[i];
					if(i != s.Count - 1)
						text += " -> ";
				}
				count++;
				seqLabel.AutoSize = true;
				seqLabel.Margin = new Padding(10, 5, 0, 5);
				seqLabel.Font = new Font(seqLabel.Font.FontFamily, 11);
				seqLabel.BorderStyle = BorderStyle.Fixed3D;
				seqLabel.BackColor = Color.Aqua;
				
				seqLabel.Text = "Visit Sequence " + count + ": " + text;
				this.tableLayoutPanelRight.Controls.Add(seqLabel);
			}
		}
		
		private void ShowRoutes(List<List<String>> results,
		                        params Object[] parameters)
		{
			// Create multiple datagrids, each for one travel path
			dataGrids = new MyDataGrid[results.Count];
			Dictionary<List<String>, int> costs = null;
			
			if( parameters != null )
				if( parameters.Length >= 1 )
					costs = (Dictionary<List<String>,int>)parameters[0];
			
			for(int i = 0; i < dataGrids.Length; i++)
			{
				dataGrids[i] = GetFlightsGrid(results[i]);
				dataGrids[i].Size = new Size(500, 50 + 20*results[i].Count);
				dataGrids[i].RowHeadersVisible = false;
				dataGrids[i].ReadOnly = true;
				dataGrids[i].AllowSorting = false;
				dataGrids[i].CaptionText = "Route " + (i + 1)
											+ ": " + dataGrids[i].CaptionText;
				if( costs != null )
					dataGrids[i].CaptionText += " [ " + costs[results[i]] + " days]";
				
				SizeColumnsToContent(dataGrids[i], -1);
				this.tableLayoutPanelRight.Controls.Add(dataGrids[i]);
			}
		}

		private MyDataGrid GetFlightsGrid(List<String> path) 
		{
			MyDataGrid newGrid = new MyDataGrid();
			DataTable table = new DataTable();
			List<Flight> data = new List<Flight>();
			string caption = "";
			
			string[] s = new string[] {
				"Flight No.",
				"Origin",
				"Destination",
				"Departure Time",
				"Arrival Time",
				"Available Days"
			};
			
			for(int i = 0; i < s.Length; i++)
			{
				table.Columns.Add(s[i]);
			}
			
			for(int row = 0; row < path.Count; row++)
			{
				data.Add(tp.Flights[path[row]]);
				caption += data[row].Origin + " -> ";
				if( row == path.Count - 1 )
					caption += data[row].Destination;

				table.Rows.Add();
				for(int col = 0; col < s.Length; col++)
				{
					table.Rows[row][col] = data[row][col];
				}
			}
			
			newGrid.DataSource = table;
			newGrid.CaptionText = caption;
			newGrid.Margin = new Padding(10, 5, 0, 5);

			DataGridTableStyle myStyle = new DataGridTableStyle();
			myStyle.AllowSorting = false;
			newGrid.TableStyles.Add(myStyle);
			newGrid.TableStyles[0].AllowSorting = false;
			
			newGrid.AllowSorting = false;
			return newGrid;
		}
		
		void ButtonPlanClick(object sender, EventArgs e)
		{
			#region ControlsCheck
			if(comboBoxVisitPlanOrigin.SelectedIndex == -1)
			{
				MessageBox.Show("Please select the origin.", 
				                "Origin is not specified", 
				                MessageBoxButtons.OK);
				return;
			}
			
			if(comboBoxVisitPlanStartOn.SelectedIndex == -1 
			   || comboBoxVisitPlanReturnOn.SelectedIndex == -1)
			{
				MessageBox.Show("Please select the start day and the return day.", 
				                "Start day or return day is not specified.", 
				                MessageBoxButtons.OK);
				return;
			}
			
			if(comboBoxPlace1.SelectedIndex == -1 
			   || comboBoxPlace2.SelectedIndex == -1 
			   || comboBoxPlace3.SelectedIndex == -1)
			{
				MessageBox.Show("Please select 3 places to visit.",
				               "Places to visit are not specified", 
				               MessageBoxButtons.OK);
				return;
			}
			
			// Make sure origin cannot be selected as 3 places
			string p1 = comboBoxPlace1.SelectedItem as String;
			string p2 = comboBoxPlace2.SelectedItem as String;
			string p3 = comboBoxPlace3.SelectedItem as String;
			string origin = comboBoxVisitPlanOrigin.SelectedItem as String;
			
			if(p1 == origin || p2 == origin || p3 == origin)
			{
				MessageBox.Show("Origin cannot be one of the places to visit.",
				               "Invalid Places",
				               MessageBoxButtons.OK);
				return;
			}
			
			// Make sure 3 places are different
			if(p1 == p2 || p2 == p3 || p1 == p3)
			{
				MessageBox.Show("Same places cannot be chosen.",
				               "Invalid Places",
				               MessageBoxButtons.OK);
				return;
			}
			#endregion
			
			FlightConstraint con = GetVisitPlanConstraint();
			List<List<String>> results = tp.CheckFlights(con);
			
			this.tableLayoutPanelRight.Controls.Clear();
			if( results.Count == 0 )
			{
				MessageBox.Show("Sorry. No applicable plans under conditions specified.", 
				                "No Applicable Plans",
				                MessageBoxButtons.OK);
				return;
			}
			
			List<List<String>> seqs;
			List<List<String>> final = tp.GetPlanResults(results, con, out seqs);
			
			ShowSequences(seqs);
			ShowRoutes(final);
		}
		
		void CheckedListBoxDaysItemCheck(object sender, ItemCheckEventArgs e)
		{
			CheckedListBox box = sender as CheckedListBox;
			int allDaysIndex = box.Items.IndexOf("Alldays");
			
			// Disable this event at first
			box.ItemCheck -= new ItemCheckEventHandler(CheckedListBoxDaysItemCheck);
			
			if(e.Index == allDaysIndex)
			{
				bool check = (e.NewValue == CheckState.Checked);
				for(int i = 1; i < box.Items.Count; i++)
					box.SetItemChecked(i, check);
			}
			else if(e.Index > allDaysIndex)
			{
				if( e.NewValue == CheckState.Unchecked )
				{
					if( box.CheckedIndices.Count == 2
					   && box.GetItemCheckState(0) == CheckState.Indeterminate)
						box.SetItemCheckState(allDaysIndex, CheckState.Unchecked);
					else
						box.SetItemCheckState(allDaysIndex, CheckState.Indeterminate);
				}
				else if( e.NewValue == CheckState.Checked )
				{
					if( box.CheckedIndices.Count == 8 - 1 )
						box.SetItemCheckState(allDaysIndex, CheckState.Checked);
				}
			}
			// Re-enable the event
			box.ItemCheck += new ItemCheckEventHandler(CheckedListBoxDaysItemCheck);
		}
		
		void ButtonExitClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		public void SizeColumnsToContent(DataGrid dataGrid, int nRowsToScan)
		{
			// Create graphics object for measuring widths.
			Graphics Graphics = dataGrid.CreateGraphics();

			// Define new table style.
			DataGridTableStyle tableStyle = new DataGridTableStyle();

			try
			{
				DataTable dataTable = (DataTable)dataGrid.DataSource;

				if (-1 == nRowsToScan)
				{
					nRowsToScan = dataTable.Rows.Count;
				}
				else
				{
					// Can only scan rows if they exist.
					nRowsToScan = System.Math.Min(nRowsToScan,
					                              dataTable.Rows.Count);
				}

				// Clear any existing table styles.
				dataGrid.TableStyles.Clear();

				// Use mapping name that is defined in the data source.
				tableStyle.MappingName = dataTable.TableName;

				// Now create the column styles within the table style.
				DataGridTextBoxColumn columnStyle;
				int iWidth;

				for (int iCurrCol = 0;
				     iCurrCol < dataTable.Columns.Count; iCurrCol++)
				{
					DataColumn dataColumn = dataTable.Columns[iCurrCol];

					columnStyle = new DataGridTextBoxColumn();

					columnStyle.TextBox.Enabled = true;
					columnStyle.HeaderText = dataColumn.ColumnName;
					columnStyle.MappingName = dataColumn.ColumnName;

					// Set width to header text width.
					iWidth = (int)(Graphics.MeasureString
					               (columnStyle.HeaderText,
					                dataGrid.Font).Width);

					// Change width, if data width is
					// wider than header text width.
					// Check the width of the data in the first X rows.
					DataRow dataRow;
					for (int iRow = 0; iRow < nRowsToScan; iRow++)
					{
						dataRow = dataTable.Rows[iRow];

						if (null != dataRow[dataColumn.ColumnName])
						{
							int iColWidth = (int)(Graphics.MeasureString
							                      (dataRow.ItemArray[iCurrCol].ToString(),
							                       dataGrid.Font).Width);
							iWidth = (int)System.Math.Max(iWidth, iColWidth);
						}
					}
					columnStyle.Width = iWidth + 4;

					// Add the new column style to the table style.
					tableStyle.GridColumnStyles.Add(columnStyle);
				}
				// Add the new table style to the data grid.
				dataGrid.TableStyles.Add(tableStyle);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				Graphics.Dispose();
			}
		}
		
		void ButtonWorldTravelPlanClick(object sender, EventArgs e)
		{
			if( comboBoxWorldTravelOrigin.SelectedIndex == -1 )
			{
				MessageBox.Show("Please select an origin to start with.", 
				                "Mising Origin", 
				                MessageBoxButtons.OK);
				return;
			}
			
			if( comboBoxWorldTravelStartOn.SelectedIndex == -1 )
			{
				MessageBox.Show("Please select an start on day.",
				               "Missing start on day",
				               MessageBoxButtons.OK);
				return;
			}
			
			// Load a new database
			tp.NewFlights("flights2.txt");
			
			List<List<String>> seqs;
			List<List<String>> results = tp.WorldTravel(
				comboBoxWorldTravelOrigin.SelectedItem as String,
				comboBoxWorldTravelStartOn.SelectedItem as String,
				out seqs
			);
			
			this.tableLayoutPanelRight.Controls.Clear();
			
			if( results.Count == 0 )
			{
				MessageBox.Show("Sorry. No applicable travels under conditions specified.", 
				                "No Applicable Travels",
				                MessageBoxButtons.OK);
				return;
			}
			
			ShowSequences(seqs);
			// ShowRoutes(results);
			
			// Recover the old database
			tp.NewFlights("flights.txt");
		}

		void ButtonPrologClick(object sender, EventArgs e)
		{
			if( comboBoxFrom.SelectedIndex == -1 || comboBoxTo.SelectedIndex == -1)
			{
				MessageBox.Show("Please select origin and destination.", 
				                "Missing input", 
				                MessageBoxButtons.OK);
				return;
			}
			
			int term;
			string query = "";

			try
			{
                LogicServer ls = new LogicServer();
                ls.Init("");
                ls.Load("flights.xpl");
				string from = comboBoxFrom.SelectedItem as String;
				string to = comboBoxTo.SelectedItem as String;

                query = "hasflight(" + from.ToLower() +"," + to.ToLower() + ").";

                MessageBox.Show("query = " + query);

				// Execute query
                term = ls.ExecStr(query); 
				if( term == 0 )
				{
					MessageBox.Show("There are no flights from " 
					                + from + " to " + to + ".");
				}
				else
				{
					MessageBox.Show("There are flights from "
					               + from + " to " + to + ".");
				}
                ls.Close();
			}
			catch(LSException lse)
			{
				MessageBox.Show(lse.GetMessage());
			}
		}
	}
}

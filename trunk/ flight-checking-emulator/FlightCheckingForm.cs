﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlightCheckingEmulator
{
    public partial class FlightCheckingForm : Form
    {
        private const string DefaultCity = "Singapore";

        private FlightPlanner flightPlanner;

        private MyDataGrid[] _dataGrids;

        public FlightCheckingForm()
        {
            //Call the initialization code generated by the WYSIWYG Designer
            InitializeComponent();

            bool couldLoadData = InitPlanner();  //Some errors occurred
            if (!couldLoadData)
            {
                Application.Exit();
            }

            DisplayData();
        }

        private bool InitPlanner()
        {
            try
            {
                flightPlanner = new FlightPlanner();
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show("Flight database is not found!", "Database missing", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void DisplayData()
        {
            //Load City
            foreach (Node<String, Flight> node in flightPlanner.Routes.Nodes)
            {
                //Load cities into the check flight combo boxes
                checkFlightFromCmb.Items.Add(node.Value);
                checkFlightToCmb.Items.Add(node.Value);

                //Load cities into the visit plan combo boxes
                visitPlanOriginCmb.Items.Add(node.Value);
                visitPlanPlacesListBox.Items.Add(node.Value);
            }

            //Select default departure city for check flight tab
            checkFlightFromCmb.SelectedIndex = checkFlightFromCmb.Items.IndexOf(DefaultCity);

            //Select default origin city for visit plan tab
            visitPlanOriginCmb.SelectedIndex = visitPlanOriginCmb.Items.IndexOf(DefaultCity);

            //Populate time slots for departure
            for (int i = 0; i <= TimeSlot.SlotCount; i++)
            {
                checkFlightDepartCmb.Items.Add(new TimeSlot(i));
            }
            //Select first time slot as default.
            checkFlightDepartCmb.SelectedIndex = 0;

            checkFlightWeekdayListBox.Items.Add("Alldays");
            string[] dayNames = DayOfWeek.GetNames(typeof(DayOfWeek));
            //Populate day names for start and end of visit plan
            for (int i = 0; i < dayNames.Length; i++)
            {
                checkFlightWeekdayListBox.Items.Add(dayNames[i]);
                visitPlanStartCmb.Items.Add(dayNames[i]);
                visitPlanReturnCmb.Items.Add(dayNames[i]);
            }

            //Mark all days by default
            for (int i = 0; i < checkFlightWeekdayListBox.Items.Count; i++)
            {
                checkFlightWeekdayListBox.SetItemChecked(i, true);
            }

            //direct flight option is checked by default.
            directFlightOpt.Checked = true;
        }

        /*
         * Handle click event. Start checking flights.
         */
        private void checkFlightBtn_Click(object sender, EventArgs e)
        {
            // Check whether destination has been selected
            if (checkFlightToCmb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an destination.",
                                "Destination missing",
                                MessageBoxButtons.OK);
                return;
            }

            FlightConstraint con = GetCheckFlightConstraint();
            List<List<String>> results = flightPlanner.CheckFlights(con);
            
            resultPanel.Controls.Clear();

            if (results.Count == 0)
            {
                MessageBox.Show("Sorry. There are no flights available under conditions specified.",
                                "No Flights",
                                MessageBoxButtons.OK);
                return;
            }

            //Checking if Sort option is checked
            /*
            //Calulate duration and pass to scheme for sorting
            List<Flight> data = new List<Flight>();
            List<String> a = results[0];
            for (int row = 0; row < a.Count; row++)
            {
                data.Add(flightPlanner.Flights[a[row]]);                
            }
            */
            ShowRoutes(results);
        }

        /**
         * Return a FlightConstraint object that encapsulates all
         * the options that the user made.
         */
        private FlightConstraint GetCheckFlightConstraint()
        {
            FlightConstraint con = new FlightConstraint();
            con.Origin = (string)checkFlightFromCmb.SelectedItem;
            con.Destination = (string)checkFlightToCmb.SelectedItem;
            con.TimeSlot = (TimeSlot)checkFlightDepartCmb.SelectedItem;

            foreach (Object obj in checkFlightWeekdayListBox.CheckedItems)
            {
                string s = obj as string;
                con.Days.Set(flightPlanner.DayIndex(s), true);
            }

            con.DirectFlightOnly = directFlightOpt.Checked;
            con.IsReturnTrip = false;
            con.FlightOnArrivalDay = true;

            return con;
        }

        /**
         * 
         */
        private void ShowRoutes(List<List<String>> results,
                                params Object[] parameters)
        {
            // Create multiple datagrids, each for one travel path
            _dataGrids = new MyDataGrid[results.Count];
            Dictionary<List<String>, int> costs = null;

            if (parameters != null)
                if (parameters.Length >= 1)
                    costs = (Dictionary<List<String>, int>)parameters[0];

            for (int i = 0; i < _dataGrids.Length; i++)
            {
                _dataGrids[i] = GetFlightsGrid(results[i]);
                _dataGrids[i].Size = new Size(500, 50 + 20 * results[i].Count);
                _dataGrids[i].RowHeadersVisible = false;
                _dataGrids[i].ReadOnly = true;
                _dataGrids[i].AllowSorting = false;
                _dataGrids[i].CaptionText = "Route " + (i + 1)
                                            + ": " + _dataGrids[i].CaptionText;
                _dataGrids[i].BackgroundColor = SystemColors.GradientInactiveCaption;
                if (costs != null)
                    _dataGrids[i].CaptionText += " [ " + costs[results[i]] + " days]";

                SizeColumnsToContent(_dataGrids[i], -1);
                this.resultPanel.Controls.Add(_dataGrids[i]);
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

            for (int i = 0; i < s.Length; i++)
            {
                table.Columns.Add(s[i]);
            }

            for (int row = 0; row < path.Count; row++)
            {
                data.Add(flightPlanner.Flights[path[row]]);
                caption += data[row].Origin + " -> ";
                if (row == path.Count - 1)
                    caption += data[row].Destination;

                table.Rows.Add();
                for (int col = 0; col < s.Length; col++)
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

        /**
         * Resize the result table to fit the table header.
         */
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Graphics.Dispose();
            }
        }

        private void prologBtn_Click(object sender, EventArgs e)
        {
        }

        private void planOrigin_SelectedIndexChange(object sender, EventArgs e)
        {
            object origin = visitPlanOriginCmb.SelectedItem;
            int numPlaces = visitPlanPlacesListBox.Items.Count;
            for (int i = 0; i < numPlaces; ++i)
            {
                if (visitPlanPlacesListBox.Items[i].Equals(origin))
                {
                    visitPlanPlacesListBox.Items.RemoveAt(i);
                }
            }
        }

        private void planBtn_Click(object sender, EventArgs e)
        {
            // Check whether the origin city has been selected
            if (visitPlanOriginCmb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an origin to start the trip.",
                                "Origin Missing",
                                MessageBoxButtons.OK);
                return;
            }

            List<String> visitPlaces = new List<String>();
            int numPlaces = visitPlanPlacesListBox.Items.Count;
            for (int i = 0; i < numPlaces; ++i)
            {
                if (visitPlanPlacesListBox.GetItemChecked(i))
                {
                    visitPlaces.Add((String) visitPlanPlacesListBox.Items[i]);
                }
            }

            if (visitPlaces.Count <= 0)
            {
                MessageBox.Show("Please select at least a place to include in the trip.",
                                "Incomplete Trip",
                                MessageBoxButtons.OK);
                return;
            }

            FlightConstraint con = new FlightConstraint();
            con.Origin = (string)visitPlanOriginCmb.SelectedItem;
            con.Destination = con.Origin;
            con.TimeSlot = new TimeSlot(0);

            con.DirectFlightOnly = false;
            con.IsReturnTrip = true;
            con.FlightOnArrivalDay = false;

            con.Days[flightPlanner.DayIndex(visitPlanStartCmb.SelectedItem as String)] = true;

            con.ReturnDay = flightPlanner.DayIndex(visitPlanReturnCmb.SelectedItem as String);

            con.Places = visitPlaces.ToArray();

            List<List<String>> results = flightPlanner.CheckFlights(con);

            resultPanel.Controls.Clear();
            if (results.Count == 0)
            {
                MessageBox.Show("No travel plan was found.",
                                "No Plan",
                                MessageBoxButtons.OK);
                return;
            }

            List<List<String>> seqs;
            List<List<String>> final = flightPlanner.GetPlanResults(results, con, out seqs);

            ShowSequences(seqs);
            ShowRoutes(final);
        }

        private void ShowSequences(List<List<String>> seqs)
        {
            int count = 0;
            foreach (List<String> s in seqs)
            {
                Label seqLabel = new Label();
                String text = "";
                for (int i = 0; i < s.Count; i++)
                {
                    text += s[i];
                    if (i != s.Count - 1)
                        text += " -> ";
                }
                count++;
                seqLabel.AutoSize = true;
                seqLabel.Margin = new Padding(10, 5, 0, 5);
                seqLabel.Font = new Font(seqLabel.Font.FontFamily, 11);
                seqLabel.BorderStyle = BorderStyle.Fixed3D;
                seqLabel.BackColor = Color.Aqua;

                seqLabel.Text = "Visit Sequence " + count + ": " + text;
                resultPanel.Controls.Add(seqLabel);
            }
        }
    }
}

using System;
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
        private FlightPlanner _flightPlanner;
        private MyDataGrid[] _dataGrids;

        public FlightCheckingForm()
        {
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            try
            {
                _flightPlanner = new FlightPlanner();
                InitializeControls();
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show("Flight database is not found!","Database missing",MessageBoxButtons.OK);
            }
        }
        private void InitializeControls()
        {
            foreach (Node<String, Flight> node in _flightPlanner.Routes.Nodes)
            {
                //Populate data of the comboboxes of check flight tab.
                chkFlightComboBoxFrom.Items.Add(node.Value);
                chkFlightComboBoxTo.Items.Add(node.Value);

                //Populate data of the comboboxes of visit plan tab.
                visitPlanComboBoxOrigin.Items.Add(node.Value);
                visitPlanChkListBoxPlaces.Items.Add(node.Value);
                //comboBoxWorldTravelOrigin.Items.Add(node.Value);
                //comboBoxPlace1.Items.Add(node.Value);
                //comboBoxPlace2.Items.Add(node.Value);
                //comboBoxPlace3.Items.Add(node.Value);
            }

            //Select Singapore as default for the departure place in check flight tab.
            chkFlightComboBoxFrom.SelectedIndex = chkFlightComboBoxFrom.Items.IndexOf("Singapore");

            //Select Singapore as default for the origin place in visit plan.
            visitPlanComboBoxOrigin.SelectedIndex = visitPlanComboBoxOrigin.Items.IndexOf("Singapore");
            

            //Populate time slots for the chkFlightComboBoxDepart
            for (int i = 0; i <= TimeSlot.SlotCount; i++)
            {
                chkFlightComboBoxDepart.Items.Add(new TimeSlot(i));
            }
            //Select first time slot as default.
            chkFlightComboBoxDepart.SelectedIndex = 0;

            
            string[] dayNames = DayOfWeek.GetNames(typeof(DayOfWeek));
            checkedListBoxDays.Items.Add("Alldays");

            //Populate data for the checked list box days in check flight tab.
            for (int i = 0; i < dayNames.Length; i++)
            {
                checkedListBoxDays.Items.Add(dayNames[i]);
                comboBoxVisitPlanStartOn.Items.Add(dayNames[i]);
                comboBoxVisitPlanReturnOn.Items.Add(dayNames[i]);
                //comboBoxWorldTravelStartOn.Items.Add(dayNames[i]);
            }

            //Mark all days by default
            for (int i = 0; i < checkedListBoxDays.Items.Count; i++)
            {
                checkedListBoxDays.SetItemChecked(i, true);
            }

            //direct flight option is checked by default.
            directFlightOption.Checked = true;
        }

        private void checkFlightBtn_Click(object sender, EventArgs e)
        {
            // Check whether destination has been selected
            if (chkFlightComboBoxTo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an destination...",
                                "Destination missing",
                                MessageBoxButtons.OK);
                return;
            }

            FlightConstraint con = GetCheckFlightConstraint();
            List<List<String>> results = _flightPlanner.CheckFlights(con);

            resultPanel.Controls.Clear();

            if (results.Count == 0)
            {
                MessageBox.Show("Sorry. There are no flights available under conditions specified.",
                                "No Flights",
                                MessageBoxButtons.OK);
                return;
            }

            //Checking if Sort option is checked

            //Calulate duration and pass to scheme for sorting
            String sortedResutl = "";
            List<Flight> data = new List<Flight>();
            sortedResutl.Split(new String[]{","},StringSplitOptions.None);
            List<String> a = results[0];
            for (int row = 0; row < a.Count; row++)
            {
                data.Add(_flightPlanner.Flights[a[row]]);                
            }

            ShowRoutes(results);
        }

        /**
         * 
         */
        private FlightConstraint GetCheckFlightConstraint()
        {
            FlightConstraint con = new FlightConstraint();
            con.Origin = (string)chkFlightComboBoxFrom.SelectedItem;
            con.Destination = (string)chkFlightComboBoxTo.SelectedItem;
            con.TimeSlot = (TimeSlot)chkFlightComboBoxDepart.SelectedItem;

            foreach (Object obj in checkedListBoxDays.CheckedItems)
            {
                string s = obj as string;
                con.Days.Set(_flightPlanner.DayIndex(s), true);
            }

            con.DirectFlightOnly = directFlightOption.Checked;
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
                data.Add(_flightPlanner.Flights[path[row]]);
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
         * Make the result table resized to fit the table header.
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
    }
}

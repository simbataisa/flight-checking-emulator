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
        private TravelPlanner tp;

        public FlightCheckingForm()
        {
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            try
            {
                tp = new TravelPlanner();
                InitializeControls();
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show("Flight database is not found!","Database missing",MessageBoxButtons.OK);
            }
        }
        private void InitializeControls()
        {
            foreach (Node<String, Flight> node in tp.Routes.Nodes)
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
      
    }
}

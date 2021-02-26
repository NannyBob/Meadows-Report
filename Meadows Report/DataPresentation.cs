using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Meadows_Report
{
    public partial class DataPresentation : Form
    {
        ResidentHandler Handler;
        public DataPresentation(ResidentHandler handler)
        {
            InitializeComponent();
            Handler = handler;

        }

        private void DataPresentation_Load(object sender, EventArgs e)
        {

        }

        private void PreviousCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateGraph();   
        }

        private void CurrentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateGraph();
            
            
        }
        private void updateGraph()
        {
            chart1.Series["Current"].Points.Clear();
            chart1.Series["Previous"].Points.Clear();
            List<Resident>[] currentYears = new List<Resident>[0];
            List<Resident>[] previousYears = new List<Resident>[0];
            double currentAv = 0;
            double prevAv = 0;
            int counter = 0;

            if (CurrentCheckBox.Checked)
            {
                currentYears = Handler.dataForGraph(true);
            }
            if (PreviousCheckBox.Checked)
            {
                previousYears = Handler.dataForGraph(false);
            }

            for (int i = 0; i < currentYears.Length; i++)
            {

                chart1.Series["Current"].Points.AddXY($"{i} - {i + 1}", currentYears[i].Count);
                foreach (Resident res in currentYears[i]) 
                {
                    currentAv += res.lengthYears();
                    counter++;
                }
            }
            CurrentAverageLabel.Text = "Average Stay for Current residents = " + Math.Round(currentAv / counter, 2);
            counter = 0;
            for (int i = 0; i < previousYears.Length; i++)
            {
                chart1.Series["Previous"].Points.AddXY($"{i} - {i + 1}", previousYears[i].Count);
                foreach (Resident res in currentYears[i])
                {
                    prevAv += res.lengthYears();
                    counter++;
                }
            }

            PreviousAverageLabel.Text = "Average Stay for Previous residents = " + Math.Round(prevAv / counter,2);
            counter = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



//picture
//Fix N/A
//House Specific
//Add more data

namespace Meadows_Report
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void GoButt_Click(object sender, EventArgs e)
        {
            FileDialog.Title = "Please choose your .csv file";
            FileDialog.ShowDialog();
            string fileName = FileDialog.FileName;
            CsvParser parse = new CsvParser(fileName);
            ResidentHandler handler = parse.findResidents();
            handler.earliestResident();

            DataPresentation dp = new DataPresentation(handler);
            dp.Show();
               
        }
    }

    public class ResidentHandler
    {
        private List<Resident> Residents;

        public ResidentHandler()
        {
            Residents = new List<Resident>();
        }
        public ResidentHandler(List<Resident> res)
        {
            Residents = res;
        }

        public void earliestResident()
        {
            Resident earliest = Residents[0];
            foreach (Resident i in Residents)
            {
                if (i.Admission < earliest.Admission)
                {
                    earliest = i;
                }
            }
            MessageBox.Show(earliest.Name);
        }

        public void addResident(Resident res)
        {
            Residents.Add(res);
        }
        public List<Resident> GetAllResidents()
        {
            return Residents;
        }
        public List<Resident> GetCurrentResidents()
        {
            List<Resident> toReturn = new List<Resident>();
            foreach (Resident i in Residents)
            {
                if (i.Admission < DateTime.Today && i.Leaving > DateTime.Today)
                {
                    toReturn.Add(i);
                }
            }
            return toReturn;
        }
        public List<Resident> GetPreviousResidents()
        {
            List<Resident> toReturn = new List<Resident>();
            foreach (Resident i in Residents)
            {
                if (i.Leaving < DateTime.Today)
                {
                    toReturn.Add(i);
                }
            }
            return toReturn;
        }

        public List<Resident>[] dataForGraph(bool current)
        {
            List<Resident> res = new List<Resident>();
            if (current)
            {
                res.AddRange(GetCurrentResidents());
            }
            else
            {
                res.AddRange(GetPreviousResidents());
            }

            if (res.Count == 0)
            {
                return new List<Resident>[0];
            }
            double highest = double.MinValue;
            double lowest = double.MaxValue;

            //this is really to get the range
            foreach (Resident i in res)
            {
                double length = i.lengthYears();
                if (length > highest)
                {
                    highest = length;
                }
                if (length < lowest)
                {
                    lowest = length;
                }

            }


            List<Resident>[] years = new List<Resident>[Convert.ToInt32(Math.Floor(highest)) + 1];
            for (int i = 0; i < years.Length; i++)
            {
                years[i] = new List<Resident>();
            }
            foreach (Resident resident in res)
            {
                double length = resident.lengthYears();
                if (length < 0)
                {
                    continue;
                }
                int rounded = Convert.ToInt32(Math.Floor(length));

                years[rounded].Add(resident);
            }
            return years;

        }
    }

    public class Resident
    {
        public string Name;
        public DateTime Admission;
        public DateTime Leaving;
        public string Home;
        public Resident(string home, string name, DateTime admission, DateTime leaving)
        {
            Home = home;
            Name = name;
            Admission = admission;
            Leaving = leaving;
        }
        public double lengthYears()
        {
            TimeSpan span;
            if (Leaving > DateTime.Today)
            {
                span = DateTime.Today - Admission;
            }
            else
            {
                span = Leaving - Admission;
            }
            
            return span.TotalDays / 365.0;
        }

        

    }
    public class CsvParser
    {
        private string fileName;

        public CsvParser(string name)
        {
            fileName = name;
        }
        public ResidentHandler findResidents()
        {
            ResidentHandler handler = new ResidentHandler();
            StreamReader reader = new StreamReader(fileName);
            //skips the first 2 lines
            reader.ReadLine();
            reader.ReadLine();
            while (true)
            {
                string[] line;
                try
                {
                    line = reader.ReadLine().Split(',');
                }
                catch (System.NullReferenceException)
                {
                    return handler;
                }

                DateTime admission = convertDate(line[2].Trim('"'));
                DateTime leaving = convertDate(line[3].Trim('"'));

                handler.addResident(new Resident(line[0].Trim('"'), line[1].Trim('"'), admission, leaving));
            }
        }
        private DateTime convertDate(string date)
        {
            if (date == "N/A")
            {
                return DateTime.Today.AddDays(1);  //returns current date and time
            }
            string[] sections = date.Split(' ');
            int day = int.Parse(sections[0]);

            IDictionary<string, int> months = new Dictionary<string, int>();
            months.Add("Jan", 1);
            months.Add("Feb", 2);
            months.Add("Mar", 3);
            months.Add("Apr", 4);
            months.Add("May", 5);
            months.Add("Jun", 6);
            months.Add("Jul", 7);
            months.Add("Aug", 8);
            months.Add("Sep", 9);
            months.Add("Oct", 10);
            months.Add("Nov", 11);
            months.Add("Dec", 12);

            int month = months[sections[1]];
            int year = int.Parse(sections[2]);

            return new DateTime(year, month, day);


        }

    }



}

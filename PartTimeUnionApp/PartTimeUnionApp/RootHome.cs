using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartTimeUnionApp
{
    public partial class RootHome : Form
    {
        private StringBuilder id;
        private RootFunctionAdapter rfa;

        public RootHome()
        {
            InitializeComponent();
            rfa = new RootFunctionAdapter();
            //currentlyTeaching.Items.Add("asdfasdf");  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ErrorLog log = new ErrorLog();
            log.WriteLog("Hello Zack");

            
        }

        private void RootHome_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < rfa.GetAllProfs().GetNumOfProf(); i++)
            {
                personBox.Items.Add(rfa.GetAllProfs().GetAll()[i].GetName());
            }
        }


        private void personBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (personBox.SelectedIndex != -1)
            {
                //ErrorLog log = new ErrorLog();
                //log.WriteLog(personBox.SelectedItem.ToString());
                id = new StringBuilder();
                int indexOfS = 0;
                while (personBox.SelectedItem.ToString().ElementAt(indexOfS)!=' ')
                {
                    id.Append(personBox.SelectedItem.ToString().ElementAt(indexOfS++));
                    ErrorLog log1 = new ErrorLog();
                    log1.WriteLog(id.ToString());
                }

                PartTimeProfessor ptp = rfa.GetAllProfs().GetProf(new PartTimeProfessor(id.ToString()));
                identification.Text = ptp.GetId();
                lastName.Text = ptp.GetLastName();
                middleName.Text = ptp.GetMiddleInitial();
                firstName.Text = ptp.GetFirstName();
                street.Text = ptp.GetStreet();
                city.Text = ptp.GetCity();
                province.Text = ptp.GetProvince();
                country.Text = ptp.GetCountry();
                postalCode.Text = ptp.GetPostcode();
                number.Text = ptp.GetWorkPhone();
                extension.Text = ptp.GetSchoolExtention();
                homePhone.Text = ptp.GetHomePhone();
                personalEmail.Text = ptp.GetPrivateEmail();
                algomaEmail.Text = ptp.GetAlgomauEmail();
                seniority.Text = ptp.GetSeniority() + "";

                int indexOfC = 0;
                while (true)
                {
                    try
                    {
                        currentlyTeaching.Items.RemoveAt(indexOfC++);
                    }
                    catch(Exception)
                    {
                        break;
                    }
                }

                for (int i = 0; i < ptp.GetTeachingCourses().GetNumOfRecord(); i++)
                {
                    currentlyTeaching.Items.Add(ptp.GetTeachingCourses().GetAll()[i].GetCourse());
                }

                int indexOfT = 0;
                while (true)
                {
                    try
                    {
                        tapRights.Items.RemoveAt(indexOfT++);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                for (int i = 0; i < ptp.GetTAPList().GetNumOfTap(); i++)
                {
                    tapRights.Items.Add(ptp.GetTAPList().GetAll()[i].GetCourseInfo());
                }



            }


        }

        private void lastName_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void currentlyTeaching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentlyTeaching.SelectedIndex != -1)
            {
                new Form1().Show();

            }

        }

        private void tapRights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentlyTeaching.SelectedIndex != -1)
            {
                new Form1().Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ErrorLog log = new ErrorLog();
            log.WriteLog(id.ToString());
            new ModifyProf(id.ToString()).Show();
        }

        //private void RootHome_GotFocus(Object sender, EventArgs e)
        //{

        //    this.Refresh();

        //}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                new login().Show();
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}

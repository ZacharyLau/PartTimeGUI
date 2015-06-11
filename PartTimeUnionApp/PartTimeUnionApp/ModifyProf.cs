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
    public partial class ModifyProf : Form
    {
        string identification;
        private RootFunctionAdapter rfa;

        public ModifyProf()
        {
            InitializeComponent();
            rfa = new RootFunctionAdapter();
        }

        public ModifyProf(string id)
        {
            InitializeComponent();
            identification = id;
            rfa = new RootFunctionAdapter();
        }

        private void ModifyProf_Load(object sender, EventArgs e)
        {
            PartTimeProfessor ptp = rfa.GetAllProfs().GetProf(new PartTimeProfessor(identification));
            idTB.Text = ptp.GetId();
            lastNameTB.Text = ptp.GetLastName();
            middleInitialTB.Text = ptp.GetMiddleInitial();
            firstNameTB.Text = ptp.GetFirstName();
            streetTB.Text = ptp.GetStreet();
            cityTB.Text = ptp.GetCity();
            provinceTB.Text = ptp.GetProvince();
            countryTB.Text = ptp.GetCountry();
            postalCodeTB.Text = ptp.GetPostcode();
            homePhoneTB.Text = ptp.GetHomePhone();
            workPhoneTB.Text = ptp.GetWorkPhone();
            schoolExtensionTB.Text = ptp.GetSchoolExtention();
            privateEmailTB.Text = ptp.GetPrivateEmail();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void schoolExtensionTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PartTimeProfessorDataAdapter ptpda = new PartTimeProfessorDataAdapter();
            ptpda.Update(identification, idTB.Text, lastNameTB.Text, middleInitialTB.Text, firstNameTB.Text, countryTB.Text,
                streetTB.Text, cityTB.Text, provinceTB.Text, countryTB.Text, postalCodeTB.Text, homePhoneTB.Text,
                workPhoneTB.Text, schoolExtensionTB.Text, privateEmailTB.Text);
            this.Close();
            //// http://www.codeproject.com/Questions/122217/how-to-close-one-form-through-another-form-by-butt

            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "RootHome")
                {
                    Application.OpenForms[index].Visible = false;
                }
            }

            new RootHome().Show();

        }
    }
}

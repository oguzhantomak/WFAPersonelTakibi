using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WFAPersonelTakibi
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.AddRange(Enum.GetNames(typeof(PersonelDepartmentType)));
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();

            personel.PersonelName = txtFirstName.Text;
            personel.PersonelLastName = txtLastName.Text;
            personel.PersonelBirthDate = dtBirthDate.Value;
            personel.PersonelMail = txtMail.Text;

            for (int i = 0; i < metroPanel1.Controls.Count; i++)
            {
                if (metroPanel1.Controls[i] is MetroRadioButton)
                {
                    MetroRadioButton metroRadio = (MetroRadioButton)metroPanel1.Controls[i];
                    if (metroRadio.Checked)
                    {
                        personel.PersonelGender = (PersonelGenderType)Enum.Parse(typeof(PersonelGenderType), metroRadio.Text);
                        break;
                    }
                }
            }

            personel.PersonelAddress = txtAddress.Text;
            personel.PersonelPhone = txtPhone.Text;
            personel.PersonelDepartment = (PersonelDepartmentType)Enum.Parse(typeof(PersonelDepartmentType), cmbDepartment.Text);
        }
    }
}

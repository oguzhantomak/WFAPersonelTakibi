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

        public static List<Personel> personeller = new List<Personel>();

        #region Save
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

            if (pcbImageUrl.Tag != null)
            {
                personel.PersonelImageURL = pcbImageUrl.Tag.ToString();
            }

            personel.PersonelAddress = txtAddress.Text;
            personel.PersonelPhone = txtPhone.Text;
            personel.PersonelDepartment = (PersonelDepartmentType)Enum.Parse(typeof(PersonelDepartmentType), cmbDepartment.Text);

            personeller.Add(personel);
        }
        #endregion

        #region Save Image
        private void PcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png |jpg files (*.jpg)|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbImageUrl.Image = Image.FromFile(ofd.FileName);
            }

            //string imageName = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(ofd.FileName)}";
            //System.IO.Path.GetExtension(ofd.FileName) anlamı ofd.filename ile çekilen dosyanın uzantısını teslim eder. yani .jpg veya .png vb.

            string imageName = $@"{Environment.CurrentDirectory}\..\..\img\{Guid.NewGuid()}{System.IO.Path.GetExtension(ofd.FileName)}";

            pcbImageUrl.Image.Save(imageName);

            bool result = System.IO.File.Exists(imageName);

            if (result)
            {
                pcbImageUrl.Tag = imageName;
            }

        }

        #endregion

        private void MetroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }
    }
}

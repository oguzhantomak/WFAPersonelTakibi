using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WFAPersonelTakibi
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvEmployees.DataSource = Form1.personeller.ToList().Select(x => new { x.Id,x.PersonelName, x.PersonelLastName, x.PersonelMail, x.PersonelPhone }).ToList();
        }

        private void TsmSil_Click(object sender, EventArgs e)
        {
            Guid id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            var personeller = Form1.personeller.Where(x => x.Id == id);
            //Bir çok kayıda ulaşıcaksak direkt where kullanıyoruz. Liste vericek. Liste verse bile içinde 1 eleman olacak.

            var personel = Form1.personeller.FirstOrDefault(x => x.Id == id);
            //Tek bir kayıda ulaşıcaksak firstordefault kullanıcaz.

            Form1.personeller.Remove(personel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi
{
    public sealed partial class Personel : BaseClass
    {
        public string PersonelName { get; set; }
        public string PersonelLastName { get; set; }
        public DateTime PersonelBirthDate { get; set; }
        public string PersonelMail { get; set; }
        public PersonelGenderType PersonelGender { get; set; }
        public string PersonelAddress { get; set; }
        public string PersonelPhone { get; set; }
        public PersonelDepartmentType PersonelDepartment { get; set; }
        public string PersonelImageURL { get; set; } = $@"{Environment.CurrentDirectory}\..\..\img\user.png";
    }
}

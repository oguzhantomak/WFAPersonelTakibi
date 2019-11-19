using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string CreatedIp { get; set; }
        public string CreatedComputerName { get; set; }

        public DateTime ModifiedDate { get; private set; }
        public string ModifiedIp { get; set; }
        public string ModifiedComputerName { get; set; }


        public BaseClass()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedIp = "12.0.0.1";
        }
    }

}

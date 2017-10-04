using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travels.dto.Dto.Request
{
    public class ContactEmergency
    {
        public string FullName { get; set; }
        public string Relationship { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string IDNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
    }
}

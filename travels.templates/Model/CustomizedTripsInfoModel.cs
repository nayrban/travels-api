using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travels.templates.Model
{
    public class CustomizedTripsInfoModel
    {
        public string Message { get; set; }        

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherSpecifications { get; set; }

        public List<string> CustomTrips { get; set; }
    }
}

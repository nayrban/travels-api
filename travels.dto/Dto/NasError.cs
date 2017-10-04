using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travels.dto.Dto
{
    public class NasError
    {
        public string Message { get; set; }

        public int Code { get; set; }

        public string DetailedMessage { set; get; }
    }
}

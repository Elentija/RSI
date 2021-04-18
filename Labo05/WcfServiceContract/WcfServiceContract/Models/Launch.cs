using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract.Models
{
    class Launch
    {
        public string flight_number { get; set; }
        public string mission_name { get; set; }
        public string launch_year { get; set; }
        public string launch_date_utc { get; set; }
        public string launch_date_local { get; set; }
        public string is_tentative { get; set; }
        public string tentative_max_precision { get; set; }
        public string launch_window { get; set; }
    }
}

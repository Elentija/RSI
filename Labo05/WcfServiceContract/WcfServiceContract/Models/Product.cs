using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract.Models
{
    class Product
    {
        public string product { get; set; }
        public string init { get; set; }
        public List<Forecast> dataseries { get; set; }
    }
}

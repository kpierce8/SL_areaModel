using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SL5_BoxData.Model
{
    public class boxStats : Observable
    {
        public int row { get; set; }
        public double top { get; set; }
        public double left { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double area { get; set; }
        public string name { get; set; }

        public boxStats()
        {

        }
    }
}

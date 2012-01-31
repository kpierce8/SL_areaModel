using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SL5_BoxData.Model
{
    //[XmlRoot(Namespace = "urn:root")]
    public class boxDataSource :Observable
    {
        public int row { get; set; }
        public double hpheArea { get; set; }
        public double hpleArea { get; set; }
        public double lpheArea { get; set; }
        public double lpleArea { get; set; }
        public double hpheUGA { get; set; }
        public double hpleUGA { get; set; }
        public double lpheUGA { get; set; }
        public double lpleUGA { get; set; }
        public double hpheAreaCng { get; set; }
        public double hpleAreaCng { get; set; }
        public double lpheAreaCng { get; set; }
        public double lpleAreaCng { get; set; }
        public double hpheUGACng { get; set; }
        public double hpleUGACng { get; set; }
        public double lpheUGACng { get; set; }
        public double lpleUGACng { get; set; }
    }
}

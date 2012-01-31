using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SL5_BoxData.Model
{
    public class getBoxData
    {
        public int row { get; set; }
        public boxStats goldArea{ get; set; }
        public boxStats redArea { get; set; }
        public boxStats blueArea { get; set; }
        public boxStats greenArea { get; set; }
        public boxStats goldUGA { get; set; }
        public boxStats redUGA { get; set; }
        public boxStats blueUGA { get; set; }
        public boxStats greenUGA { get; set; }
        public boxStats goldAreaCng { get; set; }
        public boxStats redAreaCng { get; set; }
        public boxStats blueAreaCng { get; set; }
        public boxStats greenAreaCng { get; set; }
        public boxStats goldUGACng { get; set; }
        public boxStats redUGACng { get; set; }
        public boxStats blueUGACng { get; set; }
        public boxStats greenUGACng { get; set; }
        public double _scalingFactor =20;
        //public boxDataSource bData { get; set; }

        public getBoxData(boxDataSource bData)
        {
            goldArea = new boxStats() { name = "hpheArea", area = bData.hpheArea };
            blueArea = new boxStats() { name = "lpheArea", area = bData.lpheArea };
            redArea = new boxStats() { name = "hpleArea", area = bData.hpleArea }; 
            greenArea = new boxStats() { name = "lpleArea", area = bData.lpleArea };

            goldUGA = new boxStats() { name = "hpheUGA", area = bData.hpheUGA };
            blueUGA = new boxStats(){ name = "lpheUGA", area = bData.lpheUGA };
            redUGA = new boxStats(){ name = "hpleUGA", area = bData.hpleUGA };
            greenUGA = new boxStats() { name = "lpleUGA", area = bData.lpleUGA };

            goldUGACng = new boxStats(){ name = "hpheUGACng", area = bData.hpheUGACng };
            blueUGACng = new boxStats(){ name = "lpheUGACng", area = bData.lpheUGACng };
            redUGACng = new boxStats(){ name = "hpleUGACng", area = bData.hpleUGACng };
            greenUGACng = new boxStats() { name = "lpleUGACng", area = bData.lpleUGACng };

            goldAreaCng = new boxStats(){ name = "hpheAreaCng", area = bData.hpheAreaCng };
            blueAreaCng = new boxStats(){ name = "lpheAreaCng", area = bData.lpheAreaCng };
            redAreaCng = new boxStats(){ name = "hpleAreaCng", area = bData.hpleAreaCng };
            greenAreaCng = new boxStats() { name = "lpleAreaCng", area = bData.lpleAreaCng };


        }

        public void getAreaData(boxDataSource bData)
        {

            double goldHeight = bData.hpheArea / (400 * _scalingFactor);
            double blueHeight = bData.lpheArea / (600 * _scalingFactor);
            double maxHeight = (goldHeight > blueHeight) ? goldHeight : blueHeight;
            goldArea.top = maxHeight - goldHeight;
            goldArea.height = goldHeight;
            goldArea.width = 400.0;
            goldArea.left = 0;

            blueArea.top = maxHeight - blueHeight;
            blueArea.height = blueHeight;
            blueArea.width = 600.0;
            blueArea.left = 400.0;

            redArea.height = bData.hpleArea / (400 * _scalingFactor);
            redArea.top = maxHeight;
            redArea.left = 0.0;
            redArea.width = 400.0;
            
            greenArea.height=  ((bData.lpleArea / (600.00 * _scalingFactor)) > redArea.height) ? (bData.lpleArea / (600.00 * _scalingFactor)) : redArea.height;
            greenArea.width = bData.lpleArea / (greenArea.height * _scalingFactor);
            greenArea.top = maxHeight;
            greenArea.left = 400.0;

        }


        public void getUGAData(boxDataSource bData)
        {
            double goldScale = 0.3;
            double goldHeight = bData.hpheArea / (400 * _scalingFactor);
            double blueHeight = bData.lpheArea / (600 * _scalingFactor);
            double maxHeight = (goldHeight > blueHeight) ? goldHeight : blueHeight;
            goldUGA.top = maxHeight - (goldArea.height * goldScale);
            goldUGA.height = goldArea.height * goldScale;
            goldUGA.width = bData.hpheUGA / (goldArea.height * goldScale * _scalingFactor);
            goldUGA.left = 400-goldUGA.width;
            
            blueUGA.height = goldUGA.height;
            blueUGA.top = maxHeight - blueUGA.height;
            blueUGA.width = bData.lpheUGA / ( blueUGA.height * _scalingFactor);
            blueUGA.left = 400.0;

            
            greenUGA.width = (greenArea.height < 200) ?  greenArea.width * 0.95 : 300.0;
            greenUGA.height = bData.lpleUGA / (greenUGA.width * _scalingFactor);            
            greenUGA.top = maxHeight;
            greenUGA.left = 400.0;


            redUGA.width = (redArea.height < 100) ? redArea.width * .8 : 300;
            redUGA.height =  bData.hpleUGA / (redUGA.width * _scalingFactor);
            redUGA.top = maxHeight;
           
            redUGA.left = 400.0 - redUGA.width;
        }



        public void getUGACngData(boxDataSource bData)
        {
            double goldScale = 0.1;
            double goldHeight = bData.hpheArea / (400 * _scalingFactor);
            double blueHeight = bData.lpheArea / (600 * _scalingFactor);
            double maxHeight = (goldHeight > blueHeight) ? goldHeight : blueHeight;
            goldUGACng.top = maxHeight - (goldArea.height * goldScale);
            goldUGACng.height = goldArea.height * goldScale;
            goldUGACng.width = bData.hpheUGACng / (goldArea.height * goldScale * _scalingFactor);
            goldUGACng.left = 400 - goldUGACng.width;

            blueUGACng.height = goldUGACng.height * 0.25;
            blueUGACng.top = maxHeight - blueUGACng.height;
            blueUGACng.width = bData.lpheUGACng / (blueUGACng.height * _scalingFactor);
            blueUGACng.left = 400.0;


            greenUGACng.width = (greenArea.width < 20) ? greenArea.width : 20.0;
            greenUGACng.height = bData.lpleUGACng / (greenUGACng.width * _scalingFactor);

            greenUGACng.top = maxHeight;
            greenUGACng.left = 400.0;

            redUGACng.height = redArea.height * goldScale;
            redUGACng.width = bData.hpleUGACng / (redUGACng.height * _scalingFactor);

            redUGACng.top = maxHeight;
            redUGACng.left = 400.0 - redUGACng.width;
        }


        public void getAreaCngData(boxDataSource bData)
        {
            //double goldScale = 0.1;
            double goldHeight = bData.hpheArea / (400 * _scalingFactor);
            double blueHeight = bData.lpheArea / (600 * _scalingFactor);
            double maxHeight = (goldHeight > blueHeight) ? goldHeight : blueHeight;
            goldAreaCng.width = 5.0;
            goldAreaCng.height = bData.hpheAreaCng / (goldAreaCng.width * _scalingFactor);
            goldAreaCng.top = maxHeight - (goldUGA.height + goldAreaCng.height) ;    
            goldAreaCng.left = 400 - goldAreaCng.width;

            blueAreaCng.width = 5.0;
            blueAreaCng.height =  bData.lpheAreaCng / (blueAreaCng.width * _scalingFactor);
            blueAreaCng.top = maxHeight - (blueAreaCng.height + blueUGA.height);
     
            blueAreaCng.left = 400.0;


            greenAreaCng.width = 5.0;
            greenAreaCng.height = bData.lpleAreaCng / (greenAreaCng.width * _scalingFactor);
            greenAreaCng.top = maxHeight + greenUGA.height;
            greenAreaCng.left = 400.0;

            redAreaCng.width = 5.0;
            redAreaCng.height = bData.hpleAreaCng / (redAreaCng.width * _scalingFactor);
            redAreaCng.top = maxHeight + redUGA.height;
            redAreaCng.left = 400.0 - redAreaCng.width;
        }


    }
    
}

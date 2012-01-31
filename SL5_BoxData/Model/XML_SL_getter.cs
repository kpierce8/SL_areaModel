using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

//using System.Xml.Serialization;

namespace SL5_BoxData.Model
{
    class XMLgetter
    {
        public List<boxDataSource> theLandsXML { get; set; }
     
        public ObservableCollection<boxDataSource> observeableBoxes { get; set; }
     

        public void InitializeXMLData()
        {
            
        
            observeableBoxes = new ObservableCollection<boxDataSource>();
            observeableBoxes = getAnswers();
            foreach (var item in observeableBoxes)
            {
                Console.Write(item.hpheArea.ToString());
            }


        }


        //public List<boxDataSource> getAnswers(FileStream sourceFile)
        //{
        //    XmlSerializer xmlQuestions = new XmlSerializer(typeof(List<boxDataSource>));
        //    List<boxDataSource> currentQuestions = (List<boxDataSource>)xmlQuestions.Deserialize(sourceFile);

        //    //Console.Write(currentQuestions.Count.ToString());
        //    //Console.Write(currentQuestions[3].lineValue);

        //    return currentQuestions;

        //}

        public ObservableCollection<boxDataSource> getAnswers()
        {
            //XmlSerializer xmlQuestions = new XmlSerializer(typeof(List<boxDataSource>));


            XElement document = XElement.Load("boxDataR.xml");

            ObservableCollection<boxDataSource> bob = new ObservableCollection<boxDataSource>();

            foreach (XElement element in document.Elements("boxDataSource"))
            {
                boxDataSource tempAnno = new boxDataSource();
                tempAnno.row = (int)element.Element("row");
                tempAnno.hpheArea = (double)element.Element("hpheArea");
                tempAnno.hpleArea = (double)element.Element("hpleArea");
                tempAnno.lpheArea = (double)element.Element("lpheArea");
                tempAnno.lpleArea = (double)element.Element("lpleArea");
                tempAnno.hpheUGA = (double)element.Element("hpheUGA");
                tempAnno.hpleUGA = (double)element.Element("hpleUGA");
                tempAnno.lpheUGA = (double)element.Element("lpheUGA");
                tempAnno.lpleUGA = (double)element.Element("lpleUGA");

                tempAnno.hpheAreaCng = (double)element.Element("hpheAreaCng");
                tempAnno.hpleAreaCng = (double)element.Element("hpleAreaCng");
                tempAnno.lpheAreaCng = (double)element.Element("lpheAreaCng");
                tempAnno.lpleAreaCng = (double)element.Element("lpleAreaCng");
                tempAnno.hpheUGACng = (double)element.Element("hpheUGACng");
                tempAnno.hpleUGACng = (double)element.Element("hpleUGACng");
                tempAnno.lpheUGACng = (double)element.Element("lpheUGACng");
                tempAnno.lpleUGACng = (double)element.Element("lpleUGACng");
                bob.Add(tempAnno);
            }


            return bob;



        }
    }
}

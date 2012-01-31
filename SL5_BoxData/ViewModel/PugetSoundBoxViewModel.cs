using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Text;
using System.Windows;
using SL5_BoxData.Model;
using System.Diagnostics;
//using System.Windows.Data;


namespace SL5_BoxData.ViewModel
{
    public class PugetSoundBoxViewModel : Observable
    {
     //   public Thickness quadEIHPthickness { get; set; }
     //   public int width1 { get; set; }
        public ObservableCollection<boxDataSource> theBoxData { get; set; }
        

        public PugetSoundBoxViewModel()
        {
            XMLgetter getData = new XMLgetter();

            getData.InitializeXMLData();

            theBoxData = getData.observeableBoxes;

            //_sliderValue = new ObservabelDoubleValue(20.0);
            _sliderValue = 60.0;
            
            _currentBoxes = getCurrent(_sliderValue);
           // currentBoxes = new boxDataSource();
            _boxData = new getBoxData(currentBoxes);
            _boxData.getAreaData(currentBoxes);
            _boxData.getUGAData(currentBoxes);
            _boxData.getUGACngData(currentBoxes);
            _boxData.getAreaCngData(currentBoxes);
SliderValue = _sliderValue;
        }





        private boxDataSource _currentBoxes;
        public boxDataSource currentBoxes
        {
            get
            {
                return _currentBoxes;
            }
            set
            {
                _currentBoxes = value;
                //OnPropertyChanged("currentBoxes");
            }
        }
        
        private double _sliderValue;
        public double SliderValue
        {
            get
            {
                
                return _sliderValue;
            }
            set
            {
                
                _sliderValue = value;
                currentBoxes = getCurrent(value);
                getAreaData(currentBoxes, _boxData);
                _boxData.getAreaData(currentBoxes);
                _boxData.getUGAData(currentBoxes);
                _boxData.getUGACngData(currentBoxes);
                _boxData.getAreaCngData(currentBoxes);
                NotifyPropertyChanged("SliderValue");
                NotifyPropertyChanged("BoxData");
                NotifyPropertyChanged("currentBoxes");
            }
        }



        public void getAreaData(boxDataSource bData, getBoxData bd)
        {
            double _scalingFactor = 20.0;
            double goldHeight = bData.hpheArea / (400 * _scalingFactor);
            double blueHeight = bData.lpheArea / (600 * _scalingFactor);
            double maxHeight = (goldHeight > blueHeight) ? goldHeight : blueHeight;
            bd.goldArea.top = maxHeight - goldHeight;
            bd.goldArea.height = goldHeight;
            bd.goldArea.width = 400.0;
            bd.goldArea.left = 0;

            bd.blueArea.top = maxHeight - blueHeight;
            bd.blueArea.height = blueHeight;
            bd.blueArea.width = 600.0;
            bd.blueArea.left = 400.0;

            bd.redArea.height = bData.hpleArea / (400 * _scalingFactor);
            bd.redArea.top = maxHeight;
            bd.redArea.left = 0.0;
            bd.redArea.width = 400.0;

            bd.greenArea.height = ((bData.lpleArea / (600.00 * _scalingFactor)) > bd.redArea.height) ? (bData.lpleArea / (600.00 * _scalingFactor)) : bd.redArea.height;
            bd.greenArea.width = bData.lpleArea / (bd.greenArea.height * _scalingFactor);
            bd.greenArea.top = maxHeight;
            bd.greenArea.left = 400.0;

        }


        private getBoxData _boxData;
        public getBoxData BoxData
        {
            get { return _boxData; }
            set { _boxData = value; }
        }


        boxDataSource getCurrent(double sliderValue)
        {
          
                int theRow = (int) sliderValue;
             if (theRow >= 2)
             {
                 var theBox = theBoxData.Where(b => b.row == theRow).First();
                 return theBox;
             }
             else
             {
                 var theBox = theBoxData.Where(b => b.row == 2).First();
                 return theBox;
             }        
           
        }   
    }
}

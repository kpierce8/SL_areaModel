﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SL5_BoxData.Model
{
    public class ObservabelDoubleValue : Observable
    {
        public double observeableDouble { get; set; }

        public ObservabelDoubleValue(double value)
        {
            observeableDouble = value;
        }
    }
}

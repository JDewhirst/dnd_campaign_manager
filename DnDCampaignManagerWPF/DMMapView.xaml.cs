﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnDCampaignManagerWPF
{
    /// <summary>
    /// Interaction logic for DMMapView.xaml
    /// </summary>
    public partial class DMMapView : Window
    {
        public DMMapView()
        {
            InitializeComponent();
            int count = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button MyControl = new Button();
                    MyControl.Content = count.ToString();
                    MyControl.Name = "MapButton" + count.ToString();

                    Grid.SetColumn(MyControl, j);
                    Grid.SetRow(MyControl, i);
                    gridMap.SetValue(Grid.RowProperty, j);
                    gridMap.Children.Add(MyControl);
                    count++;

                }
                gridMain.SetValue(Grid.ColumnProperty, i);
            }
        }
    }
}

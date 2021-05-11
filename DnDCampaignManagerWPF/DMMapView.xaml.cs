using System;
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

            // Generate map buttons
            int count = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button MyControl = new Button();
                    MyControl.Content = count.ToString();
                    MyControl.Name = "MapButton" + count.ToString();
                    MyControl.Click += new RoutedEventHandler(MapButtonClick);

                    // Add image to button
                    Image img = new Image() { Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Forest.bmp")) };
                    img.Stretch = Stretch.Fill;
                    MyControl.Content = img;

                    Grid.SetColumn(MyControl, j);
                    Grid.SetRow(MyControl, i);
                    gridMap.SetValue(Grid.RowProperty, j);
                    gridMap.Children.Add(MyControl);
                    count++;

                }
                gridMain.SetValue(Grid.ColumnProperty, i);
            }
        }



        protected void MapButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ProvinceInformation.Text = button.Name;
        }
    }
}

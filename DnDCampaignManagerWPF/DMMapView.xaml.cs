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
            GenerateMapButtons();
        }

        private void GenerateMapButtons()
        {
            // Generate map buttons
            int count = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button MyControl = new Button();
                    
                    MyControl.Name = "MapButton" + count.ToString();
                    MyControl.Click += new RoutedEventHandler(MapButtonClick);

                    // Add image to button
                    Image img = new Image();
                    if (j < 3)
                    {
                         img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Forest.bmp"));
                    }
                    else
                    {
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Plain.bmp"));
                    }
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

        private void MapButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ProvinceNameBox.Text = button.Name;
            ProvinceDescriptionBox.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.";
            ProvinceHiddenFeatureBox.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed pulvinar proin gravida hendrerit lectus. Blandit massa enim nec dui nunc mattis enim ut tellus. Tristique senectus et netus et malesuada fames. Lacus viverra vitae congue eu consequat. Viverra vitae congue eu consequat. Enim lobortis scelerisque fermentum dui faucibus. Blandit libero volutpat sed cras ornare. Amet dictum sit amet justo donec enim diam vulputate. Fusce ut placerat orci nulla. Nunc lobortis mattis aliquam faucibus purus. Auctor urna nunc id cursus metus aliquam. Interdum posuere lorem ipsum dolor sit. Odio ut enim blandit volutpat maecenas volutpat.";
        }

        private void RollRandomEncounter_Button_Click(object sender, RoutedEventArgs e)
        {
            RandomEncounterResultBox.Text = "Not yet implemented";
        }

        private void EditProvinceInformation_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

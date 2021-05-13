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
using DnDCampaignManagerApp;

namespace DnDCampaignManagerWPF
{
    /// <summary>
    /// Interaction logic for DMMapView.xaml
    /// </summary>
    public partial class DMMapView : Window
    {
        ProvinceManager _provinceManager = new ProvinceManager();
        public DMMapView()
        {
            InitializeComponent();
            GenerateMapButtons();
        }

        private void GenerateMapButtons()
        {
            // Generate map buttons
            int provinceCount = _provinceManager.GetNumberOfProvinces();
            var provinceList = _provinceManager.GetAllProvincesQuery();
            int mapWidth = Convert.ToInt32( Math.Truncate( Math.Sqrt(provinceCount) ) );

            int count = 1;
            int i = 0;
            int j = 0;
            foreach (var province in provinceList)
            {
                Button MyControl = new Button();

                MyControl.Name = province.ProvinceName;
                MyControl.Click += new RoutedEventHandler(MapButtonClick);

                //Add image to button
                Image img = new Image();
                switch(province.TerrainId)
                {
                    case "Plain":
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Plain.bmp"));
                        break;
                    case "Forest":
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Forest.bmp"));
                        break;
                    case "Hill":
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Hill.bmp"));
                        break;
                    case "Mountain":
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Mountain.bmp"));
                        break;
                    case "Urban":
                        img.Source = new BitmapImage(new Uri(@"C:\Users\jackd\Documents\Sparta_Global\C#SDET\three_tier_project\dnd_campaign_manager\DnDCampaignManagerWPF\Images\Urban.bmp"));
                        break;
                }
                img.Stretch = Stretch.Fill;
                MyControl.Content = img;

                Grid.SetColumn(MyControl, j);
                Grid.SetRow(MyControl, i);
                gridMap.SetValue(Grid.RowProperty, j);
                gridMap.Children.Add(MyControl);
                count++;
                j++;
                if (j >= mapWidth)
                {
                    j = 0;
                    i++;
                }

            }

        }

        private void MapButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ProvinceNameBox.Text = button.Name;
            ProvinceDescriptionBox.Text = _provinceManager.GetProvinceObviousFeature(button.Name);
            ProvinceHiddenFeatureBox.Text = _provinceManager.GetProvinceHiddenFeature(button.Name);
            ProvinceTravelSpeedBox.Text = _provinceManager.GetProvinceTravelSpeed(button.Name);
        }

        private void RollRandomEncounter_Button_Click(object sender, RoutedEventArgs e)
        {
            RandomEncounterResultBox.Text = "Not yet implemented";
        }

        private void EditProvinceInformation_Button_Click(object sender, RoutedEventArgs e)
        {
            ProvinceDescriptionBox.IsEnabled = true;
            ProvinceHiddenFeatureBox.IsEnabled = true;
            EditProvinceInformation_Button.IsEnabled = false;
            SaveProvinceInformation_Button.IsEnabled = true;
            
        }

        private void SaveProvinceInformation_Button_Click(object sender, RoutedEventArgs e)
        {
            _provinceManager.UpdateObviousFeatureDescription(ProvinceNameBox.Text, ProvinceDescriptionBox.Text);
            _provinceManager.UpdateHiddenFeatureDescription(ProvinceNameBox.Text, ProvinceHiddenFeatureBox.Text);
            EditProvinceInformation_Button.IsEnabled = true;
            SaveProvinceInformation_Button.IsEnabled = false;
            ProvinceDescriptionBox.IsEnabled = false;
            ProvinceHiddenFeatureBox.IsEnabled = false;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DnDCampaignManagerApp;

namespace DnDCampaignManagerWPF
{
    /// <summary>
    /// Interaction logic for DMMapView.xaml
    /// </summary>
    public partial class DMMapView : Window
    {
        private ProvinceManager _provinceManager = new ProvinceManager();
        private RandomEncounterManager _randomEncounterManager = new RandomEncounterManager();
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
                MyControl.Background = Brushes.Wheat;

                //Add image to button
                Image img = new Image();
                switch(province.TerrainId)
                {
                    case "Plain":
                        img.Source = new BitmapImage(new Uri(@"Images\Plain.bmp", UriKind.Relative));
                        break;
                    case "Forest":
                        img.Source = new BitmapImage(new Uri(@"Images\Forest.bmp", UriKind.Relative));
                        break;
                    case "Hill":
                        img.Source = new BitmapImage(new Uri(@"Images\Hill.bmp", UriKind.Relative));
                        break;
                    case "Mountain":
                        img.Source = new BitmapImage(new Uri(@"Images\Mountain.bmp", UriKind.Relative));
                        break;
                    case "Urban":
                        img.Source = new BitmapImage(new Uri(@"Images\Urban.bmp", UriKind.Relative));
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
            ProvinceNameBox.Content = button.Name;
            ProvinceDescriptionBox.Text = _provinceManager.GetProvinceObviousFeature(button.Name);
            ProvinceHiddenFeatureBox.Text = _provinceManager.GetProvinceHiddenFeature(button.Name);
            ProvinceTravelSpeedBox.Content = _provinceManager.GetProvinceTravelSpeed(button.Name);
            ProvinceRandomEncounterTable_Box.Text = _provinceManager.GetProvinceRandomEncounterDetails(button.Name)[0].ToString();
            RandomEncounterResultBox.Text = "";
            
            //ProvincesDropDown.ItemsSource = _provinceManager.GetAllProvincesQuery();
        }

        private void RollRandomEncounter_Button_Click(object sender, RoutedEventArgs e)
        {
            var randomEncounterDetails = _provinceManager.GetProvinceRandomEncounterDetails(ProvinceNameBox.Content.ToString());
            RandomEncounterResultBox.Text = DiceRoller.RollEncounter(randomEncounterDetails);
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
            _provinceManager.UpdateObviousFeatureDescription(ProvinceNameBox.Content.ToString(), ProvinceDescriptionBox.Text);
            _provinceManager.UpdateHiddenFeatureDescription(ProvinceNameBox.Content.ToString(), ProvinceHiddenFeatureBox.Text);
            EditProvinceInformation_Button.IsEnabled = true;
            SaveProvinceInformation_Button.IsEnabled = false;
            ProvinceDescriptionBox.IsEnabled = false;
            ProvinceHiddenFeatureBox.IsEnabled = false;
        }

        private void EditRandomEncounters_Button_Click(object sender, RoutedEventArgs e)
        {
            EditRandomEncounters editRandomEncounters = new EditRandomEncounters();
            editRandomEncounters.Show();
        }

        private void SelectRandomEncounterTable_Button_Click(object sender, RoutedEventArgs e)
        {
            RandomEncountersList.ItemsSource = _randomEncounterManager.GetListOfRandomEncounterTables();
            SelectRandomEncounterTable_Popup.IsOpen = true;

        }

        private void SaveProvinceRandomEncounterTable_Click(object sender, RoutedEventArgs e)
        {
            
            _provinceManager.SetRandomEncounterTable(_provinceManager.SelectedProvince.ProvinceName, RandomEncountersList.SelectedItem.ToString());
            ProvinceRandomEncounterTable_Box.Text = _provinceManager.GetProvinceRandomEncounterDetails(ProvinceNameBox.Content.ToString())[0].ToString();
            SelectRandomEncounterTable_Popup.IsOpen = false;
        }
    }
}

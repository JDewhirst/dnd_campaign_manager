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
    /// Interaction logic for EditRandomEncounters.xaml
    /// </summary>
    public partial class EditRandomEncounters : Window
    {
        private RandomEncounterManager _randomEncounterManager = new RandomEncounterManager();
        public EditRandomEncounters()
        {
            InitializeComponent();
            GenerateListOfEncounters();
        }

        public void GenerateListOfEncounters()
        {
            EncounterTablesListBox.ItemsSource = _randomEncounterManager.GetListOfRandomEncounterTables();

        }

        public void SelectEncounterButton(object sender, RoutedEventArgs e)
        {
            // select encounter, click edit, put details in other column, display formatting requirements
            var selectedItem = EncounterTablesListBox.SelectedItems[0];
            _randomEncounterManager.SetSelectedEnounterTable(selectedItem);
            EncounterTableNameTextBox.Text = _randomEncounterManager.SelectedEncounterTable.RandEncounterTableId;
            EncounterTableDiceTextBox.Text = _randomEncounterManager.SelectedEncounterTable.Dice;
            EncounterTableTableTextBox.Text = _randomEncounterManager.SelectedEncounterTable.RandEncounter;
        }

        private void EditTableButton_Click(object sender, RoutedEventArgs e)
        {
            EncounterTableNameTextBox.IsEnabled = true;
            EncounterTableDiceTextBox.IsEnabled = true;
            EncounterTableTableTextBox.IsEnabled = true;
            SaveTableButton.IsEnabled = true;
            EditTableButton.IsEnabled = false;
        }

        private void SaveTableButton_Click(object sender, RoutedEventArgs e)
        {
            EncounterTableNameTextBox.IsEnabled = false;
            EncounterTableDiceTextBox.IsEnabled = false;
            EncounterTableTableTextBox.IsEnabled = false;
            SaveTableButton.IsEnabled = false;
            EditTableButton.IsEnabled = true;

            _randomEncounterManager.UpdateTable(_randomEncounterManager.SelectedEncounterTable.RandEncounterTableId, EncounterTableNameTextBox.Text, EncounterTableDiceTextBox.Text, EncounterTableTableTextBox.Text);
            GenerateListOfEncounters();
        }
    }
}

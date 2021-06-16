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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pra.DemoTypes.Core.Entities;
using Pra.DemoTypes.Core.Services;

namespace Pra.DemoTypes.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        AnimalService animalService;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            animalService = new AnimalService();
            PopulateFilter();
            PopulateAnimals();
        }
        private void ClearControls()
        {
            tblDetails.Text = "";
        }
        private void PopulateFilter()
        {
            // we vragen eerst alle types op die de service klasse ter beschikking stelt en kennen dit toe aan de ItemsSource eigenschap van de listbox
            cmbFilter.ItemsSource = animalService.GetAnimalTypes();
            // met onderstaande instructie zorgen we er voor dat enkel de naam van het type getoond wordt.  Laat zelf even deze instructie weg om het verschil te zien ...
            cmbFilter.DisplayMemberPath = "Name";
        }
        private void PopulateAnimals()
        {
            // cmbFilter is gevuld met objecten van het "type" Type  ... we moeten dus casten naar Type
            // dit mag NULL opleveren : onze methode GetAnimals kan immers overweg met een argument dat de waarde Null heeft ...
            Type typeFilter = (Type)cmbFilter.SelectedItem;
            lstAnimals.ItemsSource = null;
            lstAnimals.ItemsSource = animalService.GetAnimals(typeFilter);

        }
        private void lstAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
            if(lstAnimals.SelectedItem != null)
            {
                Animal animal = (Animal)lstAnimals.SelectedItem;
                tblDetails.Text = animal.ShowDetails();
            }
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAnimals();
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cmbFilter.SelectedIndex = -1;
            PopulateAnimals();
        }
    }
}

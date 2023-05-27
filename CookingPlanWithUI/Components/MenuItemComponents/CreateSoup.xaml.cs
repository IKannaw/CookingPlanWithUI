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

namespace CookingPlanWithUI.Components.MenuItemComponents
{
    /// <summary>
    /// Interaction logic for AddSoup.xaml
    /// </summary>
    public partial class AddSoup : Window
    {
        DataModel.CookingPlanEntities _db = new DataModel.CookingPlanEntities();
        DataGrid  soupDataGrid = new DataGrid();

        public AddSoup(DataGrid _soupDataGrid)
        {
            InitializeComponent();
            soupDataGrid = _soupDataGrid;
            LoadData();
            LoadCmbSoup();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            create();
        }

        private void LoadCmbSoup()
        {
            var soupCategory = _db.SoupCategories.ToList();
            cmbSoupCategory.ItemsSource = soupCategory;
        }

        private void create()
        {
            DataModel.SoupCategory selectedCategory = cmbSoupCategory.SelectedItem as DataModel.SoupCategory;
            // Retrieve the selected value from the ComboBox
            string selectedTaste = cmbTaste.SelectedItem?.ToString();

            // Remove "System.Windows.Controls.ComboBoxItem: " from the selected value
            selectedTaste = selectedTaste?.Replace("System.Windows.Controls.ComboBoxItem: ", "");

            DataModel.Soup newSoup = new DataModel.Soup()
            {
                // Do not assign a value to the 'soupCategory_id' property
                soupCategory_id = selectedCategory.id,
                name = txbName.Text,
                taste = selectedTaste,
                description = txbDescription.Text,
                created_at = DateTime.Now
            };
            _db.Soups.Add(newSoup);
            _db.SaveChanges();
            soupDataGrid.ItemsSource = _db.Soups.ToList();
        }



        private void update()
        {
            //try
            //{
            //    DataModel.SideDish selectedSideDish = soupDataGrid.SelectedItems as DataModel.SideDish;
            //    DataModel.SideDish updateSideDish = (from c in db.SideDishes where c.id == selectedSideDish.id select c).Single();
            //    updateSideDish.name = txbName.Text;
            //    updateSideDish.sideDishCategory_id = int.Parse(cmbSoupCategory.SelectedValuePath);
            //    updateSideDish.taste = cmbTaste.SelectedItem.ToString();
            //    updateSideDish.description = txbDescription.Text;
            //    db.SaveChanges();
            //    soupDataGrid.ItemsSource = db.SideDishes.ToList();
            //    this.Close();
            //}
            //catch
            //{

            //}
        }

        public void LoadData()
        {
            var loadData = _db.Soups.ToList();
            soupDataGrid.ItemsSource = loadData;
        }
    }
}

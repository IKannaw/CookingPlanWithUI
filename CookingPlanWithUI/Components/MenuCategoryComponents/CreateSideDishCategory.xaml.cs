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

namespace CookingPlanWithUI.Components.MenuCategoryComponents
{
    /// <summary>
    /// Interaction logic for AddSideDishCategory.xaml
    /// </summary>
    public partial class AddSideDishCategory : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid sideCtgDataGrid = new DataGrid();

        public AddSideDishCategory(DataGrid _sideCtgDataGri)
        {
            InitializeComponent();
            LoadData();
            sideCtgDataGrid = _sideCtgDataGri;   
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreate.Content == "Create")
                create();
            if (btnCreate.Content == "Update")
                update();
        }

        private void create()
        {
            try
            {
                DataModel.SideDishCategory newSideDishCategory = new DataModel.SideDishCategory()
                {
                    name = txbName.Text,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.SideDishCategories.Add(newSideDishCategory);
                db.SaveChanges();
                sideCtgDataGrid.ItemsSource = db.SideDishCategories.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update()
        {
            try
            {
                DataModel.SideDishCategory value = sideCtgDataGrid.SelectedItem as DataModel.SideDishCategory;
                DataModel.SideDishCategory updateSideDishCty = (from i in db.SideDishCategories where i.id == value.id select i).Single();
                updateSideDishCty.name = txbName.Text;
                updateSideDishCty.description = txbDescription.Text;
                db.SaveChanges();
                sideCtgDataGrid.ItemsSource = db.SideDishCategories.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData()
        {
            var loadData = db.SideDishCategories.ToList();
            sideCtgDataGrid.ItemsSource = loadData;
        }
    }
}

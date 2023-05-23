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
    /// Interaction logic for AddSoupCategory.xaml
    /// </summary>
    /// 

    public partial class AddSoupCategory : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid soupCtgDataGrid = new DataGrid();

        public AddSoupCategory(DataGrid _soupCtgDataGrid)
        {
            InitializeComponent();
            LoadData();
            soupCtgDataGrid = _soupCtgDataGrid;
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
                DataModel.SoupCategory newSoupCategory = new DataModel.SoupCategory()
                {
                    name = txbName.Text,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.SoupCategories.Add(newSoupCategory);
                db.SaveChanges();
                soupCtgDataGrid.ItemsSource = db.SoupCategories.ToList();
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
                DataModel.SoupCategory value = soupCtgDataGrid.SelectedItem as DataModel.SoupCategory;
                DataModel.SoupCategory updateSoupCategory = (from i in db.SoupCategories where i.id == value.id select i).Single();
                updateSoupCategory.name = txbName.Text;
                updateSoupCategory.description = txbDescription.Text;
                db.SaveChanges();
                soupCtgDataGrid.ItemsSource = db.SoupCategories.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadData()
        {
            var loadData = db.SoupCategories.ToList();
            soupCtgDataGrid.ItemsSource = loadData;
        }
    }
}

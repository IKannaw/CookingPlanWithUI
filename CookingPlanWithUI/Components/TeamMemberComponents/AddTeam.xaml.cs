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

namespace CookingPlanWithUI.Components.TeamMemberComponents
{
    /// <summary>
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();

        DataGrid teamDataGrid = new DataGrid();
        public AddTeam(DataGrid _teamDataGrid)
        {
            InitializeComponent();
            teamDataGrid = _teamDataGrid;
            LoadData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreate.Content == "Add")
                create();
            if (btnCreate.Content == "Update")
                update();
        }


        private void create()
        {
            try
            {
                DataModel.Team newTeam = new DataModel.Team()
                {
                    name = txbName.Text,
                    description = txbDescription.Text,
                    created_at = DateTime.Now
                };
                db.Teams.Add(newTeam);
                db.SaveChanges();
                teamDataGrid.ItemsSource = db.Teams.ToList();
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
                DataModel.Team selectedTeam= teamDataGrid.SelectedItem as DataModel.Team;
                DataModel.Team updateTeam = (from i in db.Teams where i.id == selectedTeam.id select i).Single();
                updateTeam.name = txbName.Text;
                updateTeam.description = txbDescription.Text;
                db.SaveChanges();
                teamDataGrid.ItemsSource = db.Teams.ToList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData()
        {
            var loadData = db.Teams.ToList();
            teamDataGrid.ItemsSource = loadData;
        }


    }
}

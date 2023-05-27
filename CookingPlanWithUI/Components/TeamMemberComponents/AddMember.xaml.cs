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
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        DataGrid teamMemberDataGrid = new DataGrid();

        public AddMember(DataGrid _teaamMemberDataGrid)
        {
            InitializeComponent();
            teamMemberDataGrid = _teaamMemberDataGrid;
            LoadData();
            loadCmbMember();
        }

        private void loadCmbMember()
        {
            var teamData = db.Teams.ToList();
            cmbSelectTeam.ItemsSource = teamData;
        }

        public void LoadData()
        {
            var loadData = (from tm in db.TeamMembers
                            join t in db.Teams on tm.team_id equals t.id
                            select new
                            {
                                tm.id,
                                TeamName = t.name,
                                tm.name,
                                tm.description,
                                tm.created_at
                            }).ToList();

            teamMemberDataGrid.ItemsSource = loadData;
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
                DataModel.Team team = cmbSelectTeam.SelectedItem as DataModel.Team;
                DataModel.TeamMember newteam = new DataModel.TeamMember()
                {
                      team_id =team.id,
                      name = txbName.Text,
                      description = txbDescription.Text,
                      created_at = DateTime.Now  
                };
                db.TeamMembers.Add(newteam);
                db.SaveChanges();
                var teamMembers = db.TeamMembers.ToList();
                teamMemberDataGrid.ItemsSource = teamMembers;
                LoadData();
                MessageBox.Show("Added a new member successfully","",MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update()
        {

        }
    }
}

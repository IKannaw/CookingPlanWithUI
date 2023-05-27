using Newtonsoft.Json;
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

namespace CookingPlanWithUI.UI.Team
{
    /// <summary>
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();
        public Member()
        {
            InitializeComponent();
            DisplayData();

        }

        public void DisplayData()
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

            memberDataGrid.ItemsSource = loadData;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Components.TeamMemberComponents.AddMember memberDialog = new Components.TeamMemberComponents.AddMember(memberDataGrid);
            memberDialog.lblMember.Content ="Add Member";
            memberDialog.btnCreate.Content = "Create";
            memberDialog.ShowDialog();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            var teamMember = memberDataGrid.SelectedItem as dynamic;
            string name = teamMember.name.ToString();        
            string description = teamMember.description?.ToString();
            int id = teamMember.id;
            Components.TeamMemberComponents.UpdateMember updateDialog = new Components.TeamMemberComponents.UpdateMember(memberDataGrid, id);
            updateDialog.txbName.Text = name;
            string selectedTeamName = teamMember.TeamName;
            updateDialog.cmbSelectTeam.SelectedItem = selectedTeamName;
            updateDialog.txbDescription.Text = description;
            updateDialog.lblMember.Content = "Update Team";
            updateDialog.btnCreate.Content = "Update";
            updateDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            updateDialog.ShowDialog();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainTeamxaml mainTeam = new MainTeamxaml();
            mainTeam.Visibility = Visibility.Visible;
        }
    }
}

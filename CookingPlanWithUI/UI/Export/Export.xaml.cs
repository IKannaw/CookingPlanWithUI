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

namespace CookingPlanWithUI.UI.Export
{
    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : UserControl
    {
        DataModel.CookingPlanEntities db = new DataModel.CookingPlanEntities();


        public Export()
        {
            InitializeComponent();
        }

        private void btnLoad(object sender, RoutedEventArgs e)
        {
           getData();   
        }

        public void getData()
        {
            int month = selectDate.SelectedDate.Value.Month;
            int day = selectDate.SelectedDate.Value.Day;
            int year = selectDate.SelectedDate.Value.Year;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            string[,] menu = new string[daysInMonth, 3];
            Random rnd = new Random();

            var soupNames = string.Join(", ", db.Soups
                 .Where(s => !db.SideDishes.Any(sd => sd.taste == s.taste) && !db.Curries.Any(c => c.taste == s.taste))
                 .Select(s => s.name));

            string sideDishNames = string.Join(", ", db.SideDishes
                .Where(sd => !db.Soups.Any(s => s.taste == sd.taste) && !db.Curries.Any(c => c.taste == sd.taste))
                .Select(sd => sd.name));

            string curryNames = string.Join(", ", db.Curries
                .Where(c => !db.Soups.Any(s => s.taste == c.taste) && !db.SideDishes.Any(sd => sd.taste == c.taste))
                .Select(c => c.name));

            string[] soupNamesArray = soupNames.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] sideDishNamesArray = sideDishNames.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] curryNamesArray = curryNames.Split(new string[] { ", " }, StringSplitOptions.None);
            var curry = db.Curries.Select(c => c.name).ToArray();
            var sideDish = db.SideDishes.Select(s => s.name).ToArray();
            var team = db.Teams.Select(t => t.name).ToArray();

            // Populate the menu array
            for (int i = 0; i < daysInMonth; i++)
            {
                int curryIndex = rnd.Next(curry.Length);
                int soupNamesIndex = rnd.Next(soupNamesArray.Length);
                int sideDishIndex = rnd.Next(sideDish.Length);
                menu[i, 0] = curry[curryIndex];
                menu[i, 1] = soupNamesArray[soupNamesIndex];
                menu[i, 2] = sideDish[sideDishIndex];
            }

            List<MenuItem> menuItems = new List<MenuItem>();
    
            for (int i =day ; i < daysInMonth; i++)
            {
                int currentTeamIndex = 0;
                menuItems.Add(new MenuItem
                {
                    Team = team[currentTeamIndex],
                    Day = i,
                    Curry = menu[i, 0],
                    Soup = menu[i, 1],
                    SideDish = menu[i, 2]
                });    
            }

            listMenu.ItemsSource = menuItems;
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Visible;
        }
    }
}

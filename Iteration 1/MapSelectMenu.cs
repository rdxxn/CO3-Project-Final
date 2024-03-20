using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class MapSelectMenu : Form
    {
        //defualts all medals to false
        bool[] Map1 = new bool[3] { false, false, false };
        bool[] Map2 = new bool[3] { false, false, false };
        bool[] Map3 = new bool[3] { false, false, false };
        public static SelectedMap map;
        public enum SelectedMap { Map1, Map2, Map3 }
        MainMenu mainMenu = new MainMenu();
        DifficultySelectMenu difficultySelectMenu = new DifficultySelectMenu();
        public MapSelectMenu()
        {
            InitializeComponent();
        }

        //Opens destination form and hides the mapSelectMenu form, preserving size and other properties
        void GoTo(Form Destination)
        {
            Destination.Show();
            Destination.Size = new Size(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
            if (this.WindowState == FormWindowState.Maximized) { Destination.WindowState = FormWindowState.Maximized; }
            Destination.DesktopLocation = new Point(Convert.ToInt32(this.DesktopLocation.X), Convert.ToInt32(this.DesktopLocation.Y));
            this.Hide();
        }

        private void MapSelectMenu_Load(object sender, EventArgs e)
        {
            //Makes correct medals visible
            if (Map1[0] == false) { Map1BronzeContainer.Visible = false; }
            if (Map1[1] == false) { Map1SilverContainer.Visible = false; }
            if (Map1[2] == false) { Map1GoldContainer.Visible = false; }
            if (Map2[0] == false) { Map2BronzeContainer.Visible = false; }
            if (Map2[1] == false) { Map2SilverContainer.Visible = false; }
            if (Map2[2] == false) { Map2GoldContainer.Visible = false; }
            if (Map3[0] == false) { Map3BronzeContainer.Visible = false; }
            if (Map3[1] == false) { Map3SilverContainer.Visible = false; }
            if (Map3[2] == false) { Map3GoldContainer.Visible = false; }
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Exits the program fully when pressing x button
        }

        private void btnBack_Click(object sender, EventArgs e) //Opens MainMenu Form and Hides the previous form
        {
            GoTo(mainMenu);
        }

        private void btnMap1_Click(object sender, EventArgs e)
        {
            map = SelectedMap.Map1;
            GoTo(difficultySelectMenu);
        }

        private void btnMap2_Click(object sender, EventArgs e)
        {
            map = SelectedMap.Map2;
            GoTo(difficultySelectMenu);
        }

        private void btnMap3_Click(object sender, EventArgs e)
        {
            map = SelectedMap.Map3;
            GoTo(difficultySelectMenu);
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Opens destination form and hides the mainMenu form, preserving size and other properties
        private void GoTo(Form Destination)
        {
            Destination.Show(); //Opens Destination form
            Destination.Size = new Size(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
            if (this.WindowState == FormWindowState.Maximized) { Destination.WindowState = FormWindowState.Maximized; }
            Destination.DesktopLocation = new Point(Convert.ToInt32(this.DesktopLocation.X), Convert.ToInt32(this.DesktopLocation.Y));
            this.Hide();
        }

        private void PlayClick(object sender, EventArgs e)
        {
            MapSelectMenu MapSelectMenuForm = new MapSelectMenu();
            GoTo(MapSelectMenuForm);
        }

        private void QuitClick(object sender, EventArgs e)
        {
            Application.Exit(); //Exits the program
        }

        private void LeaderBoardClick(object sender, EventArgs e)
        {
            LeaderBoard LeaderBoardForm = new LeaderBoard();
            GoTo(LeaderBoardForm);
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Exits the program fully when pressing x button
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HowToPlay help = new HowToPlay();
            GoTo(help);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Setting settings = new Setting();
            GoTo(settings);
        }
    }
}
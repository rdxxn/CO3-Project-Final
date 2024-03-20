using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class DifficultySelectMenu : Form
    {
        public static SelectedDifficulty difficulty = SelectedDifficulty.Easy; //Defaults the selected value to easy
        private GameBoard gameBoard = new GameBoard();

        public enum SelectedDifficulty
        {
            Easy,
            Medium,
            Hard
        }

        public DifficultySelectMenu()
        {
            InitializeComponent();
        }

        //Opens destination form and hides the difficultySelectMenu form, preserving desktop location
        private void GoTo(Form Destination)
        {
            Destination.Show(); //Opens Destination form
            Destination.DesktopLocation = new Point(Convert.ToInt32(this.DesktopLocation.X), Convert.ToInt32(this.DesktopLocation.Y));
            this.Hide();
        }

        private void DifficultySelectMenu_Load(object sender, EventArgs e)
        {
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Exits the program fully when pressing x button
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MapSelectMenu mapSelectMenu = new MapSelectMenu();
            GoTo(mapSelectMenu);
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            difficulty = SelectedDifficulty.Easy;
            GoTo(gameBoard);
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            difficulty = SelectedDifficulty.Medium;
            GoTo(gameBoard);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            difficulty = SelectedDifficulty.Hard;
            GoTo(gameBoard);
        }
    }
}
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class LeaderBoard : Form
    {
        private string[] map1 = File.ReadAllLines(@"../../LeaderBoard/Map1.txt");
        private string[] map2 = File.ReadAllLines(@"../../LeaderBoard/Map2.txt");
        private string[] map3 = File.ReadAllLines(@"../../LeaderBoard/Map3.txt");
        private SelectedDifficulty difficulty;
        private Font font = new Font("Segoe UI", 35);
        private Size size = new Size(393, 55);
        private DockStyle dock = DockStyle.Top;
        private Color forecolor = Color.White;
        private LeaderBoardMap1 leaderBoardMap1 = new LeaderBoardMap1(@"../../LeaderBoard/Map1.txt");
        private LeaderBoardMap2 leaderBoardMap2 = new LeaderBoardMap2(@"../../LeaderBoard/Map2.txt");
        private LeaderBoardMap3 leaderBoardMap3 = new LeaderBoardMap3(@"../../LeaderBoard/Map3.txt");

        private enum SelectedDifficulty
        {
            Easy,
            Medium,
            Hard
        }

        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            btnEasy_Click(sender, e); //defaults selected difficulty to Easy and renders correct leaderboard values
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Exits the program fully when pressing x button
        }

        //goes back to the main menu, preserving size and properties of the leaderboard form
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            mainMenu.Size = new Size(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
            if (this.WindowState == FormWindowState.Maximized) { mainMenu.WindowState = FormWindowState.Maximized; }
            mainMenu.DesktopLocation = new Point(Convert.ToInt32(this.DesktopLocation.X), Convert.ToInt32(this.DesktopLocation.Y));
            this.Hide();
        }

        private void changeDifficulty(SelectedDifficulty difficulty, string[] map1, string[] map2, string[] map3)
        {
            //highlights the selected difficultys button
            if (difficulty == SelectedDifficulty.Easy)
            {
                btnEasy.BackColor = Color.FromArgb(55, 60, 65);
                btnMedium.BackColor = Color.FromArgb(35, 40, 45);
                btnHard.BackColor = Color.FromArgb(35, 40, 45);
            }
            if (difficulty == SelectedDifficulty.Medium)
            {
                btnMedium.BackColor = Color.FromArgb(55, 60, 65);
                btnEasy.BackColor = Color.FromArgb(35, 40, 45);
                btnHard.BackColor = Color.FromArgb(35, 40, 45);
            }
            if (difficulty == SelectedDifficulty.Hard)
            {
                btnHard.BackColor = Color.FromArgb(55, 60, 65);
                btnMedium.BackColor = Color.FromArgb(35, 40, 45);
                btnEasy.BackColor = Color.FromArgb(35, 40, 45);
            }

            //clears previous leaderboard values
            Map1Container.Controls.Clear();
            Map2Container.Controls.Clear();
            Map3Container.Controls.Clear();

            //displays the correct leaderboard values
            foreach (string text in map1)
            {
                Map1Container.Controls.Add(new Label { Text = text, Dock = dock, MinimumSize = size, MaximumSize = size, Font = font, ForeColor = forecolor });
            }
            foreach (string text in map2)
            {
                Map2Container.Controls.Add(new Label { Text = text, Dock = dock, MinimumSize = size, MaximumSize = size, Font = font, ForeColor = forecolor });
            }
            foreach (string text in map3)
            {
                Map3Container.Controls.Add(new Label { Text = text, Dock = dock, MinimumSize = size, MaximumSize = size, Font = font, ForeColor = forecolor });
            }
        }

        //displays the correct leaderboard values for the easy difficulty
        private void btnEasy_Click(object sender, EventArgs e)
        {
            string[] map1Easy = map1[0].Split(' ');
            string[] map2Easy = map2[0].Split(' ');
            string[] map3Easy = map3[0].Split(' ');
            difficulty = SelectedDifficulty.Easy;
            changeDifficulty(difficulty, map1Easy, map2Easy, map3Easy);
        }

        //displays the correct leaderboard values for the medium difficulty
        private void btnMedium_Click(object sender, EventArgs e)
        {
            string[] map1Medi = map1[1].Split(' ');
            string[] map2Medi = map2[1].Split(' ');
            string[] map3Medi = map3[1].Split(' ');
            difficulty = SelectedDifficulty.Medium;
            changeDifficulty(difficulty, map1Medi, map2Medi, map3Medi);
        }

        //displays the correct leaderboard values for the hard difficulty
        private void btnHard_Click(object sender, EventArgs e)
        {
            string[] map1Hard = map1[2].Split(' ');
            string[] map2Hard = map2[2].Split(' ');
            string[] map3Hard = map3[2].Split(' ');
            difficulty = SelectedDifficulty.Hard;
            changeDifficulty(difficulty, map1Hard, map2Hard, map3Hard);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class MenuPopup : Form
    {
        private MainMenu mainMenu = (MainMenu)Application.OpenForms["MainMenu"];
        private GameBoard gameBoard = (GameBoard)Application.OpenForms["GameBoard"];
        public bool gameEnded = false;
        private List<Enemy> enemiesCopy;

        public MenuPopup()
        {
            InitializeComponent();
        }

        private void MenuPopup_Load(object sender, EventArgs e)
        {
            //Check if eligible for the leaderboard
            if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map1)
            {
                if (gameBoard.game != null && gameBoard.game.currentWave > gameBoard.LeaderBoard1.getLowest(DifficultySelectMenu.difficulty))
                {
                    ScoreLabel.Text = "Score: " + gameBoard.game.currentWave;
                    ScoreLabel.Visible = true;
                    LeaderBoardLabel.Visible = true;
                    UsernameTextBox.Visible = true;
                    SubmitButton.Visible = true;
                }
            }
            else if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map2)
            {
                if (gameBoard.game.currentWave > gameBoard.LeaderBoard2.getLowest(DifficultySelectMenu.difficulty) && gameBoard.game != null)
                {
                    ScoreLabel.Text = "Score: " + gameBoard.game.currentWave;
                    ScoreLabel.Visible = true;
                    LeaderBoardLabel.Visible = true;
                    UsernameTextBox.Visible = true;
                    SubmitButton.Visible = true;
                }
            }
            else if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map3)
            {
                if (gameBoard.game.currentWave > gameBoard.LeaderBoard3.getLowest(DifficultySelectMenu.difficulty) && gameBoard.game != null)
                {
                    ScoreLabel.Text = "Score: " + gameBoard.game.currentWave;
                    ScoreLabel.Visible = true;
                    LeaderBoardLabel.Visible = true;
                    UsernameTextBox.Visible = true;
                    SubmitButton.Visible = true;
                }
            }
            //display Win Lose Screen correctly
            if (gameBoard.game != null) { enemiesCopy = new List<Enemy>(gameBoard.game.enemies); }
            if (gameEnded && gameBoard.game.WinState == true)
            {
                WinLoseBox.Image = Properties.Resources.Win; btnReturn.Visible = false;
            }
            else if (gameEnded)
            {
                WinLoseBox.Image = Properties.Resources.Lose; btnReturn.Visible = false;
            }
            else { WinLoseBox.Visible = false; }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Clears all enemies and towers from the gameboard to avoid weird bugs
            if (gameBoard.PlacedTowers != null && enemiesCopy != null)
            {
                foreach (Enemy enemy in enemiesCopy)
                {
                    enemy.Dispose();
                }
                foreach (Towers tower in gameBoard.PlacedTowers)
                {
                    tower.Dispose();
                }
            }
            mainMenu.Show();
            mainMenu.Size = new Size(Convert.ToInt32(gameBoard.Width), Convert.ToInt32(gameBoard.Height));
            if (gameBoard.WindowState == FormWindowState.Maximized) { mainMenu.WindowState = FormWindowState.Maximized; }
            mainMenu.DesktopLocation = new Point(Convert.ToInt32(gameBoard.DesktopLocation.X), Convert.ToInt32(gameBoard.DesktopLocation.Y));
            this.Close();
            gameBoard.Dispose();
            gameBoard.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map1)
            {
                gameBoard.LeaderBoard1.AddToLeaderBoard(UsernameTextBox.Text.Replace(" ", ""), gameBoard.game.currentWave, DifficultySelectMenu.difficulty);
            }
            else if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map2)
            {
                gameBoard.LeaderBoard2.AddToLeaderBoard(UsernameTextBox.Text.Replace(" ", ""), gameBoard.game.currentWave, DifficultySelectMenu.difficulty);
            }
            else if (MapSelectMenu.map == MapSelectMenu.SelectedMap.Map3)
            {
                gameBoard.LeaderBoard3.AddToLeaderBoard(UsernameTextBox.Text.Replace(" ", ""), gameBoard.game.currentWave, DifficultySelectMenu.difficulty);
            }
            btnBack_Click(this, e);
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
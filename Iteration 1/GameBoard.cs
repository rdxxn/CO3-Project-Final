using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class GameBoard : Form
    {
        public string WaveText
        {
            set { lblWave.Text = value; }
        }

        public string HealthText
        {
            set { HealthLabel.Text = value; }
        }

        public string MoneyText
        {
            set { MoneyLabel.Text = value; }
        }

        private enum Tower
        { None, Red, Blue, Green, Gray };

        private Tower SelectedTower = Tower.None;
        private Color pathColor = ColorTranslator.FromHtml("0xBFAD75");
        private Color startColor = ColorTranslator.FromHtml("0x9768D9");
        private Color exitColor = ColorTranslator.FromHtml("0xFFE019");
        private Color grassColor = ColorTranslator.FromHtml("0x40D61A");
        private bool Started = false;
        private Timer EnemyTimer;
        public GameLogic game;
        public List<Towers> PlacedTowers;
        public int moneyToSpend { get; set; } = 200; //StartingMoney
        private Towers tower;
        public LeaderBoardMap1 LeaderBoard1 { get; set; }
        public LeaderBoardMap2 LeaderBoard2 { get; set; }
        public LeaderBoardMap3 LeaderBoard3 { get; set; }



        public GameBoard()
        {
            PlacedTowers = new List<Towers>();
            InitializeComponent();
            EnemyTimer = new Timer();
            EnemyTimer.Interval = 75;
            EnemyTimer.Start();
        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            List<Point> path = FindPath(BoardTbl);
            game = new GameLogic(DifficultySelectMenu.difficulty, path, EnemyTimer, BoardTbl, this);
            game.SpendMoney(200 - moneyToSpend); //ensures that the money spent before starting the game is removed
            game.WaveManager(); //starts first wave
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            bool debugMode = Setting.DebugMode;
            //Toggles visibilty for debug buttons
            if(debugMode == false)
            {
                DebugTestWinScreen.Visible = false;
                DebugDamageAllEnemies.Visible = false;
                DebugAddHealth.Visible = false;
                DebugAddMoney.Visible = false;
            }

            MapSelectMenu.SelectedMap map = MapSelectMenu.map;
            //Creates leaderboard classes
            if(map == MapSelectMenu.SelectedMap.Map1) { LeaderBoard1 = new LeaderBoardMap1(@"../../LeaderBoard/Map1.txt"); }
            else if (map == MapSelectMenu.SelectedMap.Map2) { LeaderBoard2 = new LeaderBoardMap2(@"../../LeaderBoard/Map2.txt");  }
            else { LeaderBoard3 = new LeaderBoardMap3(@"../../LeaderBoard/Map3.txt"); }

            //Loads map
            DifficultySelectMenu.SelectedDifficulty difficulty = DifficultySelectMenu.difficulty;
            TableLayoutControlCollection[] controls = BoardTbl.Controls.OfType<TableLayoutControlCollection>().ToArray();
            String MapToLoad;
            if (map == MapSelectMenu.SelectedMap.Map1) { MapToLoad = File.ReadAllText(@"../../Maps/Map1.txt"); }
            else if (map == MapSelectMenu.SelectedMap.Map2) { MapToLoad = File.ReadAllText(@"../../Maps/Map2.txt"); }
            else { MapToLoad = File.ReadAllText(@"../../Maps/Map3.txt"); }
            int i = 0, j = 0;
            string[,] SelectedMapArr = new string[8, 15];
            foreach (var row in MapToLoad.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    SelectedMapArr[i, j] = col.Trim();
                    j++;
                }
                i++;
            }
            foreach (string s in SelectedMapArr)
            {
                Panel panel = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0) };

                if (s == "g")
                {
                    panel.BackColor = grassColor;
                }
                else if (s == "p")
                {
                    panel.BackColor = pathColor;
                }
                else if (s == "s")
                {
                    panel.BackColor = startColor;
                }
                else if (s == "x")
                {
                    panel.BackColor = exitColor;
                }

                //add the click event handler to each panel
                panel.Click += Panel_Click;

                //add the panel to the BoardTbl
                BoardTbl.Controls.Add(panel);
            }
        }

        //Changes selectedTower to correct value and highlights the button whilst setting the other tower buttons to default colors
        private void RedTowerButton_Click(object sender, EventArgs e)
        {
            RedTowerButton.BackColor = Color.FromArgb(65, 70, 75);
            SelectedTower = Tower.Red;
            BlueTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GreenTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GrayTowerButton.BackColor = Color.FromArgb(45, 50, 55);
        }

        private void BlueTowerButton_Click(object sender, EventArgs e)
        {
            BlueTowerButton.BackColor = Color.FromArgb(65, 70, 75);
            SelectedTower = Tower.Blue;
            RedTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GreenTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GrayTowerButton.BackColor = Color.FromArgb(45, 50, 55);
        }

        private void GreenTowerButton_Click(object sender, EventArgs e)
        {
            GreenTowerButton.BackColor = Color.FromArgb(65, 70, 75);
            SelectedTower = Tower.Green;
            BlueTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            RedTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GrayTowerButton.BackColor = Color.FromArgb(45, 50, 55);
        }

        private void GrayTowerButton_Click(object sender, EventArgs e)
        {
            GrayTowerButton.BackColor = Color.FromArgb(65, 70, 75);
            SelectedTower = Tower.Gray;
            BlueTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            GreenTowerButton.BackColor = Color.FromArgb(45, 50, 55);
            RedTowerButton.BackColor = Color.FromArgb(45, 50, 55);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;

            if (clickedPanel.BackColor == grassColor && SelectedTower != Tower.None && moneyToSpend >= 0 && containsATower(clickedPanel) == false)
            {
                //when you click on a grass panel
                if (SelectedTower == Tower.Red && moneyToSpend >= 100)
                {
                    //places a red tower and removes money
                    if(game == null)
                    {
                        moneyToSpend -= 100;
                        MoneyText = $"$:{moneyToSpend:0}";
                    }
                    else
                    {
                        game.currentMoney -= 100;
                        MoneyText = $"$:{game.currentMoney:0}";
                    }
                    //Creates new tower within the center
                    RedTower redTower = new RedTower(game, this, GetCenterPosition(clickedPanel), BoardTbl);
                    SelectedTower = Tower.None;
                    RedTowerButton.BackColor = Color.FromArgb(45, 50, 55);
                    Console.WriteLine("Red Tower Placed");
                }

                else if (SelectedTower == Tower.Blue && moneyToSpend >= 100)
                {
                    //places a blue tower and removes money
                    if (game == null)
                    {
                        moneyToSpend -= 100;
                        MoneyText = $"$:{moneyToSpend:0}";
                    }
                    else
                    {
                        game.currentMoney -= 100;
                        MoneyText = $"$:{game.currentMoney:0}";
                    }
                    BlueTower blueTower = new BlueTower(game, this, GetCenterPosition(clickedPanel), BoardTbl);
                    PlacedTowers.Add(blueTower);
                    SelectedTower = Tower.None;
                    BlueTowerButton.BackColor = Color.FromArgb(45, 50, 55);
                    Console.WriteLine("Blue Tower Placed");
                }

                else if (SelectedTower == Tower.Green && moneyToSpend >= 100)
                {
                    //places a green tower and removes money
                    if (game == null)
                    {
                        moneyToSpend -= 100;
                        MoneyText = $"$:{moneyToSpend:0}";
                    }
                    else
                    {
                        game.currentMoney -= 100;
                        MoneyText = $"$:{game.currentMoney:0}";
                    }
                    GreenTower greenTower = new GreenTower(game, this, GetCenterPosition(clickedPanel), BoardTbl);
                    PlacedTowers.Add(greenTower);
                    SelectedTower = Tower.None;
                    GreenTowerButton.BackColor = Color.FromArgb(45, 50, 55);
                    Console.WriteLine("Green Tower Placed");
                }

                else if (SelectedTower == Tower.Gray && moneyToSpend >= 100)
                {
                    //places a gray tower and removes money
                    if (game == null)
                    {
                        moneyToSpend -= 100;
                        MoneyText = $"$:{moneyToSpend:0}";
                    }
                    else
                    {
                        game.currentMoney -= 100;
                        MoneyText = $"$:{game.currentMoney:0}";
                    }
                    GrayTower grayTower = new GrayTower(game, this, GetCenterPosition(clickedPanel), BoardTbl);
                    PlacedTowers.Add(grayTower);
                    SelectedTower = Tower.None;
                    GrayTowerButton.BackColor = Color.FromArgb(45, 50, 55);
                    Console.WriteLine("Gray Tower Placed");
                }
            }
        }

        //checks if panel contains a tower
        private bool containsATower(Control panel)
        {
            Console.WriteLine("Checking if panel contains a tower");
            if (PlacedTowers != null)
            {
                foreach (Towers tower in PlacedTowers)
                {
                    if (GetCenterPosition(panel) == tower.Position)
                    {
                        Console.WriteLine("Panel contains a tower");
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public struct Position
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }

        public void displayTowerInfo(Towers selectedTower)
        {
            //Commented out because dispose() for towers doesnt seem to work
            //sellLabel.Visible = true;
            //SellButton.Visible = true;

            //Ensures that all relevant Controls are visible and display accurate information
            Console.WriteLine("Displaying Tower Info");
            upgradeButton.Visible = true;
            upgradeLabel.Visible = true;
            DamageLabel.Visible = true;
            RangeLabel.Visible = true;
            FireRateLabel.Visible = true;

            tower = selectedTower;
            DamageLabel.Text = $"Damage: {tower.Damage:0.0}";
            RangeLabel.Text = $"Range: {tower.Range:0.0}";
            FireRateLabel.Text = $"Fire Rate: {Math.Floor(tower.FireRate):0}";
            CurrentTowerPictureBox.BackgroundImage = tower.sprite;
            upgradeButton.Text = $"Cost: ${tower.upgradeCost:0}";
            SellButton.Text = $"Sell for: ${tower.SpentMoney * 0.8:0}";
        }
        public void unDisplayTowerInfo()
        {
            //Commented out because dispose() for towers doesnt seem to work
            //sellLabel.Visible = false;
            //SellButton.Visible = false;

            CurrentTowerPictureBox.BackgroundImage = null;
            upgradeButton.Visible = false;
            upgradeLabel.Visible = false;
            DamageLabel.Visible = false;
            RangeLabel.Visible = false;
            FireRateLabel.Visible = false;
        }
        private void upgradeButton_Click(object sender, EventArgs e)
        {
            tower.Upgrade();
            displayTowerInfo(tower);
        }
        private void SellButton_Click(object sender, EventArgs e)
        {
            tower.Sell();
        }

        public static Point GetCenterPosition(Control control)
        {
            // Calculate the center point of the control
            int X = control.Left + control.Width / 2 - control.Width / 2;
            int Y = control.Top + control.Height / 2 - control.Height / 2;
            return new Point(X, Y);
        }

        //Searches through the GameBoard and creates a list of points which are the center of the path tiles for the enemy to travel through
        private static List<Point> FindPath(TableLayoutPanel panel)
        {
            Color pathColor = ColorTranslator.FromHtml("0xBFAD75");
            Color startColor = ColorTranslator.FromHtml("0x9768D9");
            Color exitColor = ColorTranslator.FromHtml("0xFFE019");
            Color grassColor = ColorTranslator.FromHtml("0x40D61A");

            bool Pathed = false;
            Position CurrentPos = new Position();
            List<Point> path = new List<Point>();
            for (int row = 0; row < panel.RowCount; row++)
            {
                for (int col = 0; col < panel.ColumnCount; col++)
                {
                    if (panel.GetControlFromPosition(col, row).BackColor == startColor)
                    {
                        CurrentPos.Row = row;
                        CurrentPos.Column = col;
                        Point startPos = GetCenterPosition(panel.GetControlFromPosition(col, row));
                        //path.Add(startPos); Not needed
                        break;
                    }
                }
            }
            Position PreviousPos = new Position();
            Console.WriteLine($"X: {CurrentPos.Row}, Y: {CurrentPos.Column} START");
            Control currentControl;

            //Actually finds the correct path tiles to grab the correct path
            while (!Pathed)
            {
                //Check Vertical Neighbors
                if (CurrentPos.Row >= 0 || CurrentPos.Row <= 7)
                {
                    //Check Top Neighbor
                    if (CurrentPos.Row - 1 != -1 && PreviousPos.Row != CurrentPos.Row - 1 && panel.GetControlFromPosition(CurrentPos.Column, CurrentPos.Row - 1).BackColor != grassColor)
                    {
                        currentControl = panel.GetControlFromPosition(CurrentPos.Column, CurrentPos.Row - 1);
                        if (currentControl.BackColor == pathColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Row -= 1;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"up C:{CurrentPos.Column} R:{CurrentPos.Row}");
                        }
                        else if (currentControl.BackColor == exitColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Row -= 1;
                            Pathed = true;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"up C:{CurrentPos.Column} R:{CurrentPos.Row} FOUND");
                        }
                    }

                    //check Bottom Neighbor
                    else if (CurrentPos.Row + 1 != 8 && PreviousPos.Row != CurrentPos.Row + 1 && panel.GetControlFromPosition(CurrentPos.Column, CurrentPos.Row + 1).BackColor != grassColor)
                    {
                        currentControl = panel.GetControlFromPosition(CurrentPos.Column, CurrentPos.Row + 1);
                        if (currentControl.BackColor == pathColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Row += 1;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"down C:{CurrentPos.Column} R:{CurrentPos.Row}");
                        }
                        else if (currentControl.BackColor == exitColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Row += 1;
                            Pathed = true;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"down C:{CurrentPos.Column} R:{CurrentPos.Row} FOUND");
                        }
                    }
                }

                //Check Horizontal Neightbors
                if (CurrentPos.Column >= 0 || CurrentPos.Column <= 14)
                {
                    //Check Right Neighbor
                    if (CurrentPos.Column + 1 != 15 && PreviousPos.Column != CurrentPos.Column + 1 && panel.GetControlFromPosition(CurrentPos.Column + 1, CurrentPos.Row).BackColor != grassColor)
                    {
                        currentControl = panel.GetControlFromPosition(CurrentPos.Column + 1, CurrentPos.Row);
                        if (currentControl.BackColor == pathColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Column += 1;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"Right C:{CurrentPos.Column} R:{CurrentPos.Row}");
                        }
                        else if (currentControl.BackColor == exitColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Column += 1;
                            Pathed = true;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"Right C:{CurrentPos.Column} R:{CurrentPos.Row} FOUND");
                        }
                    }

                    //Check Left Neighbor
                    else if (CurrentPos.Column - 1 != 0 && PreviousPos.Column != CurrentPos.Column - 1 && panel.GetControlFromPosition(CurrentPos.Column - 1, CurrentPos.Row).BackColor != grassColor)
                    {
                        currentControl = panel.GetControlFromPosition(CurrentPos.Column - 1, CurrentPos.Row);
                        if (currentControl.BackColor == pathColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Column -= 1;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"Left C:{CurrentPos.Column} R:{CurrentPos.Row}");
                        }
                        else if (currentControl.BackColor == exitColor)
                        {
                            PreviousPos = CurrentPos;
                            CurrentPos.Column -= 1;
                            Pathed = true;
                            path.Add(GetCenterPosition(currentControl));

                            //debug stuff
                            Console.WriteLine($"Left C:{CurrentPos.Column} R:{CurrentPos.Row}");
                        }
                    }
                }
            }
            return path;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (!Started)
            {
                Started = true;
                MenuPopup menu = new MenuPopup();
                menu.gameEnded = false;
                menu.ShowDialog();
            }
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DebugTestWinScreen_Click(object sender, EventArgs e)
        {
            //DEBUG BUTTON to test win screen
            if (game != null)
            {
                game.WinState = true;
                game.WinLoss();
            }
        }

        private void DebugDamageAllEnemies_Click(object sender, EventArgs e)
        {
            //DEBUG BUTTON to deal damage to all enemies
            if (game != null)
            {
                game.dealDamageToAllEnemies();
            }
        }

        private void DebugAddHealth_Click(object sender, EventArgs e)
        {
            //DEBUG BUTTON to add health
            if(game != null)
            {
                game.addLives(100);
            }
        }

        private void DebugAddMoney_Click(object sender, EventArgs e)
        {
            //DEBUG BUTTON to add money
            if(game != null)
            {
                game.AddMoney(1000);
            }
        }

        private void lblWave_Click(object sender, EventArgs e)
        {

        }

        private void CurrentTowerPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void HealthLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
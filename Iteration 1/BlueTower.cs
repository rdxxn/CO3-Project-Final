using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    internal class BlueTower : Towers
    {
        private List<Enemy> enemiesInRange;
        private GameLogic game;
        public BlueTower(GameLogic gameLogicInstance, GameBoard gameboard, Point position, TableLayoutPanel Control) : base(gameLogicInstance, gameboard, position, Control)
        {
            Damage = 15;
            FireRate = 3;
            Range = 100;
            game = gameLogicInstance;
            attackTimer.Interval = 1000 / (int)FireRate; //turns FireRate into attacks per second
            sprite = Properties.Resources.Blue_Tower;
            enemiesInRange = new List<Enemy>();
            color = Color.Blue;
            DamageType = Enemy.enemyType.Blue;

            tower = new CircularPanel();
            tower.Click += new EventHandler(Tower_Click);
            tower.Margin = new Padding(0);
            tower.BackgroundImage = sprite;
            tower.BackColor = ColorTranslator.FromHtml("0x40D61A");
            tower.Size = Control.GetControlFromPosition(1, 1).Size;
            tower.Location = position;
            gameboard.Controls.Add(tower);
            tower.BringToFront();
        }

        //When the tower is clicked, display the correct information on information menu in the GameBoard form
        private void Tower_Click(object sender, EventArgs e)
        {
            Towers selectedTower = this;
            GameBoard.displayTowerInfo(selectedTower);
        }

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (game == null) { game = GameBoard.game; }
            else if (game != null)
            {
                enemies = game.enemies;
                List<Enemy> enemiesToRemove = new List<Enemy>();

                //Creates a list of the enemies in range of the tower
                foreach (Enemy enemy in enemies)
                {
                    if (CalculateDistance(enemy.Position, Position) <= Range)
                    {
                        if (!enemiesInRange.Contains(enemy))
                        {
                            enemiesInRange.Add(enemy);
                            Console.WriteLine("Enemy in range");
                        }
                    }
                }

                //Damages each enemy in range of the tower
                foreach (Enemy enemy in enemiesInRange)
                {
                    if (enemy.Health <= 0)
                    {
                        enemiesToRemove.Add(enemy);
                    }
                    else
                    {
                        enemy.takeDamage(Damage, DamageType);
                    }
                }

                //Removes dead enemies from the list of enemies that are in range of the tower
                foreach (Enemy enemyToRemove in enemiesToRemove)
                {
                    enemiesInRange.Remove(enemyToRemove);
                }
            }
        }
    }
}
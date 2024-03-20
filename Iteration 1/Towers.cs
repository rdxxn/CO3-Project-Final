using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public class Towers : GameObject
    {
        public int Damage { get; set; }
        public double FireRate { get; set; } = 1;
        public int Range { get; set; }
        protected Timer attackTimer;
        protected Enemy target;
        public Point Position { get; set; }
        protected GameLogic game { get; private set; }
        protected List<Enemy> enemies;
        protected CircularPanel tower;
        public Image sprite { get; set; }
        protected List<Projectile> projectiles;
        protected int ProjectileSpeed { get; set; }
        protected double angleInRadians;
        protected TableLayoutPanel table;
        protected GameBoard GameBoard;
        public Color color { get; set; }
        protected Enemy.enemyType DamageType;
        public int upgradeCost { get; private set; } = 50;
        public int SpentMoney { get; private set; } = 100; 


        public Towers(GameLogic gameLogicInstance, GameBoard gameboard, Point position, TableLayoutPanel Control)
        {
            game = gameLogicInstance;

            //debug
            Console.WriteLine("Towers - game: " + (game != null));

            table = Control;
            GameBoard = gameboard;
            attackTimer = new Timer();
            attackTimer.Interval = 1000 / (int)FireRate; //Turns fire rate into attacks per second
            attackTimer.Start();
            attackTimer.Tick += Timer_Tick;
            Position = position;

            tower = new CircularPanel();
            tower.Margin = new Padding(0);
            tower.BackgroundImage = sprite;
            tower.BackColor = ColorTranslator.FromHtml("0x40D61A");
            tower.Size = Control.GetControlFromPosition(1, 1).Size;
            tower.Location = Position;
            gameboard.Controls.Add(tower);
            tower.BringToFront();
            projectiles = new List<Projectile>();
            ProjectileSpeed = 50;
        }
        public void Upgrade()
        {
            if (game == null && GameBoard.moneyToSpend >= upgradeCost)
            {
                GameBoard.moneyToSpend -= upgradeCost;
                Damage += 2;
                FireRate += 0.5;
                Range += 25;
                upgradeCost = upgradeCost * 2;
                attackTimer.Interval = 1000 / (int)FireRate;
                GameBoard.MoneyText = $"$:{GameBoard.moneyToSpend:0}";
                SpentMoney += upgradeCost;
            }
            else if (game != null && game.currentMoney >= upgradeCost)
            {
                game.currentMoney -= upgradeCost;
                Damage += 2;
                FireRate += 0.5;
                Range += 25;
                upgradeCost = upgradeCost * 2;
                attackTimer.Interval = 1000 / (int)FireRate;
                GameBoard.MoneyText = $"$:{game.currentMoney:0}";
                SpentMoney += upgradeCost;
            }
        }

        public void Sell()
        {
            //UNUSED BECAUSE DISPOSE DOESNT WORK WITH TOWERS FOR SOME REASON
            //The rest of the code works fine though
            if (game != null)
            {
                game.currentMoney += 0.6 * SpentMoney;
                GameBoard.MoneyText = $"$:{game.currentMoney:0}";
            }
            else if(game == null)
            {
                GameBoard.moneyToSpend += Convert.ToInt32(0.6 * SpentMoney);
                GameBoard.MoneyText = $"$:{GameBoard.moneyToSpend:0}";
            }
            GameBoard.unDisplayTowerInfo();
            Dispose();
        }


        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            if (game == null) { game = GameBoard.game; }
            else if (game != null)
            {
                Console.Write("Games is not null");
                enemies = game.enemies;

                //iterates through enemies and the oldest one that is within range is set as the target
                foreach (Enemy enemy in enemies)
                {
                    if (CalculateDistance(enemy.Position, Position) <= Range)
                    {
                        target = enemy;
                        break;
                    }
                }

                if (target != null && target.Health > 0)
                {
                    // finds the bearing that points to the target
                    angleInRadians = Math.Atan2(target.Position.Y - Position.Y, target.Position.X - Position.X);

                    // fires a projectile at the target but even if the projectile misses it still deals damage to the target
                    // to avoid inaccuracy playing a part in making the game more random
                    target.takeDamage(Damage, DamageType);
                    Projectile projectile = new Projectile(target, Position, ProjectileSpeed, angleInRadians, table, GameBoard, color);
                    projectile.Move(angleInRadians, enemies);
                    projectiles.Add(projectile);

                }
            }
        }

        protected double CalculateDistance(Point point1, Point point2)
        {
            // a^2 + b^2 = c^2
            //finds the distance by finding the difference in the X and Y values of the two points and calculates the length of the direct line between the point 
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public void Dispose()
        {
            //desperately trying anything to remove Dispose the tower correctly
            Console.WriteLine("Tower disposed");
            attackTimer.Dispose();
            tower.Size = new Size(0, 0);
            tower.SendToBack();
            tower.Visible = false;
            GameBoard.SuspendLayout();
            tower.Visible = false;
            GameBoard.Controls.Remove(tower);
            tower.Dispose();
            GameBoard.ResumeLayout();
            tower.Refresh();
            tower.Update();

            //genocide the projectiles
            foreach (var projectile in projectiles)
            {
                projectile.Dispose();
            }
            projectiles.Clear();
        }
    }
}
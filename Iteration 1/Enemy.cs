using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    public class Enemy : GameObject, IDisposable
    {
        public enum enemyType
        { Red, Green, Blue, Gray };

        public double Health { get; private set; }
        private double Money;
        private double Damage;
        public GameBoard board = (GameBoard)Application.OpenForms["GameBoard"];
        private GameLogic game;
        private Color sprite;
        private CircularPanel enemy;
        private List<Point> Path;
        private Timer moveTimer;
        private int currentPointIndex;
        private const int pixelsPerTick = 10;
        private GameBoard Gameboard;
        private enemyType EnemyType;

        public Enemy(GameLogic gameLogicInstance, double health, double money, double damage, enemyType type, List<Point> path, TableLayoutPanel Control, Timer Timer, GameBoard gameboard)
        {
            game = gameLogicInstance;
            Health = health;
            Money = money;
            Damage = damage;
            Path = path;
            Gameboard = gameboard;
            EnemyType = type;

            if (type == enemyType.Red) { sprite = Color.Red; }
            if (type == enemyType.Green) { sprite = Color.Green; }
            if (type == enemyType.Blue) { sprite = Color.Blue; }
            Control control = Control.GetControlFromPosition(1,1);
            if(control != null)
            {
            enemy = new CircularPanel();
            enemy.Margin = new Padding(0);
            enemy.BackColor = sprite;
            enemy.Size = control.Size;
            enemy.Location = GetCenterPosition(7, 1, Control, enemy);
            gameboard.Controls.Add(enemy);
            enemy.BringToFront();
            }

            currentPointIndex = -1;
            moveTimer = new Timer();
            moveTimer.Interval = 75;
            moveTimer.Start();
            moveTimer.Tick += MoveTimer_Tick;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < Path.Count - 1)
            {
                MoveToNextPoint();
                if (HasReachedNextPoint())
                {
                    // Increment the index when the enemy has reached the current point
                    currentPointIndex++;
                }
            }
            else
            {
                // Reached the end of the path
                dealDamage(Damage);
                Dispose();
            }
        }
        
        private bool HasReachedNextPoint()
        {
            if (enemy != null)
            {
                Point currentPoint = enemy.Location;
                Point nextPoint = Path[currentPointIndex + 1];

                //Checks the positive values of the differences in X and Y and compares it to pixelsPerTick
                return Math.Abs(currentPoint.X - nextPoint.X) <= pixelsPerTick
                    && Math.Abs(currentPoint.Y - nextPoint.Y) <= pixelsPerTick;
            }
            else
            {
                return false;
            }
        }

        public static Point GetCenterPosition(int row, int column, TableLayoutPanel table, CircularPanel enemy)
        {
            Control selectedControl = table.GetControlFromPosition(column, row);
            // Calculate the center point of the control
            int X = selectedControl.Left + selectedControl.Width / 2 - enemy.Width / 2;
            int Y = selectedControl.Top + selectedControl.Height / 2 - enemy.Height / 2;
            return new Point(X, Y);
        }

        private void MoveToNextPoint()
        {
            //This algorithm only moves 1 pixel at a time
            //and would require a timer with very short interval
            //so this has been abandonded for performance reasons

            //Point currentPoint = enemy.Location;
            //Point nextPoint = Path[currentPointIndex + 1];

            //if (currentPoint.X < nextPoint.X)
            //    currentPoint.X += pixelsPerTick;
            //else if (currentPoint.X > nextPoint.X)
            //    currentPoint.X -= pixelsPerTick;
            //else if (currentPoint.Y < nextPoint.Y)
            //    currentPoint.Y += pixelsPerTick;
            //else if (currentPoint.Y > nextPoint.Y)
            //    currentPoint.Y -= pixelsPerTick;
            //enemy.Location = currentPoint;


            //calcs distance between current point and next point then determines max distance it can move
            //without going over the destination point or going over pixelsPerTick which would cause it to not run HasReachedNextPoint()
            if (enemy != null)
            {
                //Declare the two points
                Point currentPoint = enemy.Location;
                Point nextPoint = Path[currentPointIndex + 1];
                //Calculate the difference between the two points
                int dX = nextPoint.X - currentPoint.X;
                int dY = nextPoint.Y - currentPoint.Y;
                //Calculate the distance between the two points using pythag
                int distance = (int)Math.Sqrt(dX * dX + dY * dY);
                //Determine if the distance is less than pixelsPerTick and if it is use distance as the pixels to move rather than pixelsPerTick
                int pixelsToMove = Math.Min(distance, pixelsPerTick); // Move the most amount of pixels to get to the next point without 
                // dX / distance determines if the change in X is positive or negative
                // dY / distance determines if the change in Y is positive or negative
                int newX = currentPoint.X + (int)((double) dX / distance * pixelsToMove);
                int newY = currentPoint.Y + (int)((double) dY / distance * pixelsToMove);
                enemy.Location = new Point(newX, newY);
            }
        }

        public void dealDamage(double damageDeals)
        {
            Gameboard.game.dealDamage(damageDeals);
        }

        public void giveMoney()
        {
            game.AddMoney(Money);
        }

        public void takeDamage(int damageTaken, enemyType damageType)
        {
            double damageMult = 1; //defaults to 1x mutliplier (if damageType is gray or the same color as the enemy)

            if (damageType == enemyType.Red)
            {
                if(EnemyType == enemyType.Blue) { damageMult = 1.5; }
                else if(EnemyType == enemyType.Green) { damageMult = 0.75; }
            }
            else if (damageType == enemyType.Green)
            {
                if (EnemyType == enemyType.Blue) { damageMult = 0.75; }
                else if (EnemyType == enemyType.Red) { damageMult = 1.5; }
            }
            else if (damageType == enemyType.Blue)
            {
                if (EnemyType == enemyType.Red) { damageMult = 0.75; }
                else if (EnemyType == enemyType.Green) { damageMult = 1.5; }
            }
            Health -= damageTaken * damageMult;
            if (Health < 0)
            {
                giveMoney();
                Dispose();
            }
        }
        public Point Position
        {
            get { return enemy.Location; }
            set { enemy.Location = value; }
        }
        public Rectangle GetBounds()
        {
            return enemy.Bounds;
        }

        public void Dispose()
        {
            //Remove enemy from GameLogic enemyList "enemies"
            game.RemoveEnemyFromList(this);
            
            //Allows for detecting when all enemies are killed in order to start a new wave
            game.WaveManager(); 

            // kills the enemy object and properly stops timer
            if (moveTimer != null)
            {
                moveTimer.Stop();
                moveTimer.Tick -= MoveTimer_Tick;
                moveTimer.Dispose();
            }

            if (enemy != null)
            {
                enemy.Dispose();
            }
        }
    }
}
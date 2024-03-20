using System;
using System.Collections.Generic;
using System.Drawing;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iteration_1
{
    public class Projectile
    {
        public Point Position { get; set; }
        public int Speed { get; set; }
        private CircularPanel projectile;
        private TableLayoutPanel tableLayoutPanel;

        public Projectile( Enemy target, Point position, int projectileSpeed, double angleInDegrees, TableLayoutPanel table, GameBoard gameboard, Color color)
        {
            Position = position;
            Speed = projectileSpeed;
            tableLayoutPanel = table; // Set the tableLayoutPanel

            projectile = new CircularPanel();
            projectile.Margin = new Padding(0);
            projectile.BackColor = color;
            projectile.Size = new Size(10, 10);
            projectile.Location = position;
            gameboard.Controls.Add(projectile);
            projectile.BringToFront();
        }

        public async Task Move(double angleInRadians, List<Enemy> enemies)
        {
            // Continue moving until the projectile is out of bounds or disposed
            while (IsInBounds() && !projectile.IsDisposed)
            {
                // Convert angle to radians (i just pass in the value in radians instead)
                // double angleInRadians = angleInDegrees * (Math.PI / 180.0);

                // Calculate new position based on the given angle
                double dX = Speed * Math.Cos(angleInRadians);
                double dY = Speed * Math.Sin(angleInRadians);

                // Update the projectile's position
                Position = new Point((int)(Position.X + dX), (int)(Position.Y + dY));
                projectile.Location = Position;

                // Check for collision with each enemy and destroys if colliding
                foreach (Enemy enemy in enemies)
                {
                    if (CollidesWithEnemy(enemy))
                    {
                        Console.WriteLine("Projectile Collided with enemy");
                        projectile.Dispose();
                        return;
                    }
                }
                //Debug
                //Console.WriteLine($"New position - X: {Position.X}, Y: {Position.Y}");

                await Task.Delay(50);
            }
            //kills the projectile when its out of bounds of the GameBoards tableLayoutPanel or disposed
            projectile.Dispose();
        }
        private bool CollidesWithEnemy(Enemy enemy)
        {
            // Check if the projectile bounds intersect with the enemy bounds
            if(enemy == null) { return false;}
            return projectile.Bounds.IntersectsWith(enemy.GetBounds());
        }

        private bool IsInBounds()
        {
            return tableLayoutPanel.ClientRectangle.Contains(projectile.Bounds);
        }
        public void Dispose()
        {
            //Kills the bullet
        }
    }
}

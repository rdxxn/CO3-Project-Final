using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iteration_1
{
    internal class GreenTower : Towers
    {
        public GreenTower(GameLogic gameLogicInstance, GameBoard gameboard, Point position, TableLayoutPanel Control) : base(gameLogicInstance, gameboard, position, Control)
        {
            Damage = 5;
            FireRate = 10;
            Range = 100;
            attackTimer.Interval = 1000 / (int)FireRate;
            sprite = Properties.Resources.Green_Tower;
            color = Color.Green;
            DamageType = Enemy.enemyType.Green;

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
            Console.WriteLine("Tower clicked");
            Towers selectedTower = this;
            GameBoard.displayTowerInfo(selectedTower);
        }
    }
}
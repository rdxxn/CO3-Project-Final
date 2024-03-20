using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Iteration_1.DifficultySelectMenu;

namespace Iteration_1
{
    public class GameLogic
    {
        private double currentLives = 200;
        public double currentMoney { get; set; } = 200;
        public int currentWave { get; private set; } = 0;
        public SelectedDifficulty difficulty { get; private set;} = SelectedDifficulty.Easy;
        private bool winState = false;
        private int EnemiesPerWave = 5;
        private double rewardMoney = 1f;
        private double damageDealt = 50;
        private float DifficultyMultiplier = 1;
        private double EnemyHealth = 10f;
        private int MaxRound = 40;
        private GameBoard gameBoard = (GameBoard)Application.OpenForms["GameBoard"];
        public TableLayoutPanel gameTable;
        private List<Point> Path;
        public List<Enemy> enemies = new List<Enemy>();
        private Timer EnemyTimer;
        private GameBoard Gameboard;
        private bool FinalRound;
        private bool popupPoppedup = false;
        private TableLayoutPanel Control;

        public GameLogic(SelectedDifficulty difficulty, List<Point> path, Timer enemyTimer, TableLayoutPanel control, GameBoard gameboard)
        {
            Path = path;
            EnemyTimer = enemyTimer;
            Control = control;
            Gameboard = gameboard;
            if (difficulty == SelectedDifficulty.Easy) { DifficultyMultiplier = 0.8f; MaxRound = 40; }
            else if (difficulty == SelectedDifficulty.Medium) { DifficultyMultiplier = 1f; MaxRound = 60; }
            else { DifficultyMultiplier = 1.2f; MaxRound = 80; }
            Control = control;

        }

        public  void addLives(double livesToAdd)
        {
            currentLives += livesToAdd;
            gameBoard.HealthText = $"{currentLives:0}";
        }
        public void SpendMoney(double moneyToSpend)
        {
            currentMoney -= moneyToSpend;
            gameBoard.MoneyText = $"$:{currentMoney:0}";
        }

        public async void WaveManager()
        {
            Console.WriteLine("Enemy Left");

            await Task.Delay(3000); //Prevent Multiple waves from spawning at once if enemies are killed too fast
            if (enemies.Count <= 0 && currentLives > 0)
            {
                if (FinalRound) { winState = true; WinLoss(); }
                StartNextWave();
            }
        }

        public bool WinState { get => winState; set => winState = value; }

        public void RemoveEnemyFromList(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        public async void StartNextWave()
        {
            currentWave++;
            if (currentWave == MaxRound) { FinalRound = true; }
            gameBoard.WaveText = $"Wave: {currentWave}";
            EnemyHealth = DifficultyMultiplier * Math.Exp(-Math.Pow(currentWave / 60, 2)) * Math.Exp(0.1 * currentWave) + EnemyHealth;
            damageDealt = DifficultyMultiplier * Math.Exp(-Math.Pow(currentWave / 60, 2)) * Math.Exp(0.05 * currentWave) + damageDealt;
            rewardMoney = 0.2 * currentWave + rewardMoney;
            if (currentWave % 2 == 0) { EnemiesPerWave++; }
            for (int i = 0; i < EnemiesPerWave; i++)
            {
                //Create Enemy
                Enemy NewEnemy = new Enemy(this, EnemyHealth, rewardMoney, damageDealt, RandomEnemyType(), Path, Control, EnemyTimer, Gameboard);
                enemies.Add(NewEnemy);
                Console.WriteLine("Enemy Added");
                await Task.Delay(750);
            }
        }

        private static Enemy.enemyType RandomEnemyType()
        {
            Random random = new Random();

            int randomNumber = random.Next(1, 4);

            if (randomNumber == 1)
            {
                return Enemy.enemyType.Blue;
            }
            else if (randomNumber == 2)
            {
                return Enemy.enemyType.Red;
            }
            else
            {
                return Enemy.enemyType.Green;
            }
        }

        public void dealDamage(double damageDealt)
        {
            currentLives -= damageDealt;
            gameBoard.HealthText = $"{currentLives:0}";
            if (currentLives <= 0)
            {
                winState = false;
                WinLoss();
            }
        }

        public void AddMoney(double moneyToAdd)
        {
            currentMoney += moneyToAdd;
            gameBoard.MoneyText = $"$:{currentMoney:0}";
        }

        public void dealDamageToAllEnemies()
        {
            //DEBUG, ONLY USED FOR DEBUG PURPOSES!
            List<Enemy> enemiesCopy = new List<Enemy>(enemies);
            foreach (Enemy enemy in enemiesCopy)
            {
                enemy.takeDamage(10, Enemy.enemyType.Gray);
            }
        }

        public void WinLoss()
        {
            // Create a copy of the enemies collection to avoid modifying the collection while iterating over it to fix a minor bug
            List<Enemy> enemiesCopy = new List<Enemy>(enemies);

            // genocide the enemies 😎
            Console.WriteLine("Enemy genocide");
            foreach (Enemy enemy in enemiesCopy)
            {
                enemy.Dispose();
            }
            foreach(Towers tower in Gameboard.PlacedTowers)
            {
                tower.Dispose();
            }
            enemies.Clear();
            Console.WriteLine("Menu Popup should run here:");
            if (!popupPoppedup)
            {
                popupPoppedup = true;
                MenuPopup menu = new MenuPopup();
                menu.gameEnded = true;
                menu.ShowDialog();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Iteration_1.DifficultySelectMenu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Iteration_1
{
    public class LeaderBoardManagement
    {
        protected Dictionary<string, int>[] Hard = new Dictionary<string, int>[10];
        protected Dictionary<string, int>[] Medium = new Dictionary<string, int>[10];
        protected Dictionary<string, int>[] Easy = new Dictionary<string, int>[10];
        protected string FileLocation;
        protected string[] map;


        public LeaderBoardManagement(string Filelocation)
        {
            for (int i = 0; i < 10; i++)
            {
                Hard[i] = new Dictionary<string, int>();
                Medium[i] = new Dictionary<string, int>();
                Easy[i] = new Dictionary<string, int>();
            }
        }

        public int getLowest(DifficultySelectMenu.SelectedDifficulty diff)
        {
            if (diff == DifficultySelectMenu.SelectedDifficulty.Easy)
            {
                if (Easy[9] == null || Easy[9].Count == 0) { return 0; }
                else { return Easy[9].Values.Last(); }
            }
            else if (diff == DifficultySelectMenu.SelectedDifficulty.Medium)
            {
                if (Medium[9] == null || Medium[9].Count == 0) { return 0; }
                else { return Medium[9].Values.Last(); }
            }
            else if (diff == DifficultySelectMenu.SelectedDifficulty.Hard)
            {
                if (Hard[9] == null || Hard[9].Count == 0) { return 0; }
                else { return Hard[9].Values.Last(); }
            }
            Console.WriteLine("THIS SHOULD NOT APPEAR, SOMETHING HAS GONE WRONG IN getLowest()");
            return int.MaxValue;
        }

        public void AddToLeaderBoard(string username, int score, DifficultySelectMenu.SelectedDifficulty selectedDifficulty)
        {
            if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Easy)
            {
                Easy[9] = new Dictionary<string, int> { { username, score } };
            }
            else if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Medium)
            {
                Medium[9] = new Dictionary<string, int> { { username, score } };
            }
            else if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Hard)
            {
                Hard[9] = new Dictionary<string, int> { { username, score } };
            }
            SortLeaderboard(selectedDifficulty);
            WriteToFile(selectedDifficulty);
        }

        protected void SortLeaderboard(DifficultySelectMenu.SelectedDifficulty selectedDifficulty)
        {
            if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Easy)
            {
                BubbleSort(ref Easy);
            }
            else if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Medium)
            {
                BubbleSort(ref Medium);
            }
            else if (selectedDifficulty == DifficultySelectMenu.SelectedDifficulty.Hard)
            {
                BubbleSort(ref Hard);
            }
        }
        private void BubbleSort(ref Dictionary<string, int>[] leaderboard )
        {
            int n = leaderboard.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Check if both dictionaries have elements
                    if (leaderboard[j].Any() && leaderboard[j + 1].Any())
                    {
                        if (leaderboard[j].Values.First() < leaderboard[j + 1].Values.First())
                        {
                            // Swap elements
                            var temp = leaderboard[j];
                            leaderboard[j] = leaderboard[j + 1];
                            leaderboard[j + 1] = temp;
                        }
                    }
                }
            }
        }
        private void WriteToFile(SelectedDifficulty difficulty)
        {
            string[] arr = new string[10];
            int i = 0;

            // Populate the arr array based on the selected difficulty level
            if (difficulty == SelectedDifficulty.Easy)
            {
                foreach (var a in Easy)
                {
                    foreach (var b in a)
                    {
                        arr[i] = b.Key + "-" + b.Value.ToString();
                        i++;
                    }
                }
            }
            else if (difficulty == SelectedDifficulty.Medium)
            {
                foreach (var a in Medium)
                {
                    foreach (var b in a)
                    {
                        arr[i] = b.Key + "-" + b.Value.ToString();
                        i++;
                    }
                }
            }
            else if (difficulty == SelectedDifficulty.Hard)
            {
                foreach (var a in Hard)
                {
                    foreach (var b in a)
                    {
                        arr[i] = b.Key + "-" + b.Value.ToString();
                        i++;
                    }
                }
            }

            // Read existing lines from the file
            string line1;
            string line2;
            string line3;
            using (StreamReader reader = new StreamReader(FileLocation))
            {
                line1 = reader.ReadLine();
                line2 = reader.ReadLine();
                line3 = reader.ReadLine();
            }

            // Write lines to the file based on the selected difficulty level
            using (StreamWriter writer = new StreamWriter(FileLocation))
            {
                if (difficulty == SelectedDifficulty.Easy)
                {
                    writer.WriteLine(string.Join(" ", arr));
                    writer.WriteLine(line2); // Write the unchanged second line
                    writer.WriteLine(line3); // Write the unchanged third line
                }
                else if (difficulty == SelectedDifficulty.Medium)
                {
                    writer.WriteLine(line1); // Write the unchanged first line
                    writer.WriteLine(string.Join(" ", arr));
                    writer.WriteLine(line3); // Write the unchanged third line
                }
                else if (difficulty == SelectedDifficulty.Hard)
                {
                    writer.WriteLine(line1); // Write the unchanged first line
                    writer.WriteLine(line2); // Write the unchanged second line
                    writer.WriteLine(string.Join(" ", arr));
                }
                else
                {
                    // Write the existing lines back if difficulty is unknown
                    writer.WriteLine(line1);
                    writer.WriteLine(line2);
                    writer.WriteLine(line3);
                }
            }
        }

    }
}
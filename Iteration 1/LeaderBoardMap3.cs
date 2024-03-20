using System;
using System.Collections.Generic;
using System.IO;

namespace Iteration_1
{
    public class LeaderBoardMap3 : LeaderBoardManagement
    {
        public LeaderBoardMap3(string Filelocation) : base(Filelocation)
        {
            FileLocation = Filelocation;
            map = File.ReadAllLines(FileLocation);

            // Ensure the file contains enough lines
            if (map.Length >= 3)
            {
                //Seperates file into lines
                string[] mapEasy = map[0].Split(' ');
                string[] mapMed = map[1].Split(' ');
                string[] mapHard = map[2].Split(' ');

                //Adds the file values to the local variables
                InitializeDictionary(mapEasy, ref Easy);
                InitializeDictionary(mapMed, ref Medium);
                InitializeDictionary(mapHard, ref Hard);
            }
            else
            {
                Console.WriteLine("not enough lines in the file");
            }
        }

        private void InitializeDictionary(string[] mapData, ref Dictionary<string, int>[] leaderboard)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < mapData.Length)
                {
                    int HypenIndex = mapData[i].IndexOf("-");
                    if (HypenIndex >= 0)
                    {
                        string name = mapData[i].Substring(0, HypenIndex);
                        int score = int.Parse(mapData[i].Substring(HypenIndex + 1));
                        leaderboard[i] = new Dictionary<string, int> { { name, score } };
                    }
                    else
                    {
                        leaderboard[i] = new Dictionary<string, int> { { "NoScorer", 0 } };
                    }
                }
                else
                {
                    leaderboard[i] = new Dictionary<string, int> { { "NoScorer", 0 } };
                }
            }
        }
    }
}
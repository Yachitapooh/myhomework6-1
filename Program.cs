using System;

namespace sathomework_6_1
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static void Main(string[] args)
        {
            double Point = 0;
            Difficulty Level = 0;
            PageMainMenu(Point, Level);
        }
        static void PageMainMenu(double acpoint, Difficulty prepoint) 
        {
            int pagenumber;
            Console.WriteLine("Score : {0},Difficulty: {1}", acpoint, prepoint);
            Check(out pagenumber);
            if (pagenumber == 0)
            {
                PlayGame(acpoint, prepoint);
            }
            else if (pagenumber == 1)
            {
                Setting(acpoint, prepoint);
            }
            else if (pagenumber == 2) 
            {
                Console.WriteLine();
            }
        }
        static void Check(out int page) 
        {
            do
            {
                page = int.Parse(Console.ReadLine());
                if (page != 0 && page != 1 && page != 2)
                {
                    Console.WriteLine("Please input 0-2.");
                }
            }
            while (page != 0 && page != 1 && page != 2);
        }
        static void PlayGame(double Point, Difficulty Level) 
        {
            int d = (int)Level;
            double Answer;
            double QC = 0;
            double QA;
            Problem[] RandomProblems = GenerateRandomProblems(d * 2 + 3);
            long Start = DateTimeOffset.Now.ToUnixTimeSeconds();
            for (int j = 0; j < RandomProblems.Length; j++) 
            {
                Console.WriteLine(RandomProblems[j].Message);
                Console.WriteLine();
                Answer = int.Parse(Console.ReadLine());
                if (Answer == RandomProblems[j].Answer) 
                {
                    QC = QC + 1;
                }
            }
            long Stop = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long RangeTime = Stop - Start;
            QA = d * 2 + 3;
            Point = Point + ((QC / QA) * ((25 - Math.Pow(d, 2)) / Math.Max(RangeTime, 25 - (double)Math.Pow(d, 2))) * (Math.Pow(2 * d + 1, 2)));
            PageMainMenu(Point, Level);
        }
        static void Setting(double Point, Difficulty Level) 
        {
            int Levelnumber;
            Console.WriteLine("Score: {0},Difficulty : {1}", Point, (Difficulty)Level);
            do
            {
                Levelnumber = int.Parse(Console.ReadLine());
                if (Levelnumber != 0 && Levelnumber != 1 && Levelnumber != 2)
                {
                    Console.WriteLine("Please input 0-2.");
                }
            }
            while (Levelnumber != 0 && Levelnumber != 1 && Levelnumber != 2);
            Level = (Difficulty)Levelnumber;
            PageMainMenu(Point, Level);
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] = new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] = new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }
    }
}

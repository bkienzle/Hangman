using System;

namespace Hangman
{
    class Player
    {
        public string name { get; set; }
        public int winRecord { get; set; }
        public int lossRecord { get; set; }
        //public int TieRecord { get; set; }
        //public int TeamNumber { get; set; }

        public void getName()
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            if (name.Length > 32) name = name.Substring(0, 32);
            if (name == "") name = "Scrub";
        }
        public void showRecord()
        {
            Console.WriteLine();
            Console.WriteLine("  {0}, your current record is: Wins: {1} Losses: {2}", name, winRecord, lossRecord);
        }
    }
}

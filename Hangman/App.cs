using System;

namespace Hangman
{
    class App
    {
        public void Start()
        {
            Player human = new Player();
            Game hangman = new Game();
            human.GetName();

            while (hangman.isPlaying)
            {
                hangman.Initialize();
                while (!hangman.isMatchOver)
                {
                    Console.Clear();
                    human.ShowRecord();
                    hangman.DrawBoard();
                    hangman.PromptForLetter();
                }
            }
            Console.ReadKey();

        }
    }
}

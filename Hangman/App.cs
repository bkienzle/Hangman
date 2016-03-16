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
                Console.Clear();
                human.ShowRecord();
                hangman.Initialize();
                hangman.DrawBoard();
                hangman.PromptForLetter();
            }
            Console.ReadKey();

        }
    }
}

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

            Console.Clear();
            human.ShowRecord();
            hangman.DrawBoard();

            Console.ReadKey();

        }
    }
}

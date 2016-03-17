using System;

namespace Hangman
{
    class App
    {
        public void start()
        {
            Player human = new Player();
            Game hangman = new Game();
            human.getName();

            while (hangman.isPlaying)
            {
                hangman.initialize();
                while (!hangman.isMatchOver)
                {
                    Console.Clear();
                    human.showRecord();
                    hangman.drawBoard();
                    hangman.promptForLetter();
                    if (hangman.numberOfGuesses == 6 || Word.isFullyUnmasked()) hangman.isMatchOver = true;
                }
                string gameResult = "lose";
                if (hangman.hasWon())
                {
                    gameResult = "win";
                    human.winRecord++;
                }
                else
                {
                    human.lossRecord++;
                }
                Console.Clear();
                human.showRecord();
                hangman.drawBoard();
                hangman.playAgain(gameResult);

            }
        }
    }
}

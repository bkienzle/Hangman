﻿using System;

namespace Hangman
{
    class Game
    {
        #region Enums

        #endregion
        enum BodyParts
        {
            head,
            body,
            leftArm,
            rightArm,
            leftLeg,
            rightLeg,
        }

        #region Public Variables
        public bool isPlaying = true;
        public bool isMatchOver = false;
        public int numberOfGuesses = 0;
        #endregion

        #region Private Variables
        string[] hangee = new string[] { " ", " ", " ", " ", " ", " " };
        #endregion

        #region Public Methods
        public void drawBoard()
        {

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) +                                                                                               ",____.");
            Console.WriteLine(new string(' ', 10) +                                                                                               "|    |");
            Console.WriteLine(new string(' ', 10) + hangee[(int)BodyParts.head] +                                                                  "    |");
            Console.WriteLine(new string(' ', 9) + hangee[(int)BodyParts.leftArm] + hangee[(int)BodyParts.body] + hangee[(int)BodyParts.rightArm] + "   |" + new string(' ', 15) + Word.maskedWord());
            Console.WriteLine(new string(' ', 10) + hangee[(int)BodyParts.body] +                                                                  "    |");
            Console.WriteLine(new string(' ', 9) + hangee[(int)BodyParts.leftLeg] + " " + hangee[(int)BodyParts.rightLeg] +                         "   | " + new string(' ', 15) + "Guessed letters:");
            Console.WriteLine(new string(' ', 10) +                                                                                               "     |"  + new string(' ', 15) + Word.showGuessedLetters());
            Console.WriteLine(new string(' ', 6) +                                                                                            "---------^--");
            Console.WriteLine();
        }
        public void initialize()
        {
            for (int i = 0; i < 6; i++)
            {
                hangee[i] = " ";
            }
            numberOfGuesses = 0;
            Word.guessedLetters.Clear();
            Word.pickNewWord();
            isMatchOver = false;
        }
        public bool hasWon()
        {
            if (Word.isFullyUnmasked()) return true;
            return false;
        }
        public void playAgain(string lastGame)
        {
            Console.Write("  You {0}. Play again? ", lastGame);
            if (Console.ReadKey().KeyChar == 'n') isPlaying = false;
        }
        public void promptForLetter()
        {
            Console.Write("  Guess a letter: ");
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            if (char.IsLetter(guess))
            {
                if (!Word.isInAnswer(guess) && !Word.guessedLetters.Contains(guess))
                {
                    incrementHangman();
                }
                if (!Word.guessedLetters.Contains(guess)) Word.guessedLetters.Add(guess);
            }
        }
        #endregion

        #region Private Methods
        void incrementHangman()
        {
            numberOfGuesses++;
            switch (numberOfGuesses) 
            {
                case 1:
                    hangee[(int)BodyParts.head] = "O";
                    break;
                case 2:
                    hangee[(int)BodyParts.body] = "|";
                    break;
                case 3:
                    hangee[(int)BodyParts.leftArm] = "/";
                    break;
                case 4:
                    hangee[(int)BodyParts.rightArm] = @"\";
                    break;
                case 5:
                    hangee[(int)BodyParts.leftLeg] = "/";
                    break;
                case 6:
                    hangee[(int)BodyParts.rightLeg] = @"\";
                    isMatchOver = true;
                    break;
                default:
                    return;
            }
        }
        #endregion
    }
}

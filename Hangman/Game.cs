using System;

namespace Hangman
{
    class Game
    {
        enum BodyParts
        {
            Head,
            Body,
            LeftArm,
            RightArm,
            LeftLeg,
            RightLeg,
        }
        public bool isPlaying = true;
        int numberOfGuesses = 0;
        string[] hangee = new string[] { " ", " ", " ", " ", " ", " " };
        public void DrawBoard()
        {
            string userPrompt = "Pick a letter";
            if (Word.isFullyUnmasked()) userPrompt = "You win.";

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) +                                                                                               ",____.");
            Console.WriteLine(new string(' ', 10) +                                                                                               "|    |");
            Console.WriteLine(new string(' ', 10) + hangee[(int)BodyParts.Head] +                                                                  "    |" + new string(' ', 20) + userPrompt);
            Console.WriteLine(new string(' ', 9) + hangee[(int)BodyParts.LeftArm] + hangee[(int)BodyParts.Body] + hangee[(int)BodyParts.RightArm] + "   |");
            Console.WriteLine(new string(' ', 10) + hangee[(int)BodyParts.Body] +                                                                  "    |" + new string(' ', 20) + Word.MaskedWord());
            Console.WriteLine(new string(' ', 9) + hangee[(int)BodyParts.LeftLeg] + " " + hangee[(int)BodyParts.RightLeg] +                         "   |");
            Console.WriteLine(new string(' ', 10) +                                                                                               "     |");
            Console.WriteLine(new string(' ', 6) +                                                                                            "---------^--");
            Console.WriteLine();
        }
        public void Initialize()
        {
            for (int i = 0; i < 6; i++)
            {
                hangee[i] = " ";
            }
            numberOfGuesses = 0;
        }
        void IncrementHangman()
        {
            numberOfGuesses++;
            switch (numberOfGuesses) 
            {
                case 1:
                    hangee[(int)BodyParts.Head] = "O";
                    break;
                case 2:
                    hangee[(int)BodyParts.Body] = "|";
                    break;
                case 3:
                    hangee[(int)BodyParts.LeftArm] = "/";
                    break;
                case 4:
                    hangee[(int)BodyParts.RightArm] = @"\";
                    break;
                case 5:
                    hangee[(int)BodyParts.LeftLeg] = "/";
                    break;
                case 6:
                    hangee[(int)BodyParts.RightLeg] = @"\";
                    break;
                default:
                    return;
            }
        }
        public void PromptForLetter()
        {
            Console.Write("Guess a letter: ");
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            if (char.IsLetter(guess))
            {
                Word.guessedLetters.Add(guess);
                if (!Word.isInAnswer(guess))
                {
                    IncrementHangman();
                }
            }
        }
    }
}

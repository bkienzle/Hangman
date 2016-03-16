using System;

namespace Hangman
{
    class Game
    {
        public void DrawBoard()
        {
            string head = "O";
            string body = "|";
            string leftArm = "/"; //this is my left, not the hangee's left.
            string rightArm = @"\";
            string leftLeg = "/";
            string rightLeg = @"\";

            string userPrompt = "Pick a letter";
            if (Word.isFullyUnmasked()) userPrompt = "You win.";

            string wordblanks = "_ _ _ _ _";

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) +                             ",____.");
            Console.WriteLine(new string(' ', 10) +                             "|    |");
            Console.WriteLine(new string(' ', 10) + head +                       "    |" + new string(' ', 20) + userPrompt);
            Console.WriteLine(new string(' ', 9) + leftArm + body + rightArm +    "   |");
            Console.WriteLine(new string(' ', 10) + body +                       "    |" + new string(' ', 20) + Word.MaskedWord());
            Console.WriteLine(new string(' ', 9) + leftLeg + " " + rightLeg +     "   |");
            Console.WriteLine(new string(' ', 10) +                             "     |");
            Console.WriteLine(new string(' ', 6) +                          "---------^--");
            Console.WriteLine();
        }
    }
}

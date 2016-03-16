using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Hangman
{
    static class Word
    {
        static string hiddenWord = "testword";

        public static List<char> guessedLetters = new List<char>();

        public static string MaskedWord()
        {
            guessedLetters.Add('t');
            guessedLetters.Add('e');

            string result = hiddenWord;
            foreach (char hiddenLetter in hiddenWord.ToCharArray())
            {
                bool isMatch = false;
                foreach (char letter in guessedLetters)
                {
                    if (letter == hiddenLetter)
                    {
                        isMatch = true;
                    }
                }
                if (!isMatch)
                {
                    result = result.Replace(hiddenLetter, '_');
                }
            }
            return Regex.Replace(result, ".{1}", "$0 ");
        }
        public static bool isInAnswer (char guess)
        {
            foreach (char letter in hiddenWord.ToCharArray())
            {
                if (guess == letter) return true;
            }
            return false;
        }
        public static bool isFullyUnmasked()
        {
            bool areUnderscoresInWord = false;
            foreach (char letter in MaskedWord())
            {
                if (letter == '_') areUnderscoresInWord = true;
            }
            if (areUnderscoresInWord == true) return false;
            return true;
        }
    }
}

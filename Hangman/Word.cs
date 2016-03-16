using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Hangman
{
    static class Word
    {
        static string hiddenWord = "testword";

        static List<string> guessedLetters = new List<string>();

        public static string MaskedWord()
        {
            guessedLetters.Add("t");
            guessedLetters.Add("e");

            string result = hiddenWord;
            foreach (char hiddenLetter in hiddenWord.ToCharArray())
            {
                bool isMatch = false;
                foreach (string letter in guessedLetters)
                {
                    if (Convert.ToChar(letter) == hiddenLetter)
                    {
                        isMatch = true;
                    }
                }
                if (!isMatch)
                {
                    result = result.Replace(Convert.ToChar(hiddenLetter), '_');
                }
            }
            return Regex.Replace(result, ".{1}", "$0 ");
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

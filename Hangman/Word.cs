using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace Hangman
{
    static class Word
    {
        #region Private Variables
        static string hiddenWord = "";
        #endregion

        #region Public Methods
        public static void pickNewWord()
        {

            string[] allWords = Hangman.Properties.Resources.words.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Random rnd = new Random();
            hiddenWord = allWords[rnd.Next(0,allWords.Length)];
        }

        public static List<char> guessedLetters = new List<char>();

        public static string maskedWord()
        {
            string result = hiddenWord;
            foreach (char hiddenLetter in hiddenWord.ToCharArray())
            {
                bool isMatch = false;
                if (!char.IsLetter(hiddenLetter))
                {
                    isMatch = true;
                }
                else {
                    foreach (char letter in guessedLetters)
                    {
                        if (letter == hiddenLetter)
                        {
                            isMatch = true;
                        }
                    }
                }
                if (!isMatch)
                {
                    result = result.Replace(hiddenLetter, '_');
                }
            }
            return Regex.Replace(result, ".{1}", "$0 ");
        }
        public static string showGuessedLetters()
        {
            string totalLetters = "";
            foreach (char letter in guessedLetters) totalLetters += letter.ToString();
            return Regex.Replace(totalLetters, ".{1}", "$0 ");
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
            foreach (char letter in maskedWord())
            {
                if (letter == '_') areUnderscoresInWord = true;
            }
            if (areUnderscoresInWord == true) return false;
            return true;
        }
        #endregion
    }
}

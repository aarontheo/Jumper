using System;
using System.Collections.Generic;

namespace Jumper
{
    public class WordBank
    {
        private static Random rnGenerator = new Random();
        private List<String> words;
        public WordBank(String path)
        {
            var logFile = System.IO.File.ReadAllLines(path);
            words = new List<string>(logFile);
        }
        /// <summary>
        /// 'serves' a random word from the bank, 
        /// removing it from the words list to prevent duplicates later.
        /// </summary>
        /// <returns>A randomly selected word from the words list</returns>
        public String ServeWord()
        {
            String word = this.words[rnGenerator.Next(words.Count)];
            words.Remove(word);
            return word;
        }
    }
}

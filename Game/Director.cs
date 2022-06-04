using System;
using System.Collections.Generic;

namespace Jumper
{
    public class Director
    {
        public int score;
        public int fails;
        public int lives;
        private WordBank wordlist;
        private String currentWord;
        private List<Char> correctGuesses;
        private List<Char> wrongGuesses;
        private List<Boolean> hiddenLetters; //which letter positions are hidden
        /// <summary>
        /// Creates a new Director.
        /// </summary>
        /// <param name="wordPath">filepath to the list of words to be  drawn from</param>
        /// <param name="lives">the number of lives the player is given</param>
        public Director(String wordPath, int lives = 5)
        {
            wordlist = new WordBank(wordPath);
            this.lives = lives;
            correctGuesses = new List<char>();
            wrongGuesses = new List<char>();
            hiddenLetters = new List<bool>();
        }

        public void nextWord()
        {
            this.currentWord = wordlist.ServeWord();
            Console.WriteLine("DEBUG: "+currentWord);
            hiddenLetters.Clear();
            wrongGuesses.Clear();
            correctGuesses.Clear();
            for (int i = 0; i < currentWord.Length;i++)
            {
                hiddenLetters.Add(false);
            }
        }
        /// <summary>
        /// draws the game for every step, in the following order from top to bottom:
        /// Score, Lives
        /// Draw the jumper
        /// Display the word, with a space between all letters, replacing unguessed characters
        /// </summary>
        public void DrawGame()
        {
            Console.Clear();
            Console.WriteLine($"Score: {score}\nLives: {lives}");
            Jumper.DrawLines(fails);
            //draw the word
            Console.WriteLine(currentWord);
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (hiddenLetters[i]) //if the letter has been guessed
                {
                    Console.Write($"{currentWord[i]} ".ToUpper());
                }else{
                    Console.Write("_ ");
                }
            }
            Console.Write('\n');
        }

        public void Debug()
        {
            foreach (var c in hiddenLetters){
                Console.Write(c);
            }
            Console.WriteLine();
            foreach (var c in correctGuesses){
                Console.Write(c);
            }
            Console.WriteLine();
            foreach (var c in wrongGuesses){
                Console.Write(c);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Prompts the user for the next letter,
        /// and returns true if all letters have been guessed
        /// </summary>
        public bool Guess()
        {
            Char letter = '_';
            while (true) //guarantee that the letter has not been guessed
            {
                letter = Getter.GetChar();
                if (!wrongGuesses.Contains(letter) || !correctGuesses.Contains(letter))
                {
                    break;
                }
            }
            if (currentWord.Contains(letter))
            {
                for (int i = 0; i < currentWord.Length;i++)
                {
                    if (letter == currentWord[i])
                    {
                        hiddenLetters[i] = true;
                        correctGuesses.Add(letter);
                        score++;
                    }
                }
                if(correctGuesses.Count == currentWord.Length)
                {
                    return true;
                }
            }else{
                wrongGuesses.Add(letter);
                fails++;
                lives--;
            }
            return false;
        }
    }
}

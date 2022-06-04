using System;

namespace Jumper
{
    class Program
    {
        const String VOCAB_PATH = @"wordlist.txt";
        static void Main(string[] args)
        {
            Director director = new Director(VOCAB_PATH);
            while(director.lives > 0) //run a new round until the user says no more
            {
                director.nextWord();
                bool win = false;
                while(!win)
                {
                    director.DrawGame();
                    //director.Debug(); //a function that prints the contents of all the director's lists
                    win = director.Guess();
                    if (director.lives <= 0)
                    {
                        Console.WriteLine("You lose!");
                        break;
                    }
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}
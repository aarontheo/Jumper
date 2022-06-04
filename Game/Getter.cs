using System;

namespace Jumper
{
    public static class Getter
    {
        private static Char letter;
        public static Char GetChar(String Prompt = "",String FailMsg = "Please enter a single character!")
        {
            Console.Write(Prompt);
            while (!char.TryParse(Console.ReadLine(), out letter)) 
            {
                Console.WriteLine(FailMsg);
            }
            return letter;
        }
    }
}

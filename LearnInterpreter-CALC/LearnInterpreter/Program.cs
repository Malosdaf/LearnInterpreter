using System;

namespace LearnInterpreter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.BackgroundColor =ConsoleColor.Red;
            Interpreter Casiofx680 = new Interpreter(new Lexer(Console.ReadLine()));
            Console.WriteLine(Casiofx680.Evaluate());
        }
    }
}

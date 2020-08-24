using System;

namespace CSInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Event.ValueEvent();
            // x.MyValue = 12;
            int a = x.CompareTo(3);
            // Lexer lexer = new Lexer("( #4.39.1078.3.1 freq:10:999:1296000000 ) OU ( #4.39.1078.4.1 freq:10:999:1296000000 ) OU ( #4.39.1078.8.0 freq:10:999:1296000000 ) OU ( #4.39.1078.8.2 freq:5:999:604800000 ) OU ( #4.82.1078.4.1 freq:10:999:1296000000 ) OU ( #4.82.1078.3.1 freq:10:999:1296000000 ) tti:0");
            // Parser parser = new Parser(lexer);
            // IAST x = parser.Parse();
            // Interpreter interpreter = new Interpreter(parser);
            // int result = interpreter.Interpret();
            // Console.WriteLine("Result: " + result);
        }
    }
}
using System;

namespace CSInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            // var x = new Event.ValueEvent();
            // x.MyValue = 12;
            // int a = x.CompareTo(3);
            Lexer lexer = new Lexer("( #4.113.1870.3.2 freq:5:999:604800000 ) tti:0");
            Parser parser = new Parser(lexer);
            IAST x = parser.Parse();
            // Interpreter interpreter = new Interpreter(parser);
            // int result = interpreter.Interpret();
            // Console.WriteLine("Result: " + result);
        }
    }
}
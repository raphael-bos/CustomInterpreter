using System;

namespace CSInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("(4)*-(2+(1+13*2))");
            Parser parser = new Parser(lexer);
            Interpreter interpreter = new Interpreter(parser);
            int result = interpreter.Interpret();
            Console.WriteLine("Result: " + result);
        }
    }
}
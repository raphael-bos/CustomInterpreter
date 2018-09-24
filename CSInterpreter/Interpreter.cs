using System;
using System.Linq;

namespace CSInterpreter
{
    //Simple Interpreter
    // Test
    class Interpreter
    {
        public Interpreter(Parser parser)
        {
            this._parser = parser;
            this._visitor = new TreeVisitor();
        }
        private Parser _parser;
        private TreeVisitor _visitor;
        private int visit(IAST tree)
        {
            return 0;
        }       
        public int Interpret()
        {
            IAST tree = this._parser.Parse();
            IAST result = this._visitor.Visit(tree);
            return result.Token.Value;
        }
    }
    class TreeVisitor : ITreeVisitor
    {
        public IAST Visit (IAST tree)
        {
            return tree.Accept(this);
        }
        public IAST Visit(BinOp binOp)
        {
            if(binOp.Token.Type == TokenType.PLUS)
                return new Num( new Token(TokenType.INTEGER, binOp.Left.Accept(this).Token.Value 
                + binOp.Rigth.Accept(this).Token.Value));
            else if(binOp.Token.Type == TokenType.MINUS)
                return new Num( new Token(TokenType.INTEGER, binOp.Left.Accept(this).Token.Value 
                - binOp.Rigth.Accept(this).Token.Value));
            else if(binOp.Token.Type == TokenType.MUL)
                return new Num( new Token(TokenType.INTEGER, binOp.Left.Accept(this).Token.Value 
                * binOp.Rigth.Accept(this).Token.Value));
            else return new Num( new Token(TokenType.INTEGER, binOp.Left.Accept(this).Token.Value 
                / binOp.Rigth.Accept(this).Token.Value));
        }
        public IAST Visit(Num num)
        {
            return num;
        }
    }

}
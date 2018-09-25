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
            IAST result = this._visitor.ReduceTree(tree);
            return result.Token.Value;
        }
    }
    class TreeVisitor : ITreeVisitor
    {
        private IAST reducedTree;
        public IAST ReduceTree(IAST tree)
        {
            tree.Accept(this);
            return reducedTree;
        }
        public void Visit(BinOp binOp)
        {
            if(binOp.Token.Type == TokenType.PLUS)
                reducedTree = new Num( new Token(TokenType.INTEGER, this.ReduceTree(binOp.Left).Token.Value 
                + this.ReduceTree(binOp.Rigth).Token.Value));
            else if(binOp.Token.Type == TokenType.MINUS)
                reducedTree = new Num( new Token(TokenType.INTEGER, this.ReduceTree(binOp.Left).Token.Value 
                - this.ReduceTree(binOp.Rigth).Token.Value));
            else if(binOp.Token.Type == TokenType.MUL)
                reducedTree = new Num( new Token(TokenType.INTEGER, this.ReduceTree(binOp.Left).Token.Value 
                * this.ReduceTree(binOp.Rigth).Token.Value));
            else if(binOp.Token.Type == TokenType.DIV)
                reducedTree = new Num( new Token(TokenType.INTEGER, this.ReduceTree(binOp.Left).Token.Value 
                / this.ReduceTree(binOp.Rigth).Token.Value));
        }
        public void Visit(Num num)
        {
            reducedTree = num;
        }
    }

}
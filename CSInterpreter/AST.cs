using System;

namespace CSInterpreter
{
    //Abstract Syntax Tree
    //Visitor Desing Pattern
    interface IAST
    {
        Token Token { get; set; }
        IAST Accept(ITreeVisitor visitor);
    }
    interface ITreeVisitor
    {
        IAST Visit(BinOp binOp);
        IAST Visit(Num num);
    }
    //Binary Operators
    class BinOp : IAST
    {
        public BinOp(IAST left, Token token, IAST rigth)
        {
            this.Left = left;
            this.Rigth = rigth;
            this.Token = token;
        }
        public IAST Accept(ITreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public Token Token { get; set;}
        public IAST Left {get ; set; }
        public IAST Rigth { get; set; }
    }

    class Num: IAST
    {
        public Num (Token token)
        {
            this.Token = token;
        }        
        public IAST Accept(ITreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public Token Token { get; set; }
    }
}
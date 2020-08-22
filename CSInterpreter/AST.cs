using System;

namespace CSInterpreter
{
    //Abstract Syntax Tree
    //Visitor Desing Pattern
    interface IAST
    {
        Token Token { get; set; }
        void Accept(ITreeVisitor visitor);
    }
    interface ITreeVisitor
    {
        void Visit(BinOp binOp);
        void Visit(Num num);
        void Visit (EndpointOp endpoint);
        void Visit (StringOperand stringOperand);
        void Visit(FreqOperator freOperator);
        void Visit(TTIOperator ttiOperator);
        void Visit(IntervalOperator intervalOperator);
        void Visit(EOperator eOperator);
        void Visit(OROperator orOperator);
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
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Token Token { get; set;}
        public IAST Left {get ; set; }
        public IAST Rigth { get; set; }
    }
}
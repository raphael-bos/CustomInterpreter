using System;
using System.Linq;

namespace CSInterpreter
{
    class IntervalOperator: IAST
    {
        public IntervalOperator (IAST operand, Token token)
        {
            this.Token = token;
            this.Operand = operand;
        }        
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Token Token { get; set; }
        public IAST Operand { get; set; }
    }
}
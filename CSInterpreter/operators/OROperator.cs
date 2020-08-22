using System;
using System.Linq;

namespace CSInterpreter
{
    class OROperator: IAST
    {
        public OROperator (IAST op1, Token token, IAST op2)
        {
            this.Token = token;
            this.op1 = op1;
            this.op2 = op2;
        }        
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Token Token { get; set; }
        public IAST op1 { get; set; }
        public IAST op2 { get; set; }
    }
}
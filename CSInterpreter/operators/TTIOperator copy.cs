using System;
using System.Linq;

namespace CSInterpreter
{
    class TTIOperator: IAST
    {
        public TTIOperator (IAST operand, Token token)
        {
            this.Token = token;
            this.operand = operand;
        }        
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Token Token { get; set; }
        public IAST operand {get; set; }
    }
}
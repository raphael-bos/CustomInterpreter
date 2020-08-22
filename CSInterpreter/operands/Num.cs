using System;
using System.Linq;

namespace CSInterpreter
{
    class Num: IAST
    {
        public Num (Token token)
        {
            this.Token = token;
        }        
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Token Token { get; set; }
    }
}
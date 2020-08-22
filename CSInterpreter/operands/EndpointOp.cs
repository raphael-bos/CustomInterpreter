using System;
using System.Linq;

namespace CSInterpreter
{
    class EndpointOp: IAST
    {
        public EndpointOp (Token token)
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
using System;

namespace CSInterpreter
{
    class Token
    {
        public Token(TokenType type, char? value)
        {
            this.Type = type;
            this.CharValue = value;
        }
        public Token(TokenType type, int value)
        {
            this.Type = type;
            this.Value = value;
        }
        public TokenType Type { get; set; }
        public char? CharValue { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            if(this.CharValue.HasValue)
                return string.Format("Token({0},{1})",this.Type,this.CharValue);
            return string.Format("Token({0},{1})",this.Type,this.Value);
        }
    }
}
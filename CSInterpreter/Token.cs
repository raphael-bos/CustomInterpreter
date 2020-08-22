using System;

namespace CSInterpreter
{
    class Token
    {
        public Token(TokenType type, int value)
        {
            this.Type = type;
            this.Value = value;
        }
        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.StringValue = value;
        }
        public Token(TokenType type, bool value)
        {
            this.Type = type;
            this.BoolValue = value;
        }
        public TokenType Type { get; set; }
        public int Value { get; set; }
        public string StringValue { get; set; }
        public bool BoolValue {get; set; }

        public override string ToString()
        {
            return string.Format("Token({0},{1})",this.Type,this.Value);
        }
    }
}
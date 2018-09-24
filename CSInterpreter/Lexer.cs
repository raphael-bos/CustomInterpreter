using System;

namespace CSInterpreter
{
    class Lexer
    {
        public Lexer(string text)
        {
            this._text = text;
            this._pos = 0;
            this._currentChar = this._text[this._pos];
        }
        private string _text { get; set; }
        private int _pos { get; set; }
        private char? _currentChar { get; set; }

        private Exception error()
        {
            return new Exception("Error parsing input");
        }
        private void advance()
        {
            this._pos++;
            if(this._pos > this._text.Length - 1)
                this._currentChar = null;
            else this._currentChar = this._text[this._pos];
        }
        private void skipWhiteSpace()
        {
            while(this._currentChar.HasValue && char.IsWhiteSpace(this._currentChar.Value))
                this.advance();
        }
        private int Integer()
        {
            string result = "";
            while(this._currentChar.HasValue && char.IsDigit(this._currentChar.Value))
            {
                result += this._currentChar;
                this.advance();
            }
            return int.Parse(result);
        }
        public Token GetNextToken()
        {

            while(this._currentChar.HasValue)
            {
                if(char.IsWhiteSpace(this._currentChar.Value))
                {
                    this.skipWhiteSpace();
                    continue;
                }
                if(char.IsDigit(this._currentChar.Value))
                {
                    return new Token(TokenType.INTEGER, this.Integer());
                }
                if(this._currentChar.Value == '+')
                {
                    this.advance();
                    return new Token(TokenType.PLUS, (char?) '+');
                }
                if(this._currentChar.Value == '-')
                {
                    this.advance();
                    return new Token(TokenType.MINUS, (char?) '-');
                }
                if(this._currentChar.Value == '*')
                {
                    this.advance();
                    return new Token(TokenType.MUL, (char?) '*');
                }
                if(this._currentChar.Value == '/')
                {
                    this.advance();
                    return new Token(TokenType.DIV, (char?) '/');
                }

                if(this._currentChar.Value == '(')
                {
                    this.advance();
                    return new Token(TokenType.LPAREN, (char?) '(');
                }

                if(this._currentChar.Value == ')')
                {
                    this.advance();
                    return new Token(TokenType.RPAREN, (char?) ')');
                }
                throw this.error();
            }
            return new Token(TokenType.EOF,null);
        }
    }
}
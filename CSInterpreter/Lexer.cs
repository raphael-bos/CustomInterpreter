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
            return new Exception(string.Format("Error parsing input at position: {0}", this._pos));
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
        private string StringContent()
        {
            string result = "";
            this.advance();
            while(this._currentChar.HasValue && this._currentChar.Value != '\'')
            {
                result += this._currentChar;
                this.advance();
            }
            this.advance();
            return result;
        }
        private string StringOperator()
        {
            string result = "";
            while(this._currentChar.HasValue && (char.IsLetterOrDigit(this._currentChar.Value) || this._currentChar.Value == ':'))
            {
                result += this._currentChar;
                this.advance();
            }
            return result;
        }
        private string Endpoint()
        {
            string result = "";
            while(this._currentChar.HasValue && (char.IsLetterOrDigit(this._currentChar.Value) || this._currentChar.Value == '.'))
            {
                result += this._currentChar;
                this.advance();
            }
            return result;   
        }
        private Token GetTokenFromReservedKeyword(string keyword)
        {
            if(keyword.StartsWith("freq:"))
            {
                return new Token(TokenType.FREQ, keyword);
            }
            if(keyword == "E" )
            {
                return new Token(TokenType.E, keyword);
            }
            if(keyword == "OU")
            {
                return new Token(TokenType.OU, keyword);
            }
            if(keyword.StartsWith("interval:"))
            {
                return new Token(TokenType.INTERVAL, keyword);
            }
            if(keyword.StartsWith("tti:"))
            {
                return new Token(TokenType.TTI, keyword);
            }
            throw new Exception(string.Format("Keyword not recognized: '{0}'", keyword));
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
                if(this._currentChar.Value == '(')
                {
                    this.advance();
                    return new Token(TokenType.LPAREN, "(");
                }
                if(this._currentChar.Value == ')')
                {
                    this.advance();
                    return new Token(TokenType.RPAREN, ")");
                }
                if(this._currentChar.Value == '\'')
                {
                    this.advance();
                    return new Token(TokenType.STRING, this.StringContent());
                }
                if(this._currentChar.Value == '#')
                {
                    this.advance();
                    return new Token(TokenType.ENDPOINT, this.Endpoint());
                }
                if(char.IsLetter(this._currentChar.Value))
                {
                    Token token = this.GetTokenFromReservedKeyword(this.StringOperator());
                    return token;
                }
                throw this.error();
            }
            return new Token(TokenType.EOF, null);
        }
    }
}
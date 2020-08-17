using System;
using System.Linq;

namespace CSInterpreter
{
    class Parser
    {
        public Parser(Lexer lexer)
        {
            this._lexer = lexer;
            this._currentToken = lexer.GetNextToken();
        }
        public IAST Parse()
        {
            return this.expr();
        }
        private Lexer _lexer;
        private Token _currentToken;
        private void eat(TokenType type)
        {
            if(this._currentToken.Type == type)
                this._currentToken = this._lexer.GetNextToken();
            else
                throw this.error();
        }

        private Exception error()
        {
            return new Exception("Ivalid syntax.");
        }
        //Listando operandos em order de prioridade decrescente

        // Operando da multiplicacao/divisao
        // factor : Integer
        private IAST factor()
        {
            IAST node;
            Token token = this._currentToken;
            if(token.Type == TokenType.INTEGER)
            {
                this.eat(TokenType.INTEGER);
                node = new Num(token);
            }
            else
            {
                this.eat(TokenType.LPAREN);
                node = this.expr();
                this.eat(TokenType.RPAREN);
            }
            return node;
        }
        //Operando da soma/subtracao
        //term : factor((MUL|DIV)factor)*
        private IAST term()
        {
            IAST node = this.factor();
            while(new TokenType[]{TokenType.MUL, TokenType.DIV}.Contains(this._currentToken.Type))
            {
                Token token = this._currentToken;
                if(token.Type == TokenType.MUL)
                {
                    this.eat(TokenType.MUL);
                }
                else if(token.Type == TokenType.DIV)
                {
                    this.eat(TokenType.DIV);
                }
                node = new BinOp(node, token, this.factor());
            }
            return node;
        }
        //Expressao Final
        //expr : term((PLUS|MINUS)term)*
        private IAST expr()
        {
            IAST node = this.term();

            while(new TokenType[]{TokenType.PLUS,TokenType.MINUS}.Contains(this._currentToken.Type))
            {
                Token token = this._currentToken;

                if(token.Type == TokenType.PLUS)
                {
                    this.eat(TokenType.PLUS);
                }
                else if(token.Type == TokenType.MINUS)
                {
                    this.eat(TokenType.MINUS);
                }
                node = new BinOp(node, token, this.term());
            }
            return node;
        }
    }
}
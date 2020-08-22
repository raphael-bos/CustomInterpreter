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
        private IAST operand()
        {
            IAST node;
            Token token = this._currentToken;
            if(token.Type == TokenType.ENDPOINT)
            {
                this.eat(TokenType.ENDPOINT);
                node = new EndpointOp(token);
            }
            else if(token.Type == TokenType.STRING)
            {
                this.eat(TokenType.STRING);
                node = new StringOperand(token);
            }
            else if(token.Type == TokenType.NUMBER)
            {
                this.eat(TokenType.NUMBER);
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
        private IAST get_operator(IAST operand)
        {
            IAST node;
            Token token = this._currentToken;
            if(token.Type == TokenType.FREQ)
            {
                this.eat(TokenType.FREQ);
                node = new FreqOperator(operand, token);
            }
            else if(token.Type == TokenType.TTI)
            {
                this.eat(TokenType.TTI);
                node = new TTIOperator(operand, token);
            }
            else if(token.Type == TokenType.INTERVAL)
            {
                this.eat(TokenType.INTERVAL);
                node = new IntervalOperator(operand, token);
            }
            else if (token.Type == TokenType.E)
            {
                this.eat(TokenType.E);
                node = new EOperator(operand, token, this.operand());
            }
            else
            {
                this.eat(TokenType.OU);
                node = new OROperator(operand, token, this.operand());
            }
            return node;
        }
        //Expressao Final
        //expr : term((PLUS|MINUS)term)*
        private IAST expr()
        {
            IAST node = this.operand();
            while(this.isOperatorToken(this._currentToken.Type))
            {
                node = this.get_operator(node);
            }
            return node;
        }

        private bool isOperatorToken(TokenType type)
        {
            switch (type)
            {
                case TokenType.FREQ: return true;
                case TokenType.TTI: return true;
                case TokenType.INTERVAL: return true;
                case TokenType.E: return true;
                case TokenType.OU: return true;
                default: return false;
            }
        }
    }
}
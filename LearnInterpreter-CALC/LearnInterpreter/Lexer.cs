using System;

namespace LearnInterpreter
{
    public class Lexer
    {
        private string text;
        private char? currentChar;

        private int readPosition;

        public Lexer(string text)
        {
            this.text = text;
            currentChar = text[readPosition];
        }

        public Token NextToken()
        {
            while (currentChar != null) //if isn't EOF
            {
                if (currentChar == ' ')
                {
                    SkipWhitespace();
                    continue;
                }

                if (currentChar.IsDigit())
                {
                    return new Token(TokenType.Integer, Integer());
                }

                if (currentChar == '+')
                {
                    Advance();
                    return new Token(TokenType.Plus, "+");
                }

                if (currentChar == '-')
                {
                    Advance();
                    return new Token(TokenType.Minus, "-");
                }

                if (currentChar == '*')
                {
                    Advance();
                    return new Token(TokenType.Mult, "*");
                }

                if (currentChar == '/')
                {
                    Advance();
                    return new Token(TokenType.Div, "/");
                }

                if (currentChar == '(')
                {
                    Advance();
                    return new Token(TokenType.LeftParen, "(");
                }

                if (currentChar == ')')
                {
                    Advance();
                    return new Token(TokenType.RightParen, ")");
                }
                throw new Exception("Invalid syntax!");
            }

            return new Token(TokenType.Eof, string.Empty);
        }

        private void Advance()
        {
            readPosition++;
            if (readPosition >= text.Length)
                currentChar = null;
            else
                currentChar = text[readPosition];
        }

        private void SkipWhitespace()
        {
            while (currentChar != null && currentChar == ' ')
            {
                Advance();
            }
        }

        private string Integer()
        {
            string str = string.Empty;
            while (currentChar != null && currentChar.IsDigit())
            {
                str += currentChar;
                Advance();
            }

            return str;
        }
    }
}

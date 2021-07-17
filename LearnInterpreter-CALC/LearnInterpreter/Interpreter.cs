using System;

namespace LearnInterpreter
{
    public class Interpreter
    {
        private Lexer lexer;

        private Token currentToken;

        public Interpreter(Lexer lexer)
        {
            this.lexer = lexer;
            currentToken = lexer.NextToken();
        }

        private void Eat(TokenType tokenType)
        {
            if (tokenType == currentToken.TokenType)
                currentToken = lexer.NextToken();
            else
                throw new Exception($"Expected {tokenType}, got {currentToken.TokenType}");
        }

        private Node Factor()
        {
            // Factor : Float | LeftParen Expr RightParen

            Token token = currentToken;

            if (currentToken.TokenType == TokenType.LeftParen)
            {
                Eat(TokenType.LeftParen);
                Node node = Expr();
                Eat(TokenType.RightParen);

                return node;
            }

            if (currentToken.TokenType == TokenType.Integer)
            {
                Eat(TokenType.Integer);
                return new Node(token);
            }

            if (currentToken.TokenType == TokenType.Plus || currentToken.TokenType == TokenType.Minus)
            {
                Eat(currentToken.TokenType);
                return new UnaryOp(token, Factor());
            }

            throw new Exception();
        }

        private Node Term()
        {
            // Term : Factor ((Plus | Minus) Factor)*

            Node node = Factor();

            while (currentToken.TokenType == TokenType.Mult || currentToken.TokenType == TokenType.Div)
            {
                Token token = currentToken;
                if (token.TokenType == TokenType.Mult)
                {
                    Eat(TokenType.Mult);
                }

                if (token.TokenType == TokenType.Div)
                {
                    Eat(TokenType.Div);
                }

                node = new BinOp(token, node, Factor());
            }

            return node;
        }

        private Node Expr()
        {
            // Expr : Term ((Plus | Minus) Term)*

            Node node = Term();

            while (currentToken.TokenType == TokenType.Plus || currentToken.TokenType == TokenType.Minus)
            {
                Token token = currentToken;
                if (token.TokenType == TokenType.Plus)
                {
                    Eat(TokenType.Plus);
                }

                if (token.TokenType == TokenType.Minus)
                {
                    Eat(TokenType.Minus);
                }

                node = new BinOp(token, node, Term());
            }

            return node;
        }

        public float Evaluate()
        {
            AbstractSyntaxTree ast = new AbstractSyntaxTree(Expr());

            return Visit(ast.RootNode);
        }

        private float Visit(Node node)
        {
            if (node is BinOp)
            {
                BinOp op = (BinOp)node;

                float left = Visit(op.Left);
                float right = Visit(op.Right);

                switch (op.Token.TokenType)
                {
                    case TokenType.Plus:
                        return left + right;
                    case TokenType.Minus:
                        return left - right;
                    case TokenType.Mult:
                        return left * right;
                    case TokenType.Div:
                        return left / right;
                }

                throw new Exception();
            }
            else if (node is UnaryOp)
            {
                UnaryOp op = (UnaryOp)node;

                switch (node.Token.TokenType)
                {
                    case TokenType.Plus:
                        return Visit(op.Expr);
                    case TokenType.Minus:
                        return -Visit(op.Expr);
                }

                throw new Exception();
            }
            else
            {
                return node.Token.AsFloat();
            }
        }
    }
}

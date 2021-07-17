using System;
using System.Collections.Generic;
using System.Text;

namespace LearnInterpreter
{
    public class UnaryOp : Node
    {
        public Node Expr => _expr;

        private Node _expr;

        public UnaryOp(Token token, Node expr) : base(token)
        {
            _expr = expr;
        }
    }
}

namespace LearnInterpreter
{
    public class BinOp : Node
    {
        public Node Left => _left;
        public Node Right => _right;

        private Node _left;
        private Node _right;

        public BinOp(Token op, Node left, Node right) : base(op)
        {
            _left = left;
            _right = right;
        }
    }
}

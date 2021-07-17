namespace LearnInterpreter
{
    public class Node
    {
        public Token Token => _token;

        private Token _token;

        public Node(Token token)
        {
            _token = token;
        }
    }
}

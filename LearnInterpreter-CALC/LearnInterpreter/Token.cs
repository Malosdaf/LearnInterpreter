namespace LearnInterpreter
{
    public enum TokenType
    {
        Eof = 0,
        Integer = 1,
        Plus = 2,
        Minus = 3,
        Mult = 4,
        Div = 5,
        LeftParen = 6,
        RightParen = 7
    }

    public class Token
    {
        public TokenType TokenType => _tokenType;
        public string Value => _value;

        private TokenType _tokenType;
        private string _value;

        public Token(TokenType tokenType, string value)
        {
            _tokenType = tokenType;
            _value = value;
        }

        public int AsInteger()
        {
            return int.Parse(_value);
        }

        public float AsFloat()
        {
            return float.Parse(_value);
        }

        public override string ToString()
        {
            return $"Token({_tokenType}, {_value})";
        }
    }
}

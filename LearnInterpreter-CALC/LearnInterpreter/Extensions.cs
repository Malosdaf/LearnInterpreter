namespace LearnInterpreter
{
    public static class Extensions
    {
        public static bool IsDigit(this char? c)
        {
            return c >= '0' && c <= '9';
        }
    }
}

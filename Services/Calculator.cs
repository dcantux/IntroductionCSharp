namespace IntroductionCSharp.Services
{
    public class Calculator
    {
        int _number_one;
        int _number_two;
        int _result;

        public void SetNumberOne(int number)
        {
            _number_one = number;
        }

        public void SetNumberTwo(int number)
        {
            _number_two = number;
        }

        public void Add()
        {
            _result = _number_one + _number_two;
        }

        public int GetResult()
        {
            return _result;
        }

    }
}

using FluentAssertions;
using IntroductionCSharp.Services;
using TechTalk.SpecFlow;

namespace IntroductionCSharp.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculator _calc;

        public CalculatorStepDefinitions()
        {
            _calc = new Calculator();
        }

        [Given("I have entered (.*) in the calculator")]
        public void AddNumberOne(int number)
        {
            _calc.SetNumberOne(number);
        }

        [Given("I have entered (.*) into the calculator")]
        public void AddNumberTwo(int number)
        {
            _calc.SetNumberTwo(number);
        }

        [When("I press add")]
        public void PressAdd()
        {
            _calc.Add();
        }

        [Then("the result should be (.*) on the screen")]
        public void CompareResultWithExpected(int expectedResult)
        {
            var actualResult = _calc.GetResult();

            expectedResult.Should().Be(actualResult);
        }

    }
}

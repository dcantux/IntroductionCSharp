using Allure.Net.Commons;
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
        public void GivenTheFirstNumberIs(int number)
        {
            AllureApi.SetStepName("I have entered " + number + " in the calculator");

            _calc.SetNumberOne(number);
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calc.SetNumberTwo(number);
        }

        [When("I press add")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calc.Add();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            var actualResult = _calc.GetResult();

            expectedResult.Should().Be(actualResult);
        }

    }
}

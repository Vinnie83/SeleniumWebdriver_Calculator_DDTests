using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDriverWebdriverTests
{
    public class DataDrivenTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("10");

            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("+");

            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("5");

            var calcButton = driver.FindElement(By.Id("calcButton"));

            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 15";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("-10");

            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("+");

            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("-4");

            var calcButton = driver.FindElement(By.Id("calcButton"));

            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: -14";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("10");

            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("*");

            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("2");

            var calcButton = driver.FindElement(By.Id("calcButton"));

            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 20";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("-8");

            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("*");

            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("-5");

            var calcButton = driver.FindElement(By.Id("calcButton"));

            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 40";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }


        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("6");

            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("-");

            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("5");

            var calcButton = driver.FindElement(By.Id("calcButton"));

            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 1";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
    }
}
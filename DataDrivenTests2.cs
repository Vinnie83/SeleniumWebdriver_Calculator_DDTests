using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDriverWebdriverTests
{
    public class DataDrivenTests2
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        IWebElement firstInput;
        IWebElement operationField;
        IWebElement secondInput;
        IWebElement calcButton;
        IWebElement resultField;
        IWebElement resetButton;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;

            firstInput = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
            secondInput = driver.FindElement(By.Id("number2"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            resetButton = driver.FindElement(By.Id("resetButton"));

        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            resetButton.Click();    

            firstInput.SendKeys("10");

            operationField.SendKeys("+");

            secondInput.SendKeys("5");

            calcButton.Click();

            var expectedResult = "Result: 15";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            resetButton.Click();

            firstInput.SendKeys("-10");

            operationField.SendKeys("+");

            secondInput.SendKeys("-4");

            calcButton.Click();

            var expectedResult = "Result: -14";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            resetButton.Click();

            firstInput.SendKeys("10");

            operationField.SendKeys("*");

            secondInput.SendKeys("2");

            calcButton.Click();

            var expectedResult = "Result: 20";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            resetButton.Click();

            firstInput.SendKeys("-8");

            operationField.SendKeys("*");

            secondInput.SendKeys("-5");

            calcButton.Click();

            var expectedResult = "Result: 40";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }


        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            resetButton.Click();

            firstInput.SendKeys("6");

            operationField.SendKeys("-");

            secondInput.SendKeys("5");

            calcButton.Click();

            var expectedResult = "Result: 1";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
    }
}
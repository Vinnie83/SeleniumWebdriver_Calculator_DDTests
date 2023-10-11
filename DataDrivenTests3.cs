using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDriverWebdriverTests
{
    public class DataDrivenTests3
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private ChromeOptions options;

        IWebElement firstInput;
        IWebElement operationField;
        IWebElement secondInput;
        IWebElement calcButton;
        IWebElement resultField;
        IWebElement resetButton;
   

        [OneTimeSetUp]
        public void Setup()
        {

            options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
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

        [TestCase("10","+","5", "Result: 15")]
        [TestCase("-10","+","-4", "Result: -14")]
        [TestCase("10","*","2", "Result: 20")]
        [TestCase("10","*","2", "Result: 20")]
        [TestCase("-8","*","-5", "Result: 40")]
        [TestCase("-8","*","-5", "Result: 40")]
        [TestCase("6","-","5", "Result: 1")]
        [TestCase("10","-","bbbb", "Result: invalid input")]
        public void Test_Calculator(string firstNum, string operation, string secondNum, string expectedResult)
        {
            resetButton.Click();    

            firstInput.SendKeys(firstNum);

            operationField.SendKeys(operation);

            secondInput.SendKeys(secondNum);

            calcButton.Click();

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }    
  
    }
  
}
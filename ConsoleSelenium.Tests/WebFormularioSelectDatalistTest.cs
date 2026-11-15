using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests;

[TestClass]
public class WebFormularioSelectDatalistTest
{
    private const string Url = "https://www.selenium.dev/selenium/web/web-form.html";
    private IWebDriver _driver = null!;

    [TestInitialize]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.Navigate().GoToUrl(Url);
    }

    [TestCleanup]
    public void Teardown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [TestMethod]
    public void Exercicio2_SelectEDatalist()
    {
        // 1. Dropdown (select) com SelectElement
        var select = new SelectElement(_driver.FindElement(By.Name("my-select")));
        select.SelectByText("Two");

        // 2. Valida que a opção selecionada tem value = 2
        Assert.AreEqual("2", select.SelectedOption.GetAttribute("value"));

        // 3. Dropdown (datalist): basta digitar o texto no input
        _driver.FindElement(By.Name("my-datalist")).SendKeys("Seattle");

        // 4. Envia o formulário; a página de sucesso confirma que não houve exceções
        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        var mensagem = _driver.FindElement(By.Id("message")).Text;
        Assert.AreEqual("Received!", mensagem);
    }
}
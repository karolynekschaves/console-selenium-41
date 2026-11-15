using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Tests;

[TestClass]
public class WebFormularioEstadosTest
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
    public void Exercicio3_CheckboxesRadiosEColorPicker()
    {
        // 1. Primeiro checkbox já marcado por padrão
        var check1 = _driver.FindElement(By.Id("my-check-1"));
        Assert.IsTrue(check1.Selected);

        // 2. Marca o segundo checkbox
        var check2 = _driver.FindElement(By.Id("my-check-2"));
        if (!check2.Selected) check2.Click();
        Assert.IsTrue(check2.Selected);

        // 3. Seleciona o segundo rádio
        var radio2 = _driver.FindElement(By.Id("my-radio-2"));
        radio2.Click();
        Assert.IsTrue(radio2.Selected);

        // 4. Color picker: SendKeys não funciona em input type=color,
        //    então o valor é definido via JavaScript, disparando os eventos
        var color = _driver.FindElement(By.Name("my-colors"));
        ((IJavaScriptExecutor)_driver).ExecuteScript(
            "arguments[0].value = arguments[1];" +
            "arguments[0].dispatchEvent(new Event('input', { bubbles: true }));" +
            "arguments[0].dispatchEvent(new Event('change', { bubbles: true }));",
            color, "#ff1493");
        Assert.AreEqual("#ff1493", color.GetAttribute("value"));

        // 5. Envia e valida o sucesso
        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        var mensagem = _driver.FindElement(By.Id("message")).Text;
        Assert.AreEqual("Received!", mensagem);
    }
}
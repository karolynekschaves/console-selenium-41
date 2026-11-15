using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Tests;

[TestClass]
public class WebFormularioCadastroTest
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
    public void Exercicio1_CadastroCompleto()
    {
        // 1 e 2. Text input com o nome completo
        _driver.FindElement(By.Name("my-text")).SendKeys("Karolyne S");

        // 3. Password com uma senha segura
        _driver.FindElement(By.Name("my-password")).SendKeys("S3nh@Segura#2026");

        // 4. Textarea com a descrição da experiência
        _driver.FindElement(By.Name("my-textarea"))
               .SendKeys("Experiência inicial com testes automatizados usando Selenium e MSTest.");

        // 5. Valida o valor padrão do input de leitura
        var readonlyInput = _driver.FindElement(By.Name("my-readonly"));
        Assert.AreEqual("Readonly input", readonlyInput.GetAttribute("value"));

        // 6. Submete e valida a página de sucesso
        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        var mensagem = _driver.FindElement(By.Id("message")).Text;
        Assert.AreEqual("Received!", mensagem);
    }
}
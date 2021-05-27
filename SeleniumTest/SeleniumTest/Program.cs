using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver(); 
            driver.Navigate().GoToUrl("https://localhost:44336/weatherforecast");
            driver.Navigate().GoToUrl("https://localhost:44378/");
            driver.Manage().Window.Maximize();
            IWebElement btnLog = driver.FindElement(By.Id("#log_in"));
            btnLog.Click();
            IWebElement inputUS = driver.FindElement(By.Id("userName"));
            inputUS.SendKeys("admin");
            IWebElement inputPas = driver.FindElement(By.Id("userPassword"));
            inputPas.SendKeys("admin");
            IWebElement btnSess = driver.FindElement(By.Id("btn_Sign"));
            btnSess.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnT = driver.FindElement(By.Id("#tables"));
            btnT.Click();
            IWebElement btnTabEl = driver.FindElement(By.LinkText("Curso"));
            btnTabEl.Click();

            IWebElement btnF = driver.FindElement(By.Id("#add_functions"));
            btnF.Click();
            IWebElement btnRP = driver.FindElement(By.LinkText("Curso"));
            btnRP.Click();
          
            IWebElement inputnameC = driver.FindElement(By.Id("nameC"));
            inputnameC.SendKeys("Informatica aplicada");
            IWebElement inputcodeC = driver.FindElement(By.Id("codeC"));
            inputcodeC.SendKeys("IF6002");
            IWebElement inputcreditsC = driver.FindElement(By.Id("creditsC"));
            inputcreditsC.SendKeys("4");
            IWebElement selectElement = driver.FindElement(By.Id("semesterC"));
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByText("2");
            IWebElement selectElementYear = driver.FindElement(By.Id("yearC"));
            var selectObjectY = new SelectElement(selectElementYear);
            selectObjectY.SelectByText("4");
            IWebElement btnRPC = driver.FindElement(By.Id("btn_register_curse"));
            btnRPC.Click();


            IWebElement btnT1 = driver.FindElement(By.Id("#tables"));
            btnT1.Click();
            IWebElement btnTabEl1 = driver.FindElement(By.LinkText("Curso"));
            btnTabEl1.Click();
            

            IWebElement btnUCR = driver.FindElement(By.LinkText("UCR"));
            btnUCR.Click();
            IWebElement btnsignoutadmin = driver.FindElement(By.Id("btn-sign_out_admin"));
            btnsignoutadmin.Click();

        }
    }
    }

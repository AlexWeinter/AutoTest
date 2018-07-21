using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace AutoTest
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        public Form1()
        {
            TopMost = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://google.com");

            IWebElement SearchInput = Browser.FindElement(By.Id("lst-ib"));
            SearchInput.SendKeys("Simbirsoft" + OpenQA.Selenium.Keys.Enter);
            List<IWebElement> elements = Browser.FindElements(By.CssSelector("#rso a")).ToList();
            string text = elements[0].Text;
            if (text.Equals("SimbirSoft: Создаем программное обеспечение для бизнеса"))
            {
                MessageBox.Show("Вы восхитительны, SimbirSoft #1", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("SimbirSoft не #1, а жаль(((", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }
    }
}

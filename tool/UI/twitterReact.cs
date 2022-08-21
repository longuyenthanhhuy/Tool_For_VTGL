using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool.UI
{
    public partial class twitterReact : Form
    {
        public twitterReact()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = t1.Text;
            string[] text1Arr = text1.Split('\n');
            string text2 = t2.Text;
            string[] text2Arr = text2.Split('\n');
           

            string text4 = t4.Text;
            string[] text4Arr = text4.Split('\n');
            string text5 = t5.Text;
            int count = 0;
            foreach (string item in text1Arr) 
            {
                ChromeDriverService cService = ChromeDriverService.CreateDefaultService();
                cService.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications");
                options.AddArguments("--disable-infobars");
                options.AddArguments("--disable-popup-blocking");
                options.AddExcludedArgument("enable-automation");
                options.AddArguments("--no-sandbox");
                options.AddArguments("--disable-dev-shm-usage");
                options.AddArguments("--user-data-dir="+text5);

                options.AddArguments("--profile-directory=" + item);


                IWebDriver brower = new ChromeDriver(cService, options);
                foreach (var lk in text4Arr)
                {
                    brower.Navigate().GoToUrl(lk);
                    Thread.Sleep(3000);
                    if (checkBox1.Checked)
                    {
                        try
                        {
                            brower.FindElement(By.CssSelector("[aria-expanded='false'][aria-label='Retweet']")).Click();
                            Thread.Sleep(500);
                            brower.FindElement(By.CssSelector("[role='menuitem'][tabindex='0']")).Click();


                        }
                        catch (Exception)
                        {


                        }
                    }
                    Thread.Sleep(500);
                    if (checkBox2.Checked)
                    {
                        try
                        {
                            brower.FindElement(By.CssSelector("[aria-label='Like'][role='button']")).Click();

                        }
                        catch (Exception)
                        {


                        }
                    }
                    Thread.Sleep(500);
                    if (checkBox3.Checked)
                    {
                        try
                        {
                            brower.FindElement(By.CssSelector("[class='public-DraftStyleDefault-block public-DraftStyleDefault-ltr']")).SendKeys(text2Arr[count]);
                            Thread.Sleep(1000);
                            brower.FindElement(By.XPath("//*[.=\"Reply\"]")).Click();

                            count++;
                        }
                        catch (Exception)
                        {


                        }

                        if (count == text2Arr.Length)
                        {
                            count = 1;
                        }


                    }
                    Thread.Sleep(500);
                    if (checkBox4.Checked)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            try
                            {
                                brower.FindElement(By.XPath("//*[.=\"Follow\"]")).Click();
                                Thread.Sleep(1000);
                                
                            }
                            catch (Exception)
                            {

                            }
                            
                        }

                    }
                    Random rnd = new Random();
                    int time = rnd.Next(500, 2000);
                    Thread.Sleep(time);
                }
                
                brower.Close();
                brower.Quit();
            }
            
        }
    }
}

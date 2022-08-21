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
                brower.Navigate().GoToUrl(text4);
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
                        brower.FindElement(By.CssSelector("[class='css-18t94o4 css-1dbjc4n r-l5o3uw r-42olwf r-sdzlij r-1phboty r-rs99b7 r-19u6a5r r-2yi16 r-1qi8awa r-1ny4l3l r-ymttw5 r-o7ynqc r-6416eg r-lrvibr']")).Click();

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
                   
                       
                        foreach (var fl in brower.FindElements(By.XPath("//*[.=\"Follow\"]")))
                     {
                            fl.Click();
                            Thread.Sleep(1000);
                        try
                        {
                            brower.FindElement(By.CssSelector("[data-testid='confirmationSheetCancel']")).Click();
                        }
                        catch (Exception)
                        {
                        }
                     }
                        
                   
                   

                }
                Random rnd = new Random();
                int time = rnd.Next(500, 5000);       
                Thread.Sleep(time);
                brower.Close();
                brower.Quit();
            }
            
        }
    }
}

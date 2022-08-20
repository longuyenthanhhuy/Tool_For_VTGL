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
    public partial class signForm : Form
    {
        public signForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// mảng chứa dữ liệu các text
            string text1 = t1.Text;
            string[] text1Arr = text1.Split('\n');
            string text2 = t2.Text;
            string[] text2Arr = text2.Split('\n');
            string text3 = t3.Text;
            string[] text3Arr = text3.Split('\n');
            string text4 = t4.Text;
            string[] text4Arr = text4.Split('\n');
            string text5 = t5.Text;
            string[] text5Arr = text5.Split('\n');

            string text6 = t6.Text;
            string[] text6Arr = text6.Split('\n');
            string text7 = t7.Text;
            string[] text7Arr = text7.Split('\n');
            string text8 = t8.Text;
            string[] text8Arr = text8.Split('\n');
            string text9 = t9.Text;
            string[] text9Arr = text9.Split('\n');
            string text10 = t10.Text;
            string[] text10Arr = text10.Split('\n');

            string pro = profile.Text;
            string[] profileArr = pro.Split('\n');
            ///////////////////////////////
            String linkt = link.Text;
            String e1t = e1.Text;
            String e2t = e2.Text;
            String e3t = e3.Text;
            String e4t = e4.Text;
            String e5t = e5.Text;
            String e6t = e6.Text;
            String e7t = e7.Text;
            String e8t = e8.Text;
            String e9t = e9.Text;
            String e10t = e10.Text;
            String s1t = s1.Text;


            int plus = 0;

            foreach (string item in profileArr)
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
                options.AddArguments("--user-data-dir=C:/Users/htlvn/AppData/Local/Google/Chrome/User Data/");

                options.AddArguments("--profile-directory=" + item);


                IWebDriver brower = new ChromeDriver(cService, options);
                brower.Navigate().GoToUrl(linkt);

                brower.FindElement(By.XPath(e1t)).SendKeys(text1Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e2t)).SendKeys(text2Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e3t)).SendKeys(text3Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e4t)).SendKeys(text4Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e5t)).SendKeys(text5Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e6t)).SendKeys(text6Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e7t)).SendKeys(text7Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e8t)).SendKeys(text8Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e9t)).SendKeys(text9Arr[plus]);
                Thread.Sleep(1000);

                brower.FindElement(By.XPath(e10t)).SendKeys(text10Arr[plus]);
                Thread.Sleep(1000);





                brower.FindElement(By.XPath(s1t)).Click();
                Thread.Sleep(1000);

                plus++;
                brower.Close();


            }
        }

        private void signForm_Load(object sender, EventArgs e)
        {

        }

        private void s1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

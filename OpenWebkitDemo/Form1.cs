using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKit.DOM;

namespace OpenWebkitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //webKitBrowser1.Navigate("http://www.baidu.com");

            string filePath = $"file:///{ AppDomain.CurrentDomain.BaseDirectory}test.html";

            filePath = filePath.Replace('\\', '/');

            //中文路径会有问题，需要转义
            webKitBrowser1.Navigate(filePath);
        }

        private void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webKitBrowser1.GetScriptManager.ScriptObject = new myClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                object[] objects = new object[1];
                objects[0] = "你好啊";
                webKitBrowser1.GetScriptManager.CallFunction("showMsg", objects);
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             string val1 = webKitBrowser1.DocumentAsHTMLDocument.GetElementById("txtResult").getAttribute("value");

            string val2 = webKitBrowser1.Document.GetElementById("txtResult").getAttribute("id");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webKitBrowser1.UseJavaScript = true;
            string strScript = "document.getElementById('txtResult').value = '123456';";
            webKitBrowser1.StringByEvaluatingJavaScriptFromString(strScript);
        }
    }

    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    class myClass
    {
        public int Test(int a,int b)
        {
            int c = a * b;
            return c;
        }
    }
}

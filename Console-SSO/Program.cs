using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Console_SSO
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var option = string.Empty;

            while (option != "3")
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Login with MSHTML");
                Console.WriteLine("2. Login with WebView2");
                Console.WriteLine("3. Exit");

                Console.Write("Pick an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("You chose to login with MSHTML.");
                        ShowMshtmlWebView();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("You chose to login with WebView2.");
                        ShowWebView2();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            }
        
        }

        [STAThread]
        static void ShowMshtmlWebView()
        {
            var thread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var form = new Form
                {
                    Width = 800,
                    Height = 600,
                    Text = "MSHTML WebBrowser"
                };

                var browser = new WebBrowser
                {
                    Dock = DockStyle.Fill,
                    ScriptErrorsSuppressed = true
                };

                browser.Navigate("https://testappproxy-aboachi.msappproxy.net/");

                form.Controls.Add(browser);
                Application.Run(form);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        [STAThread]
        static void ShowWebView2()
        {
            var thread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var form = new Form
                {
                    Width = 800,
                    Height = 600,
                    Text = "WebView2 Browser"
                };

                var webView = new WebView2
                {
                    Dock = DockStyle.Fill
                };

                form.Load += async (s, e) =>
                {
                    await webView.EnsureCoreWebView2Async();
                    webView.CoreWebView2.Navigate("https://testappproxy-aboachi.msappproxy.net/");
                };

                form.Controls.Add(webView);
                Application.Run(form);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}

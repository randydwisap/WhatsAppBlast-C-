using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WhatsAppBlast
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konfigurasi Selenium WebDriver
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://web.whatsapp.com");

            Console.WriteLine("Silakan scan kode QR dengan aplikasi WhatsApp Anda.");
            Thread.Sleep(30000); // Tunggu 30 detik untuk scanning QR code

            // Daftar nomor telepon dan pesan
            var contacts = new List<string> { "6281233895599", "6281230582750" }; // Ganti dengan nomor telepon yang diinginkan
            var message = "Hello, this is a test message!";

            foreach (var contact in contacts)
            {
                try
                {
                    // Cari kontak
                    var searchBox = driver.FindElement(By.XPath("//div[@contenteditable='true'][@data-tab='3']"));
                    searchBox.Clear();
                    searchBox.SendKeys(contact);
                    searchBox.SendKeys(Keys.Enter);
                    Thread.Sleep(2000); // Tunggu beberapa detik untuk pencarian

                    // Kirim pesan
                    var messageBox = driver.FindElement(By.XPath("//div[@contenteditable='true'][@data-tab='10']"));
                    messageBox.SendKeys(message);
                    messageBox.SendKeys(Keys.Enter);
                    Thread.Sleep(2000); // Tunggu beberapa detik untuk pengiriman pesan
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send message to {contact}: " + ex.Message);
                }
            }

            driver.Quit();
        }
    }
}


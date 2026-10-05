using Microsoft.Extensions.Configuration;

using PrintForms.Helper;

namespace PrintCodeBtapp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 单实例限制：已有程序在运行时直接退出，避免同时开两个程序重复打印
            using var mutex = new Mutex(true, "PrintCodeBtapp_SingleInstance", out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show("打印程序已在运行，请勿重复打开。", "KUKA打印程序", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .Build();
            AppSetting.Init(config);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
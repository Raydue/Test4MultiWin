using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace Test4MultiWin
{
    class Program
    {
        static void Main(string[] args)
        {
            /* if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count()<=2)
             {
                 Process.Start("Test4MultiWin.exe");
             }*/
            Test();
        }

        private static void Test()
        {
            
               
            Process process = new Process();

                Console.WriteLine("Opening...");
            process.StartInfo.UseShellExecute = false;   //是否使用作業系統shell啟動 
            process.StartInfo.CreateNoWindow = true;   //是否在新視窗中啟動該程序的值 (不顯示程式視窗)
            process.StartInfo.RedirectStandardInput = true;  // 接受來自呼叫程式的輸入資訊 
            process.StartInfo.RedirectStandardOutput = true;  // 由呼叫程式獲取輸出資訊
            
           // process.StartInfo.RedirectStandardError = true;  //重定向標準錯誤輸出
            process.StartInfo.FileName = @"C:\Users\Youngtec\source\repos\MQTTCMD\bin\Debug\MQTTCMD.exe";         
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            
            process.Start();
            
            process.StandardInput.WriteLine("#");
            
            process.StandardInput.WriteLine("end");
           
            StreamReader reader = process.StandardOutput;
            string data = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    Console.WriteLine(data);
                }
                data = reader.ReadLine();
            }
            process.WaitForExit();
            process.Close();
            
        }
    }
}

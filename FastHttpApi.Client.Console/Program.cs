using FastHttpApi.Client.Console.Util;
using Newtonsoft.Json;
using System;

namespace FastHttpApi.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DoIt();
        }

        private static void DoIt()
        {
            try
            {
                String serverUrl = "http://192.168.5.110:9090/Sum";
                System.Console.WriteLine("Please enter the first number：");
                String firstNumber = System.Console.ReadLine();
                System.Console.WriteLine("The second number：");
                String secondNumber = System.Console.ReadLine();
                System.Console.WriteLine("Enter the web api URL, or empty as default:" + serverUrl);
                String newServerUrl = System.Console.ReadLine();
                if (!String.IsNullOrEmpty(newServerUrl))
                {
                    serverUrl = newServerUrl;
                }
                String responseData = HttpClientHelper.PostResponse(serverUrl, new { first = firstNumber, second = secondNumber });
                BeetleX.FastHttpApi.JsonResult responseResult = JsonConvert.DeserializeObject<BeetleX.FastHttpApi.JsonResult>(responseData);
                System.Console.WriteLine("Result：" + responseResult.Data);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine("Continue?（Y/N）：");
                String c = System.Console.ReadLine();
                if ("Y".Equals(c) || "y".Equals(c))
                {
                    DoIt();
                }
            }
        }
    }
}

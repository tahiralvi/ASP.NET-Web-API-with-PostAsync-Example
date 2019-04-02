using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PostAsyncWebApi_Test.Models
{
    public static class PostDataModel
    {
        public static List<PatOBInfo> PostAsyncWebApi_Test(PatOBInfo product)
        {
            List<PatOBInfo> list = new List<PatOBInfo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://internal.premierphc360.com/CCMAPI");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");
                // HTTP POST
                HttpResponseMessage response = client.PostAsync("https://internal.premierphc360.com/CCMAPI/api/Patient/PostAsyncWebApi_Test", content).Result;
                string data1 = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<PatOBInfo>>(data);
                }
            }
            return list;
        }
    }
}
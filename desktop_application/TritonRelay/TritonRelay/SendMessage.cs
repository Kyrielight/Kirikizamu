using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// THIS APPLICATION REQUIRES NUGET: Newtonsoft.JSON

namespace TritonRelay {

    class SendMessage {
        public SendMessage(string username, string content) {

            /*
            // FORM REQUEST STYLE
            var comment = "hello world";
            var questionId = "test";

            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("username", "username"),
                new KeyValuePair<string, string>("content", "Hello World!")
            });

            var myHttpClient = new HttpClient();
            Uri uri = new Uri("URL");
            var response = myHttpClient.PostAsync(uri.ToString(), formContent);
            */

            string result = "";
            var values = new Dictionary<string, string>
            {
                {"username", username},
                {"content", content},
                {"channel", "N/A"},
                {"user_id", username},
                {"source", "Triton Gaming Desktop Relay" }
            };
            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new WebClient()) {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                result = client.UploadString("GOLDEN URL", "POST", json);
            }

        }   
    }
}

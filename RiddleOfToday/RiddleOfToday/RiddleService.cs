using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfToday
{
    public class RiddleOfTodayService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<Riddle> GetRiddleOfToday()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var uri = "https://kingsbackmath.azurewebsites.net/Riddle/GetRiddleOfToday";

            var result = await client.GetStringAsync(uri);

            var riddle = Newtonsoft.Json.JsonConvert.DeserializeObject<Riddle>(result);

            return riddle;
        }

        [DataContract(Name = "riddle")]
        public class Riddle
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "question")]
            public string Question { get; set; }

            [DataMember(Name = "answer")]
            public string Answer { get; set; }

            [DataMember(Name = "lastDisplayDate")]
            public string LastDisplayDate { get; set; }

            [IgnoreDataMember]
            //public DateTime LastDisplayDateTime => DateTime.ParseExact(LastDisplayDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.CurrentCulture);
            public DateTime LastDisplayDateTime => DateTime.Parse(LastDisplayDate);

            [DataMember(Name = "views")]
            public int Views { get; set; }

            [DataMember(Name = "difficulty")]
            public string Difficulty { get; set; }
        }
    }
}

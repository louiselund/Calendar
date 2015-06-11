using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Calendar.test
{
    public class WeeklyRecurring
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FrequencyInterval { get; set; }
        public enum WeekDays { }
        public int WeeklyRepeat { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
    public class WeeklyRecurringTest
    {
        [Fact]
        public void PerformTest()
        {
            // setup call
            // call web service
            // get result back from web service
            var c = new HttpClient();
            c.BaseAddress = new Uri("http://localhost:55506");
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var parameters = new WeeklyRecurring
            {
                StartDate = new DateTime(2015, 6, 1),
                EndDate = new DateTime(2015, 6, 30),
                FrequencyInterval = (8),
                WeeklyRepeat = 2,
                Monday = true,
                Tuesday = false,
                Wednesday = false,
                Friday = true
            };
            string json = JsonConvert.SerializeObject(parameters);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = c.PostAsync("api/weeklyrecurring", content).Result;
            if (result.IsSuccessStatusCode)
            {
                string jsonReturnedFromServer = result.Content.ReadAsStringAsync().Result;
                var dates = JsonConvert.DeserializeObject<DateTime[]>(jsonReturnedFromServer);
                Console.WriteLine("The result for weekly are:");
                var i = 0;
                while (i < dates.Length)
                {
                    Console.WriteLine(dates[i].ToString("d"));
                    i++;
                }

                Assert.Equal(new DateTime(2015, 6, 1), dates[0]);
                Assert.Equal(new DateTime(2015, 6, 5), dates[1]);
                Assert.Equal(new DateTime(2015, 6, 8), dates[2]);
                Assert.Equal(new DateTime(2015, 6, 12), dates[3]);
                Assert.Equal(new DateTime(2015, 6, 15), dates[4]);
                Assert.Equal(new DateTime(2015, 6, 19), dates[5]);
                Assert.Equal(new DateTime(2015, 6, 22), dates[6]);
                Assert.Equal(new DateTime(2015, 6, 26), dates[7]);
                Assert.Equal(new DateTime(2015, 6, 29), dates[8]);
            }
            else
            {
                Assert.True(false);
            }
        }
    }
}

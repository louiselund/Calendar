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
                WeeklyRepeat = 2
            };

            string json = JsonConvert.SerializeObject(parameters);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = c.PostAsync("api/weeklyrecurring", content).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonReturnedFromServer = result.Content.ReadAsStringAsync().Result;
                var dates = JsonConvert.DeserializeObject<DateTime[]>(jsonReturnedFromServer);
                int Monday = 2;
                Console.WriteLine("The Result is:" + dates);
                while (Monday < dates.Length)

                   
                {
                    Console.WriteLine(dates[Monday].ToString("d"));
                    Monday++;
                }

                // Test: Every 2nd Monday in the period 2015 06 01 - 2015 07 10
                Assert.Equal(new DateTime(2015, 6, 8), dates[0]);
                Assert.Equal(new DateTime(2015, 6, 22), dates[1]);
                Assert.Equal(new DateTime(2015, 7, 6), dates[2]);

            }
            else
            {
                Assert.True(false);
            }
        }
    }
}


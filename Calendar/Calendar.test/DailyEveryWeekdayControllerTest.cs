using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Calendar.test
{

    public class DayliEveryWeekday
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class DailyEveryWeekdayControllerTest
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

            var parameters = new DayliEveryWeekday
            {
                StartDate = new DateTime(2015, 1, 1),
                EndDate = new DateTime(2015, 1, 9),
                };

            string json = JsonConvert.SerializeObject(parameters);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = c.PostAsync("api/dailyeveryweekday", content).Result;


            if (result.IsSuccessStatusCode)
            {
                string jsonReturnedFromServer = result.Content.ReadAsStringAsync().Result;
                var dates = JsonConvert.DeserializeObject<DateTime[]>(jsonReturnedFromServer);
                int i = 0;
                Console.WriteLine("The Result is:");
                while (i < dates.Length)
                {
                    Console.WriteLine(dates[i].ToString("d"));
                    i++;
                }

                //Assert.Equal(new DateTime(2015, 1, 1), dates[0]);
                //Assert.Equal(new DateTime(2015, 1, 4), dates[1]);
                //Assert.Equal(new DateTime(2015, 1, 7), dates[2]);

            }
            else
            {
                Assert.True(false);
            }
        }
    }
}

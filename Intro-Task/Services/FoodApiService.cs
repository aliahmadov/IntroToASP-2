using Intro_Task.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Intro_Task.Services
{
    public class FoodApiService
    {
        public static dynamic Data { get; set; }
        public static dynamic SingleData { get; set; }
        public static async Task<List<Meal>> GetMealsByCategory(string ctg)
        {

            var client = new HttpClient();
            var url = $@"https://www.themealdb.com/api/json/v1/1/filter.php?c={ctg}";

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri(url)
            };

            using (var response = await client.SendAsync(requestMessage))
            {

                try
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject(responseBody);

                    List<Meal> meals = new List<Meal>();

                    for (int i = 0; i < 10; i++)
                    {

                        var meal = new Meal
                        {
                            Id=Data.meals[i].idMeal,
                            Name=Data.meals[i].strMeal,
                            Thumb=Data.meals[i].strMealThumb
                        };

                        meals.Add(meal);    
                    }
                    return meals;
                }


                catch (System.Exception ex)
                {

                    throw;
                }
            }

        }



        public async static Task<List<Meal>> GetMealsByRegion(string nationality)
        {
            var client = new HttpClient();
            var url = $@"https://www.themealdb.com/api/json/v1/1/filter.php?a={nationality}";

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri(url)
            };

            using (var response = await client.SendAsync(requestMessage))
            {

                try
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject(responseBody);

                    List<Meal> meals = new List<Meal>();

                    for (int i = 0; i < 10; i++)
                    {

                        var meal = new Meal
                        {
                            Id = Data.meals[i].idMeal,
                            Name = Data.meals[i].strMeal,
                            Thumb = Data.meals[i].strMealThumb
                        };

                        meals.Add(meal);
                    }
                    return meals;
                }


                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }


    }
}

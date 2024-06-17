using Microsoft.AspNetCore.Mvc;
using MVC_UI.Models;
using Newtonsoft.Json;

namespace MVC_UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5083/api");
                var httpResponseMessage = httpClient.GetAsync($"{httpClient.BaseAddress}/Product/hepsinigetir").Result;
                string content  = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var products = JsonConvert.DeserializeObject<List<ProductGetDTO>>(content);
            return View(products);
            }
        }
    }
}

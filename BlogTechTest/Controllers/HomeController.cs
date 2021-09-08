using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using BlogTechTest.Models;
using BlogTechTest.Data.Repository;

/*    private readonly ILogger<HomeController> _logger;

       public HomeController(ILogger<HomeController> logger)
       {
           _logger = logger;
       }*/
namespace BlogTechTest.Controllers
{
    public class HomeController : Controller
    {

        private IRepository _repo;
        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string category)
        {
            var topics = string.IsNullOrEmpty(category) ? _repo.GetAllTopics() : _repo.GetAllTopics(category);
            return View(topics);
        }

        public IActionResult Topic(int id)
        {
            var topic = _repo.GetTopic(id);

            return View(topic);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return View(new Topic());
            }
            else
            {
                var topic = _repo.GetTopic((int) id);
                return View(new Topic
                {
                    Id = topic.Id,
                    Title = topic.Title,
                    Body = topic.Body,
                    Category = topic.Category,
                    Tags = topic.Tags
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Topic vm)
        {
            var topic = new Topic
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Category = vm.Category,
                Tags = vm.Tags
            };
           
            if (topic.Id > 0)
                _repo.UpdateTopic(topic);
            else
                _repo.AddTopic(topic);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(topic);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _repo.DeleteTopic(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

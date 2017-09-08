using MeetingOrganizer.DataAccess;
using MeetingOrganizer.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Web.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public async Task<ActionResult> MeetingList()
        {         
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:50707/api/Meeting"); // cevap gelene kadar bekle diyorum
                var model = JsonConvert.DeserializeObject<List<Meeting>>(
                    response.Content.ReadAsStringAsync().Result);
                return View(model);
            }
        }
        public ActionResult MeetingCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MeetingCreate(Meeting model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50707/api/Meeting");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Meeting>("Meeting", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("MeetingList","Organization");
                }
            }
            ModelState.AddModelError(string.Empty, "Kayıt yaparken bir hata oluştu.");
            return View(model);
        }

        public ActionResult MeetingEdit(int id)
        {
            Meeting meeting = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50707/api/");
                // HTTP GET
                var responseTask = client.GetAsync("Meeting/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Meeting>();
                    readTask.Wait();

                    meeting = readTask.Result;
                }               
            }
            return View(meeting);       
        }
        [HttpPost]
        public ActionResult MeetingEdit(Meeting model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50707/api/Meeting");
                //HTTP POST
                var putTask = client.PutAsJsonAsync<Meeting>("Meeting", model);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("MeetingList","Organization");
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50707/api/");

                var deleteTask = client.DeleteAsync("Meeting/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {                   
                    return RedirectToAction("MeetingList","Organization");   
                }
            }
            return RedirectToAction("MeetingList","Organization");            
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44335/api/Default/EmployeeList");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsonString);
            return View(values);
        }


        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            var httpClient = new HttpClient();
            var values = JsonConvert.SerializeObject(employeeDTO);
            StringContent content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44335/api/Default/EmployeeAdd",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "EmployeeTest");
            }

            return View(employeeDTO);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44335/api/Default/EmployeeGet/"+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var dataValues = JsonConvert.DeserializeObject<EmployeeDTO>(jsonEmployee);
                return View(dataValues);
            }
            else return RedirectToAction("Index", "EmployeeTest");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDTO employeeDTO)
        {
            var httpClient = new HttpClient();
            var dataValues = JsonConvert.SerializeObject(employeeDTO);
            var content = new StringContent(dataValues, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44335/api/Default/EmployeeUpdate", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "EmployeeTest");
            }

            return View(employeeDTO);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44335/api/Default/EmployeeDelete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {               
                return RedirectToAction("Index", "EmployeeTest");
            }
            else return View();
       
        }

    }

    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

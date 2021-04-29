using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using RVAS_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace RVAS_Hotel.Controllers
{
    public class UserController : Controller
    {
        

        public IActionResult Register()
        {
            return View();
        }
    
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser()
        {
            // Uspostavljamo konekciju sa bazom, instanciramo novog korisnika, popunjavamo njegove podatke preko vrednosti iz forme, nakon toga ga ubacujemo u bazu preko InsertOne metode; na kraju vraćamo redirect na home page (PW je hashovan unutar User modela, prilikom setovanja svojstva)
            try
            {
                DBConnection Connection = new DBConnection();
                var DB = Connection.DBName;
                var collection = DB.GetCollection<User>("User");
                User newUser = new User()
                {
                    Username = Request.Form["Username"],
                    Name = Request.Form["Name"],
                    Surname = Request.Form["Surname"],
                    PW = Request.Form["Password"],
                    EmailAddress = Request.Form["Email"]
                };
                if (newUser.Username == String.Empty || newUser.Name == String.Empty || newUser.Surname == String.Empty || newUser.PW == String.Empty || newUser.EmailAddress == String.Empty)
                {
                    TempData["alertMessage"] = "Please fill all of the fields before proceeding to register!";
                    return RedirectToAction("Register");
                }
                collection.InsertOne(newUser);
                return RedirectToAction("Home");
                
            }
            /****************************************************************************************************************** 
              
              Ako je došlo do greške prilikom registracije korisnika, prosleđujemo poruku do cshtml-a gde je prikazujemo uz pomoć JS-a (ukoliko je to potrebno) i vraćamo redirect na istu stranicu kako bi korisnik mogao da ispravi grešku u unosu
              
             *****************************************************************************************************************/
            catch (Exception ex)
            {
                TempData["alertMessage"] = ex.ToString();
                return RedirectToAction("Register");
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

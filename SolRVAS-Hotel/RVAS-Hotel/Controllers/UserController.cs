using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using RVAS_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RVAS_Hotel.Controllers
{
    public class UserController : Controller
    {
        public object ViewState { get; private set; }

        [HttpGet]
        
        public IActionResult Register()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        // Registracija korisnika
        [HttpPost]
        public IActionResult RegisterUser()
        {
            // Deklaracija parametara za konekciju sa bazom, ciljanje određene MongoDB kolekcije (User)
            DBConnection Connection = new DBConnection();
            var DB = Connection.DBName;
            var collection = DB.GetCollection<User>("User");
            ApplicationRole role = new ApplicationRole("User");


            // Setovanje parametara novog korisnika na vrednosti iz forme
            User newUser = new User()
            {
                UserName = Request.Form["Username"],
                NormalizedUserName = Request.Form["UserName"],
                Email = Request.Form["Email"],
                NormalizedEmail = Request.Form["Email"],
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Request.Form["Password"]),
                Name = Request.Form["Name"],
                Surname = Request.Form["Surname"]

            };

            // Ispisujemo grešku ukoliko je neko od polja prazno prilikom submitovanja podataka
            if (newUser.UserName == String.Empty || newUser.Email == String.Empty || Request.Form["Password"].ToString() == String.Empty || newUser.Name == String.Empty || newUser.Surname == String.Empty)
            {
                TempData["alertMessage"] = "Please fill all of the fields before submitting your entry!";
                return RedirectToAction("Register");
            }
            // Provera da li postoji korisnik sa unetom email adresom ili unetim korisničkim imenom; ukoliko postoji takav korisnik, ispisuje se odgovarajuća greška na stranici i obustavlja se proces pre unošenja u bazu; ukoliko ne postoji, ubacujemo novog korisnika u bazu i redirektujemo na stranicu koja prikazuje sve sobe

            var existingUser = collection.Find(u => u.UserName == Request.Form["Username"]).FirstOrDefault();
            var existingUserTwo = collection.Find(u => u.Email == Request.Form["Email"]).FirstOrDefault();
            if (existingUser != null)
            {

                TempData["alertMessage"] = "The username is already taken!";
                return RedirectToAction("Register");

            }
            else if (existingUserTwo != null)
            {
                TempData["alertMessage"] = "An account with the entered email address already exists!";
                return RedirectToAction("Register");
            }
            else
            {
                newUser.AddRole(role.Id);
                collection.InsertOne(newUser);
                return RedirectToAction("LoginPage", "User");
            }


        }

        public IActionResult LogoutUser()
        {
           

            if (HttpContext.Session.GetString("Session") != null)
            {
                HttpContext.Session.Remove("Session");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
           
        }


        public IActionResult LoginUser()
        {
            DBConnection Connection = new DBConnection();
            var DB = Connection.DBName;
            var collection = DB.GetCollection<User>("User");
            var LoggedUser = collection.Find(u => u.UserName == Request.Form["Username"]).FirstOrDefault();
            if (LoggedUser == null)
            {
                TempData["alertMessage"] = "Either the username or password does not match, please try again!";
                return RedirectToAction("LoginPage", "User");

            }
            // Setting a cookie's value and/or subvalue using the HttpCookie class HttpCookie cookie;
            // if(Request.Cookies[txtName.Text] == null) cookie = new HttpCookie(txtName.Text, LoggedUser.Username);
            // else cookie = Request.Cookies[txtName.Text]; if(txtSubValueName.Text.Length > 0) cookie.Values.Add(txtSubValueName.Text, txtSubValueValue.Text);
            // cookie.Expires = System.DateTime.Now.AddDays(1); // tomorrow Response.AppendCookie(cookie); 
            // Retrieving a cookie's value(s) if(!Request.Cookies[txtName.Text].HasKeys) lblResult.Text = "The value of the <b>" + txtName.Text + "</b> cookie is <b>" + Request.Cookies[txtName.Text].Value.ToString() + "</b>";
            // else { lblResult.Text = "The value of the <b>" + txtName.Text + "</b> cookie is <b>" + Request.Cookies[txtName.Text].Value.ToString() + "</b>, with subvalues:<br>";
            // foreach(string key in Request.Cookies[txtName.Text].Values.Keys) { lblResult.Text += "[" + key + " = " + Request.Cookies[txtName.Text].Values[key].ToString() + "]<br>"; } }
            bool VerifyPassword = BCrypt.Net.BCrypt.Verify(Request.Form["Password"], LoggedUser.PasswordHash);
            if (VerifyPassword)
            {
                HttpContext.Session.SetString("Session", "User");
                return RedirectToAction("Index", "Room");

            }
            else
            {
                TempData["alertMessage"] = "Either the username or password does not match, please try again!";
                return RedirectToAction("LoginPage", "User");
                
            }



        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

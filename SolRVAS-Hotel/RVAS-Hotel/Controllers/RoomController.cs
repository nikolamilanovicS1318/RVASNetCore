﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVAS_Hotel.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace RVAS_Hotel.Controllers
{
    
    public class RoomController : Controller
    {
        DBConnection Connection = new DBConnection();

        
        [HttpGet]
        public IActionResult Index()
        {
            /****************************************************************************************************************
            
            Deklarisana kolekcija koja sadrži tip Room; uz pomoć foreach petlje prolazimo kroz kolekciju i dodajemo sobe na listu, koju kasnije preko ViewData prosleđujemo i prikazujemo na front endu

            *****************************************************************************************************************/

            var database = Connection.DBName;
            var coll = database.GetCollection<Room>("Room").AsQueryable<Room>();
            var AllRooms = new List<Room>();
            foreach (Room x in coll)
            {
                AllRooms.Add(x);
            }
            ViewData["ListOfRooms"] = AllRooms;


            //Dodavanje API funkcionalnosti - uzimamo u JSON formatu sve sobe
            var client = new RestClient("https://sws-group-7-hotel-api.herokuapp.com/api/v1/rooms");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // var data = JsonSerializer.Deserialize<Room>(response.Content);


           // Parsiranje JSON-a u JObject
            JObject JsonObject = JObject.Parse(response.Content);
           
            // Lista u kojoj se čuvaju JTokeni, kasnije će se proslediti na Index kroz ViewData, preko foreach petlje se prikazuju svi članovi
            List<JToken> JTokenList = new List<JToken>();
           // Foreach petlja u kojoj prolazimo kroz sve JObjecte; JObject nema implementaciju IEnumeracije pa ne može da radi direktno sa Foreach petljom, pa je castovan u JToken
            foreach (JProperty room in (JToken)JsonObject)
            {
                string name = room.Name;
                JToken value = room.Value;
                // Foreach petlja u kojoj prolazimo kroz sve tokene i dodajemo ih u listu koju smo napravili iznad
                foreach(JToken x in value)
                {
                    JTokenList.Add(x);
                }

            }
            // Ubacujemo popunjenu listu u ViewData za korišćenje unutar index stranice
            ViewData["Data"] = JTokenList;
            ViewData["API_Rooms"] = response.Content;
         

            return View();
        }
        public IActionResult RoomAdd()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public bool IsIntNull(int x)
        {
            bool res = String.IsNullOrEmpty(x.ToString());
            return res;
        }
        [HttpPost]
        public ActionResult AddRoom()
        {
            /******************************************************************************************************************
             
              Uspostavljamo konekciju sa bazom, instanciramo novog korisnika, popunjavamo njegove podatke preko vrednosti iz forme sa cshtml stranice, nakon toga ga ubacujemo u bazu preko InsertOne metode; na kraju vraćamo redirect na home page
              
             *****************************************************************************************************************/
            try
            {

                var DB = Connection.DBName;
                var collection = DB.GetCollection<Room>("Room");
                Room newRoom = new Room()
                {
                    RoomNumber = Convert.ToInt32(Request.Form["RoomNumber"]),
                    NumberOfBeds = Convert.ToInt32(Request.Form["NumberOfBeds"]),
                    Price = float.Parse(Request.Form["Price"]),
                    Floor = Convert.ToInt32(Request.Form["Floor"]),
                    IsOccupied = Request.Form["IsOccupied"],
                    HasMiniFridge = Request.Form["HasMiniFridge"]
                };
                if (IsIntNull(newRoom.RoomNumber)|| IsIntNull(newRoom.NumberOfBeds) || newRoom.Price.Equals(null)|| IsIntNull(newRoom.Floor) || String.IsNullOrEmpty(newRoom.IsOccupied) || String.IsNullOrEmpty(newRoom.HasMiniFridge))
                {
                    TempData["alertMessage"] = "Please make sure that you filled in all of the fields before proceeding to add a new room!";
                    return RedirectToActionPreserveMethod("RoomAdd");
                }
                collection.InsertOne(newRoom);

                return RedirectToAction("Index");

            }

            /****************************************************************************************************************** 
              
              Ako je došlo do greške prilikom ubacivanja sobe, prosleđujemo poruku do cshtml-a gde je prikazujemo uz pomoć JS-a (ukoliko je to potrebno) i vraćamo redirect na istu stranicu kako bi korisnik mogao da ispravi grešku u unosu
              
             *****************************************************************************************************************/
            catch (Exception ex)
            {
                TempData["alertMessage"] = ex.ToString();
                return RedirectToAction("RoomAdd");
            }

        }

        // Popunjavamo stranicu za izmenu podataka o sobi podacima iz baze, kako bi mogli da popunimo input polja sa trenutnim vrednostima

        [HttpGet]
        public IActionResult RoomEdit(string RoomID)
        {
            Room roomToUpdate = new Room();
            var DB = Connection.DBName;
            var collection = DB.GetCollection<Room>("Room");
            roomToUpdate = collection.Find(x => x.RoomID == RoomID).Limit(1).First();
            ViewData["RoomID"] = roomToUpdate.RoomID;
            ViewData["RoomNumber"] = roomToUpdate.RoomNumber;
            ViewData["NumberOfBeds"] = roomToUpdate.NumberOfBeds;
            ViewData["Floor"] = roomToUpdate.Floor;
            ViewData["Price"] = roomToUpdate.Price;
            
            if (roomToUpdate.IsOccupied == "Yes")
            {
                ViewData["IsOccupied"] = true;
            }
            else 
            {
                ViewData["IsOccupied"] = false;
            }
            if (roomToUpdate.HasMiniFridge == "Yes")
            {
                ViewData["HasMiniFridge"] = true;
            }
            else 
            {
                ViewData["HasMiniFridge"] = false;
            }
            return View(roomToUpdate);
        }

        // Funkcija preko koje ažuriramo podatke sobe; prosleđujemo ID sobe koju hoćemo da ažuriramo, setujemo joj podatke iz polja iz forme, filtriramo željenu sobu preko RoomID-ja i onda ubacujemo (tj izmenjujemo) podatke
       [HttpPost]
        public ActionResult UpdateRoom(string RoomID)
        {
            var DB = Connection.DBName;
            var collection = DB.GetCollection<Room>("Room");
            Room roomToUpdate = new Room()
            {
                RoomNumber = Convert.ToInt32(Request.Form["RoomNumber"]),
                NumberOfBeds = Convert.ToInt32(Request.Form["NumberOfBeds"]),
                Price = float.Parse(Request.Form["Price"]),
                Floor = Convert.ToInt32(Request.Form["Floor"]),
                IsOccupied = Request.Form["IsOccupied"],
                HasMiniFridge = Request.Form["HasMiniFridge"],


        };
            
       
            var filter = Builders<Room>.Filter.Eq(r => r.RoomID, RoomID);
            var update = Builders<Room>.Update.Set(x => x.RoomNumber, roomToUpdate.RoomNumber).Set(x => x.NumberOfBeds, roomToUpdate.NumberOfBeds).Set(x => x.Price, roomToUpdate.Price).Set(x => x.Floor, roomToUpdate.Floor).Set(x => x.IsOccupied, roomToUpdate.IsOccupied).Set(x => x.HasMiniFridge, roomToUpdate.HasMiniFridge);
            var result = collection.UpdateOne(filter, update);
            return RedirectToAction("Index");
           
        }
        public ActionResult DeleteRoom(string RoomID)
        {
            var DB = Connection.DBName;
            var collection = DB.GetCollection<Room>("Room");
            var filter = Builders<Room>.Filter.Eq(r => r.RoomID, RoomID);
            try
            {
                collection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                TempData["alertMessage"] = "There was an error during the deletion process. Please make sure you're trying to delete a valid room (and that you have adequate permission to do so).";
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult ApiDetails(int id)
        {
            //Dodavanje API funkcionalnosti - uzimamo u JSON formatu podatke o pojedinacnoj sobi
            var client = new RestClient("https://sws-group-7-hotel-api.herokuapp.com/api/v1/rooms/" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Parsiranje JSON-a u JObject
            var number = JObject.Parse(response.Content)["@id"];
            var description = JObject.Parse(response.Content)["description"];
            var category = JObject.Parse(response.Content)["category"];
            var size = JObject.Parse(response.Content)["size"];
            var capacity = JObject.Parse(response.Content)["capacity"];  
            var price = JObject.Parse(response.Content)["price"];




            // Ubacujemo popunjenu listu u ViewData za korišćenje unutar index stranice
            ViewData["API_Room_Number"] = number;
            ViewData["API_Room_Desc"] = description;
            ViewData["API_Room_Category"] = category;
            ViewData["API_Room_Size"] = size;
            ViewData["API_Room_Capacity"] = capacity;
            ViewData["API_Room_Price"] = price;

            ViewData["API_Details"] = response.Content;

            return View();
        }


    }
}

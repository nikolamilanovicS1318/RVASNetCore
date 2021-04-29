using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.Extensions.Configuration;

namespace RVAS_Hotel.Models
{
    public class DBConnection
    {
        // Koristimo appSettings JSON fajl da pristupimo ConnectionStringu kako aplikacija ne bi morala da se rekompajlira svaki put kada želimo da pristupimo drugačijem clusteru ili bazi
        private static IConfigurationRoot Configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

        // Deklarišemo ConnectionString i DatabaseName stringove, setujemo im vrednost preko parametara iz JSON fajla
        private static string ConnectionString = Configuration["DatabaseSettings:ConnectionString"];
        private static string DatabaseName = Configuration["DatabaseSettings:DatabaseName"];

        // Instanciramo objekat tipa MongoClient, podešavamo ga da koristi ConnectionString koji smo deklarisali iznad
        public static MongoClient MongoClient = new MongoClient(ConnectionString);

        // Deklarišemo bazu i setujemo ime baze koju želimo da "gađamo" unutar Clustera
        public IMongoDatabase DBName = MongoClient.GetDatabase(DatabaseName);

    }
}

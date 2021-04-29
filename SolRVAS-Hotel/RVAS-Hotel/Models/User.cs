using System.Runtime.InteropServices;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

public class User
{

    // Deklaracija svojstava / atributa korisnika
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _UserID;


    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    [BsonElement("Username")]
    public string Username { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    [BsonElement("Surname")]
    public string Surname { get; set; }
    [BsonElement("Password")]
    private string _Password;

    public string PW
    {
        get { return _Password; }

        // prilikom setovanja vrednosti passworda hashujemo vrednost radi sigurnosti; korišćen Pbkdf2 algoritam prikazan u MS dokumentaciji ovde: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0 
        set
        {
            // Generisanje 128-bitnog salta pomoću RNG-ja
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // izvlači se 256-bitni podključ korišćenjem HMACSHA1 algoritma, 10000 iteracija (veći broj za više iteracija i veću nasumičnost, manji broj za brži odziv aplikacije)

            string HashedPW = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: value, salt: salt, prf: KeyDerivationPrf.HMACSHA1, iterationCount: 10000, numBytesRequested: 256 / 8));
            _Password = HashedPW;
        }
    }
    [BsonElement("Email")]
    private string _Email;

    public string EmailAddress
    {
        get { return _Email; }
        set { _Email = value; }
    }



}
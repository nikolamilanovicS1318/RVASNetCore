using System.Runtime.InteropServices;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using AspNetCore.Identity.MongoDbCore;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

[CollectionName("User")]
public class User : MongoIdentityUser<Guid>
{
    
    private string _Name;

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Surname;

    public string Surname
    {
        get { return _Surname; }
        set { _Surname = value; }
    }


    public User() : base()
    {
        
    }
    public User(string  Username, string Email) : base(Username, Email)
    {
       
    }

    public User(string Username, string Name, string Surname, string Password, string Email)
    {
        
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace RVAS_Hotel.Models
{
    public class Room
    {
        // Ništa fensi, samo deklaracije atributa / svojstava soba

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _RoomID;

        public string RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }
        [BsonElement("RoomNumber")]
        public int RoomNumber { get; set; }
        [BsonElement("NumberOfBeds")]
        public int NumberOfBeds { get; set; }
        [BsonElement("Price")]
        public float Price { get; set; }
        
        [BsonElement("Floor")]
        public int Floor { get; set; }

        [BsonElement("IsOccupied")]

        public string IsOccupied { get; set; }

        [BsonElement("HasMiniFridge")]
        public string HasMiniFridge { get; set; }

        [BsonElement("ImageName")]
        public string ImageName { get; set; }

     

    }

}

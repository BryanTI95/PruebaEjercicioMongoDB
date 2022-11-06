namespace backConpaniaFalsa.Modelo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Departamento
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id          { get; set; }
        [BsonElement("nombreDepa")]
        public string nombreDepa    { get; set; }
    }
}

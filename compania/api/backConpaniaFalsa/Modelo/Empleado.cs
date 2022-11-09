namespace backConpaniaFalsa.Modelo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class Empleado
    {
     
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id          { get; set; }
       public string nombre         { get; set; }
       public string departamento   { get; set; }
        public string correo        { get; set; }
       public string pass           { get; set; }
       public string fecIng         { get; set; }
       public string foto           { get; set; }

        public Empleado()
        {

        }
     
    }
}

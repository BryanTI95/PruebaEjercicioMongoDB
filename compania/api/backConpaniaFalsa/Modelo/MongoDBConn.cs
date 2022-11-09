using MongoDB.Driver;

namespace backConpaniaFalsa.Modelo
{
    public class MongoDBConn
    {
        public MongoClient cte;
        public IMongoDatabase db;

        //Conexion a MongoDB
        public MongoDBConn(){
            cte = new MongoClient("mongodb://localhost:27017");
            db = cte.GetDatabase("companiaFalsa");
            }

    }
}

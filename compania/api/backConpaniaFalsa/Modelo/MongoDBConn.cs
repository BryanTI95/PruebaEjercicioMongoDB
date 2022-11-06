using MongoDB.Driver;

namespace backConpaniaFalsa.Modelo
{
    public class MongoDBConn
    {
        public MongoClient cte;
        public IMongoDatabase db;

        //Conexion a MongoDB
        public MongoDBConn(){
            cte = new MongoClient("mongodb://127.0.0.1:270717");
            db = cte.GetDatabase("companiaFalsa");
            }

    }
}

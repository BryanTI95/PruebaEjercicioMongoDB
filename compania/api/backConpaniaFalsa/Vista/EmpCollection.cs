using backConpaniaFalsa.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backConpaniaFalsa.Vista
{
    public class EmpCollection : IEmpleado
    {
        internal MongoDBConn con = new MongoDBConn();
        private IMongoCollection<Empleado> collection;


        public EmpCollection()
        {
            collection = con.db.GetCollection<Empleado>("Empleado");
        }

        public async Task DeleteEmpleado(string id)
        {
            var filtro = Builders<Empleado>.Filter.Eq(s => s.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Empleado>> GetAllEmpleados()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }


        public async Task<Empleado> GetEmpleadoById(string id)
        {
            return await collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }



        public async Task<Empleado> GetLoginEmpleado(string correo,string pass)
        {
            return await collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(correo) }, { "_id", new ObjectId(pass) } }).Result.
                FirstAsync();
        }

        public async Task PostEmpleado(Empleado dep)
        {
            await collection.InsertOneAsync(dep);
        }

        public async Task PutEmpleado(Empleado dep)
        {
            var filtro = Builders<Empleado>
                .Filter
                .Eq(s => s.Id, dep.Id);

            await collection.ReplaceOneAsync(filtro, dep);
        }


    }
}

using backConpaniaFalsa.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backConpaniaFalsa.Vista
{
    public class DepCollection : IDepartamento
    {
        internal MongoDBConn con = new MongoDBConn();
        private IMongoCollection<Departamento> collection;

  
        public DepCollection()
        {
            collection = con.db.GetCollection<Departamento>("Departamento");
        }

        public async Task DeleteDepartamento(string id)
        {
            var filtro = Builders<Departamento>.Filter.Eq(s => s.Id, new ObjectId(id));
                await collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Departamento>> GetAllDepartamentos()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentosById(string id)
        {
            return await collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task PostDepartamento(Departamento dep)
        {
            await collection.InsertOneAsync(dep);
        }

        public async Task PutDepartamento(Departamento dep)
        {
            var filtro = Builders<Departamento>
                .Filter
                .Eq(s => s.Id, dep.Id);

            await collection.ReplaceOneAsync(filtro, dep);
        }
    }
}

using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;

namespace TruApp
{
    public class SongAsyncRepository
    {
        SQLiteAsyncConnection database;

        public SongAsyncRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<SongDB>();
        }

        public async Task<List<SongDB>> GetItemsAsync()
        {
            return await database.Table<SongDB>().ToListAsync();
        }

        public async Task<SongDB> GetItemAsync(int id)
        {
            return await database.GetAsync<SongDB>(id);
        }
    }
}

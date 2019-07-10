using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Threading.Tasks;
using MyApp.Model;

namespace MyApp.Data
{
	public class LocalDatabase 
	{

        private readonly SQLiteAsyncConnection database;
        public LocalDatabase (string filepath)
		{
            database = new SQLiteAsyncConnection(filepath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Author>().Wait();
            database.CreateTableAsync<Book>().Wait();
        }

        public async Task<int> CheckIfUserExists(string login, string password)
        {

            return await database.Table<User>().Where(x => x.Login == login && x.Password == password).CountAsync();
           
        }



        public async Task<List<Book>> GetBooks()
        {
            return await database.Table<Book>().ToListAsync();
        }

        public async Task<List<T>> GetItemsAsync<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }
        public async Task<List<Book>> GetBooksByAuthorId(int authorId)
        {
            return await database.Table<Book>().Where(x => x.AuthorId == authorId).ToListAsync();
        }

        public async Task<T> GetItemByIdAsync<T>(int id) where T : class, ISqliteModel, new()
        {
            return await database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync<T>(T item) where T : class, ISqliteModel, new()
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
            {
                result = await database.InsertAsync(item);
            }

            return result;
        }

        public async Task<int> DeleteItemAsync<T>(T item) where T : class, ISqliteModel, new()
        {
            return await database.DeleteAsync(item);
        }
    }
}
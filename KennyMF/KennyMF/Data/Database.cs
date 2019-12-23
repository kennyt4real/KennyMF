using KennyMF.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KennyMF.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;
        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Team>().Wait();
            database.CreateTableAsync<Login>().Wait();
            database.CreateTableAsync<LocalUser>().Wait();
            database.CreateTableAsync<Form>().Wait();
            database.CreateTableAsync<Record>().Wait();
            database.CreateTableAsync<Notification>().Wait();
                       
        }

        public Task<List<TOut>> GetItemsAsync<TOut>() where TOut: BaseEntity, new()
        {
            return database.Table<TOut>().ToListAsync();
        }
        public Task<TOut> GetItemAsync<TOut>(int id) where TOut: BaseEntity, new()
        {
            return database.Table<TOut>().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public Task<TOut> GetItemAsync<TOut>(Expression<Func<TOut,bool>> expression) where TOut :BaseEntity, new()
        {
            return database.Table<TOut>().Where(expression).FirstOrDefaultAsync();
        }

        public Task<List<TOut>> GetItemsAsync<TOut>(Expression<Func<TOut,bool>> expression) where TOut :BaseEntity, new()
        {
            return database.Table<TOut>().Where(expression).ToListAsync();
        }
        public Task<int> SaveItemAsync<Tin>(Tin item) where Tin : BaseEntity
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync<Tin>(Tin Item)
        {
            return database.DeleteAsync(Item);
        }
    }
}

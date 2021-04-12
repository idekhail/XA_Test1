using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF_UsingCamera_Sqlite
{
    public class DB
    {
        SQLiteAsyncConnection db;
        public DB(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Users>().Wait();
        }
        public Task<int> SaveItemAsync(Users user)
        {
            if (user.UserID != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return db.InsertAsync(user);
            }
        }
        public Task<Users> GetItemAsync(int userId)
        {
            return db.Table<Users>().Where(i => i.UserID == userId).FirstOrDefaultAsync();
        }

        public Task<Users> GetItemAsync(string Username)
        {
            return db.Table<Users>().Where(i => i.Username == Username).FirstOrDefaultAsync();
        }
        public Task<int> CheckItemAsync(Users user)
        {
            if (user.UserID != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return db.InsertAsync(user);
            }
        }
        public Task<int> DeleteItemAsync(Users user)
        {
            return db.DeleteAsync(user);
        }

        public Task<int> DeleteAllUsersAsync()
        {
            return db.DeleteAllAsync<Users>();
        }

    }
}

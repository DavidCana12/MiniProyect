using SQLite;
using System.Threading.Tasks;
using Miniproject.Models;
using System.Collections.Generic;

namespace Miniproject.Helper
{
     public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Tasks>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Tasks tasks)
        {
            if (tasks.TaskId != 0)
            {
                return db.UpdateAsync(tasks);
            }
            else
            {
                return db.InsertAsync(tasks);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(Tasks tasks)
        {
            return db.DeleteAsync(tasks);
        }

        //Read All Items
        public Task<List<Tasks>> GetItemsAsync()
        {
            return db.Table<Tasks>().ToListAsync();
        }


        //Read Item
        public Task<Tasks> GetItemAsync(int taskId)
        {
            return db.Table<Tasks>().Where(e => e.TaskId == taskId).FirstOrDefaultAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using JustDoIt.Models;

namespace JustDoIt.Data
{
    public class ToDoNoteDatabase
    {
        static SQLiteAsyncConnection database;

        public static readonly AsyncLazy<ToDoNoteDatabase> Instance = new AsyncLazy<ToDoNoteDatabase>(async () =>
        {
            ToDoNoteDatabase instance = new ToDoNoteDatabase();

            CreateTableResult result = await database.CreateTableAsync<ToDoNote>();

            return instance;
        });

        public ToDoNoteDatabase()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ToDoNote>> GetItemsAsync()
        {
            return database.Table<ToDoNote>().ToListAsync();
        }

        public Task<List<ToDoNote>> GetItemsByCriteriaAsync()
        {
            return database.QueryAsync<ToDoNote>($"SELECT * FROM [ToDoNote] WHERE [IsFavourite] IN ({string.Join(",", Constants.ForSql[0])}) AND [Done] IN ({string.Join(",", Constants.ForSql[1])}) AND [Priority] IN ({string.Join(",", Constants.ForSql[2])})");
        }

        public Task<ToDoNote> GetItemAsync(int id)
        {
            return database.Table<ToDoNote>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDoNote item)
        {
            if (item.ID != 0)
            {   
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ToDoNote item)
        {
            return database.DeleteAsync(item);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamarinCP.Model;

namespace XamarinCP.Database
{
    public class XamarinCPDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public XamarinCPDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Company>().Wait();
        }

        public Task<List<Company>> GetCompaniesAsync()
        {
            return _database.Table<Company>().ToListAsync();
        }

        public Task<int> SaveCompanyAsync(Company company)
        {
            if (company.Id != 0)
            {
                return _database.UpdateAsync(company);
            }
            return _database.InsertAsync(company);
        }
    }
}

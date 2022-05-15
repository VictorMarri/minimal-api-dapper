using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            return _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
        }

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>("dbo.SpUser_Get", new { Id = id });

            return results.FirstOrDefault(); //Ou retorna o primeiro usuario, ou retorna um valor Default, que no caso é nulo
        }

        public Task InsertUser(UserModel user)
        {
            return _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });
        }

        public Task UpdateUser(UserModel user)
        {
            return _db.SaveData("dbo.spUser_Update", user);
        }

        public Task DeleteUser(int id)
        {
            return _db.SaveData("dbo.spUser_Delete", new { Id = id });
        }
    }
}

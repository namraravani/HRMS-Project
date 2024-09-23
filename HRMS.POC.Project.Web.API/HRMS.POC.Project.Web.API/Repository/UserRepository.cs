using Dapper;
using HRMS.POC.Project.Web.API.Models;
using HRMS_POC_Project.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace HRMS.POC.Project.Web.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IOptions<DatabaseConfig> dbConfig) {
            _connectionString = dbConfig.Value.ConnectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            var sql = "SELECT * FROM AspNetUsers";
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<ApplicationUser>(sql);
            }
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            var sql = "SELECT * FROM AspNetUsers WHERE Id = @Id";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(sql, new { Id = id });
            }
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            var sql = "UPDATE AspNetUsers SET UserName = @UserName, Email = @Email, PhoneNumber = @PhoneNumber, Is_Delete = @Is_Delete, Created_by = @Created_by WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, user);
                return affectedRows > 0 ? user : null; 
            }
        }



        public async Task<ApplicationUser> DeleteUserAsync(ApplicationUser user)
        {
            var sql = "UPDATE AspNetUsers SET Is_Delete = 1 WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = user.Id });
                return affectedRows > 0 ? user : null; 
            }
        }



    }
}

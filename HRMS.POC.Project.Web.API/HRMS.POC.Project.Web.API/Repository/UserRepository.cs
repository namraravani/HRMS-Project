using Dapper;
using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models;
using HRMS_POC_Project.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRMS.POC.Project.Web.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(IOptions<DatabaseConfig> dbConfig,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager) {
            _connectionString = dbConfig.Value.ConnectionString;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task<ApplicationUser> DeleteUserAsync(ApplicationUser user)
        {
            var sql = "UPDATE AspNetUsers SET Is_Delete = 1 WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = user.Id });
                return affectedRows > 0 ? user : null;
            }
        }

        public async Task<bool> DeleteUserForOrganizationAsync(string userId)
        {
            var sql = "UPDATE AspNetUsers SET Is_Delete = 1 WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = userId });
                return affectedRows > 0; 
            }
        }



        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var sql = @"
        UPDATE AspNetUsers 
        SET UserName = @UserName, 
            Email = @Email, 
            PhoneNumber = @PhoneNumber,
            firstName = @FirstName,
            lastName = @LastName,
            SecurityStamp = @SecurityStamp
        WHERE Id = @Id";

            var parameters = new
            {
                user.UserName,
                user.Email,
                user.PhoneNumber,
                user.firstName,
                user.lastName,
                SecurityStamp = Guid.NewGuid().ToString(), 
                user.Id
            };

            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
        }

        

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            var sql = "SELECT * FROM AspNetUsers WHERE UserName = @UserName";

            using (var connection = CreateConnection())
            {
                var result = connection.QueryFirstOrDefault<ApplicationUser>(sql, new { UserName = username });

                return result;
            }
            
        }

        public async Task<string> AddUser(ApplicationUser user, string password, UserManager<ApplicationUser> userManager)
        {
            
            var result = await userManager.CreateAsync(user, password);

            
            if (!result.Succeeded)
            {
                
                return null;
            }

            return user.Id; 
        }

        public async Task<string> AddUserAsync(UserDTO userDto, string creatorUserId, string organizationId, string assignedRole)
        {
            
            var newUser = new ApplicationUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                firstName = userDto.FirstName,
                lastName = userDto.LastName,
                Created_by = creatorUserId
            };

            
            var result = await _userManager.CreateAsync(newUser, userDto.Password);
            if (!result.Succeeded)
            {
                
                return null; 
            }

            
            if (!string.IsNullOrEmpty(assignedRole) && await _roleManager.RoleExistsAsync(assignedRole))
            {
                await _userManager.AddToRoleAsync(newUser, assignedRole);
            }

            
            var sql = @"INSERT INTO OrganizationUsers (UserId, OrganizationId) VALUES (@UserId, @OrganizationId)";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, new
                {
                    UserId = newUser.Id,
                    OrganizationId = organizationId
                });
            }

            return newUser.Id;
        }

        

        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            var sql = @"
            UPDATE AspNetUsers 
            SET UserName = @UserName, 
                Email = @Email, 
                PhoneNumber = @PhoneNumber,
                firstName = @FirstName,
                lastName = @LastName,
                SecurityStamp = @SecurityStamp
            WHERE Id = @Id"; 

            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    user.firstName,
                    user.lastName,
                    SecurityStamp = Guid.NewGuid().ToString(), 
                    user.Id
                });

                return rowsAffected > 0;
            }

            
        }




        public async Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId)
        {
            var sql = "GetUsersByOrganizationId";
            var parameters = new { OrganizationId = organizationId }; 

            using (var connection = CreateConnection()) {
                return await connection.QueryAsync<UserDTO>(sql, parameters, commandType: CommandType.StoredProcedure);
            }

            
        }



    }
}

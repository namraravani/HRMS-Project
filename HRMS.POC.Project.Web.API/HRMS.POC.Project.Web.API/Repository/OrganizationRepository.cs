using Dapper;
using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.DTO;
using HRMS_POC_Project.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;

namespace HRMS.POC.Project.Web.API.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly string _connectionString;

        public OrganizationRepository(IOptions<DatabaseConfig> dbConfig)
        {
            _connectionString = dbConfig.Value.ConnectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<IEnumerable<Organization>> GetUserOrganizationsAsync(string userId,string role)
        {
            var sql = "GetUserOrganizations"; 
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Organization>(sql, new { UserId = userId,Role = role}, commandType: CommandType.StoredProcedure);
            }
        }



        public async Task<Organization> GetOrganizationByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Organizations WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                var organization = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { Id = id });

                if (organization == null)
                {
                    throw new Exception($"Organization with ID '{id}' not found.");
                }

                return organization;
            }
        }

        public async Task<string> AddOrganizationAsync(OrganizationDTO organizationDto)
        {
            
            var validationContext = new ValidationContext(organizationDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(organizationDto, validationContext, validationResults, true))
            {
                throw new ValidationException("Validation failed: " + string.Join(", ", validationResults.Select(v => v.ErrorMessage)));
            }

           
            var organization = new Organization
            {
                Id = Guid.NewGuid().ToString(),
                orgName = organizationDto.orgName,
                address = organizationDto.address,
                
            };

            var sql = @"INSERT INTO Organizations(Id, orgName, address) VALUES(@Id, @orgName, @address)";

            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, organization);
                if (rowsAffected == 0)
                {
                    throw new Exception("Organization could not be created.");
                }

                return organization.Id;
            }
        }


        public async Task<Organization> UpdateOrganizationAsync(Organization organization)
        {
            var sql = @"
            UPDATE Organizations 
            SET orgName = @orgName, address = @address 
            WHERE Id = @Id; 
            SELECT * FROM Organizations WHERE Id = @Id;";

            using (var connection = CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Organization>(sql, organization);
            }


        }
        public async Task<Organization> RemoveOrganizationAsync(Organization organization)
        {
            var sql = $@"
                        DELETE FROM
                            Organizations
                        WHERE
                            Id=@Id";

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql,organization);

                if (organization == null)
                {
                    throw new Exception("Object is Not added");
                }

                return organization;
            }
            
        }

        public async Task<string> GetOrganizationByName(string name)
        {
            var sql = "SELECT Id FROM Organizations WHERE orgName = @name";

            using(var connection = CreateConnection())
            {
                var id = await connection.QueryFirstOrDefaultAsync(sql, name);

                if(id == null)
                {
                    throw new Exception("No Organization Found");
                }

                return id;
            }
  
        }

        public async Task<bool> AddUserToOrganization(string organizationId, ApplicationUser user)
        {
            var sql = "INSERT INTO OrganizationUsers (OrganizationId, UserId) VALUES (@OrganizationId, @UserId)";

            using (var connection = CreateConnection())
            {
                var parameters = new
                {
                    OrganizationId = organizationId,
                    UserId = user.Id
                };

                var affectedRows = await connection.ExecuteAsync(sql, parameters);
                return affectedRows > 0;
            }
        }

        public async Task<Organization> FindOrganizationAsync(string orgId)
        {
            var sql = "SELECT * FROM Organizations WHERE Id = @Id"; 

            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Organization>(sql, new {Id = orgId});
            }
        }

        public async Task<string> GetOrganizationIdByUserIdAsync(string userId)
        {
            var sql = "SELECT OrganizationId FROM OrganizationUsers WHERE UserId = @UserId";

            using (var conn = CreateConnection())
            {
                return await conn.ExecuteScalarAsync<string>(sql, new { UserId = userId });
            }
           
        }

        public async Task<bool> DeleteOrganizationAsync(string id)
        {
            var sql = "DELETE FROM Organizations WHERE Id = @Id;";

            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
                return rowsAffected > 0; 
            }
            
        }
        public async Task<IEnumerable<string>> FetchUsersFromOrganizationIdAsync(string organizationId)
        {
            var sql = "SELECT UserId FROM OrganizationUsers WHERE OrganizationId = @Id;";

            using (var connection = CreateConnection())
            {  
                var userIds = await connection.QueryAsync<string>(sql, new { Id = organizationId });
                return userIds; 
            }
        }




    }
}

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


        public async Task<IEnumerable<Organization>> GetUserOrganizationsAsync(string userId, string role)
        {
            var sql = "GetUserOrganizations"; 
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Organization>(sql, new { UserId = userId, Role = role }, commandType: CommandType.StoredProcedure);
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

        public async Task<OrganizationDTO> AddOrganizationAsync(OrganizationDTO organizationDto)
        {
            // Validate the DTO before proceeding
            var validationContext = new ValidationContext(organizationDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(organizationDto, validationContext, validationResults, true))
            {
                throw new ValidationException("Validation failed: " + string.Join(", ", validationResults.Select(v => v.ErrorMessage)));
            }

            // Create a new organization instance
            var organization = new Organization
            {
                Id = Guid.NewGuid().ToString(),
                orgName = organizationDto.orgName,
                address = organizationDto.address,
                // Map other properties as necessary
            };

            var sql = @"INSERT INTO Organizations(Id, orgName, address) VALUES(@Id, @orgName, @address)";

            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, organization);

                if (rowsAffected == 0)
                {
                    throw new Exception("Object was not updated.");
                }

                return organizationDto; // Return the original DTO or map it back if necessary
            }
        }


        public async Task<Organization> UpdateOrganizations(Organization organization)
        {
            
            var sql = $@"UPDATE Organizations SET orgName = @orgName,address = @address WHERE Id=@Id";

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql, organization);

                if (organization == null)
                {
                    throw new Exception("Object is Not added");
                }

                return organization;
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
                    UserId = user.Id // Ensure user.Id exists
                };

                var affectedRows = await connection.ExecuteAsync(sql, parameters);
                return affectedRows > 0; // Return true if a row was inserted
            }
        }

        public async Task<Organization> FindOrganizationAsync()
        {
            var sql = "SELECT TOP 1 * FROM Organizations"; // Adjust table name as needed

            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Organization>(sql);
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


    }
}

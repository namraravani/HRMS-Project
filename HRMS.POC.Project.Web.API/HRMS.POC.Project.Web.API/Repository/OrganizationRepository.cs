using Dapper;
using HRMS.POC.Project.Web.API.Models;
using HRMS_POC_Project.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

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

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
        {
            const string sql = "SELECT * FROM Organizations";
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Organization>(sql);
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

        public async Task<Organization> AddOrganizationAsync(Organization organization)
        {
            organization.Id = Guid.NewGuid().ToString();
            var sql = @"INSERT INTO Organizations(Id,orgName,address) values(@Id,@orgName,@address)";
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(sql,organization);

                if (organization == null)
                {
                    throw new Exception("Object is Not Updated");
                }

                return organization;
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


    }
}

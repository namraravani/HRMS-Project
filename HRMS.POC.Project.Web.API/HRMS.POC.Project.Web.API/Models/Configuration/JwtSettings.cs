namespace HRMS.POC.Project.Web.API.Models.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
    }

}

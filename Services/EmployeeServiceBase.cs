using CapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Net.Http;

namespace CapstoneProject.Services
{
    public class EmployeeServiceBase
    {
        protected HttpClient HttpClientObj { get; }
        protected IMongoDatabase Database { get; }
        protected IConfiguration ConfigurationObj { get; }
        public EmployeeServiceBase(IOrcidIobmIntDatabaseSettings settings, HttpClient httpClient,
            IConfiguration configuration)
        {
            {
                var client = new MongoClient(settings.ConnectionString);
                Database = client.GetDatabase(settings.DatabaseName);
                HttpClientObj = httpClient;
                ConfigurationObj = configuration;
            }
        }
    }
}
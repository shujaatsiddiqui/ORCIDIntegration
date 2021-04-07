using CapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Services
{
    public class EmployeesService : EmployeeServiceBase
    {
        protected readonly IMongoCollection<EmployeeDetails> _employees;
        public EmployeesService(IOrcidIobmIntDatabaseSettings settings,
            HttpClient httpClient,
            IConfiguration configuration) :
            base(settings, httpClient, configuration)
        {
            _employees = Database.GetCollection<EmployeeDetails>("Employees");
        }

        public EmployeeDetails GetByOrcid(string orcId)
        {
            return _employees.Find(emp => emp.OrcId == orcId).FirstOrDefault();
        }

        public async Task<HttpResponseMessage> GetEmployeeAccessTokenFromApi(string _code)
        {
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("client_id", ConfigurationObj["ClientId"]));
            nvc.Add(new KeyValuePair<string, string>("client_secret", ConfigurationObj["ClientSecret"]));
            nvc.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            nvc.Add(new KeyValuePair<string, string>("code", _code));
            nvc.Add(new KeyValuePair<string, string>("redirect_uri", ConfigurationObj["RedirectUri"]));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/oauth/token");
            request.Content = new FormUrlEncodedContent(nvc);
            HttpClientObj.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await HttpClientObj.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return response;
        }

        public async Task<HttpResponseMessage> GetEmployeeDetailsFromAPI(string accessToken)
        {
            HttpClientObj.DefaultRequestHeaders.Accept.Clear();
            HttpClientObj.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            HttpClientObj.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.orcid+xml"));
            HttpResponseMessage response = await HttpClientObj.GetAsync("0000-0002-5807-5617" + "/external-identifiers");
            return response;
        }

        public EmployeeDetails Create(EmployeeDetails employeeDetails)
        {
            _employees.InsertOne(employeeDetails);
            return employeeDetails;
        }

        public void UpdateAccessToken(EmployeeDetails Obj)
        {
            var filter = Builders<EmployeeDetails>.Filter.Eq("OrcId", Obj.OrcId);
            var update = Builders<EmployeeDetails>.Update.Set("AccessToken", Obj.AccessToken);
            _employees.UpdateOne(filter, update);
        }

        public void UpdateEmployeeDetails(EmployeeDetails Obj)
        {
            var filter = Builders<EmployeeDetails>.Filter.Eq("OrcId", Obj.OrcId);
            var update = Builders<EmployeeDetails>.Update.Set("Details", Obj.Details);
            _employees.UpdateOne(filter, update);
        }

        public EmployeeDetails Get(string id) =>
            _employees.Find<EmployeeDetails>(emp => emp.Id == id).FirstOrDefault();

        public EmployeeDetails ValidateLoginCredentials(string orcid, string password) =>
            _employees.Find<EmployeeDetails>(emp => emp.OrcId == orcid && emp.Password == password).FirstOrDefault();

        public void Delete(string orcid)
        {
            //var delFilter 
            //_employees.Filter.Eq("student_id", 10000);
        }
    }
}

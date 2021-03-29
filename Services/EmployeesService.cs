using CapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Services
{
    public class EmployeesService : EmployeeServiceBase
    {
        protected readonly IMongoCollection<Employees> _employees;
        public EmployeesService(IOrcidIobmIntDatabaseSettings settings,
            HttpClient httpClient,
            IConfiguration configuration) :
            base(settings, httpClient, configuration)
        {
            _employees = Database.GetCollection<Employees>("Employees");
        }

        public Employees GetByOrcid(string orcId)
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
            //request.Content.Headers.Add(@"Content-Length", "50000");
            HttpResponseMessage response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            //HttpResponseMessage response = await
            //    HttpClient.SendAsync("oauth/token",
            //            new StringContent(
            //                    JsonConvert.SerializeObject(
            //                    new
            //                    {
            //                        client_id = ConfigurationObj["ClientId"],
            //                        client_secret = ConfigurationObj["ClientSecret"],
            //                        grant_type = "authorization_code",
            //                        code = _code,
            //                        redirect_uri = ConfigurationObj["RedirectUri"]
            //                    }), Encoding.UTF8, "application/x-www-form-urlencoded"
            //                ));
            return response;
        }

        public Employees Create(string fullName, string orciId, string password, string accessToken)
        {
            Employees employeesObj = new Employees() { AccessToken = accessToken, Name = fullName, OrcId = orciId, Password = password };
            _employees.InsertOne(employeesObj);
            return employeesObj;
        }

        public void Update(Employees Obj)
        {
            var filter = Builders<Employees>.Filter.Eq("OrcId", Obj.OrcId);
            var update = Builders<Employees>.Update.Set("AccessToken", Obj.AccessToken);
            _employees.UpdateOne(filter, update);
        }

        public Employees Get(string id) =>
            _employees.Find<Employees>(emp => emp.Id == id).FirstOrDefault();

        public Employees ValidateLoginCredentials(string orcid, string password) =>
            _employees.Find<Employees>(emp => emp.OrcId == orcid && emp.Password == password).FirstOrDefault();

        public void Delete(string orcid)
        {
            //var delFilter 
            //_employees.Filter.Eq("student_id", 10000);
        }
    }
}

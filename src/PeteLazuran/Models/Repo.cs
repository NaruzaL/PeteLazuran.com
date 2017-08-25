using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PeteLazuran.Models
{
    public class Repo
    {
        public string name { get; set; }
        public string html_url { get; set; }
        public int stargazers_count { get; set; }

        public static List<Repo> FindRepos()
        {
            //Who we are requesting from       
            var client = new RestClient("https://api.github.com");
            //What we are requesting
            var request = new RestRequest("/search/repositories?q=user:NaruzaL&sort=stars", Method.GET);
            //////API "Username" and "Password"
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.username, EnvironmentVariables.token);
            //API call Header
            request.AddHeader("User-Agent", "NaruzaL Portfolio");
            //request.AddHeader("token", EnvironmentVariables.token);
            //Response from API call
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse["items"].ToString());
            return messageList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
//GET /search/repositories? q = user:NaruzaL&amp;sort=stars HTTP/1.1
//Host: api.github.com
//username: Naruzal
//token: The2side8835!
//Cache-Control: no-cache
//Postman-Token: 3b13a0de-0576-1d3d-dcd0-d2c9055ddd7a


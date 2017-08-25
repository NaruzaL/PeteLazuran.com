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
            var client = new RestClient("https://api.github.com/search/repositories?");
            //What we are requesting
            var request = new RestRequest("q=user:NaruzaL&sort=stars&order=desc", Method.GET);
            ////API "Username" and "Password"
            //client.Authenticator = new HttpBasicAuthenticator("user-key", EnvironmentVariables.UserKey);
            //API call Header
            request.AddHeader("username", EnvironmentVariables.username);
            request.AddHeader("token", EnvironmentVariables.token);
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

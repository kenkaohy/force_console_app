using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Common;
using Salesforce.Force;

namespace force_console_app
{
    class Program
    {
        private static string clientId = "3MVG9ZL0ppGP5UrCIsahMReg5jlcgS0fKX6yJEYrfgaPiVhnW5fIroX.CgFmYD1SFmQMBIM8n7CKAJH2dvgm2";
        private static string clientSecret = "3228504275119711645";
        private static string username = "";//SFDC account
        private static string password = "";//SFDC password + token
        
        static void Main(string[] args)
        {
            //initial SFDC authentication.
            var auth = new AuthenticationClient();
            auth.UsernamePasswordAsync(clientId, clientSecret, username, password).Wait();

            //establish Force.com transaction.
            var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);

            //SFDC SOQL string.
            var strQuery = "SELECT Id, Name FROM Account LIMIT 1000";

            //Define the return object type and result.
            var result = client.QueryAsync<Account>(strQuery);
            result.Wait();

            var accounts = result.Result.Records;

            foreach(var acc in accounts)
            {
                Console.WriteLine(acc.Name);
                
            }




        }
    }
}

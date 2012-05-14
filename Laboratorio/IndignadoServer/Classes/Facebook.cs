using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System;

namespace IndignadoServer
{
    public class FacebookUser
    {
        public long id { get; set; } //yes. the user id is of type long...dont use int
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }

    }

    class Facebook
    {

        public static FacebookUser GetInfo(string token)
        {
            //now that we have an access token, query the Graph Api for the JSON representation of the User
            string url = "https://graph.facebook.com/me?access_token={0}";

            //create the request to https://graph.facebook.com/me
            WebRequest request = WebRequest.Create(string.Format(url, token));

            //Get the response
            WebResponse response = request.GetResponse();
           
            //Get the response stream
            Stream stream = response.GetResponseStream();

            //Take our statically typed representation of the JSON User and deserialize the response stream
            //using the DataContractJsonSerializer
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(FacebookUser));

            FacebookUser user = new FacebookUser();
            user = dataContractJsonSerializer.ReadObject(stream) as FacebookUser;

            //close the stream
            response.Close();

            return user;
        }
    }
}

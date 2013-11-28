using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using EntertainmentTrackerPersonal.Models;
using UserService;

namespace EntertainmentTrackerPersonal.WebHelpers
{
    public class WebServiceHelper
    {
        private WebRequest _webRequest;
        private HttpWebResponse _httpResponse;
        private StreamReader _streamReader;

        public User GetUserData(string requestUrl, string method)
        {
            User user = new User();

            try
            {
                _webRequest = WebRequest.Create(requestUrl);
                _webRequest.Method = method;

                _webRequest.ContentType = @"application/json; charset=utf-8";
                _httpResponse = (HttpWebResponse)_webRequest.GetResponse();

                Encoding encoding = Encoding.GetEncoding("utf-8");

                _streamReader = new StreamReader(_httpResponse.GetResponseStream(), encoding);

                var result = _streamReader.ReadToEnd();

                using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(result)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(User));
                    user = (User)serializer.ReadObject(memoryStream);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (_streamReader != null)
                {
                    _streamReader.Close(); 
                }
            }

            return user;
        }
    }
}
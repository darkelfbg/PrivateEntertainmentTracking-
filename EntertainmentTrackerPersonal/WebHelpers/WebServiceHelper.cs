using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using EntertainmentTrackerPersonal.Models;
using UserService;

namespace EntertainmentTrackerPersonal.WebHelpers
{
    public class WebServiceHelper
    {
        #region Private Variables
        private WebRequest _webRequest;
        private HttpWebResponse _httpResponse;
        private StreamReader _streamReader;
        private Stream _requestStream;
        #endregion

        #region Public Methods

        #region GetUserData Method
        public User GetUserData(string requestUrl)
        {
            User user = new User();

            try
            {
                _webRequest = WebRequest.Create(requestUrl);
                _webRequest.Method = "GET";

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

                if (_httpResponse != null)
                {
                    _httpResponse.Close();
                }
            }

            return user;
        }
        #endregion

        #region RegisterUser Method
        public bool RegisterUser(string requestUrl,UserModel user)
        {
            try
            {
                string dataToSend = "{\"Password\":\"" + user.Password + "\",\"RememberMe\":" +
                                    user.RememberMe + ",\"UserName\":\"" + user.UserName + "\"}";
                byte[] byteDataToSend = Encoding.UTF8.GetBytes(dataToSend);

                _webRequest = WebRequest.Create(requestUrl);
                _webRequest.Method = "POST";
                _webRequest.ContentType = @"application/json; charset=utf-8";
                _webRequest.ContentLength = byteDataToSend.Length;

                _requestStream = _webRequest.GetRequestStream();

                _requestStream.Write(byteDataToSend, 0, byteDataToSend.Length);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (_requestStream != null)
                {
                    _requestStream.Close();
                }
            }

            return true;
        }
        #endregion

        #endregion
    }
}
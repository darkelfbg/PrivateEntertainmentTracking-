using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using DataObjects;

namespace EntertainmentTrackerPersonal.WebHelpers
{
    public class WebServiceHelper
    {
        #region Private Variables
        private WebRequest _webRequest;
        private Stream _requestStream;
        #endregion

        #region Public Methods

        #region GetUserData Method
        public UserServiceStatusCode GetUserData(string requestUrl,User user)
        {
            int result;

            try
            {
                //added because in JSON False is actually false, no capital letter!!!
                var rememberMe = user.RememberMe ? "true" : "false";

                string dataToSend = "{\"Password\":\"" + user.Password + "\",\"RememberMe\":" + rememberMe
                     +",\"UserName\":\"" + user.UserName + "\"}";
                byte[] byteDataToSend = Encoding.UTF8.GetBytes(dataToSend);

                _webRequest = WebRequest.Create(requestUrl);
                _webRequest.Method = "POST";
                _webRequest.ContentType = @"application/json; charset=utf-8";
                _webRequest.ContentLength = byteDataToSend.Length;

                _requestStream = _webRequest.GetRequestStream();
                _requestStream.Write(byteDataToSend, 0, byteDataToSend.Length);
                _requestStream.Close();

                var response = (HttpWebResponse)_webRequest.GetResponse();

                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);

                result = Int32.Parse(streamReader.ReadToEnd());

                if (streamReader != null)
                {
                    streamReader.Close();
                }

                response.Close();

            }
            catch (Exception)
            {
                return UserServiceStatusCode.Unknown;
            }
            finally
            {
                if (_requestStream != null)
                {
                    _requestStream.Close();
                }
            }
            switch (result)
            {
                case 0: return UserServiceStatusCode.Ok;
                case 1: return UserServiceStatusCode.WrongUserName;
                case 2: return UserServiceStatusCode.WrongPassword;
                default: return UserServiceStatusCode.Unknown;
            }
        }
        #endregion

        #region RegisterUser Method
        public UserServiceStatusCode RegisterUser(string requestUrl,User user)
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
                return UserServiceStatusCode.Unknown;
            }
            finally
            {
                if (_requestStream != null)
                {
                    _requestStream.Close();
                }
            }

               return UserServiceStatusCode.Ok;
        }
        #endregion

        #endregion
    }
}
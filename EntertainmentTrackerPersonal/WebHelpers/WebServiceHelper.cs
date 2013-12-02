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
        private HttpWebResponse _httpResponse;
        private StreamReader _streamReader;
        private Stream _requestStream;
        #endregion

        #region Public Methods

        #region GetUserData Method
        public AuthenticationStatusCode GetUserData(string requestUrl,User user)
        {

            //string url = "http://193.178.152.188:9090/UserService.svc/GetUser";
            ////string dataToPost = "{\"Password\":\"pavel\",\"RememberMe\":false,\"UserName\":\"Rado\"}";
            //string dataToPost  = "{\"Password\":\"" + user.Password + "\",\"RememberMe\":" +
            //                      user.RememberMe + ",\"UserName\":\"" + user.UserName + "\"}";
            //byte[] byteData = Encoding.UTF8.GetBytes(dataToPost);

            //WebRequest webPost = WebRequest.Create(url);
            //webPost.Method = "POST";
            //webPost.ContentType = @"application/json; charset=utf-8";
            //webPost.ContentLength = byteData.Length;
            //Stream requestStream = webPost.GetRequestStream();

            //requestStream.Write(byteData, 0, byteData.Length);

            //requestStream.Close();

            //var response = (HttpWebResponse)webPost.GetResponse();

            //Encoding encoding = Encoding.GetEncoding("utf-8");
            //StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
            //var result = Int32.Parse(streamReader.ReadToEnd());

            //response.Close();

            //switch (result)
            //{
            //    case 0: return AuthenticationStatusCode.Ok;
            //    case 1: return AuthenticationStatusCode.WrongUserName;
            //    case 2: return AuthenticationStatusCode.WrongPassword;
            //    default: return AuthenticationStatusCode.Unknown;
            //}
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
                Stream requestStream = _webRequest.GetRequestStream();

                requestStream.Write(byteDataToSend, 0, byteDataToSend.Length);

                requestStream.Close();

                var response = (HttpWebResponse)_webRequest.GetResponse();

                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
                result = Int32.Parse(streamReader.ReadToEnd());

                response.Close();

            }
            catch (Exception)
            {
                return AuthenticationStatusCode.Unknown;
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
                case 0: return AuthenticationStatusCode.Ok;
                case 1: return AuthenticationStatusCode.WrongUserName;
                case 2: return AuthenticationStatusCode.WrongPassword;
                default: return AuthenticationStatusCode.Unknown;
            }
        }
        #endregion

        #region RegisterUser Method
        public AuthenticationStatusCode RegisterUser(string requestUrl,User user)
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
                return AuthenticationStatusCode.Unknown;
            }
            finally
            {
                if (_requestStream != null)
                {
                    _requestStream.Close();
                }
            }

               return AuthenticationStatusCode.Ok;
        }
        #endregion

        #endregion
    }
}
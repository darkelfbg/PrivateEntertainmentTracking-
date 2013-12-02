using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using DataObjects;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser")]
        AuthenticationStatusCode GetUserCredentials(User user);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json, UriTemplate = "CreateAccount")]
        AuthenticationStatusCode CreateAccount(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "UpdateAccount")]
        AuthenticationStatusCode UpdateAccount(User user);
    }
}

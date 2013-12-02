using System;
using DataObjects;
using UserService.SqlHelpers;

namespace UserService
{
    public class UserService : IUserService
    {
        #region Private VAriables
        private SqlHelper _sqlHelper = new SqlHelper();
        #endregion

        #region IUserService Implementation

        #region GetUserCredentials Method
        public AuthenticationStatusCode GetUserCredentials(User user)
        {
            User currentUser = new User();

            try
            {
                currentUser = _sqlHelper.GetUser(user.UserName);

                if (currentUser.UserName != user.UserName)
                {
                    return AuthenticationStatusCode.WrongUserName;
                }
                if (currentUser.Password != user.Password)
                {
                    return AuthenticationStatusCode.WrongPassword;
                }

                return AuthenticationStatusCode.Ok;
            }
            catch (Exception)
            {
                return AuthenticationStatusCode.Unknown;
            }
        }
        #endregion

        #region CreateAccount Method
        public AuthenticationStatusCode CreateAccount(User user)
        {
            try
            {
                _sqlHelper.CreateUser(user);
            }
            catch (Exception)
            {
                return AuthenticationStatusCode.Unknown;
            }

            return AuthenticationStatusCode.Ok;
               
        }
        #endregion

        #region UpdateUser Method
        public AuthenticationStatusCode UpdateAccount(User user)
        {
            try
            {
                _sqlHelper.UpdateUser(user);
            }
            catch (Exception)
            {
                return AuthenticationStatusCode.Unknown;
            }
            
            return AuthenticationStatusCode.Ok;

        }
        #endregion

        #endregion
    }
}

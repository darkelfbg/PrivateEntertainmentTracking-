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
        public UserServiceStatusCode GetUserCredentials(User user)
        {
            User currentUser = new User();

            try
            {
                currentUser = _sqlHelper.GetUser(user.UserName);

                if (currentUser.UserName != user.UserName)
                {
                    return UserServiceStatusCode.WrongUserName;
                }
                if (currentUser.Password != user.Password)
                {
                    return UserServiceStatusCode.WrongPassword;
                }

                return UserServiceStatusCode.Ok;
            }
            catch (Exception)
            {
                return UserServiceStatusCode.Unknown;
            }
        }
        #endregion

        #region CreateAccount Method
        public UserServiceStatusCode CreateAccount(User user)
        {
            try
            {
                _sqlHelper.CreateUser(user);
            }
            catch (Exception)
            {
                return UserServiceStatusCode.Unknown;
            }

            return UserServiceStatusCode.Ok;
               
        }
        #endregion

        #region UpdateUser Method
        public UserServiceStatusCode UpdateAccount(User user)
        {
            try
            {
                _sqlHelper.UpdateUser(user);
            }
            catch (Exception)
            {
                return UserServiceStatusCode.Unknown;
            }
            
            return UserServiceStatusCode.Ok;

        }
        #endregion

        #endregion
    }
}

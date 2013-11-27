using System;
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
        public User GetUserCredentials(string userName)
        {
            User currentUser = new User();

            try
            {
                currentUser = _sqlHelper.GetUser(userName);
            }
            catch (Exception)
            {
                throw new Exception("SqlHelper threw an Exception!!!");
            }

            return currentUser;
        }
        #endregion

        #region CreateAccount Method
        public bool CreateAccount(User user)
        {
            return _sqlHelper.CreateUser(user);
        }
        #endregion

        #region UpdateUser Method
        public bool UpdateAccount(User user)
        {
            return _sqlHelper.UpdateUser(user);
        }
        #endregion

        #endregion
    }
}

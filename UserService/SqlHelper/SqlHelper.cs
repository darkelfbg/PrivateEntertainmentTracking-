﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using DataObjects;

namespace UserService.SqlHelpers
{
    public class SqlHelper
    {
        #region Private Variables

        private static string _connectionString = "Server=" + ConfigurationManager.AppSettings["Server"] + ";Database=" +
                                                  ConfigurationManager.AppSettings["Database"] + ";User id=" +
                                                  ConfigurationManager.AppSettings["User"] +
                                                  ";Password=" + ConfigurationManager.AppSettings["Password"];

        private SqlConnection _connection = new SqlConnection(_connectionString);
        #endregion

        #region public Methods

        #region GetUser Method
        public User GetUser(string userName)
        {
            var user = new User();

            #region SQl command string
            const string commandString = "SELECT * FROM UserInfo WHERE UserName = @UserName";
            #endregion

            #region Read from DB

            try
            {
                _connection.Open();

                using (var command = new SqlCommand(commandString, _connection))
                {
                    var userNameParam = new SqlParameter("@UserName", userName);
                    command.Parameters.Add(userNameParam);

                    var reader = command.ExecuteReader();
                    reader.Read();

                    user.UserId = (int) reader["UserID"];
                    user.UserName = (string) reader["UserName"];
                    user.Password = (string) reader["Password"];
                    user.RememberMe = (bool) reader["RememberMe"];
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _connection.Close(); 
            }

            #endregion

            return user;
        }
        #endregion

        #region CreateUser Method
        public bool CreateUser(User user)
        {
            bool result = true;

            #region SQL Insert Command String
            string insertCommandString = "INSERT INTO UserInfo (UserName,Password,RememberMe) VALUES(@UserName,@Password,@RememberMe)";
            #endregion

            #region Insert Into Database
            try
            {
                _connection.Open();

                using (SqlCommand insertCommand = new SqlCommand(insertCommandString, _connection))
                {
                    SqlParameter userNameParam = new SqlParameter("@UserName", user.UserName);
                    SqlParameter passwordParam = new SqlParameter("@Password", user.Password);
                    SqlParameter rememberMeParam = new SqlParameter("@RememberMe", user.RememberMe);

                    insertCommand.Parameters.Add(userNameParam);
                    insertCommand.Parameters.Add(passwordParam);
                    insertCommand.Parameters.Add(rememberMeParam);

                    insertCommand.ExecuteNonQuery();
                }   
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            #endregion

            return result;
        }
        #endregion

        #region Update User Method
        public bool UpdateUser(User user)
        {
            bool result = true;

            #region Update Sql Command String
            string updateSqlcommandString = "UPDATE UserInfo SET Username = @UserName,Password = @Password WHERE UserID = @UserId";
            #endregion

            #region Updating Entry in Database
            try
            {
                _connection.Open();

                using (SqlCommand updateCommand = new SqlCommand(updateSqlcommandString, _connection))
                {
                    SqlParameter userNameParam = new SqlParameter("@UserName", user.UserName);
                    SqlParameter passwordParam = new SqlParameter("@Password", user.Password);
                    SqlParameter userIdParam = new SqlParameter("@UserId", user.UserId);

                    updateCommand.Parameters.Add(userIdParam);
                    updateCommand.Parameters.Add(userNameParam);
                    updateCommand.Parameters.Add(passwordParam);

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            #endregion

            return result;
        }
        #endregion

        #endregion
    }
}
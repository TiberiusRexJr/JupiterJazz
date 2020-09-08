using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jupiter.Models;


namespace Jupiter.DataLayer
{
    public class DataBase
    {
        #region Variables
        private readonly string _server = "etechenterprises.database.windows.net";
        private readonly string _userId = "Ravenone1";
        private readonly string _password = "supersix5!";
        private readonly string _database = "ldb";
        private readonly string _procedureName="dbo.WinningAtWalmart_CRUD";
        private readonly string _procedureExtras = "Extras";
        #endregion
        #region Properties
        public SqlConnection DbConnection { get; set; }
        public string ConnectionString { get; set; }
        public string ProcedureCRUD { get { return _procedureName; } }
        #endregion
        #region Constructor
        public DataBase()
        {
            SetConnectionString();
            SetDbConnection();
        }
        #endregion

        #region Functions
        public void SetDbConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = _database;
            sqlConnectionStringBuilder.UserID = _userId;
            sqlConnectionStringBuilder.Password = _password;
            sqlConnectionStringBuilder.DataSource = _server;
            try 
            { 
            DbConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = _database;
            sqlConnectionStringBuilder.UserID = _userId;
            sqlConnectionStringBuilder.Password = _password;
            sqlConnectionStringBuilder.DataSource = _server;
            ConnectionString = sqlConnectionStringBuilder.ConnectionString;

        }

        public bool Create(Worker worker)
        {
            #region Variables
            int queryCode = 1;
            bool IsEmailAvaliable=false;
            bool SuccessFullEntry = false;
            SqlCommand command = new SqlCommand(ProcedureCRUD, DbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            #endregion
            #region AddParameter
            command.Parameters.AddWithValue("@firstname", worker.FirstName);
            command.Parameters.AddWithValue("@lastname", worker.LastName);
            command.Parameters.AddWithValue("@email", worker.Email);
            command.Parameters.AddWithValue("@password", worker.Password);
            command.Parameters.AddWithValue("@query", queryCode);
            #endregion
            #region TryExecuteCatch
            try
            {
               
                if (IsEmailAvaliable = ValidateEmail(worker.Email))
                {
                    DbConnection.Open();
                    var resultSet = command.ExecuteScalar();
                    if (resultSet != null)
                    {
                        SuccessFullEntry = true;
                    }
                }
               /* result = command.ExecuteScalar().ToString();
                return result;*/

            }
            catch (Exception e)
            {
                /*result = e.Message;
                return result;*/
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
            return SuccessFullEntry;
        }
        public List<Worker> RetrieveAll()
        {
            #region Variables
            SqlCommand cmd = new SqlCommand(ProcedureCRUD,DbConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int queryCode = 4;
            string result = string.Empty;
            List<Worker> workers = new List<Worker>();

            #endregion
            #region SetParameters
            cmd.Parameters.AddWithValue("@id", null);
            
            cmd.Parameters.AddWithValue("@firstname",null);
            cmd.Parameters.AddWithValue("@lastname",null);
            cmd.Parameters.AddWithValue("@email",null);
            cmd.Parameters.AddWithValue("@password",null);
            cmd.Parameters.AddWithValue("@query", queryCode);

            #endregion
            #region ExecuteTryCatchFinally
            try
            {
                DbConnection.Open();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Worker worker1 = new Worker();
                    worker1.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
                    worker1.FirstName = dataSet.Tables[0].Rows[i]["FirstName"].ToString();
                    worker1.LastName = dataSet.Tables[0].Rows[i]["LastName"].ToString();
                    worker1.Email = dataSet.Tables[0].Rows[i]["Email"].ToString();
                    worker1.Password = dataSet.Tables[0].Rows[i]["Psword"].ToString();
                    /*          worker1.Id = 1;
                              worker1.FirstName = "hayyp";
                              worker1.LastName = "lastname";
                              worker1.Email = "email.com";
                              worker1.Password = "passwrd";*/




                    workers.Add(worker1); 

                }

                return workers;
            }
            catch (Exception e)
            {
                ///*UPGADE: Add a "empty" worker class object?*/
                return workers;
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
        }
        public Worker RetrieveByEmail(string userEmail)
        {
            #region Variables
            Worker worker=new Worker();
            int queryCode = 5;
            string result = string.Empty;
            SqlCommand cmd = new SqlCommand(ProcedureCRUD, DbConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd;
            #endregion
            #region AddParameters
            cmd.Parameters.AddWithValue("@email",userEmail);
            cmd.Parameters.AddWithValue("@query", queryCode);
            #endregion
            #region ExecuteTryCatchFinally
            try
            {
                DbConnection.Open();

                sqlDataAdapter.Fill(dataSet);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    worker.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
                    worker.FirstName = dataSet.Tables[0].Rows[i]["FirstName"].ToString();
                    worker.Email = dataSet.Tables[0].Rows[i]["Email"].ToString();
                    worker.Password = dataSet.Tables[0].Rows[i]["Psword"].ToString();
                    worker.UserType = dataSet.Tables[0].Rows[i]["UserType"].ToString();
                }
                return worker;

            }
            catch (Exception e)
            {
                worker.FirstName = e.Message;
                return worker;
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
        }

        public bool Validate(string userEmail, string userPassword)
        {
            #region Variables
            string response = string.Empty;
            bool validUser = false;
            int queryCode = 6;
            SqlCommand cmd = new SqlCommand(ProcedureCRUD,DbConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            

            #endregion
            #region Parameters
            cmd.Parameters.AddWithValue("@email", userEmail);
            cmd.Parameters.AddWithValue("@password", userPassword);
            cmd.Parameters.AddWithValue("@query", queryCode);
            #endregion
            #region TryExecute
            try
            {
                DbConnection.Open();
                var result=cmd.ExecuteScalar();
                if (result != null)
                {
                    validUser = true;
                }
            }
            catch (Exception e)
            {
                response = e.Message.ToString();
            }
            finally 
            {
                DbConnection.Close();
            }
            return validUser;
            #endregion
        }
        public bool ValidateEmail(string userEmail)
        {
            #region variables
            string error = string.Empty;
            bool EmailAvaliable = true;
            SqlCommand sqlCommand = new SqlCommand(ProcedureCRUD, DbConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            int query = 7;
            #endregion
            #region parameters
            sqlCommand.Parameters.AddWithValue("@email", userEmail);
            sqlCommand.Parameters.AddWithValue("@query", query);
            #endregion
            #region TryExecute
            try
            {
                DbConnection.Open();
                var response = sqlCommand.ExecuteScalar();
                if (response != null)
                {
                    EmailAvaliable = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                error = e.Message.ToString();
            }
            finally
            {
                DbConnection.Close();
            }
            #endregion
            return EmailAvaliable;
        }
        public string Update(Worker worker)
        {
            #region Variables
            SqlCommand cmd = new SqlCommand(ProcedureCRUD, DbConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string result = string.Empty;
            int queryCode = 2;
            #endregion
            throw new NotImplementedException();
        }
        public string Delete(int id)
        {
            #region Variables
            int queryCode = 3;
            #endregion
            throw new NotImplementedException();
        }

        public bool UploadProfilePic(string filename,string contentType,byte[] picData,string userEmail)
        {
            #region Variables
            int rowCount = 0;
            bool UploadStatus = false;
            SqlCommand cmd = new SqlCommand(_procedureExtras, DbConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            #endregion
            #region Parameters
            cmd.Parameters.AddWithValue("@filename", filename);
            cmd.Parameters.AddWithValue("@contentType", contentType);
            cmd.Parameters.AddWithValue("@picData", picData);
            cmd.Parameters.AddWithValue("@userEmail", userEmail);
            #endregion
            #region TryExecute
            rowCount = cmd.ExecuteNonQuery();
            if (rowCount != 0)
            {
                UploadStatus = true;
            }
            #endregion
            return UploadStatus;
                }
        #endregion
    }
}

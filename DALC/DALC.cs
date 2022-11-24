using Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Transactions;


namespace DALC
{
    public class DALC
    {
        public class MSSQL
        {
            readonly string _ConnectionString;
            public MSSQL(string _conn) //string i_ConnectionString
            {
                this._ConnectionString = _conn;
                //this._ConnectionString = @"Data Source= CHADI-DESKTOP\\INSTANCE_2K19_01;Database=IDO;user Id = sa;password=79152894Ch@di$$"
            }

            public void addUser()
            {
                using (SqlConnection _con = new SqlConnection(_ConnectionString))
                {
                    _con.Open();
                    string TheSqlOperationItSelf = "addVoter";
                    using (SqlCommand _cmd = new SqlCommand(TheSqlOperationItSelf, _con))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@Fname", v.FName);
                        _cmd.Parameters.AddWithValue("@Mname", v.MName);
                        _cmd.Parameters.AddWithValue("@Lname", v.LName);
                        _cmd.Parameters.AddWithValue("@Sex", v.Sex);
                        _cmd.Parameters.AddWithValue("@RecNb", v.RecorNumber);
                        _cmd.Parameters.AddWithValue("@ido", v.Religion);
                        _cmd.Parameters.AddWithValue("@isVot", v.IsVoted);
                        _cmd.Parameters.AddWithValue("@ROOM", v.Room);
                        _cmd.Parameters.AddWithValue("@Note", "");
                        _cmd.Parameters.AddWithValue("@KEY", 2);
                        _cmd.Parameters.AddWithValue("@PHONE", 43432431);
                        //_cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy/MM/dd"));
                        _cmd.Parameters.AddWithValue("@Date", v.DOB);
                        _cmd.ExecuteNonQuery();
                    }
                }
            }

            //Function to get all voters
            public List<Voter> getAllVoters()
            {
                List<Voter> allVoters = new List<Voter>();

                using (SqlConnection _con = new SqlConnection(_ConnectionString))
                {
                    _con.Open();
                    string TheSqlOperationItSelf = "GET_ALL_VOTERS";
                    using (SqlCommand _cmd = new SqlCommand(TheSqlOperationItSelf, _con))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = _cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Voter v = new Voter();
                            v.FName = reader.GetString("Fname");
                            v.LName = reader.GetString("Lname");
                            v.MName = reader.GetString("Mname");
                            v.RecorNumber = reader.GetInt32("RECORD_NUMBER");
                            v.Religion = reader.GetString("IDEOLOGY");
                            v.IsVoted = reader.GetBoolean("IS_VOTED");
                            v.Note = reader.GetString("NOTE");
                            v.Phone = reader.GetInt32("PHONE_NUMBER");
                            v.DOB = reader.GetDateTime("DOB");
                            v.Sex = reader.GetString("SEX");
                            v.Key = reader.GetString("KEY");
                            allVoters.Add(v);
                        }
                        reader.Close();
                    }
                }

                return allVoters;
            }

            //Function to get Voter by ID 
            public Voter GetVoterByID(int id)
            {
                Voter voter = new Voter();

                using (SqlConnection _con = new SqlConnection(_ConnectionString))
                {
                    _con.Open();
                    string TheSqlOperationItSelf = "GET_VOTER_BY_ID";
                    using (SqlCommand _cmd = new SqlCommand(TheSqlOperationItSelf, _con))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = _cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            voter.Id = reader.GetInt32("VOTER_ID");
                            voter.FName = reader.GetString("Fname");
                            voter.LName = reader.GetString("Lname");
                            voter.MName = reader.GetString("Mname");
                            voter.RecorNumber = reader.GetInt32("RECORD_NUMBER");
                            voter.Religion = reader.GetString("IDEOLOGY");
                            voter.IsVoted = reader.GetBoolean("IS_voterOTED");
                            voter.Note = reader.GetString("NOTE");
                            voter.Phone = reader.GetInt32("PHONE_NUMBER");
                            voter.DOB = reader.GetDateTime("DOB");
                            voter.Sex = reader.GetString("SEX");
                            voter.Key = reader.GetString("KEY");
                        }
                        reader.Close();
                    }
                    return voter;
                }
            }//End of function
        }
    }
}
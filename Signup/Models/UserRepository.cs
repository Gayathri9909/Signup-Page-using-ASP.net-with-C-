using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Signup.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Signup.Repository
{
    public class UserRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constr);
        }

        //to add user details
        public bool AddUser(SignupModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertUserdetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserId", obj.UserId);
            com.Parameters.AddWithValue("@Firstname", obj.Firstname);
            com.Parameters.AddWithValue("@Lastname", obj.Lastname);
            com.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Phonenumber", obj.Phonenumber);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Password", obj.Password);
            com.Parameters.AddWithValue("@Confirmpassword", obj.Confirmpassword);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }

        //to view user details
        public List<SignupModel> GetUser()
        {
            connection();
            List<SignupModel> UserList = new List<SignupModel>();
            SqlCommand com = new SqlCommand("GetUserdetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            UserList = (from DataRow dr in dt.Rows

                        select new SignupModel()
                        {
                            UserId = Convert.ToInt32(dr["Id"]),
                            Firstname = Convert.ToString(dr["Firstname"]),
                            Lastname = Convert.ToString(dr["Lastname"]),
                            DOB = Convert.ToDateTime(dr["DOB"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Phonenumber = Convert.ToString(dr["Phonenumber"]),
                            Email = Convert.ToString(dr["Email"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                            Password = Convert.ToString(dr["Password"]),
                            Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                        }).ToList();
            return UserList;
        }

        //to update userdetails
        public bool UpdateUser(SignupModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateUserdetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserId", obj.UserId);
            com.Parameters.AddWithValue("@Firstname", obj.Firstname);
            com.Parameters.AddWithValue("@Lastname", obj.Lastname);
            com.Parameters.AddWithValue("@DOB", obj.DOB);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Phonenumber", obj.Phonenumber);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Password", obj.Password);
            com.Parameters.AddWithValue("@Confirmpassword", obj.Confirmpassword);
          
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        // to delete user
        public bool DeleteUser(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteUserdetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Npgsql;

namespace BackEnd.Repository
{
    public class UserAuthRepository : CommonRepository, IUserAuthRepository
    {
       

        public void Insert(t_user obj)
        {
          conn.Open();
          NpgsqlCommand cmd=new NpgsqlCommand("INSERT INTO t_user(c_name, c_email, c_password, c_gender, c_address, c_city, c_contact, c_image, c_roleid) VALUES ( @c_name,@c_email,@c_password,@c_gender,@c_address,@c_city,@c_contact,@c_image,@c_roleid);",conn);
            cmd.Parameters.AddWithValue("@c_name",obj.c_name);
            cmd.Parameters.AddWithValue("@c_email",obj.c_email);
            cmd.Parameters.AddWithValue("@c_password",obj.c_password);
            cmd.Parameters.AddWithValue("@c_gender",obj.c_gender);
            cmd.Parameters.AddWithValue("@c_address",obj.c_address);
            cmd.Parameters.AddWithValue("@c_city",obj.c_city);
            cmd.Parameters.AddWithValue("@c_contact",obj.c_contact);
            cmd.Parameters.AddWithValue("@c_image",obj.c_image);
            cmd.Parameters.AddWithValue("@c_roleid",obj.c_roleid);
            NpgsqlDataReader rd=cmd.ExecuteReader();        
          conn.Close();
        }

        public t_user Login(vmLogin data)
        {
           conn.Open();
           NpgsqlCommand cmd=new NpgsqlCommand("select c_userid,c_name,c_email,c_password from t_user where c_email=@c_email and c_password=@c_password",conn);
           cmd.Parameters.AddWithValue("@c_email",data.c_email);
           cmd.Parameters.AddWithValue("@c_password",data.c_password);
           NpgsqlDataReader rd=cmd.ExecuteReader();
           t_user user=new t_user();
           if(rd.Read()){
                user.c_userid=Convert.ToInt32(rd["c_userid"]);
                user.c_name=rd["c_name"].ToString();
                user.c_email=rd["c_email"].ToString();
           }

           conn.Close();
           return user;
        }

    }
}
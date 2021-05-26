using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Project_SPA.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Data
{
    public class CommentsDAO
    {

   

        private readonly IConfiguration _configuration;
        string connectionString;

        public CommentsDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection2");
        }

        public CommentsDAO()
        {

        }

        public List<Comments> GetCommentsByNews(int id) 
        {
            List<Comments> show = new List<Comments>();

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand("SelectCommentsByNews", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure; 
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader sqlDataReader = command.ExecuteReader();
         
                while (sqlDataReader.Read())
                {
                    show.Add(new Comments
                    {
                        IdComment = Convert.ToInt32(sqlDataReader["id_comment"]),
                        Comment = sqlDataReader["comment"].ToString(),
                        IdUser = Convert.ToInt32(sqlDataReader["id_user"]),
                        IdNews = Convert.ToInt32(sqlDataReader["id_news"]),
                    });
                }
                connection.Close(); 
            }

            return show; 

        }

    }
}

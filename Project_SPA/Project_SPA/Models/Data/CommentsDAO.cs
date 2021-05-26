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

       // private readonly IF4101_SPA_APIContext _context;

        private readonly IConfiguration _configuration;
        string connectionString;

        public CommentsDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection2");
        }

       /* public CommentsDAO(IF4101_SPA_APIContext context)
        {
            _context = context;
        }*/

        public CommentsDAO()
        {

        }

      /*  public Comments GetCommentsByNews(int id) 
        {
            List<Comments> comments = new List<Comments>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand("SelectCommentsByNews", connection); 
                command.CommandType = System.Data.CommandType.StoredProcedure; 
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    comments.Add(new Comments
                    {
                        IdComment = Convert.ToInt32(sqlDataReader["id_comment"]),
                        Comment = sqlDataReader["comment"].ToString(),
                        IdUser = Convert.ToInt32(sqlDataReader["id_user"]),
                        IdNews = Convert.ToInt32(sqlDataReader["id_news"]),
                    });
                }
                connection.Close(); 
            }

            return comments; 

        }*/

        public List<Comments> GetCommentsByNews(int id) //ya no es void, sino una lista
        {
            List<Comments> show = new List<Comments>();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("SelectCommentsByNews", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP
                command.Parameters.AddWithValue("@Id", id);
                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
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
                connection.Close(); //cerramos conexión. 
            }

            return show; //retornamos resultado al Controller.  

        }

    }
}

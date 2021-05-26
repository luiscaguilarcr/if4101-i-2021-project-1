using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public class Comments
    {

        private int idComment;
        private string comment;
        private int idUser;
        private int idNews;

        public Comments() 
        { 

        }

        public Comments(int idComment, string comment, int idUser, int idNews)
        {
            this.idComment = idComment;
            this.comment = comment;
            this.idUser = idUser;
            this.idNews = idNews;
        }

        public int IdComment { get => idComment; set => idComment = value; }
        public string Comment { get => comment; set => comment = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdNews { get => idNews; set => idNews = value; }
    }
}

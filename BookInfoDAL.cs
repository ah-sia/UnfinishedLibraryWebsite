using AishasLib.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace LibraryDataAccessLayer
{
    public interface IBookInfoDAL
    {
        List<BookInfo> GetBookInfo();
        bool AddBookInfo(BookInfo book);
        bool DeleteBookInfo(BookInfo book);
    }
    public class BookInfoDAL : IBookInfoDAL
    {
        public readonly IConfiguration _configuration;

        public BookInfoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<BookInfo> GetBookInfo()
        {
            var BookList = new List<BookInfo>();

            string queryString = "SELECT BookTitle, AuthorFirstName, AuthorLastName, BookEdition, PublisherName, PublishedDate\r\nFROM dbo.BOOKS";
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AishasLibrary")
                .ToString());
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    BookInfo bookInfo = new BookInfo();
                    bookInfo.BookTitle = Convert.ToString(reader["BookTitle"]);
                    bookInfo.AuthorFirstName = Convert.ToString(reader["AuthorFirstName"]);
                    bookInfo.AuthorLastName = Convert.ToString(reader["AuthorLastName"]);
                    bookInfo.BookEdition = Convert.ToInt32(reader["BookEdition"]);
                    bookInfo.PublisherName = Convert.ToString(reader["PublisherName"]);
                    bookInfo.PublishedDate = Convert.ToDateTime(reader["PublishedDate"]);
                    BookList.Add(bookInfo);
                }
            }
            connection.Close();
            return BookList;
        }

        public bool AddBookInfo(BookInfo book)
        {
            bool ret = false;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AishasLibrary")
                .ToString());
            SqlCommand cmd = new SqlCommand("INSERT into dbo.[BOOKS] (BookTitle, AuthorFirstName, AuthorLastName, BookEdition, PublisherName, PublishedDate) "
                                             + "VALUES (@BookTitle,@AuthorFirstName,@AuthorLastName,@BookEdition,@PublisherName,@PublishedDate)", connection);  // add the parameter names
            cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);  // parameter name with respect to the value
            cmd.Parameters.AddWithValue("@AuthorFirstName", book.AuthorFirstName);
            cmd.Parameters.AddWithValue("@AuthorLastName", book.AuthorLastName);
            cmd.Parameters.AddWithValue("@BookEdition", book.BookEdition);
            cmd.Parameters.AddWithValue("@PublisherName", book.PublisherName);
            cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
            connection.Open();  //open the connection
            ret = cmd.ExecuteNonQuery() == 1;
            connection.Close();
            return ret;

        }

        public bool DeleteBookInfo(BookInfo book)
        {
            bool ret = false;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AishasLibrary")
                .ToString());
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.[BOOKS] WHERE BookTitle='@BookTitle' AND AuthorFirstName='@AuthorFirstName' AND AuthorLastName='@AuthorLastName'",connection);  // add the parameter names
            cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);  // parameter name with respect to the value
            cmd.Parameters.AddWithValue("@AuthorFirstName", book.AuthorFirstName);
            cmd.Parameters.AddWithValue("@AuthorLastName", book.AuthorLastName);
            connection.Open(); //open the connection
            ret = cmd.ExecuteNonQuery() == 1;
            connection.Close();
            return ret;
        }
    }
}

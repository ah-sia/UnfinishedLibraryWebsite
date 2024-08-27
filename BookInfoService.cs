using AishasLib.Models;
using LibraryDataAccessLayer;
using System.Data;
using System.Data.SqlClient;


namespace AishasLib.Service
{
    public interface IBookInfoService
    {
        List<BookInfo> GetBookInfo();
        bool AddBookInfo(BookInfo book);
        bool DeleteBookInfo(BookInfo book);
    }
    public class BookInfoService : IBookInfoService
    {
     
        private readonly IBookInfoDAL _bookInfoDAL;

        public BookInfoService(IBookInfoDAL bookInfoDal) {
            _bookInfoDAL = bookInfoDal;
        }

        public List<BookInfo> GetBookInfo()
        {
            return _bookInfoDAL.GetBookInfo();
        }

        public bool AddBookInfo(BookInfo book)
        {

         //   addNewBook.BookEdition = addNewBook.BookEdition == -1 ? 0 : 100;

            //if(addNewBook.BookEdition == -1)
            //{
            //    addNewBook.BookEdition = 0;
            //}
            //else
            //{
            //    addNewBook.BookEdition = 100;
            //}

            return _bookInfoDAL.AddBookInfo(book);
        }

        public bool DeleteBookInfo(BookInfo book)
        {
            return _bookInfoDAL.DeleteBookInfo(book);

        }

    }
}

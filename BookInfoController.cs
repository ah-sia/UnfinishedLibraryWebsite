using AishasLib.Models;
using AishasLib.Service;
using Microsoft.AspNetCore.Mvc;


namespace AishasLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookInfoController : ControllerBase {

        private readonly IBookInfoService _bookInfoService;

        public BookInfoController(IBookInfoService bookInfoService)
        {
            _bookInfoService = bookInfoService;
        }

        [HttpGet]
        [Route("GetBookInfo")]
        public List<BookInfo> GetBookInfo() { 
          var result = _bookInfoService.GetBookInfo();
           return result;
        }

        
        [HttpPost]
        [Route("AddBookInfo")]
        public bool AddBookInfo([FromBody]BookInfo book)
        {
            return _bookInfoService.AddBookInfo(book);
        }

        [HttpDelete]
        [Route("DeleteBookInfo")]
        public bool DeleteBookInfo([FromBody]BookInfo book) {
            return _bookInfoService.DeleteBookInfo(book);
        }
    }
}

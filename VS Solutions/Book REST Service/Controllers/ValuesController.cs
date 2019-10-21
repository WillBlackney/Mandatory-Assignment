using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book_Library;

namespace Book_REST_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {        
            // GET: api/Items
            [HttpGet]
            public IEnumerable<Book> Get()
            {
                return books;
            }

        //// GET: api/Items/5
        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}", Name = "Get")]
        public Book Get(string id)
            {
                return books.Find(i => i.IsbnCode == id);
            }

            // POST: api/Items
            [HttpPost]
            public void Post([FromBody] Book value)
            {
                books.Add(value);
            }

            // PUT: api/Items/5
            [HttpPut]
            [Route("{id}")]
            public void Put(string IsbnCode, [FromBody] Book value)
            {
                Book item = Get(IsbnCode);
                if (item != null)
                {
                    item.IsbnCode = value.IsbnCode;
                    item.Author = value.Author;
                    item.Title = value.Title;
                    item.NumberOfPages = value.NumberOfPages;
                }


            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete]
            [Route("{id}")]
            public void Delete(string IsbnCode)
            {
                Book item = Get(IsbnCode);
                books.Remove(item);
            }

            // GET all that contain string
            [HttpGet]
            [Route("Name/{substring}")]
            public IEnumerable<Book> GetFromSubstring(String substring)
            {
                return books.FindAll(i => i.IsbnCode.Contains(substring));
            }


            private static readonly List<Book> books = new List<Book>()
        {
            new Book("Mein Kampf","Adolf Hitler","0000000000001",52),
            new Book("Animal Farm","George Orwell","0000000000002",183),
            new Book("American Psycho","Brett Easton Ellis","0000000000003",220),
            new Book("A Brief History Of Time","Steven Hawking","0000000000004",279),
            new Book("Origin Of Species","Charles Darwin","0000000000005",312)
        };
        
    }
}

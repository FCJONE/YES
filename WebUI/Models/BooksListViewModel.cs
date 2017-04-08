using System.Collections.Generic;
using Domain;

namespace WebUI.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace libraryCataloger.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Книга")]
        public string Title { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Издатель")]
        public string Publisher { get; set; }

        public bool IsAvailable { get; set; }

        [Display(Name = "Читатель")]
        public string Name { get; set; }

        [Display(Name = "Время взятия")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Время возврата")]
        public DateTime? ReturnDate { get; set; }
    }
}
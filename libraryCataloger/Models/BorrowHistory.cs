using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace libraryCataloger.Models
{
    public class BorrowHistory
    {
        public int BorrowHistoryId { get; set; }

        [Required]
        [Display(Name = "Книга")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        [Display(Name = "Читатель")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Дата возврата")]
        public DateTime? ReturnDate { get; set; }
    }
}
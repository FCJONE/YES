using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Domain.Common;

namespace Domain
{
    public class Cart : EntityBase
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines => _lineCollection;

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int CartId { get; set; }

    }


    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

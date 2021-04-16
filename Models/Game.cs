using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required, StringLength(60)]
        public string Title { get; set; }

        [Required, StringLength(30)]
        public string Console { get; set; }

        [Required, StringLength(30)]
        public string Genre { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

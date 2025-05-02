using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entity.Ḍto
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public int OrderId { get; set; }

        public string? ProductName { get; set; }

        public int Qty { get; set; }

        public int Total { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int TotalPrice { get; set; }
    }
}

using ECommerce.HTTPAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.HTTPAPI.Models
{
    public class Basket : EntityBase
    {
       
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public Guid UserId { get; set; }

    }

}

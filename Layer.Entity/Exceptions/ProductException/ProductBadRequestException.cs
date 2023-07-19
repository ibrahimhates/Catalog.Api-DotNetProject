using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Exceptions.ProductException
{
    public class ProductBadRequestException : BadRequestException
    {
        public ProductBadRequestException(int id) 
            : base($"Incorrect request for products. Category could not found with id:{id}")
        {
        }
    }
}

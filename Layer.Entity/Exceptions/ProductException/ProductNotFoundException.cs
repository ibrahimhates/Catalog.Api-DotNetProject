using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Exceptions.ProductException
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) 
            : base($"Prodduct could not found with id: {id}")
        {
        }
    }
}

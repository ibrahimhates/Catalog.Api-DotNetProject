using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Exceptions.CategoryException
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id) 
            : base($"Category could not found with id: {id}")
        {
        }
    }
}

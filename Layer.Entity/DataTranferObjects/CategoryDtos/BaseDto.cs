using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.DataTranferObjects.CategoryDtos
{
    public record BaseDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}

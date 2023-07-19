using System;
using System.Text.Json;

namespace Layer.Entity.ErrorModels
{
    public class ErrorDetail
    {
        public String ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

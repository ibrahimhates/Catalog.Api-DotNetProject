
using Layer.Entity.Models;
using System.Linq.Expressions;

namespace Layer.Repository.Extensions
{
    public static class FeatureExtensions
    {
        public static IQueryable<T> ToPageList<T>(this IQueryable<T> values,
            int pageSize,int pageNumber) 
            where T : class
        {
            var pagedValues = values
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize);

            return pagedValues;
        }

        public static IQueryable<T> Search<T>(this IQueryable<T> values,
            string? searchTerm) where T : BaseModel
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return values;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            var searchedValues = values
                .Where(x => x.Name
                .ToLower()
                .Contains(lowerCaseSearchTerm));

            return searchedValues;
        }
    }
}

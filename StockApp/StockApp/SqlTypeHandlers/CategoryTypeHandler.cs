using Dapper;
using StockApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.SqlTypeHandlers;

public class CategoryTypeHandler : SqlMapper.TypeHandler<IEnumerable<Category>>
{
    public override IEnumerable<Category> Parse(object value)
    {
        if (value is string stringValue)
        {
            var categoryStrings = stringValue.Split(',')
                                             .Select(s => s.Trim().ToLowerInvariant());

            var categories = new List<Category>();
            foreach (var categoryString in categoryStrings)
            {
                if (Enum.TryParse(categoryString, ignoreCase: true, out Category category))
                {
                    categories.Add(category);
                }
            }
            return categories;
        }
        return Enumerable.Empty<Category>();
    }

    public override void SetValue(System.Data.IDbDataParameter parameter, IEnumerable<Category> value)
    {
        throw new NotImplementedException();
    }
}
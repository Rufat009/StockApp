using System.Collections.Generic;

namespace StockApp.Models;

public class Product
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }
    public int? Count { get; set; }

	public IEnumerable<Category> Categories { get; set; }

}

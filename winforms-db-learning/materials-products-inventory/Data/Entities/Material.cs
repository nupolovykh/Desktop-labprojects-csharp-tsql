namespace WinFormsApp.Data.Entities;

internal class Material
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;


	public IEnumerable<Product> Products { get; set; } = null!;
}

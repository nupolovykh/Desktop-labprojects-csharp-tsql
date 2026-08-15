namespace WinFormsApp.Data.Entities;

internal class Product
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public decimal Price { get; set; } = 0M;


	public int? MaterialId { get; set; }
	public Material? Material { get; set; }
}

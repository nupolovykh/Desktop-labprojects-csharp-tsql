using WinFormsApp.Data.Entities;

namespace WinFormsApp.Services.Interfaces;

internal interface IDbWorker
{
	public IEnumerable<Material> Materials { get; }
	public IEnumerable<Product> Products { get; }

	public void SaveChanges();
}

using Microsoft.EntityFrameworkCore;
using WinFormsApp.Data;
using WinFormsApp.Data.Entities;
using WinFormsApp.Services.Interfaces;

namespace WinFormsApp.Services.Implementations;

internal class DbWorker : IDbWorker
{
	private readonly AppDbContext _appDbContext;
	private readonly List<Product> _products;
	private readonly List<Material> _materials;

	public DbWorker(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;

		_products = _appDbContext.Products
			.Include(x => x.Material)
			.ToList();

		_materials = _appDbContext.Materials
			.Include(x => x.Products)
			.ToList();
	}

	public IEnumerable<Material> Materials => _materials;

	public IEnumerable<Product> Products => _products;

	public void SaveChanges() => _appDbContext.SaveChanges();
	
}

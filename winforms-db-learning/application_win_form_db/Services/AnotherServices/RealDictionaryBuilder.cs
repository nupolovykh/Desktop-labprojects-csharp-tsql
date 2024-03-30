namespace application_win_form_db.Services
{
	internal static class RealDictionaryBuilder
	{
		public static void SubscribeToCollectionChangesInDictionary(this Dictionary<string, ObservableCollection<object>> dict, AppDbContext context)
		{
			foreach (var key in dict.Keys)
			{
				dict[key].CollectionChanged += (sender, e) =>
				{
					if (e.Action == NotifyCollectionChangedAction.Add)
					{
						foreach (var item in e.NewItems!)
						{
							AddToAnyCollection(context, (dynamic)item);
						}
					}

					if (e.Action == NotifyCollectionChangedAction.Remove)
					{
						foreach (var item in e.OldItems!)
						{
							RemoveFromAnyCollection(context, (dynamic)item);
						}
					}
				};
			}
		}

		private static void AddToAnyCollection<T>(AppDbContext context, T item) where T : class
		{
			var dbSet = context.Set<T>();
			dbSet.Add(item);
		}

        private static void RemoveFromAnyCollection<T>(AppDbContext context, T item) where T : class
		{
			var dbSet = context.Set<T>();
			dbSet.Remove(item);
		}


		public static void CreateTypeToIdDictionary(this Dictionary<string, Type> dict, AppDbContext context)
		{
			var dbProperties = context.GetType().GetProperties();

			foreach (var property in dbProperties)
			{
				if (IsDbSet(property.PropertyType))
				{
					var tableName = property.Name;
					var entity = property.PropertyType.GetGenericArguments()[0];
					dict.Add(tableName, entity);
				}
			}
		}

		private static bool IsDbSet(Type propertyType) =>
			propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(DbSet<>);
	}
}

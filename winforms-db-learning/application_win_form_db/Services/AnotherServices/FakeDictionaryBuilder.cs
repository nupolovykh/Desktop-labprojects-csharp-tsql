namespace application_win_form_db.Services
{
    internal static class FakeDictionaryBuilder
    {
        public static void FakeSubscribeToCollectionChangesInDictionary(this Dictionary<string, ObservableCollection<object>> dict, IServiceProvider provider)
        {
            foreach (var key in dict.Keys)
            {
                dict[key].CollectionChanged += (sender, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (var item in e.NewItems!)
                        {
                            FakeAddToAnyCollection((dynamic)item, provider);
                        }
                    }

                    if (e.Action == NotifyCollectionChangedAction.Remove)
                    {
                        foreach (var item in e.OldItems!)
                        {
                            FakeRemoveFromAnyCollection((dynamic)item, provider);
                        }
                    }
                };
            }
        }

        private static void FakeAddToAnyCollection<T>(T item, IServiceProvider provider) where T : class
        {
            var fakeDb = provider.GetService<FakeDbWorker>();
            //fakeDb.Add(item);
        }

        private static void FakeRemoveFromAnyCollection<T>(T item, IServiceProvider provider) where T : class
        {
            var fakeDb = provider.GetService<FakeDbWorker>();
            //dbSet.Remove(item);
        }
    }
}

global using Xunit;

// UnitTestFirst/Second/Third all read and write the same shared fixture files
// (People.json etc.) in the lab4 root. xUnit runs different test classes in
// parallel by default, which races on that shared file state. Force sequential
// execution instead of rewriting the tests to use isolated fixtures.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
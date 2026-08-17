using System.Runtime.CompilerServices;

// Lets Screenshot/ construct internal Main/DbWorker/AppDbContext types directly
// instead of duplicating them or changing their visibility just for a screenshot harness.
[assembly: InternalsVisibleTo("Lab3.Screenshot")]

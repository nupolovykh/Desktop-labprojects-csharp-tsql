using System.Runtime.CompilerServices;

// Lets Screenshot/ construct internal RealDbWorker/UserIdentity types directly
// instead of duplicating them or changing their visibility just for a screenshot harness.
[assembly: InternalsVisibleTo("MyWinFormsAppForDb.Screenshot")]

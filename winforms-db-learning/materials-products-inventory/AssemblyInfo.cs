using System.Runtime.CompilerServices;

// Lets Screenshot/ construct internal Forms/DbContext types directly instead of
// duplicating them or changing their visibility just for a screenshot harness.
[assembly: InternalsVisibleTo("MaterialsProductsInventory.Screenshot")]

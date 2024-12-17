using Modelos.Add;
//obtener asndencia o desendencia de Address1 o CreationDate 
public class AddressSv
{
    public IEnumerable<Address> GetSortedAddresses(IEnumerable<Address> addresses, string orderBy = "Address1", string sortOrder = "asc")
    {
        var sorted = addresses.AsQueryable();
        orderBy = orderBy.ToLower();
        sortOrder = sortOrder.ToLower();

        if (orderBy == "creationdate")
        {
            sorted = sortOrder == "desc" ?
            sorted.OrderByDescending(a => a.CreationDate) :
                sorted.OrderBy(a => a.CreationDate);
        }
        else
        {
            sorted = sortOrder == "desc" ?
            sorted.OrderByDescending(a => a.address1) :
                sorted.OrderBy(a => a.address1);
        }
        return sorted.ToList();
    }
}

using Modelos.Add;
//direccion preferida
public class PreferredAdSv
{
    public Address? GetPreferredAddress(IEnumerable<Address> addresses)
    {
        var preferredAddress = addresses.FirstOrDefault(a => a.preferred);
        return preferredAddress;
    }
}

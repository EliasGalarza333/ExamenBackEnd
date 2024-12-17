using Modelos.Add;

//Acceder por medio de codigo postal haciendo uso de Where de linQ
public class postalSv
{
    public IEnumerable<Address> GetAddressesByPostalCode(List<Address> addresses, string postalCode)
    {
        return addresses.Where(a => a.postalCode == postalCode).ToList();
    }
}

using MiProyecto.Modelos;
//Solo informacion importante
public class infoSv
{
    public object GetImportantInfo(Client client)
    {
        return new
        {
            client.CustomerId,
            client.Email,
            client.PhoneHome,
            client.FirstName,
            client.LastName,
            client.addresses
        };
    }
}

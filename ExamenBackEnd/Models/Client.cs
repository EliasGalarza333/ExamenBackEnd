using System.Text.Json.Serialization;
using Modelos.Add;

namespace MiProyecto.Modelos
{
    public class Client
    {
        /*inicializamos los strings y List como default para tener mas control al inicio 
        y evitar errores o confuciones, luego se llenan mediante la obtencion del json*/

        [JsonPropertyName("authType")]
        public string AuthType { get; set; } = "default_value";
        //uso de JsonPropertyName para indicar la verdadera clave del json.. 

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } = "default_value";

        [JsonPropertyName("customerNo")]
        public string CustomerNo { get; set; } = "default_value";

        [JsonPropertyName("email")]
        public string Email { get; set; } = "default_value";

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = "default_value";

        [JsonPropertyName("lastLoginTime")]
        public DateTime LastLoginTime { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = "default_value";

        [JsonPropertyName("lastVisitTime")]
        public DateTime LastVisitTime { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; } = "default_value";

        [JsonPropertyName("phoneHome")]
        public string PhoneHome { get; set; } = "default_value";

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; } = "default_value";
        public List<Address> addresses { get; set; } = new List<Address>();

    
    }


   
}

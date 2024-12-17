using MiProyecto.Modelos;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class ClientService
{
    //httpclient para realizar peticiones y asignar la url del json junto a la authenticacion 
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer";
    private const string AuthHeader = "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=";

    public ClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Client> GetClientAsync()
    {
        //acceso con la authenticacion Base64
        _httpClient.DefaultRequestHeaders.Add("Authorization", AuthHeader);
        _httpClient.DefaultRequestHeaders.Add("Version", "2.0.6.0");

        var response = await _httpClient.GetAsync(BaseUrl);
        response.EnsureSuccessStatusCode(); 

        string jsonResponse = await response.Content.ReadAsStringAsync();

        /*/eliminar el mayor problema de legibilidad escapes, espacios, caracteres y muy importante
        las comillas al principio y al final de json utilizando remplazos*/

        jsonResponse = Regex.Replace(jsonResponse, @"\s+", ""); 
        jsonResponse = jsonResponse.Replace("\\r", "").Replace("\\n", ""); 
        jsonResponse = jsonResponse.Replace("\\", "");

        if (jsonResponse.StartsWith("\"") && jsonResponse.EndsWith("\""))
        {
            jsonResponse = jsonResponse.Substring(1, jsonResponse.Length - 2); 
        }

        Console.WriteLine("JSON después de eliminar escapes, caracteres y espacios..:");
        Console.WriteLine(jsonResponse);  

        // Deserializar 
        var client = JsonSerializer.Deserialize<Client>(jsonResponse);

        return client;
    }
    /*importante: una vez teniendo la respuesta en consola del json completamente correcto y sin escapes,
    utilize la extencion Json Crack de Visual Studio para el json en el archivo "Controller/ResponseServer.json"
    para conprender aun mejor la estructura.
    */
}

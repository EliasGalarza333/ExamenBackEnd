using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;
    private readonly infoSv _infoService;
    private readonly postalSv _postalService;
    private readonly AddressSv _addressSv;
    private readonly PreferredAdSv _preferredAdSv;

    //inyeccion de los servicios para utilizarlos en el controlador
    public ClientController(ClientService clientService, 
    infoSv infoService, postalSv postalService, AddressSv addressSv, PreferredAdSv preferredAdSv)
    {
        _clientService = clientService;
        _infoService = infoService;
        _postalService = postalService;
        _addressSv = addressSv;
        _preferredAdSv = preferredAdSv;

    }

    [HttpGet("info")]
    public async Task<IActionResult> GetImportantInfo()
    {
        try
        {
            var client = await _clientService.GetClientAsync();
            if (client == null)
            {
                return NotFound("sin datos del cliente");
            }
            var importantInfo = _infoService.GetImportantInfo(client);
            return Ok(importantInfo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("addresses")]
    public async Task<IActionResult> GetSortedAddresses([FromQuery] string orderBy = "Address1", [FromQuery] string sortOrder = "asc")
    {
        try
        {
            var client = await _clientService.GetClientAsync();

            if (client == null)
            {
                return NotFound("sin datos del cliente");
            }
            var addresses = client.addresses;
            var sortedAddresses = _addressSv.GetSortedAddresses(addresses, orderBy, sortOrder);

            if (!sortedAddresses.Any())
            {
                return NotFound("sin direcciones");
            }
            return Ok(sortedAddresses);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("addresses/{postalCode}")]
    public async Task<IActionResult> GetAddressesByPostalCode(string postalCode)
    {
        try
        {
            var client = await _clientService.GetClientAsync();
            if (client == null)
            {
                return NotFound("sin datos");
            }
            var addresses = _postalService.GetAddressesByPostalCode(client.addresses, postalCode);
            if (!addresses.Any())
            {
                return NotFound($"no hay direcciones para el postal {postalCode}");
            }
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("preferred_address")]
    public async Task<IActionResult> GetPreferredAddress()
    {
        try
        {
            var client = await _clientService.GetClientAsync();
            if (client == null)
            {
                return NotFound("sin datos del cliente");
            }
            var preferredAddress = _preferredAdSv.GetPreferredAddress(client.addresses);
            if (preferredAddress == null)
            {
                return NotFound("no a encontrado preferencias.");
            }
            return Ok(preferredAddress);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}

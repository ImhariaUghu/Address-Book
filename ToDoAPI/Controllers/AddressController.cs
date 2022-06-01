using AddressAPI.Models;
using AddressAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//URL: http://localhost:5066/address
public class AddressController : ControllerBase
{
    private readonly ICrudService<AddressItem, int> _addressService;
    public AddressController(ICrudService<AddressItem, int> addressService)
    {
        _addressService = addressService;
    }

    // GET all action
    [HttpGet] // auto returns data with a Content-Type of application/json
    public ActionResult<List<AddressItem>> GetAll() => _addressService.GetAll().ToList();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<AddressItem> Get(int id)
    {
        var address = _addressService.Get(id);
        if (address is null) return NotFound();
        else return address;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(AddressItem address)
    {
        // Runs validation against model using data validation attributes
        if (ModelState.IsValid)
        {
            _addressService.Add(address);
            return CreatedAtAction(nameof(Create), new { id = address.Id }, address);
        }
        return BadRequest();
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, AddressItem address)
    {
        var existingAddressItem = _addressService.Get(id);
        if (existingAddressItem is null || existingAddressItem.Id != id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            _addressService.Update(existingAddressItem, address);
            return NoContent();
        }
        return BadRequest();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var address = _addressService.Get(id);
        if (address is null) return NotFound();
        _addressService.Delete(id);
        return NoContent();
    }
}

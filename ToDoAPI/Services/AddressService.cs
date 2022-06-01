using AddressAPI.Models;

namespace AddressAPI.Services;

public class AddressService : ICrudService<AddressItem, int>
{
    private readonly ICrudRepository<AddressItem, int> _addressRepository;
    public AddressService(ICrudRepository<AddressItem, int> addressRepository)
    {
        _addressRepository = addressRepository;
    }
    public void Add(AddressItem element)
    {
        _addressRepository.Add(element);
        _addressRepository.Save();
    }
    public void Delete(int id)
    {
        _addressRepository.Delete(id);
        _addressRepository.Save();
    }
    public AddressItem Get(int id)
    {
        return _addressRepository.Get(id);
    }
    public IEnumerable<AddressItem> GetAll()
    {
        return _addressRepository.GetAll();
    }
    public void Update(AddressItem old, AddressItem newT)
    {
        old.Description = newT.Description;
        old.Status = newT.Status;
        _addressRepository.Update(old);
        _addressRepository.Save();
    }
}

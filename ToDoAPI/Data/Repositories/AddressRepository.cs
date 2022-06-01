using AddressAPI.Models;

namespace AddressAPI.Data.Repositories
{
    public class AddressRepository : ICrudRepository<AddressItem, int>
    {
        private readonly AddressContext _addressContext;
        public AddressRepository(AddressContext todoContext)
        {
            _addressContext = todoContext ?? throw new
            ArgumentNullException(nameof(todoContext));
        }
        public void Add(AddressItem element)
        {
            _addressContext.AddressItems.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _addressContext.AddressItems.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _addressContext.AddressItems.Any(u => u.Id == id);
        }
        public AddressItem Get(int id)
        {
            return _addressContext.AddressItems.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<AddressItem> GetAll()
        {
            return _addressContext.AddressItems.ToList();
        }
        public bool Save()
        {
            return _addressContext.SaveChanges() > 0;
        }
        public void Update(AddressItem element)
        {
            _addressContext.Update(element);
        }
    }
   
}

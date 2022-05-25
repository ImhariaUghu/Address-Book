namespace ToDoAPI.Data
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
        }
        public DbSet<AddressItem> AddressItems { get; set; }
    }
}

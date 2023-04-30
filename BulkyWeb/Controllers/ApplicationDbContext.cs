namespace BulkyWeb.Controllers
{
    internal class ApplicationDbContext
    {
        public object Products { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
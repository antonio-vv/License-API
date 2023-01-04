using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfCategories
    {
        Categories GetCat(string name);

        bool CreateCat(Categories cat);

        bool UpdateCat(Categories cat);
        
        IEnumerable<Categories> GetCats();
    }
}

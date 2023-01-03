using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfCategories
    {
        Categories GetCat(string name);

        void CreateCat(Categories cat);

        void UpdateCat(Categories cat);
        
        IEnumerable<Categories> GetCats();
    }
}

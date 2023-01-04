using License_API.DTOs;
using License_API.Entities;
using License_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly InterfCategories repo;

        public CategoryController(InterfCategories repo)
        {
            this.repo = repo;
        }

        // GET /Category
        [HttpGet]
        public IEnumerable<Categories> GetCats()
        {
            var cats = repo.GetCats();
            return cats;
        }

        // GET /Category/{name}
        [HttpGet("{name}")]
        public ActionResult<CategoriesDTO> GetCat(string name)
        {
            var cat = repo.GetCat(name);
            if (cat is null)
            {
                return NotFound();
            }
            else
            {
                return cat.AsDTO();
            }
        }

        // POST /Category
        [HttpPost]
        public ActionResult<CategoriesDTO> CreateCat(NewCatDTO ncDTO)
        {
            Categories cat = new()
            {
                Name = ncDTO.Name,
                Creations = ncDTO.Creations,
                Updates = ncDTO.Updates,
                Additions = ncDTO.Additions,
                Deletions = ncDTO.Deletions,
            };

            if (repo.CreateCat(cat))
            {
                return CreatedAtAction(nameof(GetCat), new { name = cat.Name }, cat.AsDTO());
            }
            else
            {
                return BadRequest();
            }
            
        }

        // PUT /Category/{name}
        [HttpPut("{name}")]
        public ActionResult<CategoriesDTO> UpdateCat(string name, UpdateCatDTO ncDTO)
        {
            var exCat = repo.GetCat(name);
            if (exCat is null)
            {
                return NotFound();
            }

            Categories cat = exCat with
            {
                Creations = ncDTO.Creations,
                Updates = ncDTO.Updates,
                Additions = ncDTO.Additions,
                Deletions = ncDTO.Deletions,
            };

            if (repo.UpdateCat(cat))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

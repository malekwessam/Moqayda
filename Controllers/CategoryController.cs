using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using Moqayda.API.ViewModel.Create;
using Moqayda.API.ViewModel.Get;
using Moqayda.API.ViewModel.Update;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moqayda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        private readonly IHostingEnvironment hostingEnvironment;

        public CategoryController(ICategoryService categoryService, IHostingEnvironment hostingEnvironment)
        {
            this.categoryService = categoryService;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<CategoryController>
        [HttpGet("", Name = "GetCategorys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {

            var categorys = await categoryService.GetCategorysAsync();

            var models = categorys.Select(category => new CategoryViewModel()
            {

                Id = category.Id,
                Name = category.CategoryName,
                CategoryBackgroundColor = category.CategoryBgColor ?? 0,
                pathImage = "http://www.moqayda.somee.com/" + category.PathImage,
                IsActive = category.IsAcTive


            }).ToList();
            return Ok(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(short id)

        {
           
            var category = await categoryService.GetCategoryAndProductsAsync(id);
            if (category == null)
                return NotFound();
            var nn = "http://www.moqayda.somee.com/" + category.PathImage;

            var model = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.CategoryName,
                pathImage = nn,
                CategoryBackgroundColor = category.CategoryBgColor ?? 0,
                IsActive = category.IsAcTive,

                CategoryProductViewModels = category.Product.Any() ? category.Product.Select(s => new CategoryProductViewModel()
                {

                    
                    Id = s.Id,
                    Name = s.ProductName,
                    Descriptions = s.ProductDescription,
                    pathImage = "http://www.moqayda.somee.com/" + s.PathImage,
                    AvailableSince = s.AvailableSince,
                    IsActive = s.IsActive,
                    CategoryId = category.Id

                }).ToList() : new List<CategoryProductViewModel>()

            };
            return Ok(model);
        }

        // POST api/<CategoryController>
        [HttpPost]

        public async Task<ActionResult> Post([FromForm] CreateCategory createCategory, IFormFile image)
        {
            Random random = new Random();
            int rNum = random.Next();
            var images = "images/"+ rNum + image.FileName ;
            var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
            var streamImage = new FileStream(pathImage, FileMode.Append);
            image.CopyTo(streamImage);
            var entityToAdd = new Category()
            {
                //Id=createCategory.Id,
                CategoryName = createCategory.Name,
                PathImage = images,
                CategoryBgColor = createCategory.CategoryBackgroundColor,
                IsAcTive = createCategory.IsActive

            };
            var createdProduct = await categoryService.CreateCategoryAsync(entityToAdd);
            return new CreatedAtRouteResult("Get", new { Id = createCategory.Id });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}", Name = "UpdateCategory")]

        public async Task<ActionResult> Put(short id, [FromForm] UpdateCategory updateCategory, IFormFile image)
        {
            Random random= new Random();
            int rNum = random.Next(5);
            //Guid guid =Guid.NewGuid();
            //string extention=Path.GetExtension(image.FileName);
            //string newFileName=guid.ToString()+extention;
            var images = "images/" + image.FileName +rNum;
            var pathImage = Path.Combine(hostingEnvironment.WebRootPath, images);
            var streamImage = System.IO.File.OpenRead(pathImage);

            image.CopyTo(streamImage);
            var entityToUpdate = await categoryService.GetCategoryAsync(updateCategory.Id);


            entityToUpdate.Id = updateCategory.Id;
            entityToUpdate.CategoryName = updateCategory.Name;

            entityToUpdate.IsAcTive = updateCategory.IsActive;

            entityToUpdate.PathImage = images;
            entityToUpdate.CategoryBgColor = updateCategory.CategoryBackgroundColor;

            var updatedCategory = await categoryService.UpdateCategoryAsync(entityToUpdate);
            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(short id)
        {
            var category = await categoryService.GetCategoryAsync(id);
            if (category == null)
                return NotFound();
            //var nn = "http://www.moqayda.somee.com/" + category.PathImage;
            //System.IO.File.Delete(nn);
            var isSuccess = await categoryService.DeleteCategoryAsync(id);

            return Ok();
        }
    }
}

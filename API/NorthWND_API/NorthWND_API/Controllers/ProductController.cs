using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using North_Business.Abstract;
using North_Business.Concreate;
using North_Model.Concreate.DTOs;
using North_Model.Concreate.Entities;

namespace NorthWND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBS _bs;
        private IMapper _mapper;
        // public ProductControlller(Product bs)
        public ProductController(IProductBS bs, IMapper mapper)
        {
            _bs = bs;
            _mapper = mapper;
        }



        [HttpGet("hepsinigetir")]
        public List<ProductGetDTO> GetAll()
        {
            var list = _bs.GetProducts(null, "Category");
            //List<ProductGetDTO> veriler = new List<ProductGetDTO>();
            //foreach (var item in list)
            //{
            //    ProductGetDTO dto = new ProductGetDTO();
            //    dto.ProductName = item.ProductName;
            //    dto.CategoryName = item.Category.CategoryName;
            //    dto.UnitPrice = item.UnitPrice;
            //    dto.UnitsInStock = item.UnitsInStock;
            //    veriler.Add(dto);
            //}
            var veriler = _mapper.Map<List<ProductGetDTO>>(list);
            return veriler;
        }



        [HttpPost("add")]
        public ProductGetDTO Add([FromBody] ForCreationProductDTO dto)
        {
            // Dto -> product Map
            var product = _mapper.Map<Product>(dto);
            // Product
            var addedProduct = _bs.AddProduct(product);

            // Product--> GetDto
            var addedProductDto = _mapper.Map<ProductGetDTO>(addedProduct);

            return addedProductDto;
        }


        [HttpPost("getbyid/{id}")]
        public ProductGetDTO GetById(int id)
        {
            if (id > 0)
            {
                var product = _bs.GetProductById(id, "Category");
                var dto = _mapper.Map<ProductGetDTO>(product);
                return dto;
            }
            else
            {
                return null;
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Filter")]
        public ActionResult<List<ProductGetDTO>> Filter([FromQuery] string categoryName, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {

            if (categoryName == null && minPrice == 0 && maxPrice == 0)
            {
                return BadRequest();
            }

            var list = _bs.GetProducts((x => x.Category.CategoryName == categoryName && x.UnitPrice > minPrice && x.UnitPrice < maxPrice), "Category");
            var veriler = _mapper.Map<List<ProductGetDTO>>(list);

            if (veriler.Count == 0)
            {
                return NotFound();
            }
            else
            {

                return Ok(veriler);
            }
        }

    }

}

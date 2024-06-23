using Microsoft.AspNetCore.Mvc;
using Tekton.Examen.Application.DTO;
using Tekton.Examen.Application.Interface.Features;

namespace Tekton.Examen.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            this._productApplication = productApplication;
        }

        #region Sincronos

        [HttpPost]
        public ActionResult Insert([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var response = _productApplication.Insert(productDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPut]
        public ActionResult Update([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var response = _productApplication.Update(productDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpGet("id")]
        public ActionResult GetById(int id)
        {

            var response = _productApplication.GetById(id);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }
        #endregion


        #region Asincronos

        [HttpPost]
        [ActionName("InsertAsync")]
        public async Task<ActionResult> InsertAsync([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var response = await _productApplication.InsertAsync(productDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPut]
        [ActionName("UpdateAsync")]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var response = await _productApplication.UpdateAsync(productDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpGet("id")]
        [ActionName("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {

            var response = await _productApplication.GetByIdAsync(id);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }
        #endregion


    }
}

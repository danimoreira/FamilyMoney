using FamilyMoney.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMoney.API.Controllers
{
    [ApiController]
    [Route("v1/family")]
    public class FamilyController : ControllerBase
    {
        /// <summary>
        /// Adicionar Família
        /// </summary>
        /// <remarks>
        /// Parametros de Entrada
        /// {
        ///     "name": "string"
        /// }
        /// </remarks>
        /// <param name="family">Objeto do tipo Familia</param>
        /// <response code="400">Ocorreu um erro na exceção</response>
        [HttpPost]        
        public ActionResult<FamilyModel> AddFamily(
            [FromBody] FamilyModel family
        )
        {
            if (ModelState.IsValid)
                return family;
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<FamilyModel> GetFamily(int id)
        {

            FamilyModel family = new FamilyModel();
            family.Name = "Nascimento's Family";

            if (ModelState.IsValid)
                return family;
            else
                return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteFamily(int id)
        {
            if (ModelState.IsValid)
                return NotFound();
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        public ActionResult<FamilyModel> UpdateFamily(
            [FromBody] FamilyModel family
        )
        {
            family.Name = family.Name + " - Updated";

            if (ModelState.IsValid)
                return family;
            else
                return BadRequest(ModelState);
        }

    }
}
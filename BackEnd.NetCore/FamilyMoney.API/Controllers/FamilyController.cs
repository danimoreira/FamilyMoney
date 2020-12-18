using System.Collections.Generic;
using System.Linq;
using FamilyMoney.API.Models;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Service.Interfaces;
using FamilyMoney.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMoney.API.Controllers
{
    [ApiController]
    [Route("v1/family")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _service;
        public FamilyController(IFamilyService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<int> AddFamily(
            [FromBody] FamilyModel obj
        )
        {
            if (ModelState.IsValid)
            {
                Family family = new Family(obj.Name, User.Identity.Name);
                return _service.Create(family);
            }

            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public ActionResult<FamilyModel> GetFamily(int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _service.GetById(id);

                if (obj == null)
                    return NotFound("Registro não encontrado.");

                return new FamilyModel()
                {
                    Id = obj.Id,
                    Name = obj.Name
                };
            }
            else
                return BadRequest(ModelState);

        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<FamilyModel>> GetAllFamily()
        {
            var obj = _service.GetAll();            

            if (obj != null)
                return obj.Select(x => new FamilyModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            else
                return NotFound("Não foram encontrados registros cadastrados.");

        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteFamily(int id)
        {
            _service.Delete(id);

            if (ModelState.IsValid)
                return NotFound();
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize]
        public ActionResult<FamilyModel> UpdateFamily(
            [FromBody] FamilyModel family
        )
        {
            if (ModelState.IsValid)
            {
                var obj = _service.GetById(family.Id);
                if (obj != null)
                {
                    obj.Update(family.Name, User.Identity.Name);
                    _service.Update(obj);
                    return family;
                }
                else
                {
                    return NotFound("Registro não encontrado");
                }

            }

            else
                return BadRequest(ModelState);
        }
    }
}
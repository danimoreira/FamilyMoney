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
    [Route("v1/savings")]
    public class SavingsAccountController : ControllerBase
    {
        private readonly ISavingsAccountService _service;
        public SavingsAccountController(ISavingsAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<SavingsAccountModel>> GetAll()
        {
            var obj = _service.GetAll();

            if (obj == null)
                return NotFound("Registros não encontrados");

            return obj.Select(x => new SavingsAccountModel()
            {
                Id = x.Id,
                IdFamily = x.IdFamily,
                DateMovement = x.Movement.DateMovement,
                TypeMovement = x.Movement.TypeMovement,
                TypePayment = x.Movement.TypePayment,
                Description = x.Movement.Description,
                ProviderName = x.Movement.ProviderName,
                IdMemberMovement = x.IdMemberMovement,
                UrlPaymentVoucher = x.Movement.UrlPaymentVoucher,
                ValueMovement = x.Movement.ValueMovement,
                SituationMovement = x.Movement.SituationMovement
            }).ToList();
        }

        [HttpGet]
        [Route("{idFamily}")]
        [Authorize]
        public ActionResult<IEnumerable<SavingsAccountModel>> GetAllFinancialByFamily(int idFamily)
        {
            var obj = _service.GetAllRegisterByFamily(idFamily);

            return obj.Select(x => new SavingsAccountModel()
            {
                Id = x.Id,
                IdFamily = x.IdFamily,
                DateMovement = x.Movement.DateMovement,
                TypeMovement = x.Movement.TypeMovement,
                TypePayment = x.Movement.TypePayment,
                Description = x.Movement.Description,
                ProviderName = x.Movement.ProviderName,
                IdMemberMovement = x.IdMemberMovement,
                UrlPaymentVoucher = x.Movement.UrlPaymentVoucher,
                ValueMovement = x.Movement.ValueMovement,
                SituationMovement = x.Movement.SituationMovement
            }).ToList();

        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public ActionResult<SavingsAccountModel> GetById(int id)
        {
            var obj = _service.GetById(id);

            return new SavingsAccountModel()
            {
                Id = obj.Id,
                IdFamily = obj.IdFamily,
                DateMovement = obj.Movement.DateMovement,
                TypeMovement = obj.Movement.TypeMovement,
                TypePayment = obj.Movement.TypePayment,
                Description = obj.Movement.Description,
                ProviderName = obj.Movement.ProviderName,
                IdMemberMovement = obj.IdMemberMovement,
                UrlPaymentVoucher = obj.Movement.UrlPaymentVoucher,
                ValueMovement = obj.Movement.ValueMovement,
                SituationMovement = obj.Movement.SituationMovement
            };
        }

        [HttpPost]
        [Authorize]
        public ActionResult<int> AddSavingsAccount(
            [FromBody] SavingsAccountModel obj
        )
        {
            if (ModelState.IsValid)
            {
                var financial = new SavingsAccount(obj.IdFamily, obj.DateMovement, obj.TypeMovement,
                obj.TypePayment, obj.Description, obj.ProviderName,
                obj.IdMemberMovement, obj.UrlPaymentVoucher, obj.ValueMovement,
                obj.SituationMovement, User.Identity.Name);

                return _service.Create(financial);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult<SavingsAccountModel> UpdateSavingsAccount(
            [FromBody] SavingsAccountModel obj
        )
        {
            if (ModelState.IsValid)
            {
                var financial = _service.GetById(obj.Id);

                if (financial != null)
                {
                    financial.Update(obj.IdFamily, obj.DateMovement, obj.TypeMovement,
                    obj.TypePayment, obj.Description, obj.ProviderName,
                    obj.IdMemberMovement, obj.UrlPaymentVoucher, obj.ValueMovement,
                    obj.SituationMovement, User.Identity.Name);

                    _service.Update(financial);

                    return obj;
                }
                else
                {
                    return NotFound("Registro não encontrado");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public ActionResult DeleteSavingsAccount(int id)
        {
            var obj = _service.GetById(id);

            if (obj != null)
            {
                _service.Delete(id);
                return Ok("Registro excluído com sucesso");
            }

            return NotFound("Registro não encontrado");
        }
    }
}
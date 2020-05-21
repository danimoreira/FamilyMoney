using System.Collections.Generic;
using System.Linq;
using FamilyMoney.API.Models;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMoney.API.Controllers
{
    [ApiController]
    [Route("v1/member")]
    public class MemberController : ControllerBase
    {
        MemberService _service;

        public MemberController()
        {
            _service = new MemberService();
        }

        [HttpPost]
        public ActionResult<int> RegisterMember(
            [FromBody] MemberModel member
        )
        {
            if (ModelState.IsValid)
            {
                Member obj = new Member(member.IdFamily, member.Name, member.Username, member.Password, member.Role, "dmoreira");
                return _service.Create(obj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public ActionResult<List<MemberModel>> GetAllMembers()
        {
            var obj = _service.GetAll();

            return obj.Select(x => new MemberModel()
            {
                Id = x.Id,
                IdFamily = x.IdFamily,
                Name = x.Name,
                Username = x.Username,
                Role = x.Role
            }).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Member> GetById(int id)
        {
            var obj = _service.GetById(id);
            if (obj != null)
                return obj;

                // return new MemberModel()
                // {
                //     Id = obj.Id,
                //     IdFamily = obj.IdFamily,
                //     Name = obj.Name,
                //     User = obj.User,
                //     Role = obj.Role
                // };
            else
                return NotFound("Registro não encontrado");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMember(int id)
        {
            _service.Delete(id);

            return NotFound("Registro excluído com sucesso.");
        }

        [HttpPut]
        public ActionResult<MemberModel> UpdateMember(
            [FromBody] MemberModel member
        )
        {
            if (ModelState.IsValid)
            {
                var obj = _service.GetById(member.Id);
                if (obj != null)
                {
                    obj.Update(member.IdFamily, member.Name, member.Role, "dnascimento");
                    _service.Update(obj);
                    return member;
                }
                else
                {
                    return NotFound("Registro não encontrado");
                }

            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("login")]
        public ActionResult<LoginModel> Login(
            [FromBody] LoginModel login
        )
        {
            if (ModelState.IsValid)
            {
                var result = _service.Login(login.User, login.Password);
                if (result)
                    return Ok("Acesso permitido");
                else
                    return Unauthorized("Acesso negado");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
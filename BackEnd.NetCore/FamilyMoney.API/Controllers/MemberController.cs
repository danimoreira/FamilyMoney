using System.Collections.Generic;
using System.Linq;
using FamilyMoney.API.Models;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Service.Services;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public ActionResult<int> RegisterMember(
            [FromBody] MemberModel member
        )
        {
            if (ModelState.IsValid)
            {
                Member obj = new Member(member.IdFamily, member.Name, member.Username, member.Password, member.Role, member.Username);
                return _service.Create(obj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<MemberModel>> GetAllMembers()
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
        [Authorize(Roles = "admin")]
        public ActionResult<MemberModel> GetById(int id)
        {
            var obj = _service.GetById(id);
            if (obj != null)
                return new MemberModel()
                {
                    Id = obj.Id,
                    IdFamily = obj.IdFamily,
                    Name = obj.Name,
                    Username = obj.Username,
                    Role = obj.Role
                };
            else
                return NotFound("Registro não encontrado");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteMember(int id)
        {
            var obj = _service.GetById(id);

            if (obj != null)
            {
                _service.Delete(id);
                return Ok("Registro excluído com sucesso.");
            }

            return NotFound("Registr não encontrado");


        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public ActionResult<MemberModel> UpdateMember(
            [FromBody] MemberModel member
        )
        {
            if (ModelState.IsValid)
            {
                var obj = _service.GetById(member.Id);
                if (obj != null)
                {
                    obj.Update(member.IdFamily, member.Name, member.Role, User.Identity.Name);
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
        [AllowAnonymous]
        public ActionResult<dynamic> Login(
            [FromBody] LoginModel login
        )
        {
            if (ModelState.IsValid)
            {
                Member obj = _service.Login(login.User, login.Password);
                if (obj == null)
                    return NotFound("Usuário não encontrado");

                // Gera o token
                var token = TokenService.GenerateToken(obj);

                var user = new MemberModel()
                {
                    Id = obj.Id,
                    IdFamily = obj.IdFamily,
                    Name = obj.Name,
                    Username = obj.Username,
                    Role = obj.Role
                };

                return new { user = user, token = token };
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
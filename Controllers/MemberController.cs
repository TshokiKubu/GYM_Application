using AutoMapper;
using GYMAPI.Models;
using GYMAPI.Models.Dtos;
using GYMAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Controllers
{
   // [Route("api/v{version:apiVersion}/members")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepo;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepo, IMapper mapper)
        {
            _memberRepo = memberRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of members.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MemberDto>))]
        public IActionResult GetMembers()
        {
            var objList = _memberRepo.GetMembers();
            var objDto = new List<MemberDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<MemberDto>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// Get each member
        /// </summary>
        /// <param name="memberId"> The Id of the member </param>
        /// <returns></returns>
        [HttpGet("{memberId:int}", Name = "GetMember")]
        [ProducesResponseType(200, Type = typeof(MemberDto))]
        [ProducesResponseType(404)]
        [Authorize]
        [ProducesDefaultResponseType]
        public IActionResult GetMember(int memberId)
        {
            var obj = _memberRepo.GetMember(memberId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<MemberDto>(obj);
            //var objDto = new NationalParkDto()
            //{
            //    Created = obj.Created,
            //    Id = obj.Id,
            //    Name = obj.Name,
            //    Surname = obj.Surname,
            //};
            return Ok(objDto);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(MemberDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateMember([FromBody] MemberDto memberDto)
        {
            if (memberDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_memberRepo.MemberExists(memberDto.Name))
            {
                ModelState.AddModelError(""," Member Exists!");
                return StatusCode(404, ModelState);
            }
            var memberkObj = _mapper.Map<Member>(memberDto);
            if (!_memberRepo.CreateMember(memberkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {memberkObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetMember", new { memberid = memberkObj.MemberId }, memberkObj);
        }

        [HttpPatch("{memberId:int}", Name = "UpdateMember")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateMember(int memberId, [FromBody] MemberDto memberDto)
        {
            if (memberDto == null || memberId != memberDto.MemberId)
            {
                return BadRequest(ModelState);
            }

            var memberkObj = _mapper.Map<Member>(memberDto);
            if (!_memberRepo.UpdateMember(memberkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {memberkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }


        [HttpDelete("{memberId:int}", Name = "DeleteMember")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteMember(int memberId)
        {
            if (!_memberRepo.MemberExists(memberId))
            {
                return NotFound();
            }

            var memberObj = _memberRepo.GetMember(memberId);
            if (!_memberRepo.DeleteMember(memberObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {memberObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
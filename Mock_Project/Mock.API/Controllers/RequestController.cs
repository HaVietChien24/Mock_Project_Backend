﻿using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.RequestService;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("get-all-by-user-id/{userId}")]
        public IActionResult GetAllByUserId(int userId)
        {
            try
            {
                var list = _requestService.GetAllByUserId(userId);
                if (list.Count == 0)
                {
                    return Ok("Không có dữ liệu");
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }

        [HttpPut("cancel-request")]
        public IActionResult CancelRequest([FromBody]int requestId)
        {
            try
            {
                var result = _requestService.CancelRequest(requestId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }

        [HttpPost("send-request")]
        public IActionResult CreateRequest([FromBody] RequestDTO requestDTO)
        {
            try
            {
                var result = _requestService.CreateRequest(requestDTO);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
    }
}

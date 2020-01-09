using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DpcNtwk.API.Data;
using DpcNtwk.API.Data.Repos;
using DpcNtwk.API.Models;
using DpcNtwk.API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DpcNtwk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly IMainRepository _repo;
        private readonly IMapper _mapper;
        public ColumnsController(IMainRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColumns()
        {
            var columns = await _repo.GetColumns();
            return Ok(columns);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColumn(ColumnForCreateDto columnData)
        {
            var column = _mapper.Map<Column>(columnData);
            _repo.Add(column);
            if(await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
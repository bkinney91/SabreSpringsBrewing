using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;

namespace SabreSprings.Brewing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService BatchService;
        public BatchController(IBatchService batchService)
        {
            BatchService = batchService;
        }
        

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                BatchDto batch = await BatchService.GetBatch(id);
                return Ok(batch);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetBatchTable")]
        public async Task<IActionResult> GetBatchTable()
        {
            try
            {
                List<BatchTableRow> batches = await BatchService.GetBatchTable();
                return Ok(batches);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetBatchDetails")]
        public async Task<IActionResult> GetBatchDetails(int id)
        {
            Log.Information($"Geting Batch Details for ID {id}");
            try
            {
                BatchDetailsDto batch = await BatchService.GetBatchDetails(id);
                return Ok(batch);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]BatchDto dto)
        {
            try
            {
                await BatchService.Add(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody]BatchDto dto)
        {
            try
            {
                await BatchService.Update(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        
    }
}
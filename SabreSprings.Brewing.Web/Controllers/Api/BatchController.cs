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

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService BatchService;
        private readonly ILogger Logger;
        public BatchController(IBatchService batchService, ILogger logger)
        {
            BatchService = batchService;
            Logger = logger;
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
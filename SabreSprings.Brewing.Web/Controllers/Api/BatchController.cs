using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Data.Interfaces;
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
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly ILogger Logger;
        public BatchController(IBatchService batchService, IBatchDataProvider batchDataProvider, ILogger logger)
        {
            BatchService = batchService;
            batchDataProvider = batchDataProvider;
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
        [Route("GetBatch")]
        public async Task<IActionResult> GetBatch(int id)
        {
            try
            {
                Batch batch = await BatchDataProvider.GetBatch(id);
                return Ok(batch);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
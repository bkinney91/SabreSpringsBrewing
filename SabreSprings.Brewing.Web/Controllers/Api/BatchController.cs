using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchDataProvider BatchDataProvider;
        private readonly ILogger Logger;
        public BatchController(IBatchDataProvider batchDataProvider, ILogger logger)
        {
            BatchDataProvider = batchDataProvider;
            Logger = logger;
        }
        
        [HttpGet]
        [Route("GetAllBatches")]
        public async Task<IActionResult> GetAllBatches()
        {
            try
            {
                List<Batch> batches = await BatchDataProvider.GetAllBatches();
                return Ok(batches);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
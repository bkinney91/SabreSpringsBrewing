using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Services.Interfaces;

namespace SabreSprings.Brewing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentabuoyAssignmentController : ControllerBase
    {
        private readonly IFermentabouyAssignmentService FermentabuoyAssignmentService;
        public FermentabuoyAssignmentController(IFermentabouyAssignmentService fermentabouyAssignmentService)
        {
            FermentabuoyAssignmentService = fermentabouyAssignmentService;
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(FermentabuoyAssignmentDto dto)
        {
            try
            {
                await FermentabuoyAssignmentService.AddFermentabuoyAssignment(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
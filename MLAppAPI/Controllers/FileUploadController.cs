using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLAppAPI.Models;
using MLAppAPI.Services;
using MLAppAPI.Services.Interfaces;

namespace MLAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploaderService _fileUploaderService;

        public FileUploadController(IFileUploaderService fileUploaderService)
        {
            _fileUploaderService = fileUploaderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataFilesList()
        {
            try
            {
                var dataFiles = await _fileUploaderService.GetListAsync();
                return Ok(dataFiles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DataFile dataFile)
        {
            try
            {
                await _fileUploaderService.CreateAsync(dataFile);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

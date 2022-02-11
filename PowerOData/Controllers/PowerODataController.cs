using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.PowerOData.Service;
using Microsoft.PowerOData.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PowerOData.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PowerODataController : ControllerBase
    {
        public PowerODataController(IRepoService<EmployeeModel> powerService, IRepoService<ProductModel> fairsService, IRepoService<ProductEntityModel> efService, ILogger<PowerODataController> logger)
        {
            empSvc = powerService;
            prodSvc = fairsService;
            efSvc = efService;
            _logger = logger;
        }

        private readonly IRepoService<EmployeeModel> empSvc;

        private readonly IRepoService<ProductModel> prodSvc;

        private readonly IRepoService<ProductEntityModel> efSvc;

        private readonly ILogger<PowerODataController> _logger;

        [HttpGet(nameof(GetEmpData))]
        [EnableQuery]
        public async Task<ActionResult<EmployeeModel>> GetEmpData()
        {
            _logger.LogInformation("Entered GetEmpData");
            try
            {
                var data = await empSvc.GetData();

                return data is null ? BadRequest(data) : Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpGet(nameof(GetProdData))]
        [EnableQuery]
        public async Task<ActionResult<ProductModel>> GetProdData()
        {
            _logger.LogInformation("Entered GetProdData");
            try
            {
                var data = await prodSvc.GetData();

                return data is null ? BadRequest(data) : Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpGet(nameof(GetProdEFData))]
        [EnableQuery]
        public ActionResult<IQueryable<ProductEntityModel>> GetProdEFData()
        {
            _logger.LogInformation("Entered GetProdEFData");
            try
            {
                return Ok(efSvc.GetDataAsQueryable());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }

    }
}
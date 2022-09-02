using AL.Customer.Domain.Interface;
using AL.Customer.Domain.Service;
using AL.Customer.Effigy.DTOModel;
using AL.Customer.Effigy.Model;
using AL.Customer.Effigy.Model.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AL.Customer.Services.Rest.Controllers
{
    [Authorize]
    public class DailyBhavController : BaseApiController
    {
        private readonly IDailyBhavService dailyBhavService;
        private readonly ITokenService tokenService;
        public DailyBhavController(IDailyBhavService _dailyBhavService, ITokenService _tokenService)
        {
            this.dailyBhavService = _dailyBhavService;
            this.tokenService = _tokenService;
        }

        [HttpPost("GetDailyBhavPaginatedView")]
        [ProducesResponseType(typeof(PaginatedGridResultModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDailyBhavPaginatedView(GridDetailsModel detailsModel)
        {
           if(detailsModel != null)
            {
                PaginatedGridResultModel getDailyGridResultModel = await this.dailyBhavService.GetDailyBhavService(detailsModel).ConfigureAwait(false);
                if(getDailyGridResultModel != null)
                {
                    return this.Ok(getDailyGridResultModel);
                }
            }

            return this.NotFound();
        }

        [HttpGet]
        public IEnumerable<DailyBhavModel> Get()
        {
            return dailyBhavService.getAllBhav().Where(a=>a.Symbol == "HINDOILEXP").ToList();
        }

    }
}

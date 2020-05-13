using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using FreeMedHelp.InfrastructureServices.Presenters;

namespace FreeMedHelp.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedPointsController : ControllerBase
    {
        private readonly ILogger<MedPointsController> _logger;
        private readonly IGetMedPointListUseCase _getMedPointListUseCase;

        public MedPointsController(ILogger<MedPointsController> logger,
                                IGetMedPointListUseCase getMedPointListUseCase)
        {
            _logger = logger;
            _getMedPointListUseCase = getMedPointListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMedPoints()
        {
            var presenter = new MedPointListPresenter();
            await _getMedPointListUseCase.Handle(GetMedPointListUseCaseRequest.CreateAllMedPointsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{medpointId}")]
        public async Task<ActionResult> GetMedPoint(long medpointId)
        {
            var presenter = new MedPointListPresenter();
            await _getMedPointListUseCase.Handle(GetMedPointListUseCaseRequest.CreateMedPointRequest(medpointId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("ismedhelpfree/{ismedhelpfree}")]
        public async Task<ActionResult> GetIsMedHelpFreeMedPoints(string ismedhelpfree)
        {
            var presenter = new MedPointListPresenter();
            await _getMedPointListUseCase.Handle(GetMedPointListUseCaseRequest.CreateIsMedHelpFreeMedPointsRequest(ismedhelpfree), presenter);
            return presenter.ContentResult;
        }
    }
}

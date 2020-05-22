using System.Threading.Tasks;
using System.Collections.Generic;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using FreeMedHelp.ApplicationServices.Ports;

namespace FreeMedHelp.ApplicationServices.GetMedPointListUseCase
{
    public class GetMedPointListUseCase : IGetMedPointListUseCase
    {
        private readonly IReadOnlyMedPointRepository _readOnlyMedPointRepository;

        public GetMedPointListUseCase(IReadOnlyMedPointRepository readOnlyMedPointRepository)
            => _readOnlyMedPointRepository = readOnlyMedPointRepository;

        public async Task<bool> Handle(GetMedPointListUseCaseRequest request, IOutputPort<GetMedPointListUseCaseResponse> outputPort)
        {
            IEnumerable<MedPoint> medpoints = null;
            if (request.MedPointId != null)
            {
                var medpoint = await _readOnlyMedPointRepository.GetMedPoint(request.MedPointId.Value);
                medpoints = (medpoint != null) ? new List<MedPoint>() { medpoint } : new List<MedPoint>();

            }
            else if (request.IsMedHelpFree != null)
            {
                medpoints = await _readOnlyMedPointRepository.QueryMedPoints(new IsMedHelpFreeCriteria(request.IsMedHelpFree));
            }
            else
            {
                medpoints = await _readOnlyMedPointRepository.GetAllMedPoints();
            }
            outputPort.Handle(new GetMedPointListUseCaseResponse(medpoints));
            return true;
        }
    }
}

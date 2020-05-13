using FreeMedHelp.DomainObjects;
using FreeMedHelp.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeMedHelp.ApplicationServices.GetMedPointListUseCase
{
    public class GetMedPointListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<MedPoint> MedPoints { get; }

        public GetMedPointListUseCaseResponse(IEnumerable<MedPoint> medpoints) => MedPoints = medpoints;
    }
}

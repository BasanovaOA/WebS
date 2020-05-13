using FreeMedHelp.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeMedHelp.ApplicationServices.GetMedPointListUseCase
{
    public class GetMedPointListUseCaseRequest : IUseCaseRequest<GetMedPointListUseCaseResponse>
    {
        public string IsMedHelpFree { get; private set; }
        public long? MedPointId { get; private set; }

        private GetMedPointListUseCaseRequest()
        { }

        public static GetMedPointListUseCaseRequest CreateAllMedPointsRequest()
        {
            return new GetMedPointListUseCaseRequest();
        }

        public static GetMedPointListUseCaseRequest CreateMedPointRequest(long medpointId)
        {
            return new GetMedPointListUseCaseRequest() { MedPointId = medpointId };
        }
        public static GetMedPointListUseCaseRequest CreateOrganizationMedPointsRequest(string ismedhelpfree)
        {
            return new GetMedPointListUseCaseRequest() { IsMedHelpFree = ismedhelpfree };
        }
    }
}

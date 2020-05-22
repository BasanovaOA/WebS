using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using System.Net;
using Newtonsoft.Json;
using FreeMedHelp.ApplicationServices.Ports;

namespace FreeMedHelp.InfrastructureServices.Presenters
{
    public class MedPointListPresenter : IOutputPort<GetMedPointListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public MedPointListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetMedPointListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.MedPoints) : JsonConvert.SerializeObject(response.Message);
        }
    }
}

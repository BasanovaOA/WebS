using FreeMedHelp.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using System.Linq.Expressions;
using FreeMedHelp.ApplicationServices.Ports;
using FreeMedHelp.DomainObjects.Ports;
using FreeMedHelp.ApplicationServices.Repositories;

namespace FreeMedHelp.WebService.Core.Tests
{
    public class GetMedPointListUseCaseTest
    {
        private InMemoryMedPointRepository CreateMedPointtRepository()
        {

            var repo = new InMemoryMedPointRepository(new List<MedPoint> {
                new MedPoint { Id = 1, IsMedHelpFree = "��", FullName = "��������������� ��������� ���������� ��������������� ������ ������ ������ ��������� ���� � ����������������� ������������ ��������������� ������ �������"},
                new MedPoint { Id = 2, IsMedHelpFree = "��", FullName = "��������������� ��������� ���������� ��������������� ������ ������ �������-����������������� �������� ������ ������ ��. �.�. �������������� ������������ ��������������� ������ �������"},
                new MedPoint { Id = 3, IsMedHelpFree = "���", FullName = "��������������� ��������� ���������� ��������������� ������ ������ ������ ��������� ���� � ����������������� ������������ ��������������� ������ �������"},
                new MedPoint { Id = 4, IsMedHelpFree = "���", FullName = "��������������� ��������� ���������� ��������������� ������ ������ ����������� ��������� ����� ������������ ������� �� �������������� ������� � ������������� �������� ������������� �������� ������������ ��������������� ������ �������"},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllMedPoints()
        {
            var useCase = new GetMedPointListUseCase(CreateMedPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetMedPointListUseCaseRequest.CreateAllMedPointsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.MedPoints.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.MedPoints.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllMedPointsFromEmptyRepository()
        {
            var useCase = new GetMedPointListUseCase(new InMemoryMedPointRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetMedPointListUseCaseRequest.CreateAllMedPointsRequest(), outputPort).Result);
            Assert.Empty(outputPort.MedPoints);
        }

        [Fact]
        public void TestGetMedPoint()
        {
            var useCase = new GetMedPointListUseCase(CreateMedPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetMedPointListUseCaseRequest.CreateMedPointRequest(2), outputPort).Result);
            Assert.Single(outputPort.MedPoints, mp => 2 == mp.Id);
        }

        [Fact]
        public void TestTryGetNotExistingMedPoint()
        {
            var useCase = new GetMedPointListUseCase(CreateMedPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetMedPointListUseCaseRequest.CreateMedPointRequest(999), outputPort).Result);
            Assert.Empty(outputPort.MedPoints);
        }




    }

    class OutputPort : IOutputPort<GetMedPointListUseCaseResponse>
    {
        public IEnumerable<MedPoint> MedPoints { get; private set; }

        public void Handle(GetMedPointListUseCaseResponse response)
        {
            MedPoints = response.MedPoints;
        }
    }
}

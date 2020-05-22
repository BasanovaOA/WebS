using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using FreeMedHelp.ApplicationServices.Ports;
using FreeMedHelp.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FreeMedHelp.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetMedPointListUseCase _getMedPointListUseCase;

        public MainViewModel(IGetMedPointListUseCase getMedPointListUseCase)
            => _getMedPointListUseCase = getMedPointListUseCase;

        private Task<bool> _loadingTask;
        private MedPoint _currentMedPoint;
        private ObservableCollection<MedPoint> _medpoints;

        public event PropertyChangedEventHandler PropertyChanged;

        public MedPoint CurrentMedPoint
        {
            get => _currentMedPoint; 
            set
            {
                if (_currentMedPoint != value)
                {
                    _currentMedPoint = value;
                    OnPropertyChanged(nameof(CurrentMedPoint));
                }
            }
        }

        private async Task<bool> LoadMedPoints()
        {
            var outputPort = new OutputPort();
            bool result = await _getMedPointListUseCase.Handle(GetMedPointListUseCaseRequest.CreateAllMedPointsRequest(), outputPort);
            if (result)
            {
                MedPoints = new ObservableCollection<MedPoint>(outputPort.MedPoints);
            }
            return result;
        }

        public ObservableCollection<MedPoint> MedPoints
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadMedPoints();
                }
                
                return _medpoints; 
            }
            set
            {
                if (_medpoints != value)
                {
                    _medpoints = value;
                    OnPropertyChanged(nameof(MedPoints));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetMedPointListUseCaseResponse>
        {
            public IEnumerable<MedPoint> MedPoints { get; private set; }

            public void Handle(GetMedPointListUseCaseResponse response)
            {
                if (response.Success)
                {
                    MedPoints = new ObservableCollection<MedPoint>(response.MedPoints);
                }
            }
        }
    }
}

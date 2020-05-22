using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeMedHelp.DomainObjects.Repositories
{
    public abstract class ReadOnlyMedPointRepositoryDecorator : IReadOnlyMedPointRepository
    {
        private readonly IReadOnlyMedPointRepository _medpointRepository;

        public ReadOnlyMedPointRepositoryDecorator(IReadOnlyMedPointRepository medpointRepository)
        {
            _medpointRepository = medpointRepository;
        }

        public virtual async Task<IEnumerable<MedPoint>> GetAllMedPoints()
        {
            return await _medpointRepository?.GetAllMedPoints();
        }

        public virtual async Task<MedPoint> GetMedPoint(long id)
        {
            return await _medpointRepository?.GetMedPoint(id);
        }

        public virtual async Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria)
        {
            return await _medpointRepository?.QueryMedPoints(criteria);
        }
    }
}

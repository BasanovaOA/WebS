using FreeMedHelp.ApplicationServices.Ports.Cache;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using FreeMedHelp.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeMedHelp.ApplicationServices.Repositories
{
    public class CachedReadOnlyMedPointRepository : ReadOnlyMedPointRepositoryDecorator
    {
        private readonly IDomainObjectsCache<MedPoint> _medpointsCache;

        public CachedReadOnlyMedPointRepository(IReadOnlyMedPointRepository medpointRepository, 
                                             IDomainObjectsCache<MedPoint> medpointsCache)
            : base(medpointRepository)
            => _medpointsCache = medpointsCache;

        public async override Task<MedPoint> GetMedPoint(long id)
            => _medpointsCache.GetObject(id) ?? await base.GetMedPoint(id);

        public async override Task<IEnumerable<MedPoint>> GetAllMedPoints()
            => _medpointsCache.GetObjects() ?? await base.GetAllMedPoints();

        public async override Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria)
            => _medpointsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryMedPoints(criteria);

    }
}

using FreeMedHelp.ApplicationServices.Ports.Cache;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FreeMedHelp.InfrastructureServices.Repositories
{
    public class NetworkMedPointRepository : NetworkRepositoryBase, IReadOnlyMedPointRepository
    {
        private readonly IDomainObjectsCache<MedPoint> _medpointCache;

        public NetworkMedPointRepository(string host, ushort port, bool useTls, IDomainObjectsCache<MedPoint> medpointCache)
            : base(host, port, useTls)
            => _medpointCache = medpointCache;

        public async Task<MedPoint> GetMedPoint(long id)
            => CacheAndReturn(await ExecuteHttpRequest<MedPoint>($"medpoints/{id}"));

        public async Task<IEnumerable<MedPoint>> GetAllMedPoints()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<MedPoint>>($"medpoints"), allObjects: true);

        public async Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<MedPoint>>($"medpoints"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<MedPoint> CacheAndReturn(IEnumerable<MedPoint> medpoints, bool allObjects = false)
        {
            if (allObjects)
            {
                _medpointCache.ClearCache();
            }
            _medpointCache.UpdateObjects(medpoints, DateTime.Now.AddDays(1), allObjects);
            return medpoints;
        }

        private MedPoint CacheAndReturn(MedPoint medpoint)
        {
            _medpointCache.UpdateObject(medpoint, DateTime.Now.AddDays(1));
            return medpoint;
        }
    }
}

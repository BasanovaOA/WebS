using FreeMedHelp.ApplicationServices.Ports.Gateways.Database;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FreeMedHelp.ApplicationServices.Repositories
{
    public class DbMedPointRepository : IReadOnlyMedPointRepository,
                                     IMedPointRepository
    {
        private readonly IMedDatabaseGateway _databaseGateway;

        public DbMedPointRepository(IMedDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<MedPoint> GetMedPoint(long id)
            => await _databaseGateway.GetMedPoint(id);

        public async Task<IEnumerable<MedPoint>> GetAllMedPoints()
            => await _databaseGateway.GetAllMedPoints();

        public async Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria)
            => await _databaseGateway.QueryMedPoints(criteria.Filter);

        public async Task AddMedPoint(MedPoint medpoint)
            => await _databaseGateway.AddMedPoint(medpoint);

        public async Task RemoveMedPoint(MedPoint medpoint)
            => await _databaseGateway.RemoveMedPoint(medpoint);

        public async Task UpdateMedPoint(MedPoint medpoint)
            => await _databaseGateway.UpdateMedPoint(medpoint);
    }
}

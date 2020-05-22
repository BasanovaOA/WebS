using FreeMedHelp.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using FreeMedHelp.ApplicationServices.Ports.Gateways.Database;

namespace FreeMedHelp.InfrastructureServices.Gateways.Database
{
    public class MedEFSqliteGateway : IMedDatabaseGateway
    {
        private readonly MedContext _medContext;

        public MedEFSqliteGateway(MedContext MedContext)
            => _medContext = MedContext;

        public async Task<MedPoint> GetMedPoint(long id)
           => await _medContext.MedPoints.Where(mp => mp.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<MedPoint>> GetAllMedPoints()
            => await _medContext.MedPoints.ToListAsync();

        public async Task<IEnumerable<MedPoint>> QueryMedPoints(Expression<Func<MedPoint, bool>> filter)
            => await _medContext.MedPoints.Where(filter).ToListAsync();

        public async Task AddMedPoint(MedPoint medpoint)
        {
            _medContext.MedPoints.Add(medpoint);
            await _medContext.SaveChangesAsync();
        }

        public async Task UpdateMedPoint(MedPoint medpoint)
        {
            _medContext.Entry(medpoint).State = EntityState.Modified;
            await _medContext.SaveChangesAsync();
        }

        public async Task RemoveMedPoint(MedPoint medpoint)
        {
            _medContext.MedPoints.Remove(medpoint);
            await _medContext.SaveChangesAsync();
        }

    }
}

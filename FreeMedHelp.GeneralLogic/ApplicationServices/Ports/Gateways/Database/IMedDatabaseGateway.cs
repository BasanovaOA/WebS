using FreeMedHelp.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeMedHelp.ApplicationServices.Ports.Gateways.Database
{
    public interface IMedDatabaseGateway
    {
        Task AddMedPoint(MedPoint medpoint);

        Task RemoveMedPoint(MedPoint medpoint);

        Task UpdateMedPoint(MedPoint medpoint);

        Task<MedPoint> GetMedPoint(long id);

        Task<IEnumerable<MedPoint>> GetAllMedPoints();

        Task<IEnumerable<MedPoint>> QueryMedPoints(Expression<Func<MedPoint, bool>> filter);

    }
}

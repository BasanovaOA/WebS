using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FreeMedHelp.DomainObjects.Ports
{
    public interface IReadOnlyMedPointRepository
    {
        Task<MedPoint> GetMedPoint(long id);

        Task<IEnumerable<MedPoint>> GetAllMedPoints();

        Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria);

    }

    public interface IMedPointRepository
    {
        Task AddRoute(MedPoint route);

        Task RemoveRoute(MedPoint route);

        Task UpdateRoute(MedPoint route);
    }
}

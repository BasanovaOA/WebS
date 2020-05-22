using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeMedHelp.ApplicationServices.Repositories
{
    public class InMemoryMedPointRepository : IReadOnlyMedPointRepository,
                                           IMedPointRepository
    {
        private readonly List<MedPoint> _medpoints = new List<MedPoint>();

        public InMemoryMedPointRepository(IEnumerable<MedPoint> medpoints = null)
        {
            if (medpoints != null)
            {
                _medpoints.AddRange(medpoints);
            }
        }

        public Task AddMedPoint(MedPoint medpoint)
        {
            _medpoints.Add(medpoint);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<MedPoint>> GetAllMedPoints()
        {
            return Task.FromResult(_medpoints.AsEnumerable());
        }

        public Task<MedPoint> GetMedPoint(long id)
        {
            return Task.FromResult(_medpoints.Where(mp => mp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<MedPoint>> QueryMedPoints(ICriteria<MedPoint> criteria)
        {
            return Task.FromResult(_medpoints.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveMedPoint(MedPoint medpoint)
        {
            _medpoints.Remove(medpoint);
            return Task.CompletedTask;
        }

        public Task UpdateMedPoint(MedPoint medpoint)
        {
            var foundMedPoint = GetMedPoint(medpoint.Id).Result;
            if (foundMedPoint == null)
            {
                AddMedPoint(medpoint);
            }
            else
            {
                if (foundMedPoint != medpoint)
                {
                    _medpoints.Remove(foundMedPoint);
                    _medpoints.Add(medpoint);
                }
            }
            return Task.CompletedTask;
        }
    }
}

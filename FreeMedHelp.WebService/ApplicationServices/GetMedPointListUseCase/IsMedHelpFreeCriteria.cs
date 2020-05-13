using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FreeMedHelp.ApplicationServices.GetMedPointListUseCase
{
    public class IsMedHelpFreeCriteria : ICriteria<MedPoint>
    {
        public string IsMedHelpFree { get; }

        public IsMedHelpFreeCriteria(string ismedhelpfree)
            => IsMedHelpFree = ismedhelpfree;

        public Expression<Func<MedPoint, bool>> Filter
            => (mp => mp.IsMedHelpFree == IsMedHelpFree);
    }
}

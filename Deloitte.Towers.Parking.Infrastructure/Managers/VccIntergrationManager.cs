using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.VccData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Managers
{
    public class VccIntergrationManager : IVccIntergrationManager
    {
        private readonly IVccIntegrationRepository _vccIntegrationRepository;

        public VccIntergrationManager(IVccIntegrationRepository vccIntegrationRepository)
        {
            _vccIntegrationRepository = vccIntegrationRepository;
        }

        public void SaveVccData(VCCRootData vCCRootData)
        {
            try
            {
                _vccIntegrationRepository.Save(vCCRootData);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

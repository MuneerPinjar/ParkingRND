﻿using Deloitte.Towers.Parking.Domain.Dto.VccData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Managers
{
   public interface IVccIntergrationManager
    {
        void SaveVccData(VCCRootData vCCRootData);
    }
}

using Deloitte.Towers.Parking.Domain.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.Building
{
    [Validator(typeof(BuildingLevelDtoValidator))]
    public class BuildingLevelEditDto : BuildingLevelDto
    {
        public string LevelName { get; set; }
        public string ModifiedBy { get; set; }
    }
}

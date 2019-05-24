using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Validators
{
    public class BuildingLevelDtoValidator : AbstractValidator<BuildingLevelEditDto>
    {
        public BuildingLevelDtoValidator()
        {
            RuleFor(x => x.CampusId).NotNull().WithMessage("CampusId Cannout be null")
                .NotEmpty()
                .WithMessage("CampusId cannout be empty");
                

            RuleFor(x => x.BikeParkings).NotNull().WithMessage("The Bike Parkings cannout be null");

            RuleFor(x => x.CarParkings).NotNull().WithMessage("The Car Parkings cannout be null");

            RuleFor(x => x.LevelId).NotNull().WithMessage("LevelId Cannout be null").NotEmpty().WithMessage("The LevelId Cannout be Empty");

            RuleFor(x => x.ReservedCarParkings).NotNull().WithMessage("The Reserved Car Parkings cannout be null").LessThanOrEqualTo(x => x.CarParkings).WithMessage("The Reserved Car Parkings cannout be greater than Car Parkings");

            RuleFor(x => x.ReservedBikeParkings).NotNull().WithMessage("The Reserved Bike Parkings cannout be null").LessThanOrEqualTo(x => x.BikeParkings).WithMessage("The Reserved Bike Parkings cannout be greater than Bike Parkings");

            RuleFor(x => x.ModifiedBy).NotEmpty().WithMessage("The Modified By cannout be Empty");

        }
    }
}
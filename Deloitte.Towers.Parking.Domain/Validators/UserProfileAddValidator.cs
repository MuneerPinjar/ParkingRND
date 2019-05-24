﻿using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Validators
{
    public class UserProfileAddValidator : AbstractValidator<UserProfileDto>
    {
        public UserProfileAddValidator()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty()
             .WithMessage("The First Name cannot be blank")
             .Length(0, 50)
             .WithMessage("The First Name cannot be more than 50 characters.");

            RuleFor(x => x.LastName)
             .NotEmpty()
             .WithMessage("The Last Name cannot be blank")
             .Length(0, 50)
             .WithMessage("The Last Name cannot be more than 50 characters.");

            RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage("The Email cannot be blank")
             .EmailAddress()
             .WithMessage("Incorrect Email Format");

            RuleFor(x => x.CreatedBy)
             .NotEmpty()
             .WithMessage("Created By cannout be blank");
        }
    }
}

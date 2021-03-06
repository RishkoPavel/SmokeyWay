﻿using DAL.Entities;
using FluentValidation;

namespace SmokeyWay.Validators
{
    public class DepartamentValidator : AbstractValidator<Departament>
    {
        public DepartamentValidator()
        {
            RuleFor(e => e.Name).Length(1, 45).NotEmpty();
            RuleFor(e => e.Country).Length(1, 45).NotEmpty();
            RuleFor(e => e.City).Length(1, 45).NotEmpty();
            RuleFor(e => e.Street).Length(1, 45).NotEmpty();
            RuleFor(e => e.HouseNumber).Length(1, 5).NotEmpty();
        }
    }
}

using Domain.Validation;
using KolejeStudenckie.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejeStudenckie.Validation
{
    public class PersonnelValidator : IValidator<PersonnelDTO>
    {
        public ValidationResult Validate(PersonnelDTO personnel)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(personnel.Name) || personnel.Name.Length > 50)
            {
                result.IsValid = false;
                result.Errors.Add("Name cannot be empty and must be less than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(personnel.Surname) || personnel.Surname.Length > 50)
            {
                result.IsValid = false;
                result.Errors.Add("Surname cannot be empty and must be less than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(personnel.Position) || personnel.Position.Length > 50)
            {
                result.IsValid = false;
                result.Errors.Add("Position cannot be empty and must be less than 50 characters.");
            }

            if (personnel.Salary <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Salary must be greater than zero.");
            }

            return result;
        }
    }
}

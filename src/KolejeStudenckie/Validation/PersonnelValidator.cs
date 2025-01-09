using Domain.Validation;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;

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

        public static bool CanDeletePersonnel(PersonnelDTO personnel, out List<string> trainIds)
        {
            var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
            trainIds = trains
                .Where(t => t.Personnel.Contains(personnel.Id))
                .Select(t => t.Id)
                .ToList();
            return !trainIds.Any();
        }
    }
}

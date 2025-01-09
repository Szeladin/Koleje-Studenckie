using Domain.Validation;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;


namespace KolejeStudenckie.Validation
{
    public class TrainValidator : IValidator<TrainDTO>
    {
        public ValidationResult Validate(TrainDTO train)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(train.Name))
            {
                result.IsValid = false;
                result.Errors.Add("Name cannot be empty.");
            }

            if (train.MaxSpeed <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Max Speed must be greater than zero.");
            }

            if (train.Carriage.CarriageCount <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Carriage Count must be greater than zero.");
            }

            if (train.Personnel.Distinct().Count() != 3 || train.Personnel.Any(p => string.IsNullOrEmpty(p)))
            {
                result.IsValid = false;
                result.Errors.Add("Train must have exactly three unique personnel.");
            }

            return result;
        }

        public static bool CanDeleteTrain(TrainDTO train, out List<string> scheduleIds)
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            scheduleIds = schedules
                .Where(s => s.TrainId == train.Id)
                .Select(s => s.Id)
                .ToList();
            return !scheduleIds.Any();
        }
    }
}

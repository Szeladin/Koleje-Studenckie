using Domain.Validation;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;

namespace KolejeStudenckie.Validation
{
    public class ScheduleValidator : IValidator<ScheduleDTO>
    {
        public ValidationResult Validate(ScheduleDTO schedule)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(schedule.TrainId))
            {
                result.IsValid = false;
                result.Errors.Add("Train ID cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(schedule.Station))
            {
                result.IsValid = false;
                result.Errors.Add("Station cannot be empty.");
            }

            if (schedule.DepartureTime <= schedule.ArrivalTime)
            {
                result.IsValid = false;
                result.Errors.Add("Arrival time must be earlier than departure time.");
            }

            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            var overlappingSchedules = schedules
                .Where(s => s.TrainId == schedule.TrainId && s.Id != schedule.Id &&
                            schedule.DepartureTime > s.ArrivalTime && schedule.ArrivalTime < s.DepartureTime)
                .ToList();

            if (overlappingSchedules.Any())
            {
                result.IsValid = false;
                result.Errors.Add("Train is already assigned to another schedule during the specified time.");
            }

            return result;
        }
    }
}

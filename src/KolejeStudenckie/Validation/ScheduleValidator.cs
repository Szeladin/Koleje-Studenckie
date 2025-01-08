using Domain.Validation;
using KolejeStudenckie.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (schedule.DepartureTime >= schedule.ArrivalTime)
            {
                result.IsValid = false;
                result.Errors.Add("Departure time must be earlier than arrival time.");
            }

            return result;
        }
    }
}

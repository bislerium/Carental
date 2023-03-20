using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters
{
    public class DateOnlyToDateTimeConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyToDateTimeConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue), // convert from DateOnly to DateTime
            dt => DateOnly.FromDateTime(dt)) // convert from DateTime to DateOnly
        { }
    }
}

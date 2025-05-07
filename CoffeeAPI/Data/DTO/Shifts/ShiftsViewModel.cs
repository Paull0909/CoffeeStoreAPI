using AutoMapper;

namespace Data.DTO.Shifts
{
    public class ShiftsViewModel
    {
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Description { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Entities.Shifts, ShiftsViewModel>();
            }
        }
    }
}

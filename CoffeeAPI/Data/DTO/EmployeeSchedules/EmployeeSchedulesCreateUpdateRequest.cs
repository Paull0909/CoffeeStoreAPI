using AutoMapper;

namespace Data.DTO.EmployeeSchedules
{
    public class EmployeeSchedulesCreateUpdateRequest
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateOnly WorkDate { get; set; }
        public bool IsWorking { get; set; }
        public string Note { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<EmployeeSchedulesCreateUpdateRequest, Entities.EmployeeSchedules>();
            }
        }
    }
}

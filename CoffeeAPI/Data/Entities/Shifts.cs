namespace Data.Entities
{
    public class Shifts
    {
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Description { get; set; }
        public List<EmployeeSchedules> EmployeeSchedules { get; set; }
    }
}

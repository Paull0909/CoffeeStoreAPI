namespace Data.Entities
{
    public class EmployeeSchedules
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateOnly WorkDate { get; set; }
        public bool IsWorking { get; set; }
        public string Note { get; set; }
        public Shifts Shifts { get; set; }
        public Employees Employees { get; set; }
    }
}

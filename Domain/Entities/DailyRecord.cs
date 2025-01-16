using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DailyRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FunctionList { get; set; }
        public string DateRange { get; set; }
        public string History { get; set; }
        public string Day {  get; set; }
        public string Transit1 { get; set; }
        public string Transit2 { get; set; }
        public string Transit3 { get; set; }
        public string Transit4 { get; set; }
        public string Transit5 { get; set; }
        public string Transit6 { get; set; }
        public string ShiftLength { get; set; }
        public string Performance { get; set; } // عملکرد 
        public string NightShift { get; set; }
        public string OvertimeHoliday { get; set; }
        public string OvertimeMission { get; set; }
        public string OvertimeTotal { get; set; }
        public string LateArrival { get; set; }
        public string EarlyDeparture { get; set; }
        public string AllowedDelay { get; set; }
        public string Absence { get; set; }
        public string MissionHourly { get; set; }
        public string MissionDaily { get; set; }
        public string LeaveHourly { get; set; }
        public string LeaveEntitlement { get; set; }
        public string LeaveMedical { get; set; }
        public string LeaveUnpaid { get; set; }
        public string LeaveBonus { get; set; }
        public string LeaveOther { get; set; }
    }

}

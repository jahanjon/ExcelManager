using ClosedXML.Excel;
using Domain.Entities;
using Domain.Interface;
using Domain.Persistence;
using System.Dynamic;

namespace ExcelManager.Implementation
{
    public class ExcelService : IExcelService
    {
        private readonly ExcelManagerDBContext dbContext;

        public ExcelService(ExcelManagerDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> ProcessExcelFileAsync(Stream excelStream)
        {
            try
            {
                using (var workbook = new XLWorkbook(excelStream))
                {
                    var worksheet = workbook.Worksheet(1);

                    var allData = new List<DailyRecord>(); 

                    foreach (var row in worksheet.RowsUsed().Skip(1))  
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, Object>;

                        foreach (var cell in row.CellsUsed())
                        {
                            dataRow[cell.Address.ColumnLetter] = cell.GetValue<string>(); 
                        }


                        var dailyRecord = new DailyRecord
                        {
                            DateRange = dataRow.ContainsKey("Q") ? dataRow["Q"].ToString() : string.Empty,         // تاریخ دوره
                            History = dataRow.ContainsKey("AJ") ? dataRow["AJ"].ToString() : string.Empty,          // تاریخچه
                            Day = dataRow.ContainsKey("AI") ? dataRow["AI"].ToString() : string.Empty,              // روز
                            Transit1 = dataRow.ContainsKey("AH") ? dataRow["AH"].ToString() : string.Empty,         // تراورس 1
                            Transit2 = dataRow.ContainsKey("AG") ? dataRow["AG"].ToString() : string.Empty,         // تراورس 2
                            Performance = dataRow.ContainsKey("Y") ? dataRow["Y"].ToString() : string.Empty,        // عملکرد
                            OvertimeHoliday = dataRow.ContainsKey("W") ? dataRow["W"].ToString() : string.Empty,    // اضافه کاری تعطیلی
                            OvertimeMission = dataRow.ContainsKey("V") ? dataRow["V"].ToString() : string.Empty,    // اضافه کاری مأموریت
                            OvertimeTotal = dataRow.ContainsKey("U") ? dataRow["U"].ToString() : string.Empty,      // اضافه کاری کل
                            LateArrival = dataRow.ContainsKey("T") ? dataRow["T"].ToString() : string.Empty,        // تأخیر ورود
                            EarlyDeparture = dataRow.ContainsKey("S") ? dataRow["S"].ToString() : string.Empty,     // خروج زودهنگام
                            AllowedDelay = dataRow.ContainsKey("R") ? dataRow["R"].ToString() : string.Empty,       // تاخیر مجاز
                            Absence = dataRow.ContainsKey("O") ? dataRow["O"].ToString() : string.Empty,            // غیبت
                            MissionHourly = dataRow.ContainsKey("N") ? dataRow["N"].ToString() : string.Empty,      // مأموریت ساعتی
                            MissionDaily = dataRow.ContainsKey("M") ? dataRow["M"].ToString() : string.Empty,       // مأموریت روزانه
                            LeaveHourly = dataRow.ContainsKey("L") ? dataRow["L"].ToString() : string.Empty,        // مرخصی ساعتی
                            LeaveEntitlement = dataRow.ContainsKey("K") ? dataRow["K"].ToString() : string.Empty,   // مرخصی
                            LeaveMedical = dataRow.ContainsKey("J") ? dataRow["J"].ToString() : string.Empty,       // مرخصی پزشکی
                            LeaveUnpaid = dataRow.ContainsKey("I") ? dataRow["I"].ToString() : string.Empty,        // مرخصی بدون حقوق
                            LeaveBonus = dataRow.ContainsKey("H") ? dataRow["H"].ToString() : string.Empty,         // مرخصی تشویقی
                            LeaveOther = dataRow.ContainsKey("G") ? dataRow["G"].ToString() : string.Empty          // مرخصی دیگر
                        };


                        if (dataRow.ContainsKey("AD"))
                        {
                            var employeeInfo = dataRow["AD"].ToString();
                            var employeeParts = employeeInfo.Split(":")[1]?.Trim();
                            if (employeeParts != null)
                            {
                                var splitName = employeeParts.Split(' ');
                                if (splitName.Length >= 2)
                                {
                                    dailyRecord.FirstName = splitName[0];
                                    dailyRecord.LastName = splitName[1];
                                }
                            }
                        }

                        allData.Add(dailyRecord);
                    }


                    dbContext.DailyRecords.AddRange(allData);
                    await dbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }





    }
}

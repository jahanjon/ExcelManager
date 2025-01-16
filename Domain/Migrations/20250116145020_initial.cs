using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transit6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Performance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NightShift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeHoliday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateArrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarlyDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowedDelay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Absence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionHourly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDaily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveHourly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveEntitlement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveMedical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveUnpaid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveOther = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyRecords");
        }
    }
}

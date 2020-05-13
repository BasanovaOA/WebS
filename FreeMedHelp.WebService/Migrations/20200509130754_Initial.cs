using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeMedHelp.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateTable(
                name: "MedPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsMedHelpFree = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                   
                });


            migrationBuilder.InsertData(
                table: "MedPoints",
                columns: new[] { "Id", "FullName", "IsMedHelpFree"},
                values: new object[] { 1L, "Государственное бюджетное учреждение города Москвы «Станция скорой и неотложной медицинской помощи им. А.С. Пучкова» Департамента здравоохранения города Москвы", "Да" });

            migrationBuilder.InsertData(
                table: "MedPoints",
                columns: new[] { "Id", "FullName", "IsMedHelpFree" },
                values: new object[] { 2L, "Государственное бюджетное учреждение здравоохранения города Москвы «Научно-исследовательский институт скорой помощи им. Н.В. Склифосовского Департамента здравоохранения города Москвы»", "Да" });

            migrationBuilder.InsertData(
                table: "MedPoints",
                columns: new[] { "Id", "FullName", "IsMedHelpFree" },
                values: new object[] { 3L, "Государственное бюджетное учреждение здравоохранения города Москвы «Центр патологии речи и нейрореабилитации Департамента здравоохранения города Москвы»", "Нет"});

            migrationBuilder.InsertData(
                table: "MedPoints",
                columns: new[] { "Id", "FullName", "IsMedHelpFree" },
                values: new object[] { 4L, "Государственное бюджетное учреждение здравоохранения города Москвы «Московский городской центр реабилитации больных со спинномозговой травмой и последствиями детского церебрального паралича Департамента здравоохранения города Москвы»", "Нет" });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedPoints");

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPGZService.Migrations.JPGZServiceDb
{
    public partial class init_sqlserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    BrowserInfo = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "tb_News",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Ntype = table.Column<int>(nullable: true),
            //        UserType = table.Column<int>(nullable: true),
            //        Ntitle = table.Column<string>(nullable: true),
            //        Ncontent = table.Column<string>(nullable: true),
            //        Nattachment = table.Column<string>(nullable: true),
            //        SysNattachment = table.Column<string>(nullable: true),
            //        UserID = table.Column<int>(nullable: true),
            //        Cdate = table.Column<DateTime>(nullable: true),
            //        IsDelete = table.Column<bool>(nullable: true),
            //        DataOrganizeID = table.Column<int>(nullable: true),
            //        IsPublish = table.Column<int>(nullable: false),
            //        NewObject = table.Column<int>(nullable: true),
            //        CoverPicture = table.Column<string>(nullable: true),
            //        IsTopping = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_News", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "tb_News");
        }
    }
}

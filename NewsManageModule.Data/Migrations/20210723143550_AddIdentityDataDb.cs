using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsManageModule.Data.Migrations
{
    public partial class AddIdentityDataDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_UID",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Post_UID",
                table: "Post");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UID",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Post",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("068a176a-fdbf-42f0-8cdc-7cb7ce32b6fd"), "4813b0ed-21f3-46f3-9bf1-8ab4f9779947", "Staff", "staff" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), new Guid("068a176a-fdbf-42f0-8cdc-7cb7ce32b6fd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0, "7c269fcd-f0cc-44e9-ad94-6c14d68857d3", "khai12345678t@gmail.com", true, "Nguyen Duy Khai", false, null, "khai12345678t@gmail.com", "itkhainddotdev", "AQAAAAEAACcQAAAAEPKjmZq21osaRopbwFLmB9D9+Q2e6hbmMRt/ZsMJ7UVlwsP29ppHpEwm3m/dckIEvA==", null, false, "", false, "itKhaiNDdotDev" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Time", "UserId" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 35, 49, 674, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15") });

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_UserId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserId",
                table: "Post");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UID");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UID", "Fullname", "Password", "RegistDate", "Username" },
                values: new object[,]
                {
                    { 11, "Nguyen Khai", "123456", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "itKhaiND" },
                    { 1, "Nguyen Duy Khai", "15042kKhai", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "itKhaiND.Dev" },
                    { 2, "Khai Nguyen", "15042000", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "khainguyen" },
                    { 3, "Demo Namei", "1234", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "DemoU" },
                    { 4, "Abc Xyz", "1111", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "abcxyz" },
                    { 5, "Dinh Dat", "12345678", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "DatDv" },
                    { 6, "Tri Nam", "12345678", new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "TNG" }
                });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 4 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 3 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 2 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 11 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 11 });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Time", "UID" },
                values: new object[] { new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Post_UID",
                table: "Post",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_UID",
                table: "Post",
                column: "UID",
                principalTable: "Users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

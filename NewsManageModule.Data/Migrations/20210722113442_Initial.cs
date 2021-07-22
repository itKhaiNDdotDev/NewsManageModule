using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsManageModule.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Fullname = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false),
                    RegistDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Head = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UID = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Post_Users_UID",
                        column: x => x.UID,
                        principalTable: "Users",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: false),
                    OldHeader = table.Column<string>(maxLength: 300, nullable: false),
                    NewHeader = table.Column<string>(maxLength: 300, nullable: false),
                    OldContent = table.Column<string>(nullable: false),
                    NewContent = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HID);
                    table.ForeignKey(
                        name: "FK_Histories_Post_ID",
                        column: x => x.ID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsInTopics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsInTopics", x => new { x.ID, x.TID });
                    table.ForeignKey(
                        name: "FK_PostsInTopics_Post_ID",
                        column: x => x.ID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsInTopics_Topics_TID",
                        column: x => x.TID,
                        principalTable: "Topics",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    RID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: false),
                    URL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 300, nullable: false),
                    IsAvatar = table.Column<bool>(nullable: false),
                    ImportDate = table.Column<DateTime>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.RID);
                    table.ForeignKey(
                        name: "FK_Resources_Post_ID",
                        column: x => x.ID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ID",
                table: "Histories",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UID",
                table: "Post",
                column: "UID");

            migrationBuilder.CreateIndex(
                name: "IX_PostsInTopics_TID",
                table: "PostsInTopics",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ID",
                table: "Resources",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "PostsInTopics");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

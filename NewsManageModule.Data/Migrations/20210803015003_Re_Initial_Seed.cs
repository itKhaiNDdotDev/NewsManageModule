using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsManageModule.Data.Migrations
{
    public partial class Re_Initial_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Head = table.Column<string>(maxLength: 300, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
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
                        name: "FK_Histories_Posts_ID",
                        column: x => x.ID,
                        principalTable: "Posts",
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
                        name: "FK_PostsInTopics_Posts_ID",
                        column: x => x.ID,
                        principalTable: "Posts",
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
                        name: "FK_Resources_Posts_ID",
                        column: x => x.ID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("068a176a-fdbf-42f0-8cdc-7cb7ce32b6fd"), "90bbc3ff-2ddb-4470-9c59-bb566c5a858d", "Staff", "staff" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TID", "TName" },
                values: new object[,]
                {
                    { 11, "Thể thao" },
                    { 1, "Văn hóa" },
                    { 2, "Công nghệ" },
                    { 3, "Showbiz" },
                    { 4, "Tài chính" },
                    { 5, "Pháp luật" },
                    { 6, "Giáo dục" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), new Guid("068a176a-fdbf-42f0-8cdc-7cb7ce32b6fd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0, "2b2d3f5f-c52b-4052-93fc-fd0ba2149d56", "khai12345678t@gmail.com", true, "Nguyen Duy Khai", false, null, "khai12345678t@gmail.com", "itkhainddotdev", "AQAAAAEAACcQAAAAEDDTS5nSk+4gR6PAxYN1Dy07XpZRsN0a3Yc4jrN87CvbXmZb5iih12qZzqXBsNoqRg==", null, false, "", false, "itKhaiNDdotDev" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Content", "Head", "Time", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 11, "EURO2020 đã chính thức khép lại, mặc dù chỉ cần chươi 4 trận đấu và bị loại sớm tại vòng 1/8 nhưng siêu sao Cristiano Ronaldo - Tiền đạo đội trưởng ĐTQG Bồ Đào Nha vẫn giành danh hiệu vua phá lưới với 5 bàn thắng và một kiến tạo", "C. Ronaldo giành danh hiệu vua phá lưới EURO2020", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 100 },
                    { 1, "Rạng sáng nay, trang thông tin chính thức của tập đoàn công nghệ hàng đầu thế giới Microsoft đã chính thức ra thông báo cung cấp phiên bản dùng thử của công nghệ >NET 10 và dự kiến sẽ ra mắt bản chính thức vào khoảng tháng 12/2022.", "Microsoft cho ra đời công nghệ .NET 10", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 96 },
                    { 2, "Sau nhiều năm chờ đợi, cuối cùng LM10 - Enpulga cùng các đồng đội tại ĐTQG Argentina đã chính thức lên ngôi vô địch Copa America 2021 sau khi giành chiến thắng 1-0 trước Brazil với pha lập công duy nhất của A. Dimaria.", "L. Messi cùng Argentina vô địch Copa America", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 1 },
                    { 3, "Trận chung kết UEFA EURO 2020 khép lại với phần thắng thuộc về tân vương Azzurri sau loạt luân lưu căng thẳng. Điểm nhấn đáng chú ý là 3 cầu thủ được tung vào sân M. Rashford, B. Saka và J. Sancho - những cầu thủ da màu của ĐTQG Anh là những người bỏ lỡ cả 3 quả quyết định cuối cùng. Sau trận đấy nạn phân biệt chủng tộc lại nổi lên gắt gao hơn bao giờ hết...", "Đá hỏng Penalty - 3 cầu thủ da màu của tuyển Anh bị phân biệt chủng tộc", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0 },
                    { 4, "Thị trường tiền ảo Bitcoins là một nền tảng - hình thức kinh doanh nổi lên đình đám trong thời gian qua với hoạt động điển hìn gắn với từ khóa Đào Bitcoin. Theo ghi nhận của chúng tôi, đến 12h trưa nay, các con số thông kê thị trường tiền ảo này có dấu hiệu giảm mạnh và chưa có tín hiệu dừng lại... ", "Bitcoins bắt đầu đi xuống và có nguy cơ lụi tàn", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0 },
                    { 5, " Mới đấy, hình ảnh được chia sẻ rất nhiều trên MXH sau trận đấu giữu 2 ĐTQG Bồ Đào Nha với Hungary đó là việc siêu sao Cristiano Ronaldo đã có hành động đẩy chai nước COcacola của nhà tài trợ EURO2020 ra khỏi tầm camera và khuyene mọi người uống nước lọc giống anh. Ngày hôm nay, thị trường cổ phiếu ghi nhận hãng Cocacola bị giảm mạnh với mức giảm 5% giá trị cổ phiếu...", "Cổ phiếu Cocacola giảm mạnh sau pha /dìm hàng/ của CR7", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0 },
                    { 6, "Sau 2 năm im lặng với các sản phẩm âm nhạc cảu mình, Kay Trần đã chính thức cumback với bản hit Nắm đôi bàn tay với rất nhiều những ý kiến trái chiều của CĐM xoay quanh sự ảnh hưởng của Sơn Tùng MTP....", "Kay Trần quay trở lại với sản phẩm âm nhạc thuộc MTP ENtertaiments", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 0 },
                    { 7, "Mới đây, Lionel Messi sau khi đá hỏng quả phạt đền dâng chức vô địch cho ĐTQG Chile, CĐM lại nhận được bão chia sẻ với hình ảnh Mesi hát thuộc lòng quốc ca Chile trước trận đấu...", "Shock! Missi khiến người hâm mô điên đảo khi hát thuộc lòng quốc ca Chiile", new DateTime(2021, 8, 3, 1, 50, 2, 962, DateTimeKind.Utc), new Guid("742863b0-f2cb-499e-bb94-b4646526fc15"), 7 }
                });

            migrationBuilder.InsertData(
                table: "PostsInTopics",
                columns: new[] { "ID", "TID" },
                values: new object[,]
                {
                    { 11, 11 },
                    { 1, 2 },
                    { 2, 11 },
                    { 3, 11 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 4 },
                    { 5, 11 },
                    { 5, 4 },
                    { 6, 3 },
                    { 7, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ID",
                table: "Histories",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

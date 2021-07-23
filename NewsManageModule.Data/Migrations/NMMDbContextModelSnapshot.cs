﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsManageModule.Data.EF;

namespace NewsManageModule.Data.Migrations
{
    [DbContext(typeof(NMMDbContext))]
    partial class NMMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewsManageModule.Data.Entities.History", b =>
                {
                    b.Property<int>("HID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EditTime");

                    b.Property<int>("ID");

                    b.Property<string>("NewContent")
                        .IsRequired()
                        .IsUnicode(true);

                    b.Property<string>("NewHeader")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<string>("OldContent")
                        .IsRequired()
                        .IsUnicode(true);

                    b.Property<string>("OldHeader")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.HasKey("HID");

                    b.HasIndex("ID");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsUnicode(true);

                    b.Property<string>("Head")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<DateTime>("Time");

                    b.Property<int>("UID");

                    b.Property<int>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("ID");

                    b.HasIndex("UID");

                    b.ToTable("Post");

                    b.HasData(
                        new { ID = 11, Content = "EURO2020 đã chính thức khép lại, mặc dù chỉ cần chươi 4 trận đấu và bị loại sớm tại vòng 1/8 nhưng siêu sao Cristiano Ronaldo - Tiền đạo đội trưởng ĐTQG Bồ Đào Nha vẫn giành danh hiệu vua phá lưới với 5 bàn thắng và một kiến tạo", Head = "C. Ronaldo giành danh hiệu vua phá lưới EURO2020", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 1, ViewCount = 100 },
                        new { ID = 1, Content = "Rạng sáng nay, trang thông tin chính thức của tập đoàn công nghệ hàng đầu thế giới Microsoft đã chính thức ra thông báo cung cấp phiên bản dùng thử của công nghệ >NET 10 và dự kiến sẽ ra mắt bản chính thức vào khoảng tháng 12/2022.", Head = "Microsoft cho ra đời công nghệ .NET 10", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 1, ViewCount = 96 },
                        new { ID = 2, Content = "Sau nhiều năm chờ đợi, cuối cùng LM10 - Enpulga cùng các đồng đội tại ĐTQG Argentina đã chính thức lên ngôi vô địch Copa America 2021 sau khi giành chiến thắng 1-0 trước Brazil với pha lập công duy nhất của A. Dimaria.", Head = "L. Messi cùng Argentina vô địch Copa America", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 4, ViewCount = 1 },
                        new { ID = 3, Content = "Trận chung kết UEFA EURO 2020 khép lại với phần thắng thuộc về tân vương Azzurri sau loạt luân lưu căng thẳng. Điểm nhấn đáng chú ý là 3 cầu thủ được tung vào sân M. Rashford, B. Saka và J. Sancho - những cầu thủ da màu của ĐTQG Anh là những người bỏ lỡ cả 3 quả quyết định cuối cùng. Sau trận đấy nạn phân biệt chủng tộc lại nổi lên gắt gao hơn bao giờ hết...", Head = "Đá hỏng Penalty - 3 cầu thủ da màu của tuyển Anh bị phân biệt chủng tộc", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 3, ViewCount = 0 },
                        new { ID = 4, Content = "Thị trường tiền ảo Bitcoins là một nền tảng - hình thức kinh doanh nổi lên đình đám trong thời gian qua với hoạt động điển hìn gắn với từ khóa Đào Bitcoin. Theo ghi nhận của chúng tôi, đến 12h trưa nay, các con số thông kê thị trường tiền ảo này có dấu hiệu giảm mạnh và chưa có tín hiệu dừng lại... ", Head = "Bitcoins bắt đầu đi xuống và có nguy cơ lụi tàn", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 2, ViewCount = 0 },
                        new { ID = 5, Content = " Mới đấy, hình ảnh được chia sẻ rất nhiều trên MXH sau trận đấu giữu 2 ĐTQG Bồ Đào Nha với Hungary đó là việc siêu sao Cristiano Ronaldo đã có hành động đẩy chai nước COcacola của nhà tài trợ EURO2020 ra khỏi tầm camera và khuyene mọi người uống nước lọc giống anh. Ngày hôm nay, thị trường cổ phiếu ghi nhận hãng Cocacola bị giảm mạnh với mức giảm 5% giá trị cổ phiếu...", Head = "Cổ phiếu Cocacola giảm mạnh sau pha /dìm hàng/ của CR7", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 1, ViewCount = 0 },
                        new { ID = 6, Content = "Sau 2 năm im lặng với các sản phẩm âm nhạc cảu mình, Kay Trần đã chính thức cumback với bản hit Nắm đôi bàn tay với rất nhiều những ý kiến trái chiều của CĐM xoay quanh sự ảnh hưởng của Sơn Tùng MTP....", Head = "Kay Trần quay trở lại với sản phẩm âm nhạc thuộc MTP ENtertaiments", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 11, ViewCount = 0 },
                        new { ID = 7, Content = "Mới đây, Lionel Messi sau khi đá hỏng quả phạt đền dâng chức vô địch cho ĐTQG Chile, CĐM lại nhận được bão chia sẻ với hình ảnh Mesi hát thuộc lòng quốc ca Chile trước trận đấu...", Head = "Shock! Missi khiến người hâm mô điên đảo khi hát thuộc lòng quốc ca Chiile", Time = new DateTime(2021, 7, 23, 3, 48, 21, 768, DateTimeKind.Utc), UID = 11, ViewCount = 7 }
                    );
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.PostInTopic", b =>
                {
                    b.Property<int>("ID");

                    b.Property<int>("TID");

                    b.HasKey("ID", "TID");

                    b.HasIndex("TID");

                    b.ToTable("PostsInTopics");

                    b.HasData(
                        new { ID = 11, TID = 11 },
                        new { ID = 1, TID = 2 },
                        new { ID = 2, TID = 11 },
                        new { ID = 3, TID = 11 },
                        new { ID = 3, TID = 1 },
                        new { ID = 3, TID = 3 },
                        new { ID = 3, TID = 5 },
                        new { ID = 3, TID = 6 },
                        new { ID = 4, TID = 4 },
                        new { ID = 5, TID = 11 },
                        new { ID = 5, TID = 4 },
                        new { ID = 6, TID = 3 },
                        new { ID = 7, TID = 11 }
                    );
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.Resource", b =>
                {
                    b.Property<int>("RID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<long>("FileSize");

                    b.Property<int>("ID");

                    b.Property<DateTime>("ImportDate");

                    b.Property<bool>("IsAvatar");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("RID");

                    b.HasIndex("ID");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.Topic", b =>
                {
                    b.Property<int>("TID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("TID");

                    b.ToTable("Topics");

                    b.HasData(
                        new { TID = 11, TName = "Thể thao" },
                        new { TID = 1, TName = "Văn hóa" },
                        new { TID = 2, TName = "Công nghệ" },
                        new { TID = 3, TName = "Showbiz" },
                        new { TID = 4, TName = "Tài chính" },
                        new { TID = 5, TName = "Pháp luật" },
                        new { TID = 6, TName = "Giáo dục" }
                    );
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.User", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<DateTime>("RegistDate");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("UID");

                    b.ToTable("Users");

                    b.HasData(
                        new { UID = 11, Fullname = "Nguyen Khai", Password = "123456", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "itKhaiND" },
                        new { UID = 1, Fullname = "Nguyen Duy Khai", Password = "15042kKhai", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "itKhaiND.Dev" },
                        new { UID = 2, Fullname = "Khai Nguyen", Password = "15042000", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "khainguyen" },
                        new { UID = 3, Fullname = "Demo Namei", Password = "1234", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "DemoU" },
                        new { UID = 4, Fullname = "Abc Xyz", Password = "1111", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "abcxyz" },
                        new { UID = 5, Fullname = "Dinh Dat", Password = "12345678", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "DatDv" },
                        new { UID = 6, Fullname = "Tri Nam", Password = "12345678", RegistDate = new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), Username = "TNG" }
                    );
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.History", b =>
                {
                    b.HasOne("NewsManageModule.Data.Entities.Post", "Post")
                        .WithMany("Histories")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.Post", b =>
                {
                    b.HasOne("NewsManageModule.Data.Entities.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("UID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.PostInTopic", b =>
                {
                    b.HasOne("NewsManageModule.Data.Entities.Post", "Post")
                        .WithMany("PostInTopics")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsManageModule.Data.Entities.Topic", "Topic")
                        .WithMany("PostsInTopic")
                        .HasForeignKey("TID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewsManageModule.Data.Entities.Resource", b =>
                {
                    b.HasOne("NewsManageModule.Data.Entities.Post", "Post")
                        .WithMany("Resources")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

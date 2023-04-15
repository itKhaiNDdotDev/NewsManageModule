using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsManageModule.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData
               (
                   new Topic() { TID = 11, TName = "Thể thao" },
                   new Topic() { TID = 1, TName = "Văn hóa" },
                   new Topic() { TID = 2, TName = "Công nghệ" },
                   new Topic() { TID = 3, TName = "Showbiz" },
                   new Topic() { TID = 4, TName = "Tài chính" },
                   new Topic() { TID = 5, TName = "Pháp luật" },
                   new Topic() { TID = 6, TName = "Giáo dục" }
               );

            //modelBuilder.Entity<User>().HasData
            //   (                                                                        // DateTime.Now.ToString("dd/MM/yyyy")
            //       new User() { UID = 11, Username = "itKhaiND", Fullname = "Nguyen Khai", Password = "123456", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 1, Username = "itKhaiND.Dev", Fullname = "Nguyen Duy Khai", Password = "15042kKhai", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 2, Username = "khainguyen", Fullname = "Khai Nguyen", Password = "15042000", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 3, Username = "DemoU", Fullname = "Demo Namei", Password = "1234", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 4, Username = "abcxyz", Fullname = "Abc Xyz", Password = "1111", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 5, Username = "DatDv", Fullname = "Dinh Dat", Password = "12345678", RegistDate = DateTime.UtcNow.Date },
            //       new User() { UID = 6, Username = "TNG", Fullname = "Tri Nam", Password = "12345678", RegistDate = DateTime.UtcNow.Date }
            //   );
            // any guid
            var roleID = new Guid("068A176A-FDBF-42F0-8CDC-7CB7CE32B6FD");
            var staffID = new Guid("742863B0-F2CB-499E-BB94-B4646526FC15");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleID,
                Name = "Staff",
                NormalizedName = "staff"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = staffID,
                UserName = "itKhaiNDdotDev",
                NormalizedUserName = "itkhainddotdev",
                Email = "khai12345678t@gmail.com",
                NormalizedEmail = "khai12345678t@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "15042kKhai"),
                SecurityStamp = string.Empty,
                Fullname = "Nguyen Duy Khai"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleID,
                UserId = staffID
            });

            modelBuilder.Entity<Post>().HasData
               (
                   new Post()
                   {
                       ID = 11,
                       Head = "C. Ronaldo giành danh hiệu vua phá lưới EURO2020",
                       Content = "EURO2020 đã chính thức khép lại, mặc dù chỉ cần chươi 4 trận đấu và bị loại sớm tại vòng 1/8 nhưng " +
                        "siêu sao Cristiano Ronaldo - Tiền đạo đội trưởng ĐTQG Bồ Đào Nha vẫn giành danh hiệu vua phá lưới với 5 bàn thắng và một kiến tạo",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 100
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 0, TID = 0 }
                       //}
                   },
                   new Post()
                   {
                       ID = 1,
                       Head = "Microsoft cho ra đời công nghệ .NET 10",
                       Content = "Rạng sáng nay, trang thông tin chính thức của tập đoàn công nghệ hàng đầu thế giới Microsoft đã " +
                        "chính thức ra thông báo cung cấp phiên bản dùng thử của công nghệ >NET 10 và dự kiến sẽ ra mắt bản chính thức vào khoảng tháng 12/2022.",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 96
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 1, TID = 2 }
                       //}
                   },
                   new Post()
                   {
                       ID = 2,
                       Head = "L. Messi cùng Argentina vô địch Copa America",
                       Content = "Sau nhiều năm chờ đợi, cuối cùng LM10 - Enpulga cùng các đồng đội tại ĐTQG Argentina " +
                        "đã chính thức lên ngôi vô địch Copa America 2021 sau khi giành chiến thắng 1-0 trước Brazil với pha lập công duy nhất của A. Dimaria.",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 1
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 2, TID = 0 }
                       //}
                   },
                   new Post()
                   {
                       ID = 3,
                       Head = "Đá hỏng Penalty - 3 cầu thủ da màu của tuyển Anh bị phân biệt chủng tộc",
                       Content = "Trận chung kết UEFA EURO 2020 khép lại với phần thắng thuộc về tân vương Azzurri sau loạt luân lưu căng thẳng. " +
                        "Điểm nhấn đáng chú ý là 3 cầu thủ được tung vào sân M. Rashford, B. Saka và J. Sancho - những cầu thủ da màu của ĐTQG Anh " +
                        "là những người bỏ lỡ cả 3 quả quyết định cuối cùng. Sau trận đấy nạn phân biệt chủng tộc lại nổi lên gắt gao hơn bao giờ hết...",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 0
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 3, TID = 0 },
                       //    new NewsInTopics() { ID = 3, TID = 1 },
                       //    new NewsInTopics() { ID = 3, TID = 3 },
                       //    new NewsInTopics() { ID = 3, TID = 5 },
                       //    new NewsInTopics() { ID = 3, TID = 6 }
                       //}
                   },
                   new Post()
                   {
                       ID = 4,
                       Head = "Bitcoins bắt đầu đi xuống và có nguy cơ lụi tàn",
                       Content = "Thị trường tiền ảo Bitcoins là một nền tảng - hình thức kinh doanh nổi lên đình đám trong thời gian qua với hoạt động điển hìn " +
                        "gắn với từ khóa Đào Bitcoin. Theo ghi nhận của chúng tôi, đến 12h trưa nay, các con số thông kê thị trường tiền ảo này có dấu hiệu giảm mạnh " +
                        "và chưa có tín hiệu dừng lại... ",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 0
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 4, TID = 4 }
                       //}
                   },
                   new Post()
                   {
                       ID = 5,
                       Head = "Cổ phiếu Cocacola giảm mạnh sau pha /dìm hàng/ của CR7",
                       Content = " Mới đấy, hình ảnh được chia sẻ rất nhiều trên MXH sau trận đấu giữu 2 ĐTQG Bồ Đào Nha với Hungary đó là việc " +
                        "siêu sao Cristiano Ronaldo đã có hành động đẩy chai nước COcacola của nhà tài trợ EURO2020 ra khỏi tầm camera " +
                        "và khuyene mọi người uống nước lọc giống anh. Ngày hôm nay, thị trường cổ phiếu ghi nhận hãng Cocacola bị giảm mạnh " +
                        "với mức giảm 5% giá trị cổ phiếu...",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 0
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 5, TID = 0 },
                       //    new NewsInTopics() { ID = 5, TID = 4 }
                       //}
                   },
                   new Post()
                   {
                       ID = 6,
                       Head = "Kay Trần quay trở lại với sản phẩm âm nhạc thuộc MTP ENtertaiments",
                       Content = "Sau 2 năm im lặng với các sản phẩm âm nhạc cảu mình, Kay Trần đã chính thức cumback với bản hit Nắm đôi bàn tay " +
                        "với rất nhiều những ý kiến trái chiều của CĐM xoay quanh sự ảnh hưởng của Sơn Tùng MTP....",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 0
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 6, TID = 3 }
                       //}
                   },
                   new Post()
                   {
                       ID = 7,
                       Head = "Shock! Missi khiến người hâm mô điên đảo khi hát thuộc lòng quốc ca Chiile",
                       Content = "Mới đây, Lionel Messi sau khi đá hỏng quả phạt đền dâng chức vô địch cho ĐTQG Chile, CĐM lại nhận được bão chia sẻ " +
                        "với hình ảnh Mesi hát thuộc lòng quốc ca Chile trước trận đấu...",
                       UserId = staffID,
                       Time = DateTime.UtcNow,
                       ViewCount = 7
                       //NewsInTopics = new List<NewsInTopics>()
                       //{
                       //    new NewsInTopics() { ID = 7, TID = 0 }
                       //}
                   }
               );

            modelBuilder.Entity<PostInTopic>().HasData
                (
                           //new List<NewsInTopics>()
                           //   {
                           new PostInTopic() { ID = 11, TID = 11 },
                           new PostInTopic() { ID = 1, TID = 2 },
                           new PostInTopic() { ID = 2, TID = 11 },
                           new PostInTopic() { ID = 3, TID = 11 },
                           new PostInTopic() { ID = 3, TID = 1 },
                           new PostInTopic() { ID = 3, TID = 3 },
                           new PostInTopic() { ID = 3, TID = 5 },
                           new PostInTopic() { ID = 3, TID = 6 },
                           new PostInTopic() { ID = 4, TID = 4 },
                           new PostInTopic() { ID = 5, TID = 11 },
                           new PostInTopic() { ID = 5, TID = 4 },
                           new PostInTopic() { ID = 6, TID = 3 },
                           new PostInTopic() { ID = 7, TID = 11 }
                //}
                );
        }
    }
}

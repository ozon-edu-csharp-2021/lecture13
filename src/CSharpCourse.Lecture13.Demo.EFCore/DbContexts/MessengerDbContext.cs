using CSharpCourse.Lecture13.Demo.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.Lecture13.Demo.EFCore.DbContexts
{
    public class MessengerDbContext : DbContext
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChat> UserChats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(System.Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(opt =>
            {
                opt.ToTable("chats")
                    .HasKey(it => it.Id);
                opt.Property(it => it.Id)
                    .HasColumnName("id");
                opt.Property(it => it.Name)
                    .HasColumnName("name");
                opt.Property(it => it.LogoUrl)
                    .HasColumnName("logo_url");
            });

            modelBuilder.Entity<Message>(opt =>
            {
                opt.ToTable("messages")
                    .HasKey(it => it.Id);
                opt.Property(it => it.Id)
                    .HasColumnName("id");
                opt.Property(it => it.Text)
                    .HasColumnName("text");
                opt.Property(it => it.ChatId)
                    .HasColumnName("chat_id");
                opt.Property(it => it.IsRead)
                    .HasColumnName("is_read");
                opt.Property(it => it.UserFrom)
                    .HasColumnName("user_from");
                opt.Property(it => it.UserTo)
                    .HasColumnName("user_to");
                opt.Property(it => it.UserFrom)
                    .HasColumnName("user_from");
            });

            modelBuilder.Entity<User>(opt =>
            {
                opt.ToTable("users");
                opt.HasKey(it => it.Id);
                opt.Property(it => it.Id)
                    .HasColumnName("id");
                opt.Property(it => it.City)
                    .HasColumnName("city");
                opt.Property(it => it.Nickname)
                    .HasColumnName("nickname");
                opt.Property(it => it.AvatarUrl)
                    .HasColumnName("avatar_url");
                opt.Property(it => it.Phone)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<UserChat>(opt =>
            {
                opt.ToTable("users_chats");
                opt.HasKey(it => new { it.ChatId, it.UserId });
                opt.Property(it => it.UserId)
                    .HasColumnName("user_id");
                opt.Property(it => it.ChatId)
                    .HasColumnName("chat_id");
                
                opt.HasOne(it => it.Chat)
                    .WithMany(it => it.UsersChats)
                    .HasForeignKey(it => it.ChatId)
                    .HasConstraintName("chats_users_fk");
                opt.HasOne(it => it.User)
                    .WithMany(it => it.UsersChats)
                    .HasForeignKey(it => it.UserId)
                    .HasConstraintName("user_chats_fk");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
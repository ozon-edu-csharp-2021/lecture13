using CSharpCourse.Lecture13.Demo.Linq2DB.Models;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.DbContexts
{
    public class MessengerDbContext : DataConnection
    {
        public MessengerDbContext(LinqToDbConnectionOptions<MessengerDbContext> options) : base(options)
        {
        }

        public ITable<Chat> Chats => GetTable<Chat>();
        public ITable<User> Users => GetTable<User>();
        public ITable<UserChat> UsersChats => GetTable<UserChat>();
        public ITable<Message> Messages => GetTable<Message>();
    }
}
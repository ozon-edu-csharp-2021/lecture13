
using LinqToDB.Mapping;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Models
{
    /// <summary>
    /// Модель связи между пользователем и чатом
    /// </summary>
    [Table(Name = "users_chats")]
    public class UserChat
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Модель пользователя
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Модель чата
        /// </summary>
        public Chat Chat { get; set; }
    }
}
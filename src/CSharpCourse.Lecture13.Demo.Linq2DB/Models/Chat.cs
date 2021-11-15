using System.Collections.Generic;
using LinqToDB.Mapping;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Models
{
    /// <summary>
    /// Модель которая представляет чат
    /// </summary>
    [Table(Name = "chats")]
    public class Chat
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        [PrimaryKey]
        [Column(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Название чата
        /// </summary>
        [Column(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Адрес по которому располагается лого чата
        /// </summary>
        [Column(Name = "logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Коллекция пользователей в чате
        /// </summary>
        public ICollection<UserChat> UsersChats { get; set; }
    }
}
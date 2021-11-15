using System.Collections.Generic;
using LinqToDB.Mapping;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Models
{
    /// <summary>
    /// Модель которая представляет пользователя чат мессенджера
    /// </summary>
    [Table(Name = "users")]
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [PrimaryKey]
        [Column(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Псевдоним пользователя
        /// </summary>
        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        [Column(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес по которому располагается аватарка пользователя
        /// </summary>
        [Column(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Город пользователя
        /// </summary>
        [Column(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Коллекция чатов для данного пользователя
        /// </summary>
        public ICollection<UserChat> UsersChats { get; set; }
    }
}
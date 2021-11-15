using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CSharpCourse.Lecture13.Demo.EFCore.Models
{
    /// <summary>
    /// Модель которая представляет пользователя чат мессенджера
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Псевдоним пользователя
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес по которому располагается аватарка пользователя
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Город пользователя
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Коллекция чатов для данного пользователя
        /// </summary>
        public ICollection<UserChat> UsersChats { get; set; }
    }
}
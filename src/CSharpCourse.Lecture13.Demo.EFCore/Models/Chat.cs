using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CSharpCourse.Lecture13.Demo.EFCore.Models
{
    /// <summary>
    /// Модель которая представляет чат
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название чата
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес по которому располагается лого чата
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Коллекция пользователей в чате
        /// </summary>
        public ICollection<UserChat> UsersChats { get; set; }
    }
}
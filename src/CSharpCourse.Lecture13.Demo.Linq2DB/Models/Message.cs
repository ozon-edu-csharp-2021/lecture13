using LinqToDB.Mapping;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Models
{
    /// <summary>
    /// Модель которая представляет сообщение
    /// </summary>
    [Table(Name = "messages")]
    public class Message
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        [PrimaryKey]
        [Column(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Сообщение от кого
        /// </summary>
        [Column(Name = "user_from")]
        public int UserFrom { get; set; }

        /// <summary>
        /// Сообщение кому
        /// </summary>
        [Column(Name = "user_to")]
        public int UserTo { get; set; }

        /// <summary>
        /// Идентификатор чата
        /// </summary>
        [Column(Name = "chat_id")]
        public int ChatId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Column(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Флаг того, прочитано ли сообщеие
        /// </summary>
        [Column(Name = "is_read")]
        public bool IsRead { get; set; }

        /// <summary>
        /// Модель для чата
        /// </summary>
        public Chat Chat { get; set; }
    }
}
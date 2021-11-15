namespace CSharpCourse.Lecture13.Demo.EFCore.Models
{
    /// <summary>
    /// Модель которая представляет сообщение
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сообщение от кого
        /// </summary>
        public int UserFrom { get; set; }

        /// <summary>
        /// Сообщение кому
        /// </summary>
        public int UserTo { get; set; }

        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Флаг того, прочитано ли сообщеие
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Модель для чата
        /// </summary>
        public Chat Chat { get; set; }
    }
}
namespace MovieApp.Models
{
    public class ErrorDto
    {
        /// <summary>
        /// Общее сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Дополнительные данные
        /// </summary>
        public object? Data { get; set; }
    }
}

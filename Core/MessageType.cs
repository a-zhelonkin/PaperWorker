namespace Core
{
    public enum MessageType : byte
    {
        /// <summary>
        /// Запрос на восстановление пароля
        /// </summary>
        RestoreRequest,

        /// <summary>
        /// Запрос отправки ссылки авторизации
        /// </summary>
        AuthLinkRequest
    }
}
namespace Core
{
    public enum UserStatus : byte
    {
        /// <summary>
        /// Время приглашения вышло
        /// </summary>
        Expired,

        /// <summary>
        /// Ожидает отправки приглашения
        /// </summary>
        Prepared,

        /// <summary>
        /// Ожидает регистрации пользователя
        /// </summary>
        Pending,

        /// <summary>
        /// Зарегистрированный пользователь
        /// </summary>
        Confirmed
    }
}
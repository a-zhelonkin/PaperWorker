namespace Core
{
    public enum UserStatus : byte
    {
        /// <summary>
        /// Просрочено
        /// </summary>
        Expired,

        /// <summary>
        /// В подготовке
        /// </summary>
        Prepared,

        /// <summary>
        /// В ожидании
        /// </summary>
        Pending,

        /// <summary>
        /// Принято
        /// </summary>
        Accepted,

        /// <summary>
        /// Подтверждено
        /// </summary>
        Confirmed
    }
}
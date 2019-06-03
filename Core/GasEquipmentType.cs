namespace Core
{
    public enum GasEquipmentType : byte
    {
        /// <summary>
        /// Счетчик
        /// </summary>
        Counter,

        /// <summary>
        /// Трубопровод
        /// </summary>
        Pipeline,

        /// <summary>
        /// Плита x-конфорочная
        /// </summary>
        Stove2Hob,
        Stove3Hob,
        Stove4Hob,

        /// <summary>
        /// Плита повышенной комфортности
        /// </summary>
        StoveHighComfort,

        /// <summary>
        /// Отопительная печь
        /// </summary>
        Furnace,
    }
}
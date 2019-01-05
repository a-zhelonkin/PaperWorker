using System;

namespace Core
{
    public enum RoleName : byte
    {
        /// <summary>
        /// Потребитель
        /// </summary>
        Consumer,

        /// <summary>
        /// Слесарь
        /// </summary>
        Locksmith,

        /// <summary>
        /// Администратор
        /// </summary>
        Admin
    }

    public static class RoleNameExtension
    {
        public static readonly Guid ConsumerRoleId = Guid.Parse("aba45201-df85-44b5-bf6c-18c88a53bcdf");
        public static readonly Guid LocksmithRoleId = Guid.Parse("80e1eac8-73c1-4521-b7b1-d17432863986");
        public static readonly Guid AdminRoleId = Guid.Parse("c112f70e-1a4b-4abf-86b2-dcbd9b78b37b");

        public static Guid GetId(this RoleName roleName)
        {
            switch (roleName)
            {
                case RoleName.Consumer:
                    return ConsumerRoleId;
                case RoleName.Locksmith:
                    return LocksmithRoleId;
                case RoleName.Admin:
                    return AdminRoleId;
                default:
                    throw new ArgumentException($"Cannot get id from {roleName}");
            }
        }
    }
}
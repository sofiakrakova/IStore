using System;

namespace IStore.BusinessLogic
{
    internal static class Protector
    {
        internal static void SetIfNotNull<T>(ref T member, T value)
        {
            member = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}

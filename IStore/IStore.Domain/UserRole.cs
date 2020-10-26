namespace IStore.Domain
{
    public class UserRole
    {
        public enum RoleType
        {
            Administrator = 1,
            User = 2,
            Guest = 3,
        }

        public int Id { get; set; }
        public string Title { get; set; }

        //private UserRole() { }

        //public UserRole RoleFor(RoleType roleType)
        //{
        //    return new UserRole() { Id = (int)roleType, Title = nameof(roleType) };
        //}
    }
}

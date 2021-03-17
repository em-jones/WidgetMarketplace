using System;

namespace UserManagement.UserStore
{
    [Serializable]
    public record UserState
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid id { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
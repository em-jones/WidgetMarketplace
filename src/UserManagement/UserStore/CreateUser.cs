using System;
using Core.Messaging;
using LanguageExt;
using Newtonsoft.Json;

namespace UserManagement.UserStore
{
    public record CreateUser(string FirstName,
        string LastName,
        string Email,
        DateTime Timestamp) :
        UserCommand(Timestamp), ICommand<UserState>
    {
        public CreateUser() : this("","", "", DateTime.Now.ToUniversalTime())
        {
        }
        [JsonIgnore]
        public TryAsync<UserState> FindIfUserExists { get; init; }
    }
}
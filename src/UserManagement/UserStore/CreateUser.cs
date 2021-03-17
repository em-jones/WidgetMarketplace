using System;
using Core.Messaging;
using LanguageExt;
using Newtonsoft.Json;

namespace UserManagement.UserStore
{
    public record CreateUser(string FirstName,
        string LastName,
        string Email) :
        UserCommand, ICommand<UserState>
    {
        public CreateUser() : this("","", "")
        {
        }
        [JsonIgnore]
        public TryAsync<UserState> FindIfUserExists { get; init; }
    }
}
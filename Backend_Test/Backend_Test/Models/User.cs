using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Backend_Test.Context;

namespace Backend_Test.Models
{
    [Table("User")]
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }

        [JsonIgnore]
        public byte[] Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public DateTime LastLoginTimestamp { get; set; }

        public int CreateBy { get; set; }

        public int DeleteBy { get; set; }

        public DateTime CreateTimestamp { get; set; }
    }
}


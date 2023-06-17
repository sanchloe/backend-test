using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Test.Models
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}


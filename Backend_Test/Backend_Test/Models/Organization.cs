using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Backend_Test.Context;

namespace Backend_Test.Models
{
    [Table("Organization")]
    public class Organization{
        public Organization(){

        }

        public string Name {get; set;}
        public string BusinessRegistrationNumber {get; set;} //TODO: change db to int
        public string Address {get; set;}
        public int PostCode {get; set;}
        public int ContactNumber {get; set;}
        public DateTime CreatedTimestamp { get; set; }
    }
}
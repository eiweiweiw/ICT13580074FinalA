using System;
using SQLite;
namespace ICT13580074FinalA.Models
{
   

    public class Product
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Name { get; set; }

        public string LastName { get; set; }


        public string Category { get; set; }
        [NotNull]
        [MaxLength(100)]
        public int Age { get; set; }
        [NotNull]
        [MaxLength(100)]
        public string Gender { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Child { get; set; }
        public Decimal Salary { get; set; }
    }
}
    

using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        /// <summary>Login password (plain text for learning only; hash passwords in production).</summary>
        public string Password { get; set; }

        public int Age { get; set; }
    }
}
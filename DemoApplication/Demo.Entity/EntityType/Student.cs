using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class Student
    {
        public Student()
        {
            this.UserID = Guid.NewGuid();
            this.IsDeleted = false;
        }

        [Key]
        [Required]
        public Guid UserID { get; set; }

        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        [MaxLength(300)]
        [Required]
        [Index("IX_Email", IsClustered = false, IsUnique = true)]
        public string Email { get; set; }

        [MaxLength(10)]
        [Required]
        [Index("IX_Mobile", IsClustered = false, IsUnique = true)]
        public string Mobile { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

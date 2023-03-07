using System.ComponentModel.DataAnnotations;

namespace Namaa_CRUD_Project.Models
{
    public class Users_Model
    {
        [Key]
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
}

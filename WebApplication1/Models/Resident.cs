using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormsTest.Models
{
    public class Resident
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [DisplayName("Name of person")]
        public string Name { get; set; }
    }
}

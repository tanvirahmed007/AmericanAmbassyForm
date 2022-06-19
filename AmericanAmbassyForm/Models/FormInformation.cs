
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericanAmbassyForm.Models
{
    [Table("FormInfo")]
    public class FormInformation
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }




        [Display(Name = "Given Name")]
        public string Name { get; set; }




        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Display(Name = "Age")]
        public int Age { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Contact Number")]
        public string Phone { get; set; }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Models
{
    public class StringsViewModel
    {
        [Display(Name = "Reference String")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Reference String cannot be empty.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Reference String cannot be more than 10 characters")]
        public string FirstString { get; set; }

        [Display(Name = "Hypotheses String")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hypotheses String cannot be empty.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Hypotheses String cannot be more than 10 characters")]
        public string SecondString { get; set; }
    }
}

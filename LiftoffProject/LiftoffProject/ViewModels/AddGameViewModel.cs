using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.ViewModels
{
    public class AddGameViewModel
    {
        [Required]
        [Display(Name = "Game Name")]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Models
{
    public class Game
    {
        [Required(ErrorMessage = "Please enter number")]
        public int Number { get; set; }
    }
}
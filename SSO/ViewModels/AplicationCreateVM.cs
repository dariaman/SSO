using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class AplicationCreateVM
    {
        [Key]
        public string Name { get; set; }
        public string Ket { get; set; }
    }
}

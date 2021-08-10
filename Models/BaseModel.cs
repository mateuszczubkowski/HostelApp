using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelApp.Models
{
    public class BaseModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
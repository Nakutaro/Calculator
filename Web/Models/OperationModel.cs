using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OperationModel
    {
        [DisplayName("Операция")]
        [Required]
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public object[] GetParameters()
        {
            return new object[] { X, Y };
        }
    }
}
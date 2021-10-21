using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class MedicineType:IEntity
    {
        public int Id { get; set; }
        public string TypeName{ get; set; }
        
    }
}

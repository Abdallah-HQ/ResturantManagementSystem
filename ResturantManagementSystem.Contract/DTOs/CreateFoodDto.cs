using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantManagementSystem.Contract.DTOs
{
    public class CreateFoodDto
    {
        public string Name { get; set; }
        public decimal Price{ get; set; }
    }
}

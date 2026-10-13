using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Dtos.TenantDto
{
    public class CreateTenantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
     //   public string isActive {  get; set; } = string.Empty;
    }
}

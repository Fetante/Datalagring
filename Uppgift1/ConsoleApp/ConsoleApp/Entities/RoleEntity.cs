using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities
{
    internal class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
    }
}

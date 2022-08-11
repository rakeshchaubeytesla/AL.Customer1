using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Effigy.DTOModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

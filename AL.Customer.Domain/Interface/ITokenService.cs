using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Interface
{
	public interface ITokenService
	{
		string CreateToken(string userName);
	}
}

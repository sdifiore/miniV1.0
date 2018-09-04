using miniV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniV1.Core
{
    public interface IEmail
    {
        Task SendAsync(Contato contato);
    }
}

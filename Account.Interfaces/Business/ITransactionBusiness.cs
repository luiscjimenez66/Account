using Account.DTO.Input;
using Account.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.Business
{
    public interface ITransactionBusiness
    {
        Task<OutTransactionDTO> save(InTransactionDTO transaction);
    }
}

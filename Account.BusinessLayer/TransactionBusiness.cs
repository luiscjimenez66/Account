using Account.BusinessLayer.Exception;
using Account.DTO.Input;
using Account.DTO.Output;
using Account.Interfaces.Business;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Account.BusinessLayer.Configuration;

namespace Account.BusinessLayer
{
    public class TransactionBusiness : ITransactionBusiness
    {
        public async Task<OutTransactionDTO> save(InTransactionDTO transaction)
        {
            OutTransactionDTO transactionOut = new OutTransactionDTO();

            switch ((eTransactionType)transaction.TransactionTypeId)
            {
                case eTransactionType.DEPOSIT:
                    transactionOut = ProcessDeposit(transaction);
                    break;
                case eTransactionType.WITHDRAW:
                    break;
                case eTransactionType.TRANSFER_MONEY:
                    break;

                default:
                    throw new BusinessException(string.Format("Transaction type {0} not found", transaction.TransactionTypeId), StatusCodes.Status400BadRequest);
            }

            return transactionOut;
        }

        private OutTransactionDTO ProcessDeposit(InTransactionDTO transaction)
        {
            OutTransactionDTO transactionOut = new OutTransactionDTO();

            return transactionOut;
        }
    }
}

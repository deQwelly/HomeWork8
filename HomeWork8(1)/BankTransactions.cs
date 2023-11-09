using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_1_
{
    public class BankTransactions
    {
        private DateTime dateTransaction;
        private double sumTransaction;

        public BankTransactions(double sumTransaction)
        {
            this.sumTransaction = sumTransaction;
            dateTransaction = DateTime.UtcNow;
        }

        public DateTime DateTransaction
        {
            get
            {
                return dateTransaction;
            }
        }

        public double SumTransaction
        {
            get
            {
                return sumTransaction;
            }
        }
    }
}

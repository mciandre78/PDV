using pdv.Models;
using pdv.Contracts;
using pdv.Services;
using System.Linq;
using System.Collections.Generic;
using pdv.Data;
using pdv.Enums;

namespace pdv.Repos
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly DataContext _DbContext;

        public BillRepository(DataContext context) : base(context)
        {
            this._DbContext = context;
        }

        private void FillBillsData()
        {
            if (this._DbContext.Bills.Any())
                return;

            this._DbContext.Bills.AddRange(
                new Bill
                {
                    Description = "100 Reais",
                    EBillType = EnumBillType.EBillType.Bill,
                    Value = 100
                },
                new Bill
                {
                    Description = "50 Reais",
                    EBillType = EnumBillType.EBillType.Bill,
                    Value = 50
                },
                new Bill
                {
                    Description = "20 Reais",
                    EBillType = EnumBillType.EBillType.Bill,
                    Value = 20
                },
                new Bill
                {
                    Description = "10 Reais",
                    EBillType = EnumBillType.EBillType.Bill,
                    Value = 10
                },
                new Bill
                {
                    Description = "50 Centavos",
                    EBillType = EnumBillType.EBillType.Coin,
                    Value = (decimal)0.5
                },
                new Bill
                {
                    Description = "10 Centavos",
                    EBillType = EnumBillType.EBillType.Coin,
                    Value = (decimal)0.10
                },
                new Bill
                {
                    Description = "5 Centavos",
                    EBillType = EnumBillType.EBillType.Coin,
                    Value = (decimal)0.05
                },
                new Bill
                {
                    Description = "1 Centavo",
                    EBillType = EnumBillType.EBillType.Coin,
                    Value = (decimal)0.01
                }
                );

            this._DbContext.SaveChanges();
        }

        public List<Bill> CalculateChange(Pdv pdv)
        {

            FillBillsData();
            decimal price = pdv.Price;
            decimal amount = pdv.AmountPaid;
            decimal change = amount - price;

            List<Bill> lBills = (from b in this._DbContext.Bills
                                 select b)
                                  .OrderByDescending(x => x.Value)
                                  .ToList();

            foreach (Bill bill in lBills)
            {
                if (change >= bill.Value)
                {
                    bill.Quantity = (int)(change / bill.Value);
                    change -= bill.Quantity * bill.Value;
                }

                if (change == 0) break;
            }

            return lBills;
        }
    }
}

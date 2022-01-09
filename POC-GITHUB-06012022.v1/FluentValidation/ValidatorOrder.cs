using FluentValidation;
using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Validator
{
    public class ValidatorOrder : AbstractValidator<Order>
    {

        public ValidatorOrder()
        {
            //Order
            RuleFor(x=> x.IdCustomer).NotEqual(x=> 0);
            RuleFor(x => x.IdTypePayment).NotEqual(x => 0);
            RuleFor(x => x.IdTypeDelivery).NotEqual(x => 0);
            RuleFor(x => x.IdAddressDelivery).NotEqual(x => 0);
        }
    }
}

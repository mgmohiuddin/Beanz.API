using Beanz.Domain.Common;
//using Beanz.Domain.SupplyChainManagment.Masters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beanz.WebAPI.Validations
{
    public class BrandValidations : AbstractValidator<BeanzCommonDTO>
    {
        public BrandValidations()
        {            
            RuleFor(x => x)
            .Must(CheckScreens).WithMessage("Does not have Screen Role");
            //RuleFor(x => x.BrandAlias).NotEmpty();           
        }
        private bool CheckScreens(BeanzCommonDTO arg)
        {

            if (arg.ScreenID=="10")
            {
                if(arg.UserID==1)
                {
                    return false;
                }
                return false;
            }
            return true;
            

        }
    }
}

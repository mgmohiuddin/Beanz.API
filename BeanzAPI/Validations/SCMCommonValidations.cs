using Beanz.Domain.Common;
//using Beanz.Domain.SupplyChainManagment.Masters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beanz.WebAPI.Validations
{
    public class SCMCommonValidations : AbstractValidator<BeanzCommonDTO>
    {
        public SCMCommonValidations()
        {
            RuleFor(x => x)
            .Must(CheckScreens).WithMessage("Does not have Screen Role");
           // .Must(CheckDepartment).WithMessage("Does not belong to department");
            ////var person = new BrandDTO();
            ////var context = new ValidationContext<BeanzCommonDTO>(person);
            ////context.RootContextData["screenID"] = "Brands";
            ////var validator = new SCMCommonValidations();
            ////validator.Validate(context);
            //RuleFor(x => x.screenID).Equal("Brands").DependentRules(() => {
            //    RuleFor(x => x.PrimaryKeyID).NotNull();
            //});

            //RuleFor(x => x.screenID).Equal("Barcodes").DependentRules(() => {
            //    RuleFor(x => x.PrimaryKeyID).NotNull();
            //});
            ////RuleFor(x => x.screenID).Custom((x, context) =>
            ////{
            ////    if (context.RootContextData.ContainsKey("MyCustomData"))
            ////    {
            ////        context.AddFailure("My error message");
            ////    }
            ////});
            ////var validator = new SCMCommonValidations();
            ////var scmcommon = new BeanzCommonDTO();


            ////RuleFor(x => x.screenID)
            ////    .Equal("Brands");
            ////    {
            ////    RuleFor(x => x.PrimaryKeyID)
            ////    .NotEmpty();
            ////    };
            ////RuleFor(x => x.screenID)
            ////    .NotEqual("Brands");
        }

        private bool CheckScreens(BeanzCommonDTO arg)
        {
            if (((BeanzCommonDTO)arg).ScreenID == "Brands")
            {
                string brand = ((BeanzCommonDTO)arg).Json;
                if (brand !=null)
                {
                    arg.PrimaryKeyID = 2;
                    BrandDTO Brands = new BrandDTO();
                    Brands =  Newtonsoft.Json.JsonConvert.DeserializeObject<BrandDTO>(brand);
                    //BrandValidations validationRules = new BrandValidations();
                    //validationRules.RuleFor(x => x);                     
                    return false;
                }
                else
                {
                    arg.PrimaryKeyID = 2;
                    return true;
                }
            }
            else
                return false;

        }
    }
}
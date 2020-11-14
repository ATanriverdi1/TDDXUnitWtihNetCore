using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddBlogDevto.Entity;

namespace TddBlogDevto.Validations
{
    public class PostUserValidator : AbstractValidator<User>
    {
        public PostUserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithErrorCode("100")
                .MaximumLength(20)
                .WithErrorCode("101");
        }
    }
}

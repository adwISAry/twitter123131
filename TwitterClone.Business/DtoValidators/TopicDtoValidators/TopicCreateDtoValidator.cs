using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.TopicDtos;

namespace TwitterClone.Business.DtoValidators.TopicDtoValidators
{
    public class TopicCreateDtoValidator : AbstractValidator<TopicCreateDto>
    {
        public TopicCreateDtoValidator()
        {
            RuleFor(table => table.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(32);
        }
    }
}

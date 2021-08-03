using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    internal class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator()
        {
        }
    }
}
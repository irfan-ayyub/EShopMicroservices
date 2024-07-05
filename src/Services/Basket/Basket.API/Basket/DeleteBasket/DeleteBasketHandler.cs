namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteCommandResult>;
    public record DeleteCommandResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }


    public class DeleteBasketHandler
        (IBasketRepository repository)
        : ICommandHandler<DeleteBasketCommand, DeleteCommandResult>
    {
        public async Task<DeleteCommandResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(command.UserName, cancellationToken);

            return new DeleteCommandResult(true);
        }
    }
}

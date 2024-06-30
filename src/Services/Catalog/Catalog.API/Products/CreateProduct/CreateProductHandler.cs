
namespace Catalog.API.Products.CreateProduct
{
    // data we need to create new product
    public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
        ) : ICommand<CreateProductResult>;

    // response object, in this case Id
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // return result
            return new CreateProductResult(product.Id);
        }
    }
}

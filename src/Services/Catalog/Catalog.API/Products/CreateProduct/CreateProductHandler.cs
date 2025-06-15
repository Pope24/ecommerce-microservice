using BuildingBlocks.CQRS;
using Catalog.API.Entities;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, string ImageFile, decimal Price, List<string> Categories) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Categories = command.Categories
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}

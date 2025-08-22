using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Products.Commands.ProductCommands;

public sealed record UpdateProductPriceCommand(
    int Id,
    decimal Price
);

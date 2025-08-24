namespace Domain.Shadred.Helpers;

public static class DomainErrors
{
    #region Shared

    public const string NotFoundEntity = "Can't find Any {0} by given Id!";

    #endregion

    #region Products

    public const string ProductPriceLessThanOrEqualToZero = "Price of a product can not be less than or equal to zero";

    #endregion
}
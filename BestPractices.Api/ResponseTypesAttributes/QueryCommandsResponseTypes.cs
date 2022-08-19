using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.ResponseTypesAttributes
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class QueryCommandsResponseTypes : Attribute
    {
    }
}

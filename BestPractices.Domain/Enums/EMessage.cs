using System.ComponentModel;

namespace BestPractices.Domain.Enums
{
    public enum EMessage
    {
        [Description("{0} need to be filled")]
        Required,

        [Description("Field {0} allows {1} chars")]
        MoreExpected,

        [Description("{0} not found")]
        NotFound,

        [Description("Invalid Format")]
        InvalidFormat,

        [Description("{0} age has to be greater than 18 years")]
        InvalidAge,
        
        [Description("An unexpected error happened")]
        UnexpectedError,

        [Description("Invalid Credencials")]
        InvalidCredencials
    }
}

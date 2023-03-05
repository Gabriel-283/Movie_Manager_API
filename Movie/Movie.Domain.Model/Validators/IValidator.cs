using MovieAPI.Models;

namespace MovieAPI.Data.ValidatorsInterfaces
{
    public interface IValidator <T>
    {
        void ValidateRequest(T objectToValidate);
    }
}

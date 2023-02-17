using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApiStore.Tools
{
    public static class ToolResponse
    {
        public static ObjectResult responseOk(object response)
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
        }

        public static ObjectResult responseCreated(object response)
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        public static ObjectResult responseAccepted(object response)
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status202Accepted };
        }

        public static ActionResult responseNotFound(string response)
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status404NotFound };
        }

        public static ObjectResult responseServerError(string response = "El servidor no está disponible para procesar esta solicitud. Intenta más tarde.")
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
        }

        public static ObjectResult responseBadRequest(List<ValidationResult> response)
        {
            return new ObjectResult(response) { StatusCode = StatusCodes.Status400BadRequest };
        }

        public static IActionResult responseNoContent()
        {
            return new NoContentResult();
        }

        internal static ActionResult responseBadRequest(List<object> result)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Infrastucture.Controller
{

    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediatR = null;
        protected IMediator MediatR => _mediatR ?? (_mediatR = HttpContext.RequestServices.GetRequiredService<IMediator>());
    }
}

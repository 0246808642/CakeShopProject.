using CakeShopProject.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace CakeShopProject.WebApi.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
    }
}

using AplicationProgrammingInterface.Clases;
using AplicationProgrammingInterface.Controllers;
using DataAccess.EFCore.UnitOfWorks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnitTesting
{
    public class ClienteTesting 
    {


        private readonly DbContextOptions<PichinchaContext> _dbContextOptions;
        private readonly PichinchaContext _context;
        private readonly ClienteController _controller;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteTesting()
        {
            var builder = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            _dbContextOptions = new DbContextOptionsBuilder<PichinchaContext>()
               .UseSqlServer(builder)
               .Options;

            _context = new PichinchaContext();
            _unitOfWork = new UnitOfWorks(_context);
            _controller = new ClienteController(_unitOfWork);
        }

      

        [Fact]
        public void GetAllClientes_Ok()
        {  
            var result = _controller.GetAllClientes();
             Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetClientesbyId_Exist()
        {
            var id = "e4d7f177-95e4-4c7f-9178-3bd9b4725121";
            var result = (OkObjectResult)_controller.GetClientebyId(id);
            Assert.NotNull(result);

            //var  cliente = Assert.IsType<Cliente>(result.Value);
            //Assert.Equal(cliente?.Id, new Guid(id));

        }

        [Fact]
        public void RegistrarCliente_FailValidation()
        {

            var nuevo_cliente = new ObjCliente();  

            var result = _controller.RegistrarCliente(nuevo_cliente);
            Assert.IsNotType<OkObjectResult>(result);

        }

    }
}
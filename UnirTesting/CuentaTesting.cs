using AplicationProgrammingInterface.Clases;
using AplicationProgrammingInterface.Controllers;
using DataAccess.EFCore.UnitOfWorks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class CuentaTesting
    {
        private readonly DbContextOptions<PichinchaContext> _dbContextOptions;
        private readonly PichinchaContext _context;
        private readonly CuentaController _controller;
        private readonly IUnitOfWork _unitOfWork;


        public CuentaTesting()
        {
            var builder = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            _dbContextOptions = new DbContextOptionsBuilder<PichinchaContext>()
               .UseSqlServer(builder)
               .Options;

            _context = new PichinchaContext();
            _unitOfWork = new UnitOfWorks(_context);
            _controller = new CuentaController(_unitOfWork);
        }


        [Fact]
        public void RegistrarCuenta_FailValidation()
        {

            var nueva_cuenta= new ObjCuenta();

            var result = _controller.RegistrarCuenta(nueva_cuenta);
            Assert.IsNotType<OkObjectResult>(result);

        }


    }
}

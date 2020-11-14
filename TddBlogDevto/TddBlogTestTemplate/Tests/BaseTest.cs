using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TddBlogDevto.Entity.Repository;
using Xunit;

namespace TddBlogTestTemplate
{
    public class BaseTest
    {
        protected ApplicationDbContext _context;

        public BaseTest(ApplicationDbContext context = null)
        {
            this._context = context ?? GetInMemoryDbContext();
        }

        protected ApplicationDbContext GetInMemoryDbContext()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            ApplicationDbContext dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        protected void CheckError<T>(AbstractValidator<T> validator, int errorCode, T vm)
        {
            var val = validator.Validate(vm);
            Assert.False(val.IsValid);

            if (!val.IsValid)
            {
                bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(errorCode.ToString()));
                Assert.True(hasError);
            }
        }
    }
}

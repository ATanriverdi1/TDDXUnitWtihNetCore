using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TddBlogDevto.Controllers;
using TddBlogDevto.Entity;
using TddBlogDevto.Entity.Repository;
using TddBlogDevto.Validations;
using Xunit;

namespace TddBlogTestTemplate
{
   public class PostTest : BaseTest
    {
        #region THEORY
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        //[InlineData("Alihan Tanrıverdi")]
        //public void Theory_PostUser_Name_NoValidation(string Name)
        //{
        //    var user = new User
        //    {
        //        Name = Name
        //    };
        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);
        //}

        //[Theory]
        //[InlineData(null,100)]
        //[InlineData("", 100)]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZwwewq", 101)]
        //[InlineData("Alihan Tanrıverdi", 101)]
        //public void Theory_PostUser_Name_Validation(string name, int errorCode)
        //{
        //    var user = new User
        //    {
        //        Name = name
        //    };
        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);

        //    if (!val.IsValid)
        //    {
        //        bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(errorCode.ToString()));
        //        Assert.True(hasError);
        //    }
        //}

        [Theory]
        [InlineData(null, 100)]
        [InlineData("", 100)]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZwwewq", 101)]
        [InlineData("Alihan Tanrıverdi", 101)]
        public void Theory_PostUser_Name(string name, int errorCode)
        {
            var user = new User
            {
                Name = name
            };
            CheckError(new PostUserValidator(), errorCode, user);
        }

        #endregion
        #region FACT
        //[Fact]
        //public void Fact_Post_NoModelNoRepository()
        //{
        //    var user = new User("Alihan Tanrıverdi", 22, true);

        //    context.User.Add(user);
        //    context.SaveChanges();

        //    Assert.Equal(1, user.Id);
        //}

        [Fact]
        public void Fact_Post_NoRepository()
        {
            var user = new User(0,"Alihan Tanrıverdi", 22, true);

            user = new UserRepository(_context).Post(user);

            Assert.Equal(1, user.Id);
        }
        #endregion
    }
}

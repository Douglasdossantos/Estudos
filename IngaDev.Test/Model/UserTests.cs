using IngaDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaDev.Test.Model
{
    public class UserTests
    {
        [Theory]
        [InlineData("123456")]
        [InlineData("minhasenhafavorita")]
        public void User_Verify_Password( string password) 
        {
            //arrange
            var user = new User { Password = password };
            //act
            var verifild = user.VerifyPassword(password);
            // assert
            Assert.True(verifild);
        }
    }
}

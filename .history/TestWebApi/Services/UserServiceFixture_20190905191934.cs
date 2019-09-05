using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using WebApi1.Data;
using WebApi1.Models;

namespace TestWebApi.Data
{
    public class UserServiceFixture
    {
        [Fact]
        public void Test_GetSingle_Returns_NullAndStatus300_On_NegativeId()
        {
            
        }
        [Fact]
        public void Test_GetSingle_Returns_NullAndStatus400_On_UnAvailableData()
        {
            
        }
        [Fact]
        public void Test_GetList_Returns_ListOfFiveElements_On_Call()
        {
            
        }
        [Fact]
        public void Test_GetList_Returns_NullAndStatus103_On_AgeBelow18()
        {
            
        }

    }
}

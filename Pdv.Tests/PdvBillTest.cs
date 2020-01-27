using Xunit;
using pdv.Repos;
using pdv.Contracts;
using pdv.Data;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using pdv.Services;
using pdv.Models;
using Moq;

namespace pdv.Tests
{
    public class PdvBillTest 
    {
        
        [Fact]
        public void BillTestAsync() 
        {
            var pdvMock = new Mock<PdvRepository>();
            var contextMock = new Mock<DataContext>();            
            pdvMock.Setup(x => x.Add(new Pdv { 
                                               Id=1,
                                               AmountPaid=1100, 
                                               Description="PDV xUnit", 
                                               Price=1000 
            }));

            var result = pdvMock.Object;
            var pdvDetails = result.GetById(1);
            Assert.NotNull(pdvDetails);
        }
    }
}

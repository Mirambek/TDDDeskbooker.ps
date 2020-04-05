using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            _processor = new DeskBookingRequestProcessor();
        }
        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            //Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "M",
                LastName = "N",
                Email = "n.mirambek@gmail.com",
                Date = new DateTime(2020, 4, 5)
            };
            _processor.BookDesk(request);
            //Act
            DeskBookingResult result = _processor.BookDesk(request);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }
        
        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}

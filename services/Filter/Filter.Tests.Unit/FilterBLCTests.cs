using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace Filter
{
    public class FilterBLCTests
    {
        private Mock<IFilterDAO> _mockDAO;
        private FilterBLC _blc;

        public FilterBLCTests()
        {
            _mockDAO = new Mock<IFilterDAO>();
            _blc = new FilterBLC(_mockDAO.Object);
        }

        [Fact]
        public void GetFilter_ReturnsFilter()
        {
            _mockDAO.Setup(m => m.GetFilter(It.IsAny<int>())).Returns(new Filter());

            var result = _blc.GetFilter(new UserFilter());

            Assert.NotNull(result);
        }
    }
}
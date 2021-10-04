using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataMunging
{
    public class WheatherTests
    {
        [Fact]
        public void Should_get_dayNumber_from_row()
        {
            var row = "   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5";
            var lines = new List<string> {row};

            var sut = new Weather();

            var expected = 1;

            var result = sut.GetDayWithMinimumSpread(lines);

            Assert.Equal(expected, result);

        }

        [Fact]
        public void Should_get_minimumSpread_from_twoRows()
        {
            var lines = new List<string>
            {
                "   1  10    1    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5",
                "   2  10    2    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5",
            };

            var sut = new Weather();

            var expected = 2;

            var result = sut.GetDayWithMinimumSpread(lines);

            Assert.Equal(expected, result);

        }

        [Fact]
        public void Should_get_minimumSpread_from_twoRowsWithStar()
        {
            var lines = new List<string>
            {
                "   1  10    1    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5",
                "   2*  10*    2*    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5",
            };

            var sut = new Weather();

            var expected = 2;

            var result = sut.GetDayWithMinimumSpread(lines);

            Assert.Equal(expected, result);

        }

        [Fact]
        public void Should_ignoreHeader()
        {
            var lines = new List<string>
            {
                "     Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP",
                "   2*  10*    2*    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5",
            };

            var sut = new Weather();

            var expected = 2;

            var result = sut.GetDayWithMinimumSpread(lines);

            Assert.Equal(expected, result);

        }
    }
}
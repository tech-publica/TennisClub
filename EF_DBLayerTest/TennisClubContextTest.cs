using EF_DBLayer;
using System;
using TennisClubModel;
using Xunit;

namespace EF_DBLayerTest
{
    public class TennisClubContextTest
    {
        [Fact]
        public void TestContextCreation()
        {
            using (var ctx = TennisClubContext.CreateContext())
            { }
        }

        [Fact]
        public void TestDiifferentCourtInsertion()
        {
            using (var ctx = TennisClubContext.CreateContext())
            {
                Court tennisCourt = new TennisCourt
                {
                    Length = 25,
                    Width = 8,
                    HasRoof = true,
                    HourlyCourtCost = 5,
                    HourlyIlluminationCost = 1
                };

                Court padelCourt = new PadelCourt
                {
                    Length = 25,
                    Width = 8,
                    HasRoof = true,
                    HourlyCourtCost = 5,
                    HourlyIlluminationCost = 1
                };

                ctx.Add(tennisCourt);
                ctx.Add(padelCourt);
                ctx.SaveChanges();
            }
        }
    }
}


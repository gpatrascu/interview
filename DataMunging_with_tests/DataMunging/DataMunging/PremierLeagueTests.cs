using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace DataMunging
{
    public class PremierLeagueTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PremierLeague premierLeague = new PremierLeague();

        public PremierLeagueTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
    }
}
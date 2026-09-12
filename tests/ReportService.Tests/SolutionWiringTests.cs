using System.Reflection;

namespace ReportService.Tests;

public class SolutionWiringTests
{
    [Fact]
    public void TestProjectLoadsApiAssembly()
    {
        var apiAssembly = Assembly.Load("ReportService.Api");

        Assert.NotNull(apiAssembly);
    }
}

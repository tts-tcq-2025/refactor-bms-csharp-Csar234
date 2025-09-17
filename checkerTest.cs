using Xunit;

public class CheckerTests
{
    [Fact]
    public void TemperatureTooHighIsNotOk()
    {
        Assert.False(Checker.VitalsOkSilent(103f, 70, 95));
    }

    [Fact]
    public void TemperatureTooLowIsNotOk()
    {
        Assert.False(Checker.VitalsOkSilent(94f, 70, 95));
    }

    [Fact]
    public void PulseTooHighIsNotOk()
    {
        Assert.False(Checker.VitalsOkSilent(98f, 120, 95));
    }

    [Fact]
    public void PulseTooLowIsNotOk()
    {
        Assert.False(Checker.VitalsOkSilent(98f, 50, 95));
    }

    [Fact]
    public void Spo2TooLowIsNotOk()
    {
        Assert.False(Checker.VitalsOkSilent(98f, 70, 85));
    }

    [Fact]
    public void AllVitalsOkWithinRange()
    {
        Assert.True(Checker.VitalsOkSilent(98.1f, 70, 95));
    }

    [Fact]
    public void BoundaryValuesAreStillOk()
    {
        Assert.True(Checker.VitalsOkSilent(95f, 60, 90));
        Assert.True(Checker.VitalsOkSilent(102f, 100, 90));
    }
}

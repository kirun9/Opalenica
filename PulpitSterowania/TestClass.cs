namespace PulpitSterowania;

using Pulpit.Logger;
using Pulpit.Module;

[Service]
public class TestClass
{
    public ILogger logger { get; set; }

    public int InstanceNumber { get; private set; }

    public int SomeValue { get; set; } = 10;

    public TestClass(ILogger logger)
    {
        InstanceNumber++;
        this.logger = logger;
    }

    public void DoSomething()
    {
        logger.Log("Something from Instance ID: " + InstanceNumber);
        logger.Log("Some Value: " + SomeValue);
    }
}
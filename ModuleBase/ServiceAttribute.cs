namespace Pulpit.Module;

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ServiceAttribute : Attribute
{
    public Type? BaseInterface { get; private set; }

    public ServiceType ServiceType { get; private set; }

    public ServiceAttribute(Type baseInterface, ServiceType serviceType = ServiceType.Singleton)
    {
        BaseInterface = baseInterface;
        ServiceType = serviceType;
    }

    public ServiceAttribute(ServiceType serviceType = ServiceType.Singleton)
    {
        ServiceType = serviceType;
    }
}

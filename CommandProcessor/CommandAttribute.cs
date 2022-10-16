namespace CommandProcessor;

[System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
public sealed class RegisterCommandAttribute : Attribute {
    public string Name { get; set; }
    public bool NeedConfirm { get; set; }

    public RegisterCommandAttribute(String name, Boolean needConfirm) {
        Name = name;
        NeedConfirm = needConfirm;
    }
}
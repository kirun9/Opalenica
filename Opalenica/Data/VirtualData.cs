namespace Opalenica;

public class VirtualData : Data
{
    private VirtualData() { }

    public static VirtualData GetData(string Id)
    {
        var data = DataList.FirstOrDefault(x => x.Name == Id);
        if (data is not null and VirtualData vdata) return vdata;
        VirtualData v = new VirtualData();
        v.Name = Id;
        v.DisplayName = "V " + Id;
        v.Direction = DataDirection.InputOutput;
        DataList.Add(v);
        return v;
    }
}

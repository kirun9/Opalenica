namespace Opalenica;

using CommandProcessor;

using Timer = System.Windows.Forms.Timer;

public partial class OpalenicaForm : Form
{
    /*private List<string> prevCommands = new List<string>(new string[] { "" });
    private int prevCommandPos = 0;*/
    private Timer updateTimer;

    public static Screen actualScreen;

    public OpalenicaForm()
    {
        InitializeComponent();
        updateTimer = new Timer() { Interval = 100, Enabled = true };
        updateTimer.Tick += new EventHandler(UpdateTimer_Tick);
#if DEBUG
        //CommandProcessor.ExecuteCommand("debugmode");
#endif
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        CommandProcessor.ExecuteCommand(Program.startupCommands);
        if (SerialManager.Instance.IsConfigured)
        {
            CommandProcessor.ExecuteCommand("serial start");
        }
    }

    private void UpdateTimer_Tick(Object? sender, EventArgs e)
    {
        Invalidate(true);
    }

    private void OpalenicaForm_Load(object sender, EventArgs e)
    {
        //this.WindowState = FormWindowState.Maximized;
        updateTimer.Enabled = true;
        actualScreen = (Screen.AllScreens.Where((e) => !e.Primary).FirstOrDefault() ?? Screen.PrimaryScreen);
        var location = actualScreen.WorkingArea.Location;
        var dimensions = actualScreen.WorkingArea.Size;
        this.Location = new Point(location.X + (dimensions.Width - this.Width) / 2, location.Y + (dimensions.Height - this.Height) / 2);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        CommandProcessor.ExecuteCommand("exit");
    }

    private void Pulpit1_KeyDown(Object sender, KeyEventArgs e)
    {
        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    private void CommandTextBox_KeyDown(Object sender, KeyEventArgs e)
    {
    }
}

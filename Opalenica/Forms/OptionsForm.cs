namespace Opalenica.Forms;

using CustomUIDesign;

using Opalenica.Forms.Settings;

using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class OptionsForm : ResizableForm
{
    public List<Tab> SettingsTabs = new List<Tab>();
    private int firstTabIndex = 0;

    public OptionsForm()
    {
        SettingsTabs = new List<Tab>()
        {
            new Tab("Ogólne", new GeneralSettingsControl()) { Selected = true },
            new Tab("Port", new SerialSettingsControl()),
            new Tab("Semafory", new SemSettingsControl()),
            new Tab("Rozjazdy", new JuncSettingsControl()),
            new Tab("Tory", new TrackSettingsControl()),
            new Tab("Blokady", new LBSettingsControl()),
        };

        InitializeComponent();
        SuspendLayout();
        this.DragControls = new Collection<Control>() { this.TopPanel, this.Title };
        foreach (var tab in SettingsTabs)
        {
            tab.Button = GetTabButton(tab.Name);
        }
        CalculateTabs();
        ShowTab(SettingsTabs[0].Name);
        ResumeLayout(false);
    }

    private void CalculateTabs()
    {
        if (firstTabIndex >= SettingsTabs.Count) throw new ArgumentOutOfRangeException(nameof(firstTabIndex));
        TabFlowPanel.Controls.Clear();
        bool breakOccured = false;
        foreach (var tab in SettingsTabs.Skip(firstTabIndex))
        {
            TabFlowPanel.Controls.Add(tab.Button);
            if (tab.Button.Bounds.Right > TabFlowPanel.Bounds.Right)
            {
                RightButton.Visible = true;
                LeftButton.Visible = true;
                breakOccured = true;
                break;
            }
        }
        if (!breakOccured)
        {
            RightButton.Enabled = false;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using Pen pen = new Pen(Colors.White, 3);
        pen.Alignment = PenAlignment.Inset;
        e.Graphics.DrawRectangle(pen, ClientRectangle);
        base.OnPaint(e);
    }

    private void ShowTab(string name)
    {
        foreach (var tab in SettingsTabs)
        {
            if (tab.Selected)
            {
                ContentPanel.Controls.Remove(tab.Control);
                tab.Button.Selected = tab.Selected = false;
                break;
            }
        }

        foreach (var tab in SettingsTabs)
        {
            if (tab.Name == name)
            {
                tab.Button.Selected = tab.Selected = true;
                ContentPanel.Controls.Add(tab.Control);
            }
        }
    }

    public TabButton GetTabButton(string name)
    {
        var button = new TabButton(name);
        button.Click += (_, _) => { ShowTab(name); };
        return button;
    }

    private void RightButton_Click(object sender, EventArgs e)
    {
        if (firstTabIndex < SettingsTabs.Count - 1)
        {
            firstTabIndex++;
            LeftButton.Enabled = true;
            CalculateTabs();
        }
        if (firstTabIndex == SettingsTabs.Count - 1)
            RightButton.Enabled = false;
    }

    private void LeftButton_Click(object sender, EventArgs e)
    {
        if (firstTabIndex > 0)
        {
            firstTabIndex -= 1;
            RightButton.Enabled = true;
            CalculateTabs();
        }
        if (firstTabIndex is 0)
            LeftButton.Enabled = false;
    }
}
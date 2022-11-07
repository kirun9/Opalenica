namespace Opalenica.Forms;

using CustomUIDesign;

using Opalenica.Forms.Settings;

using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using static System.ComponentModel.Design.ObjectSelectorEditor;

public partial class OptionsForm : ResizableForm
{
    public List<Tab> SettingsTabs = new List<Tab>();
    private int firstTabIndex = 0;

    public OptionsForm()
    {
        SettingsTabs = new List<Tab>()
        {
            new Tab("Ogólne", new GeneralSettingsControl()) { Selected = true },
            new Tab("Port", new GeneralSettingsControl()),
            new Tab("Semafory", new GeneralSettingsControl()),
            new Tab("Rozjazdy", new GeneralSettingsControl()),
            new Tab("Tory", new GeneralSettingsControl()),
            new Tab("Blokady", new GeneralSettingsControl()),
            // For test purposes
            new Tab("Ogólne2", new GeneralSettingsControl()),
            new Tab("Semafory2", new GeneralSettingsControl()),
            new Tab("Rozjazdy2", new GeneralSettingsControl()),
            new Tab("Tory2", new GeneralSettingsControl()),
            new Tab("Blokady2", new GeneralSettingsControl()),
        };

        InitializeComponent();
        SuspendLayout();
        this.DragControls = new Collection<Control>() { this.TopPanel, this.Title };
        foreach (var tab in SettingsTabs)
        {
            tab.Button = GetTabButton(tab.Name, tab.Selected);
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
                tab.Selected = false;
                SetButtonBackColor(tab.Button, false);
                break;
            }
        }

        foreach (var tab in SettingsTabs)
        {
            if (tab.Name == name)
            {
                tab.Selected = true;
                SetButtonBackColor(tab.Button, true);
                ContentPanel.Controls.Add(tab.Control);
            }
        }
    }

    private void SetButtonBackColor(Button button, bool selected)
    {
        button.BackColor = selected ? ControlPaint.Dark(Colors.Blue) : Colors.Black;
    }

    public ButtonWithoutPadding GetTabButton(string name, bool selected)
    {
        var button = new ButtonWithoutPadding();
        button.Text = name;

        button.AutoSize = true;
        button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        button.BackColor = selected ? ControlPaint.Dark(Colors.Blue) : Colors.Black;
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseDownBackColor = ControlPaint.Light(button.BackColor);
        button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(button.BackColor);
        button.FlatStyle = FlatStyle.Flat;
        button.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        button.ForeColor = Color.White;
        button.Location = new Point(3, 3);
        button.MaximumSize = new Size(0, 20);
        button.Size = new Size(57, 20);
        button.TabIndex = 6;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.UseVisualStyleBackColor = true;

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
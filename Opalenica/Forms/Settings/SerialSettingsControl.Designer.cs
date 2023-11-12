namespace Opalenica.Forms.Settings;

using CustomUIDesign;

partial class SerialSettingsControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        PortComboBox = new ComboBox();
        PortLabel = new Label();
        BaudComboBox = new ComboBox();
        BaudLabel = new Label();
        RestartButton = new ButtonWithoutPadding();
        StartButton = new ButtonWithoutPadding();
        SaveButton = new ButtonWithoutPadding();
        ConnectionStatusLabel = new Label();
        ConnectionLed = new RoundControlLED();
        SuspendLayout();
        // 
        // PortComboBox
        // 
        PortComboBox.AccessibleRole = AccessibleRole.ComboBox;
        PortComboBox.BackColor = Color.Black;
        PortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        PortComboBox.FlatStyle = FlatStyle.Flat;
        PortComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        PortComboBox.ForeColor = Color.White;
        PortComboBox.Location = new Point(217, 107);
        PortComboBox.Name = "PortComboBox";
        PortComboBox.Size = new Size(121, 25);
        PortComboBox.TabIndex = 11;
        // 
        // PortLabel
        // 
        PortLabel.AccessibleRole = AccessibleRole.StaticText;
        PortLabel.AutoSize = true;
        PortLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        PortLabel.Location = new Point(68, 110);
        PortLabel.Name = "PortLabel";
        PortLabel.Size = new Size(34, 19);
        PortLabel.TabIndex = 10;
        PortLabel.Text = "Port";
        // 
        // BaudComboBox
        // 
        BaudComboBox.AccessibleRole = AccessibleRole.ComboBox;
        BaudComboBox.BackColor = Color.Black;
        BaudComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        BaudComboBox.FlatStyle = FlatStyle.Flat;
        BaudComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        BaudComboBox.ForeColor = Color.White;
        BaudComboBox.Location = new Point(217, 70);
        BaudComboBox.Name = "BaudComboBox";
        BaudComboBox.Size = new Size(121, 25);
        BaudComboBox.TabIndex = 9;
        // 
        // BaudLabel
        // 
        BaudLabel.AccessibleRole = AccessibleRole.StaticText;
        BaudLabel.AutoSize = true;
        BaudLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        BaudLabel.Location = new Point(68, 73);
        BaudLabel.Name = "BaudLabel";
        BaudLabel.Size = new Size(64, 19);
        BaudLabel.TabIndex = 8;
        BaudLabel.Text = "Szybkość";
        // 
        // RestartButton
        // 
        RestartButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        RestartButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        RestartButton.FlatStyle = FlatStyle.Flat;
        RestartButton.Location = new Point(68, 175);
        RestartButton.Name = "RestartButton";
        RestartButton.Size = new Size(118, 23);
        RestartButton.TabIndex = 12;
        RestartButton.Text = "Zrestartuj połączenie";
        RestartButton.UseVisualStyleBackColor = true;
        RestartButton.Click += RestartButton_Click;
        // 
        // StartButton
        // 
        StartButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        StartButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        StartButton.FlatStyle = FlatStyle.Flat;
        StartButton.Location = new Point(217, 175);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(121, 23);
        StartButton.TabIndex = 13;
        StartButton.Text = "Uruchom połączenie";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        SaveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        SaveButton.FlatStyle = FlatStyle.Flat;
        SaveButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        SaveButton.Location = new Point(702, 334);
        SaveButton.Margin = new Padding(6);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(101, 29);
        SaveButton.TabIndex = 14;
        SaveButton.Text = "Zapisz";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // ConnectionStatusLabel
        // 
        ConnectionStatusLabel.AccessibleRole = AccessibleRole.StaticText;
        ConnectionStatusLabel.AutoSize = true;
        ConnectionStatusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ConnectionStatusLabel.Location = new Point(68, 227);
        ConnectionStatusLabel.Name = "ConnectionStatusLabel";
        ConnectionStatusLabel.Size = new Size(114, 19);
        ConnectionStatusLabel.TabIndex = 16;
        ConnectionStatusLabel.Text = "Status Połączenia";
        // 
        // ConnectionLed
        // 
        ConnectionLed.LEDColors = new Color[] { Color.Gray, Color.Red, Color.FromArgb(0, 192, 0), Color.Blue };
        ConnectionLed.Location = new Point(217, 227);
        ConnectionLed.Name = "ConnectionLed";
        ConnectionLed.Size = new Size(30, 30);
        ConnectionLed.TabIndex = 17;
        ConnectionLed.Text = "roundControlled1";
        // 
        // SerialSettingsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        Controls.Add(ConnectionLed);
        Controls.Add(ConnectionStatusLabel);
        Controls.Add(SaveButton);
        Controls.Add(StartButton);
        Controls.Add(RestartButton);
        Controls.Add(PortComboBox);
        Controls.Add(PortLabel);
        Controls.Add(BaudComboBox);
        Controls.Add(BaudLabel);
        ForeColor = Color.White;
        Name = "SerialSettingsControl";
        Size = new Size(809, 369);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox PortComboBox;
    private Label PortLabel;
    private ComboBox BaudComboBox;
    private Label BaudLabel;
    private ButtonWithoutPadding RestartButton;
    private ButtonWithoutPadding StartButton;
    private ButtonWithoutPadding SaveButton;
    private Label ConnectionStatusLabel;
    private RoundControlLED ConnectionLed;
}

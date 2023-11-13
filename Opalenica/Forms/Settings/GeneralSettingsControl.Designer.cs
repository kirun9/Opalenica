namespace Opalenica.Forms.Settings;

partial class GeneralSettingsControl
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
        AcceptButton = new CustomUIDesign.ButtonWithoutPadding();
        MonitorComboBox = new ComboBox();
        MonitorLabel = new Label();
        FullScreenLabel = new Label();
        FullScreenOnStartCheckBox = new CheckBox();
        ApplyButton = new CustomUIDesign.ButtonWithoutPadding();
        CancelButton = new CustomUIDesign.ButtonWithoutPadding();
        ModeLabel = new Label();
        ModeDropdown = new ComboBox();
        LanguageLabel = new Label();
        LanguageComboBox = new ComboBox();
        RestartInfoLabel = new Label();
        SuspendLayout();
        // 
        // AcceptButton
        // 
        AcceptButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        AcceptButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        AcceptButton.FlatStyle = FlatStyle.Flat;
        AcceptButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        AcceptButton.Location = new Point(702, 334);
        AcceptButton.Margin = new Padding(6);
        AcceptButton.Name = "AcceptButton";
        AcceptButton.Size = new Size(101, 29);
        AcceptButton.TabIndex = 10;
        AcceptButton.Text = "Akceptuj";
        AcceptButton.UseVisualStyleBackColor = true;
        AcceptButton.Click += AcceptButton_Click;
        // 
        // MonitorComboBox
        // 
        MonitorComboBox.AccessibleRole = AccessibleRole.ComboBox;
        MonitorComboBox.BackColor = Color.Black;
        MonitorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        MonitorComboBox.FlatStyle = FlatStyle.Flat;
        MonitorComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        MonitorComboBox.ForeColor = Color.White;
        MonitorComboBox.Location = new Point(217, 70);
        MonitorComboBox.Name = "MonitorComboBox";
        MonitorComboBox.Size = new Size(244, 25);
        MonitorComboBox.TabIndex = 1;
        // 
        // MonitorLabel
        // 
        MonitorLabel.AccessibleRole = AccessibleRole.StaticText;
        MonitorLabel.AutoSize = true;
        MonitorLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        MonitorLabel.Location = new Point(68, 73);
        MonitorLabel.Name = "MonitorLabel";
        MonitorLabel.Size = new Size(82, 19);
        MonitorLabel.TabIndex = 0;
        MonitorLabel.Text = "Wyświetlacz";
        // 
        // FullScreenLabel
        // 
        FullScreenLabel.AccessibleRole = AccessibleRole.StaticText;
        FullScreenLabel.AutoSize = true;
        FullScreenLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FullScreenLabel.Location = new Point(68, 184);
        FullScreenLabel.Name = "FullScreenLabel";
        FullScreenLabel.Size = new Size(80, 19);
        FullScreenLabel.TabIndex = 6;
        FullScreenLabel.Text = "Pełny ekran";
        // 
        // FullScreenOnStartCheckBox
        // 
        FullScreenOnStartCheckBox.CheckAlign = ContentAlignment.MiddleCenter;
        FullScreenOnStartCheckBox.FlatAppearance.BorderSize = 0;
        FullScreenOnStartCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FullScreenOnStartCheckBox.Location = new Point(217, 181);
        FullScreenOnStartCheckBox.Name = "FullScreenOnStartCheckBox";
        FullScreenOnStartCheckBox.Size = new Size(24, 24);
        FullScreenOnStartCheckBox.TabIndex = 7;
        FullScreenOnStartCheckBox.UseVisualStyleBackColor = true;
        // 
        // ApplyButton
        // 
        ApplyButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        ApplyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        ApplyButton.FlatStyle = FlatStyle.Flat;
        ApplyButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        ApplyButton.Location = new Point(589, 334);
        ApplyButton.Margin = new Padding(6);
        ApplyButton.Name = "ApplyButton";
        ApplyButton.Size = new Size(101, 29);
        ApplyButton.TabIndex = 9;
        ApplyButton.Text = "Zastosuj";
        ApplyButton.UseVisualStyleBackColor = true;
        ApplyButton.Click += ApplyButton_Click;
        // 
        // CancelButton
        // 
        CancelButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
        CancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
        CancelButton.FlatStyle = FlatStyle.Flat;
        CancelButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        CancelButton.Location = new Point(476, 334);
        CancelButton.Margin = new Padding(6);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(101, 29);
        CancelButton.TabIndex = 8;
        CancelButton.Text = "Anuluj";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // ModeLabel
        // 
        ModeLabel.AccessibleRole = AccessibleRole.StaticText;
        ModeLabel.AutoSize = true;
        ModeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ModeLabel.Location = new Point(68, 110);
        ModeLabel.Name = "ModeLabel";
        ModeLabel.Size = new Size(118, 19);
        ModeLabel.TabIndex = 2;
        ModeLabel.Text = "Tryb Wyświetlania";
        // 
        // ModeDropdown
        // 
        ModeDropdown.AccessibleRole = AccessibleRole.ComboBox;
        ModeDropdown.BackColor = Color.Black;
        ModeDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
        ModeDropdown.FlatStyle = FlatStyle.Flat;
        ModeDropdown.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ModeDropdown.ForeColor = Color.White;
        ModeDropdown.Items.AddRange(new object[] { "Pełny Ekran", "Okno" });
        ModeDropdown.Location = new Point(217, 107);
        ModeDropdown.Name = "ModeDropdown";
        ModeDropdown.Size = new Size(139, 25);
        ModeDropdown.TabIndex = 3;
        // 
        // LanguageLabel
        // 
        LanguageLabel.AccessibleRole = AccessibleRole.StaticText;
        LanguageLabel.AutoSize = true;
        LanguageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        LanguageLabel.Location = new Point(68, 147);
        LanguageLabel.Name = "LanguageLabel";
        LanguageLabel.Size = new Size(116, 19);
        LanguageLabel.TabIndex = 4;
        LanguageLabel.Text = "Język (wyłączone)";
        // 
        // LanguageComboBox
        // 
        LanguageComboBox.AccessibleRole = AccessibleRole.ComboBox;
        LanguageComboBox.BackColor = Color.Black;
        LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        LanguageComboBox.FlatStyle = FlatStyle.Flat;
        LanguageComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        LanguageComboBox.ForeColor = Color.White;
        LanguageComboBox.Location = new Point(217, 144);
        LanguageComboBox.Name = "LanguageComboBox";
        LanguageComboBox.Size = new Size(139, 25);
        LanguageComboBox.TabIndex = 5;
        LanguageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
        // 
        // RestartInfoLabel
        // 
        RestartInfoLabel.AccessibleRole = AccessibleRole.StaticText;
        RestartInfoLabel.AutoSize = true;
        RestartInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        RestartInfoLabel.ForeColor = Color.Red;
        RestartInfoLabel.Location = new Point(68, 221);
        RestartInfoLabel.Name = "RestartInfoLabel";
        RestartInfoLabel.Size = new Size(257, 15);
        RestartInfoLabel.TabIndex = 13;
        RestartInfoLabel.Text = "* Zrestartuj aplikację aby zmiany odniosły efekt.";
        RestartInfoLabel.Visible = false;
        // 
        // GeneralSettingsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        Controls.Add(RestartInfoLabel);
        Controls.Add(LanguageComboBox);
        Controls.Add(LanguageLabel);
        Controls.Add(ModeDropdown);
        Controls.Add(ModeLabel);
        Controls.Add(CancelButton);
        Controls.Add(ApplyButton);
        Controls.Add(FullScreenOnStartCheckBox);
        Controls.Add(FullScreenLabel);
        Controls.Add(AcceptButton);
        Controls.Add(MonitorComboBox);
        Controls.Add(MonitorLabel);
        ForeColor = Color.White;
        Name = "GeneralSettingsControl";
        Size = new Size(809, 369);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private ComboBox MonitorComboBox;
    private Label MonitorLabel;
    private Label FullScreenLabel;
    private CheckBox FullScreenOnStartCheckBox;
    private CustomUIDesign.ButtonWithoutPadding ApplyButton;
    private CustomUIDesign.ButtonWithoutPadding CancelButton;
    private Label ModeLabel;
    private ComboBox ModeDropdown;
    private Label LanguageLabel;
    private ComboBox LanguageComboBox;
    private Label RestartInfoLabel;
    private CustomUIDesign.ButtonWithoutPadding AcceptButton;
}
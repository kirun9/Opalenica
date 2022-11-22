namespace Opalenica.Forms.Settings;

using static Language;

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
            this.AcceptButton = new CustomUIDesign.ButtonWithoutPadding();
            this.MonitorComboBox = new System.Windows.Forms.ComboBox();
            this.MonitorLabel = new System.Windows.Forms.Label();
            this.FullScreenLabel = new System.Windows.Forms.Label();
            this.FullScreenOnStartCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyButton = new CustomUIDesign.ButtonWithoutPadding();
            this.CancelButton = new CustomUIDesign.ButtonWithoutPadding();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeDropdown = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.RestartInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AcceptButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AcceptButton.Location = new System.Drawing.Point(702, 334);
            this.AcceptButton.Margin = new System.Windows.Forms.Padding(6);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(101, 29);
            this.AcceptButton.TabIndex = 10;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // MonitorComboBox
            // 
            this.MonitorComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.MonitorComboBox.BackColor = System.Drawing.Color.Black;
            this.MonitorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonitorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonitorComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorComboBox.ForeColor = System.Drawing.Color.White;
            this.MonitorComboBox.Location = new System.Drawing.Point(217, 70);
            this.MonitorComboBox.Name = "MonitorComboBox";
            this.MonitorComboBox.Size = new System.Drawing.Size(244, 25);
            this.MonitorComboBox.TabIndex = 1;
            // 
            // MonitorLabel
            // 
            this.MonitorLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.MonitorLabel.AutoSize = true;
            this.MonitorLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorLabel.Location = new System.Drawing.Point(68, 73);
            this.MonitorLabel.Name = "MonitorLabel";
            this.MonitorLabel.Size = new System.Drawing.Size(111, 19);
            this.MonitorLabel.TabIndex = 0;
            this.MonitorLabel.Text = "<MonitorLabel>";
            // 
            // FullScreenLabel
            // 
            this.FullScreenLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.FullScreenLabel.AutoSize = true;
            this.FullScreenLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FullScreenLabel.Location = new System.Drawing.Point(68, 184);
            this.FullScreenLabel.Name = "FullScreenLabel";
            this.FullScreenLabel.Size = new System.Drawing.Size(122, 19);
            this.FullScreenLabel.TabIndex = 6;
            this.FullScreenLabel.Text = "<FullScreenLabel>";
            // 
            // FullScreenOnStartCheckBox
            // 
            this.FullScreenOnStartCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FullScreenOnStartCheckBox.FlatAppearance.BorderSize = 0;
            this.FullScreenOnStartCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FullScreenOnStartCheckBox.Location = new System.Drawing.Point(217, 181);
            this.FullScreenOnStartCheckBox.Name = "FullScreenOnStartCheckBox";
            this.FullScreenOnStartCheckBox.Size = new System.Drawing.Size(24, 24);
            this.FullScreenOnStartCheckBox.TabIndex = 7;
            this.FullScreenOnStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ApplyButton.Location = new System.Drawing.Point(589, 334);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(6);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(101, 29);
            this.ApplyButton.TabIndex = 9;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.Location = new System.Drawing.Point(476, 334);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(101, 29);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ModeLabel
            // 
            this.ModeLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeLabel.Location = new System.Drawing.Point(68, 110);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(97, 19);
            this.ModeLabel.TabIndex = 2;
            this.ModeLabel.Text = "<ModeLabel>";
            // 
            // ModeDropdown
            // 
            this.ModeDropdown.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.ModeDropdown.BackColor = System.Drawing.Color.Black;
            this.ModeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModeDropdown.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeDropdown.ForeColor = System.Drawing.Color.White;
            this.ModeDropdown.Items.AddRange(new object[] {
            "Fullscreen",
            "Window"});
            this.ModeDropdown.Location = new System.Drawing.Point(217, 107);
            this.ModeDropdown.Name = "ModeDropdown";
            this.ModeDropdown.Size = new System.Drawing.Size(139, 25);
            this.ModeDropdown.TabIndex = 3;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LanguageLabel.Location = new System.Drawing.Point(68, 147);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(121, 19);
            this.LanguageLabel.TabIndex = 4;
            this.LanguageLabel.Text = "<LanguageLabel>";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.LanguageComboBox.BackColor = System.Drawing.Color.Black;
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LanguageComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LanguageComboBox.ForeColor = System.Drawing.Color.White;
            this.LanguageComboBox.Location = new System.Drawing.Point(217, 144);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(139, 25);
            this.LanguageComboBox.TabIndex = 5;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // RestartInfoLabel
            // 
            this.RestartInfoLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.RestartInfoLabel.AutoSize = true;
            this.RestartInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RestartInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.RestartInfoLabel.Location = new System.Drawing.Point(68, 221);
            this.RestartInfoLabel.Name = "RestartInfoLabel";
            this.RestartInfoLabel.Size = new System.Drawing.Size(108, 15);
            this.RestartInfoLabel.TabIndex = 13;
            this.RestartInfoLabel.Text = "<RestartInfoLabel>";
            this.RestartInfoLabel.Visible = false;
            // 
            // GeneralSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.RestartInfoLabel);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.ModeDropdown);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.FullScreenOnStartCheckBox);
            this.Controls.Add(this.FullScreenLabel);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.MonitorComboBox);
            this.Controls.Add(this.MonitorLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "GeneralSettingsControl";
            this.Size = new System.Drawing.Size(809, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

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

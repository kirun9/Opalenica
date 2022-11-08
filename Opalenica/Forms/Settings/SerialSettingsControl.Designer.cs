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
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.BaudLabel = new System.Windows.Forms.Label();
            this.RestartButton = new CustomUIDesign.ButtonWithoutPadding();
            this.StartButton = new CustomUIDesign.ButtonWithoutPadding();
            this.SaveButton = new CustomUIDesign.ButtonWithoutPadding();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.ConnectionLed = new Opalenica.Forms.Settings.RoundControlLED();
            this.SuspendLayout();
            // 
            // PortComboBox
            // 
            this.PortComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.PortComboBox.BackColor = System.Drawing.Color.Black;
            this.PortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PortComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortComboBox.ForeColor = System.Drawing.Color.White;
            this.PortComboBox.Location = new System.Drawing.Point(217, 107);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 25);
            this.PortComboBox.TabIndex = 11;
            // 
            // PortLabel
            // 
            this.PortLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortLabel.Location = new System.Drawing.Point(68, 110);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(35, 19);
            this.PortLabel.TabIndex = 10;
            this.PortLabel.Text = "Port";
            // 
            // BaudComboBox
            // 
            this.BaudComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.BaudComboBox.BackColor = System.Drawing.Color.Black;
            this.BaudComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BaudComboBox.ForeColor = System.Drawing.Color.White;
            this.BaudComboBox.Location = new System.Drawing.Point(217, 70);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(121, 25);
            this.BaudComboBox.TabIndex = 9;
            // 
            // BaudLabel
            // 
            this.BaudLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.BaudLabel.AutoSize = true;
            this.BaudLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BaudLabel.Location = new System.Drawing.Point(68, 73);
            this.BaudLabel.Name = "BaudLabel";
            this.BaudLabel.Size = new System.Drawing.Size(40, 19);
            this.BaudLabel.TabIndex = 8;
            this.BaudLabel.Text = "Baud";
            // 
            // RestartButton
            // 
            this.RestartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartButton.Location = new System.Drawing.Point(68, 175);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(118, 23);
            this.RestartButton.TabIndex = 12;
            this.RestartButton.Text = "Restart Connection";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(217, 175);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(121, 23);
            this.StartButton.TabIndex = 13;
            this.StartButton.Text = "Start Connection";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(702, 334);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(101, 29);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(68, 227);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(121, 19);
            this.ConnectionStatusLabel.TabIndex = 16;
            this.ConnectionStatusLabel.Text = "Connection Status";
            // 
            // ConnectionLed
            // 
            this.ConnectionLed.LEDColors = new System.Drawing.Color[] {
        System.Drawing.Color.Gray,
        System.Drawing.Color.Red,
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Blue};
            this.ConnectionLed.Location = new System.Drawing.Point(217, 227);
            this.ConnectionLed.Name = "ConnectionLed";
            this.ConnectionLed.Size = new System.Drawing.Size(30, 30);
            this.ConnectionLed.TabIndex = 17;
            this.ConnectionLed.Text = "roundControlled1";
            // 
            // SerialSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.ConnectionLed);
            this.Controls.Add(this.ConnectionStatusLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.BaudComboBox);
            this.Controls.Add(this.BaudLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SerialSettingsControl";
            this.Size = new System.Drawing.Size(809, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

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

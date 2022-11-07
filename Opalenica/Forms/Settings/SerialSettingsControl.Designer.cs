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
            this.button1 = new CustomUIDesign.ButtonWithoutPadding();
            this.buttonWithoutPadding1 = new CustomUIDesign.ButtonWithoutPadding();
            this.buttonWithoutPadding2 = new CustomUIDesign.ButtonWithoutPadding();
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
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(68, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Restart Connection";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonWithoutPadding1
            // 
            this.buttonWithoutPadding1.Enabled = false;
            this.buttonWithoutPadding1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonWithoutPadding1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonWithoutPadding1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithoutPadding1.Location = new System.Drawing.Point(217, 175);
            this.buttonWithoutPadding1.Name = "buttonWithoutPadding1";
            this.buttonWithoutPadding1.Size = new System.Drawing.Size(121, 23);
            this.buttonWithoutPadding1.TabIndex = 13;
            this.buttonWithoutPadding1.Text = "Start Connection";
            this.buttonWithoutPadding1.UseVisualStyleBackColor = true;
            // 
            // buttonWithoutPadding2
            // 
            this.buttonWithoutPadding2.Enabled = false;
            this.buttonWithoutPadding2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonWithoutPadding2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonWithoutPadding2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithoutPadding2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonWithoutPadding2.Location = new System.Drawing.Point(702, 334);
            this.buttonWithoutPadding2.Margin = new System.Windows.Forms.Padding(6);
            this.buttonWithoutPadding2.Name = "buttonWithoutPadding2";
            this.buttonWithoutPadding2.Size = new System.Drawing.Size(101, 29);
            this.buttonWithoutPadding2.TabIndex = 14;
            this.buttonWithoutPadding2.Text = "Save";
            this.buttonWithoutPadding2.UseVisualStyleBackColor = true;
            // 
            // SerialSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonWithoutPadding2);
            this.Controls.Add(this.buttonWithoutPadding1);
            this.Controls.Add(this.button1);
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
    private ButtonWithoutPadding button1;
    private ButtonWithoutPadding buttonWithoutPadding1;
    private ButtonWithoutPadding buttonWithoutPadding2;
}

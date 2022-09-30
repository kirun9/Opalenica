namespace Opalenica;

partial class OpalenicaForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pulpit1 = new Opalenica.NewPulpit();
            this.SuspendLayout();
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CommandTextBox.BackColor = System.Drawing.Color.Black;
            this.CommandTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CommandTextBox.ForeColor = System.Drawing.Color.White;
            this.CommandTextBox.Location = new System.Drawing.Point(12, 985);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(413, 27);
            this.CommandTextBox.TabIndex = 0;
            this.CommandTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandTextBox_KeyDown);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(1527, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(34, 40);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pulpit1
            // 
            this.pulpit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulpit1.Location = new System.Drawing.Point(0, 0);
            this.pulpit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pulpit1.Name = "pulpit1";
            this.pulpit1.Size = new System.Drawing.Size(1561, 1024);
            this.pulpit1.TabIndex = 1;
            this.pulpit1.Text = "pulpit1";
            this.pulpit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pulpit1_KeyDown);
            // 
            // OpalenicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1561, 1024);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.pulpit1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(16, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OpalenicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opalenica";
            this.Load += new System.EventHandler(this.OpalenicaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

	#endregion
    private Button ExitButton;
    private NewPulpit pulpit1;
	public TextBox CommandTextBox;
}

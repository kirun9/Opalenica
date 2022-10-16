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
            this.pulpit1 = new Opalenica.Pulpit(this, "pulpit1");
            this.SuspendLayout();
            // 
            // pulpit1
            // 
            this.pulpit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulpit1.Location = new System.Drawing.Point(0, 0);
            this.pulpit1.Name = "pulpit1";
            this.pulpit1.Size = new System.Drawing.Size(1366, 768);
            this.pulpit1.TabIndex = 1;
            this.pulpit1.Text = "pulpit1";
            this.pulpit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pulpit1_KeyDown);
            // 
            // OpalenicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pulpit1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(16, 0);
            this.Name = "OpalenicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opalenica";
            this.Load += new System.EventHandler(this.OpalenicaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

	#endregion
    private Pulpit pulpit1;
}

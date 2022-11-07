namespace Opalenica.Forms;

using CustomUIDesign;

partial class OptionsForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new CustomUIDesign.ButtonWithoutPadding();
            this.Title = new System.Windows.Forms.Label();
            this.PrevTabButton = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.TabPanel = new System.Windows.Forms.Panel();
            this.TabFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LeftButton = new CustomUIDesign.ButtonWithoutPadding();
            this.RightButton = new CustomUIDesign.ButtonWithoutPadding();
            this.TopPanel.SuspendLayout();
            this.PrevTabButton.SuspendLayout();
            this.TabPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.ExitButton);
            this.TopPanel.Controls.Add(this.Title);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(3, 3);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(809, 30);
            this.TopPanel.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(779, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "✖";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(773, 30);
            this.Title.TabIndex = 0;
            this.Title.Text = "Options";
            // 
            // PrevTabButton
            // 
            this.PrevTabButton.Controls.Add(this.ContentPanel);
            this.PrevTabButton.Controls.Add(this.TabPanel);
            this.PrevTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrevTabButton.Location = new System.Drawing.Point(3, 33);
            this.PrevTabButton.Name = "PrevTabButton";
            this.PrevTabButton.Size = new System.Drawing.Size(809, 395);
            this.PrevTabButton.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 26);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(809, 369);
            this.ContentPanel.TabIndex = 2;
            // 
            // TabPanel
            // 
            this.TabPanel.Controls.Add(this.TabFlowPanel);
            this.TabPanel.Controls.Add(this.LeftButton);
            this.TabPanel.Controls.Add(this.RightButton);
            this.TabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabPanel.Location = new System.Drawing.Point(0, 0);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.Size = new System.Drawing.Size(809, 26);
            this.TabPanel.TabIndex = 1;
            // 
            // TabFlowPanel
            // 
            this.TabFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabFlowPanel.Location = new System.Drawing.Point(26, 0);
            this.TabFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TabFlowPanel.Name = "TabFlowPanel";
            this.TabFlowPanel.Size = new System.Drawing.Size(757, 26);
            this.TabFlowPanel.TabIndex = 0;
            this.TabFlowPanel.WrapContents = false;
            // 
            // LeftButton
            // 
            this.LeftButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftButton.FlatAppearance.BorderSize = 0;
            this.LeftButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LeftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LeftButton.ForeColor = System.Drawing.Color.White;
            this.LeftButton.Location = new System.Drawing.Point(0, 0);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(26, 26);
            this.LeftButton.TabIndex = 5;
            this.LeftButton.Text = "◀";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Visible = false;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightButton.FlatAppearance.BorderSize = 0;
            this.RightButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RightButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RightButton.ForeColor = System.Drawing.Color.White;
            this.RightButton.Location = new System.Drawing.Point(783, 0);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(26, 26);
            this.RightButton.TabIndex = 4;
            this.RightButton.Text = "▶";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Visible = false;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(815, 431);
            this.Controls.Add(this.PrevTabButton);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.RestrainLocation = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionsForm";
            this.TopPanel.ResumeLayout(false);
            this.PrevTabButton.ResumeLayout(false);
            this.TabPanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Panel TopPanel;
    private Label Title;
    private ButtonWithoutPadding ExitButton;
    private Panel PrevTabButton;
    private FlowLayoutPanel TabFlowPanel;
    private Panel TabPanel;
    private ButtonWithoutPadding LeftButton;
    private ButtonWithoutPadding RightButton;
    private Panel ContentPanel;
}
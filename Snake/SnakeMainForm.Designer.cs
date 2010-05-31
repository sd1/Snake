namespace Snake
{
    partial class SnakeMainForm
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
            this.components = new System.ComponentModel.Container();
            this.TimerUpdateWorld = new System.Windows.Forms.Timer(this.components);
            this.PanelArena = new Snake.Controls.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // TimerUpdateWorld
            // 
            this.TimerUpdateWorld.Enabled = true;
            this.TimerUpdateWorld.Interval = 50;
            this.TimerUpdateWorld.Tick += new System.EventHandler(this.TimerUpdateWorld_Tick);
            // 
            // PanelArena
            // 
            this.PanelArena.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelArena.Location = new System.Drawing.Point(12, 12);
            this.PanelArena.Name = "PanelArena";
            this.PanelArena.Size = new System.Drawing.Size(511, 397);
            this.PanelArena.TabIndex = 2;
            this.PanelArena.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelArena_Paint);
            this.PanelArena.Resize += new System.EventHandler(this.PanelArena_Resize);
            // 
            // SnakeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 421);
            this.Controls.Add(this.PanelArena);
            this.Name = "SnakeMainForm";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeMainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerUpdateWorld;
        private Snake.Controls.DoubleBufferedPanel PanelArena;
    }
}


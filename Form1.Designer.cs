namespace TimeAlarmWinForms
{
    partial class Form1
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
            labelInstructions = new Label();
            textBoxTime = new TextBox();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.Location = new Point(0, 0);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.RightToLeft = RightToLeft.Yes;
            labelInstructions.Size = new Size(287, 37);
            labelInstructions.TabIndex = 0;
            labelInstructions.Text = "Enter time (HH:MM:SS)";
            // 
            // textBoxTime
            // 
            textBoxTime.Location = new Point(50, 50);
            textBoxTime.Name = "textBoxTime";
            textBoxTime.Size = new Size(100, 43);
            textBoxTime.TabIndex = 1;
            // 
            // buttonStart
            // 
            buttonStart.AutoSize = true;
            buttonStart.Location = new Point(50, 100);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(100, 47);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStart);
            Controls.Add(textBoxTime);
            Controls.Add(labelInstructions);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInstructions;
        private TextBox textBoxTime;
        private Button buttonStart;
    }
}

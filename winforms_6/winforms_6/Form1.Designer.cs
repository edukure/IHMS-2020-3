namespace winforms_6
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.NoiseChart = new LiveCharts.Wpf.CartesianChart();
            this.ThLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fsInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wInput = new System.Windows.Forms.TextBox();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(41, 46);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(422, 143);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.NoiseChart;
            // 
            // ThLabel
            // 
            this.ThLabel.AutoSize = true;
            this.ThLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThLabel.Location = new System.Drawing.Point(99, 207);
            this.ThLabel.Name = "ThLabel";
            this.ThLabel.Size = new System.Drawing.Size(147, 33);
            this.ThLabel.TabIndex = 1;
            this.ThLabel.Text = "th (limiar):";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(564, 182);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(142, 58);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(541, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "fs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(543, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "w:";
            // 
            // fsInput
            // 
            this.fsInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsInput.Location = new System.Drawing.Point(593, 42);
            this.fsInput.Name = "fsInput";
            this.fsInput.Size = new System.Drawing.Size(77, 40);
            this.fsInput.TabIndex = 5;
            this.fsInput.Text = "500";
            this.fsInput.TextChanged += new System.EventHandler(this.fsInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hz";
            // 
            // wInput
            // 
            this.wInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wInput.Location = new System.Drawing.Point(593, 85);
            this.wInput.Name = "wInput";
            this.wInput.Size = new System.Drawing.Size(77, 40);
            this.wInput.TabIndex = 7;
            this.wInput.Text = "50";
            this.wInput.TextChanged += new System.EventHandler(this.wInput_TextChanged);
            // 
            // timeInput
            // 
            this.timeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInput.Location = new System.Drawing.Point(593, 131);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(77, 40);
            this.timeInput.TabIndex = 9;
            this.timeInput.Text = "10";
            this.timeInput.TextChanged += new System.EventHandler(this.timeInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "tempo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(676, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 267);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ThLabel);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart NoiseChart;
        private System.Windows.Forms.Label ThLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fsInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wInput;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}


namespace lab10
{
    partial class Lab10
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countOfIteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.efficiency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmdahlLaw1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GustafsonLaw1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(250, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 89);
            this.button4.TabIndex = 14;
            this.button4.Text = "Модифікована каскадна схема";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 89);
            this.button3.TabIndex = 13;
            this.button3.Text = "послідовно";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(250, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 89);
            this.button2.TabIndex = 12;
            this.button2.Text = "Редукція";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.time,
            this.countOfIteration,
            this.efficiency,
            this.speedup,
            this.result,
            this.AmdahlLaw1,
            this.GustafsonLaw1});
            this.dataGridView1.Location = new System.Drawing.Point(517, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(954, 202);
            this.dataGridView1.TabIndex = 11;
            // 
            // Name
            // 
            this.Name.HeaderText = "Назва";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.Width = 125;
            // 
            // time
            // 
            this.time.HeaderText = "Час виконання";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            this.time.Width = 125;
            // 
            // countOfIteration
            // 
            this.countOfIteration.HeaderText = "кількість ітерацій";
            this.countOfIteration.MinimumWidth = 6;
            this.countOfIteration.Name = "countOfIteration";
            this.countOfIteration.Width = 125;
            // 
            // efficiency
            // 
            this.efficiency.HeaderText = "Ефективність";
            this.efficiency.MinimumWidth = 6;
            this.efficiency.Name = "efficiency";
            this.efficiency.Width = 125;
            // 
            // speedup
            // 
            this.speedup.HeaderText = "Прискорення";
            this.speedup.MinimumWidth = 6;
            this.speedup.Name = "speedup";
            this.speedup.Width = 125;
            // 
            // result
            // 
            this.result.HeaderText = "результат";
            this.result.MinimumWidth = 6;
            this.result.Name = "result";
            this.result.Width = 125;
            // 
            // AmdahlLaw1
            // 
            this.AmdahlLaw1.HeaderText = "AmdahlLaw";
            this.AmdahlLaw1.MinimumWidth = 6;
            this.AmdahlLaw1.Name = "AmdahlLaw1";
            this.AmdahlLaw1.Width = 125;
            // 
            // GustafsonLaw1
            // 
            this.GustafsonLaw1.HeaderText = "GustafsonLaw";
            this.GustafsonLaw1.MinimumWidth = 6;
            this.GustafsonLaw1.Name = "GustafsonLaw1";
            this.GustafsonLaw1.Width = 125;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 89);
            this.button1.TabIndex = 10;
            this.button1.Text = "Каскадна схема";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(309, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 41);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кількість ітерацій";
            // 
            // Lab10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 393);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
         
            this.Text = "Lab10";
            this.Load += new System.EventHandler(this.Lab10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn countOfIteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn efficiency;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedup;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmdahlLaw1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GustafsonLaw1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
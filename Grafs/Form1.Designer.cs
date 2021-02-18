namespace Grafs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.rdSquare = new System.Windows.Forms.RadioButton();
            this.rdCircle = new System.Windows.Forms.RadioButton();
            this.rdTriangle = new System.Windows.Forms.RadioButton();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.bGroup = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.Ivory;
            this.pb1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb1.Location = new System.Drawing.Point(166, 0);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(840, 574);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Paint += new System.Windows.Forms.PaintEventHandler(this.pb1_Paint);
            this.pb1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb1_MouseClick);
            // 
            // rdSquare
            // 
            this.rdSquare.AutoSize = true;
            this.rdSquare.Location = new System.Drawing.Point(3, 83);
            this.rdSquare.Name = "rdSquare";
            this.rdSquare.Size = new System.Drawing.Size(59, 17);
            this.rdSquare.TabIndex = 4;
            this.rdSquare.Text = "Square";
            this.rdSquare.UseVisualStyleBackColor = true;
            // 
            // rdCircle
            // 
            this.rdCircle.AutoSize = true;
            this.rdCircle.Location = new System.Drawing.Point(3, 60);
            this.rdCircle.Name = "rdCircle";
            this.rdCircle.Size = new System.Drawing.Size(51, 17);
            this.rdCircle.TabIndex = 3;
            this.rdCircle.Text = "Circle";
            this.rdCircle.UseVisualStyleBackColor = true;
            // 
            // rdTriangle
            // 
            this.rdTriangle.AutoSize = true;
            this.rdTriangle.Checked = true;
            this.rdTriangle.Location = new System.Drawing.Point(3, 37);
            this.rdTriangle.Name = "rdTriangle";
            this.rdTriangle.Size = new System.Drawing.Size(63, 17);
            this.rdTriangle.TabIndex = 2;
            this.rdTriangle.TabStop = true;
            this.rdTriangle.Text = "Triangle";
            this.rdTriangle.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Checked = true;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.Location = new System.Drawing.Point(6, 3);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(80, 17);
            this.cb1.TabIndex = 1;
            this.cb1.Text = "Создавать";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.bGroup);
            this.panel1.Controls.Add(this.bLoad);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.cb1);
            this.panel1.Controls.Add(this.rdTriangle);
            this.panel1.Controls.Add(this.rdCircle);
            this.panel1.Controls.Add(this.rdSquare);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 550);
            this.panel1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 477);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 36);
            this.button4.TabIndex = 12;
            this.button4.Text = "Delete All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bGroup
            // 
            this.bGroup.Location = new System.Drawing.Point(3, 121);
            this.bGroup.Name = "bGroup";
            this.bGroup.Size = new System.Drawing.Size(80, 23);
            this.bGroup.TabIndex = 10;
            this.bGroup.Text = "Make Group";
            this.bGroup.UseVisualStyleBackColor = true;
            this.bGroup.Click += new System.EventHandler(this.bGroup_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(0, 212);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(83, 23);
            this.bLoad.TabIndex = 9;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(0, 183);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(83, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.RadioButton rdSquare;
        private System.Windows.Forms.RadioButton rdCircle;
        private System.Windows.Forms.RadioButton rdTriangle;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bGroup;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


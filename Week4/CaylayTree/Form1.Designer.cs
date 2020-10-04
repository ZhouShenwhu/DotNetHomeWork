namespace CaylayTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Draw = new System.Windows.Forms.Button();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.textBoxPer1 = new System.Windows.Forms.TextBox();
            this.textBoxPer2 = new System.Windows.Forms.TextBox();
            this.textBoxTh1 = new System.Windows.Forms.TextBox();
            this.textBoxTh2 = new System.Windows.Forms.TextBox();
            this.PenColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Draw
            // 
            this.Draw.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Draw.Location = new System.Drawing.Point(74, 263);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(115, 37);
            this.Draw.TabIndex = 0;
            this.Draw.Text = "Draw";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(150, 25);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(100, 25);
            this.textBoxN.TabIndex = 1;
            // 
            // textBoxL
            // 
            this.textBoxL.Location = new System.Drawing.Point(150, 59);
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.Size = new System.Drawing.Size(100, 25);
            this.textBoxL.TabIndex = 2;
            // 
            // textBoxPer1
            // 
            this.textBoxPer1.Location = new System.Drawing.Point(150, 91);
            this.textBoxPer1.Name = "textBoxPer1";
            this.textBoxPer1.Size = new System.Drawing.Size(100, 25);
            this.textBoxPer1.TabIndex = 3;
            // 
            // textBoxPer2
            // 
            this.textBoxPer2.Location = new System.Drawing.Point(150, 122);
            this.textBoxPer2.Name = "textBoxPer2";
            this.textBoxPer2.Size = new System.Drawing.Size(100, 25);
            this.textBoxPer2.TabIndex = 4;
            // 
            // textBoxTh1
            // 
            this.textBoxTh1.Location = new System.Drawing.Point(150, 153);
            this.textBoxTh1.Name = "textBoxTh1";
            this.textBoxTh1.Size = new System.Drawing.Size(100, 25);
            this.textBoxTh1.TabIndex = 5;
            // 
            // textBoxTh2
            // 
            this.textBoxTh2.Location = new System.Drawing.Point(150, 187);
            this.textBoxTh2.Name = "textBoxTh2";
            this.textBoxTh2.Size = new System.Drawing.Size(100, 25);
            this.textBoxTh2.TabIndex = 6;
            // 
            // PenColor
            // 
            this.PenColor.FormattingEnabled = true;
            this.PenColor.Location = new System.Drawing.Point(150, 220);
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(100, 23);
            this.PenColor.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "递归深度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "主干长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "右分支长度比";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "左分支长度比";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "右分支角度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(6, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "左分支角度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(6, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "画笔颜色";
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Controls.Add(this.Draw);
            this.GroupBox.Controls.Add(this.PenColor);
            this.GroupBox.Controls.Add(this.label7);
            this.GroupBox.Controls.Add(this.textBoxTh2);
            this.GroupBox.Controls.Add(this.textBoxN);
            this.GroupBox.Controls.Add(this.textBoxTh1);
            this.GroupBox.Controls.Add(this.label6);
            this.GroupBox.Controls.Add(this.textBoxPer2);
            this.GroupBox.Controls.Add(this.label2);
            this.GroupBox.Controls.Add(this.textBoxPer1);
            this.GroupBox.Controls.Add(this.label5);
            this.GroupBox.Controls.Add(this.textBoxL);
            this.GroupBox.Controls.Add(this.label4);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Location = new System.Drawing.Point(533, 51);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(255, 306);
            this.GroupBox.TabIndex = 15;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "参数设定";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 447);
            this.panel1.TabIndex = 16;
          
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxL;
        private System.Windows.Forms.TextBox textBoxPer1;
        private System.Windows.Forms.TextBox textBoxPer2;
        private System.Windows.Forms.TextBox textBoxTh1;
        private System.Windows.Forms.TextBox textBoxTh2;
        private System.Windows.Forms.ComboBox PenColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Panel panel1;
    }
}


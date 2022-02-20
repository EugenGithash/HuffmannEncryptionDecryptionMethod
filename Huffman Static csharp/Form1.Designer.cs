namespace Huffman_Static_csharp
{
    partial class Form1
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEncode = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEncodeText = new System.Windows.Forms.Button();
            this.btnLoadEncodedFIle = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(39, 48);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(140, 47);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load FIle";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(39, 134);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(140, 46);
            this.btnEncode.TabIndex = 1;
            this.btnEncode.Text = "Encode File";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 340);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 147);
            this.textBox1.TabIndex = 2;
            // 
            // btnEncodeText
            // 
            this.btnEncodeText.Location = new System.Drawing.Point(39, 275);
            this.btnEncodeText.Name = "btnEncodeText";
            this.btnEncodeText.Size = new System.Drawing.Size(140, 43);
            this.btnEncodeText.TabIndex = 3;
            this.btnEncodeText.Text = "Encode Text";
            this.btnEncodeText.UseVisualStyleBackColor = true;
            this.btnEncodeText.Click += new System.EventHandler(this.btnEncodeText_Click);
            // 
            // btnLoadEncodedFIle
            // 
            this.btnLoadEncodedFIle.Location = new System.Drawing.Point(436, 48);
            this.btnLoadEncodedFIle.Name = "btnLoadEncodedFIle";
            this.btnLoadEncodedFIle.Size = new System.Drawing.Size(148, 47);
            this.btnLoadEncodedFIle.TabIndex = 4;
            this.btnLoadEncodedFIle.Text = "Load EncodedFIle";
            this.btnLoadEncodedFIle.UseVisualStyleBackColor = true;
            this.btnLoadEncodedFIle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(436, 134);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(147, 45);
            this.btnDecode.TabIndex = 5;
            this.btnDecode.Text = "Decode File";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(270, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show Codes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(236, 332);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 155);
            this.textBox2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 633);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncodedFIle);
            this.Controls.Add(this.btnEncodeText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEncodeText;
        private System.Windows.Forms.Button btnLoadEncodedFIle;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}


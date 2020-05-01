namespace GUITestSystem
{
    partial class UC_Question
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_question = new System.Windows.Forms.Label();
            this.pn_answer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pn_answer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_question, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.05952F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_question
            // 
            this.lb_question.AutoSize = true;
            this.lb_question.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_question.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_question.Location = new System.Drawing.Point(42, 22);
            this.lb_question.Name = "lb_question";
            this.lb_question.Size = new System.Drawing.Size(554, 19);
            this.lb_question.TabIndex = 0;
            this.lb_question.Text = "label1";
            // 
            // pn_answer
            // 
            this.pn_answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_answer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_answer.Location = new System.Drawing.Point(42, 44);
            this.pn_answer.Name = "pn_answer";
            this.pn_answer.Size = new System.Drawing.Size(554, 212);
            this.pn_answer.TabIndex = 1;
            // 
            // UC_Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Question";
            this.Size = new System.Drawing.Size(599, 259);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pn_answer;
        private System.Windows.Forms.Label lb_question;
    }
}

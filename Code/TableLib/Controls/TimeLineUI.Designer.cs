namespace TableLib.Controls
{
    internal partial class TimeLineUI
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plLeftLine = new System.Windows.Forms.Panel();
            this.plItemList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeftLine
            // 
            this.plLeftLine.BackColor = System.Drawing.Color.SteelBlue;
            this.plLeftLine.Dock = System.Windows.Forms.DockStyle.Right;
            this.plLeftLine.Location = new System.Drawing.Point(10, 0);
            this.plLeftLine.Margin = new System.Windows.Forms.Padding(0);
            this.plLeftLine.Name = "plLeftLine";
            this.plLeftLine.Size = new System.Drawing.Size(3, 572);
            this.plLeftLine.TabIndex = 0;
            // 
            // plItemList
            // 
            this.plItemList.AutoScroll = true;
            this.plItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plItemList.Location = new System.Drawing.Point(13, 0);
            this.plItemList.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.plItemList.Name = "plItemList";
            this.plItemList.Size = new System.Drawing.Size(618, 575);
            this.plItemList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 575);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.plLeftLine);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 572);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 3);
            this.panel2.TabIndex = 0;
            // 
            // TimeLineUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.plItemList);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "TimeLineUI";
            this.Size = new System.Drawing.Size(631, 575);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plLeftLine;
        private System.Windows.Forms.Panel plItemList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}

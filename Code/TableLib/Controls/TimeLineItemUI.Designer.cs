namespace TableLib.Controls
{
    partial class TimeLineItemUI
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
            this.SuspendLayout();
            // 
            // TimeLineItemUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 13F);
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TimeLineItemUI";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Size = new System.Drawing.Size(502, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeLineItemUI_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

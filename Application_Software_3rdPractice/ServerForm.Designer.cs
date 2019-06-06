namespace Application_Software_3rdPractice
{
    partial class ServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Board = new Application_Software_3rdPractice.DoubleBufferPanel();
            this.txt_Chat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel_Board
            // 
            this.panel_Board.BackColor = System.Drawing.Color.White;
            this.panel_Board.Location = new System.Drawing.Point(0, 0);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(800, 340);
            this.panel_Board.TabIndex = 0;
            this.panel_Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Board_Paint);
            // 
            // txt_Chat
            // 
            this.txt_Chat.Location = new System.Drawing.Point(0, 340);
            this.txt_Chat.Multiline = true;
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.ReadOnly = true;
            this.txt_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Chat.Size = new System.Drawing.Size(800, 110);
            this.txt_Chat.TabIndex = 1;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Chat);
            this.Controls.Add(this.panel_Board);
            this.Name = "ServerForm";
            this.Text = "세계그림판_서버";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferPanel panel_Board;
        private System.Windows.Forms.TextBox txt_Chat;
    }
}


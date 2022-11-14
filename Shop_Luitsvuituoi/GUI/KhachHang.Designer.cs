namespace Shop_Luitsvuituoi.GUI
{
    partial class KhachHang
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
            this.tableKhachHang = new System.Windows.Forms.DataGridView();
            this.id_KH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // tableKhachHang
            // 
            this.tableKhachHang.AllowUserToAddRows = false;
            this.tableKhachHang.AllowUserToResizeRows = false;
            this.tableKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_KH,
            this.tenKhachhang,
            this.phone});
            this.tableKhachHang.Location = new System.Drawing.Point(12, 79);
            this.tableKhachHang.Name = "tableKhachHang";
            this.tableKhachHang.RowHeadersVisible = false;
            this.tableKhachHang.Size = new System.Drawing.Size(798, 419);
            this.tableKhachHang.TabIndex = 0;
            this.tableKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableKhachHang_CellClick);
            // 
            // id_KH
            // 
            this.id_KH.DataPropertyName = "id_KH";
            this.id_KH.HeaderText = "Mã khách hàng";
            this.id_KH.Name = "id_KH";
            // 
            // tenKhachhang
            // 
            this.tenKhachhang.DataPropertyName = "tenKhachhang";
            this.tenKhachhang.HeaderText = "Tên khách hàng";
            this.tenKhachhang.Name = "tenKhachhang";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Số điện thoại";
            this.phone.Name = "phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhachHang.Location = new System.Drawing.Point(123, 29);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(120, 23);
            this.txtMaKhachHang.TabIndex = 2;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(366, 29);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(199, 23);
            this.txtTenKhachHang.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(571, 28);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(117, 25);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(694, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 510);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.txtMaKhachHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableKhachHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách khách hàng";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_KH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
    }
}
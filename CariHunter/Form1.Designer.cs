namespace CariHunter
{
    partial class CariHunter
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.productsTable = new System.Windows.Forms.DataGridView();
            this.product_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amount_box = new System.Windows.Forms.NumericUpDown();
            this.fetch_button = new System.Windows.Forms.Button();
            this.kill_task = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_file = new System.Windows.Forms.ToolStripMenuItem();
            this.save_file = new System.Windows.Forms.ToolStripMenuItem();
            this.save_new_file = new System.Windows.Forms.ToolStripMenuItem();
            this.update_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_box)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productsTable
            // 
            this.productsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsTable.Location = new System.Drawing.Point(10, 300);
            this.productsTable.Name = "productsTable";
            this.productsTable.RowTemplate.Height = 33;
            this.productsTable.Size = new System.Drawing.Size(2290, 800);
            this.productsTable.TabIndex = 2;
            // 
            // product_box
            // 
            this.product_box.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.product_box.Location = new System.Drawing.Point(190, 212);
            this.product_box.Name = "product_box";
            this.product_box.Size = new System.Drawing.Size(640, 31);
            this.product_box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "商品名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "取得数：";
            // 
            // amount_box
            // 
            this.amount_box.Location = new System.Drawing.Point(190, 257);
            this.amount_box.Name = "amount_box";
            this.amount_box.Size = new System.Drawing.Size(166, 31);
            this.amount_box.TabIndex = 7;
            // 
            // fetch_button
            // 
            this.fetch_button.Location = new System.Drawing.Point(925, 212);
            this.fetch_button.Name = "fetch_button";
            this.fetch_button.Size = new System.Drawing.Size(160, 50);
            this.fetch_button.TabIndex = 8;
            this.fetch_button.Text = "検索";
            this.fetch_button.UseVisualStyleBackColor = true;
            this.fetch_button.Click += new System.EventHandler(this.fetch_button_Click);
            // 
            // kill_task
            // 
            this.kill_task.Location = new System.Drawing.Point(1285, 212);
            this.kill_task.Name = "kill_task";
            this.kill_task.Size = new System.Drawing.Size(160, 50);
            this.kill_task.TabIndex = 9;
            this.kill_task.Text = "終了";
            this.kill_task.UseVisualStyleBackColor = true;
            this.kill_task.Click += new System.EventHandler(this.kill_task_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1974, 40);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file,
            this.save_file,
            this.save_new_file});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(121, 36);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // open_file
            // 
            this.open_file.Name = "open_file";
            this.open_file.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.open_file.Size = new System.Drawing.Size(401, 38);
            this.open_file.Text = "開く(&O)";
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // save_file
            // 
            this.save_file.Name = "save_file";
            this.save_file.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.save_file.Size = new System.Drawing.Size(401, 38);
            this.save_file.Text = "上書き保存(&S)";
            this.save_file.Click += new System.EventHandler(this.save_file_Click);
            // 
            // save_new_file
            // 
            this.save_new_file.Name = "save_new_file";
            this.save_new_file.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.save_new_file.Size = new System.Drawing.Size(401, 38);
            this.save_new_file.Text = "名前を付けて保存(&A)";
            this.save_new_file.Click += new System.EventHandler(this.save_new_file_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(1105, 212);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(160, 50);
            this.update_button.TabIndex = 11;
            this.update_button.Text = "更新";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // CariHunter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1974, 1129);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.kill_task);
            this.Controls.Add(this.fetch_button);
            this.Controls.Add(this.amount_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.product_box);
            this.Controls.Add(this.productsTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CariHunter";
            this.Text = "Mercari Price Checher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount_box)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productsTable;
        private System.Windows.Forms.TextBox product_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown amount_box;
        private System.Windows.Forms.Button fetch_button;
        private System.Windows.Forms.Button kill_task;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open_file;
        private System.Windows.Forms.ToolStripMenuItem save_file;
        private System.Windows.Forms.ToolStripMenuItem save_new_file;
        private System.Windows.Forms.Button update_button;
    }
}


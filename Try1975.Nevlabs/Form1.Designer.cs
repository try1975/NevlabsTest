namespace Try1975.Nevlabs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.gbLoadCsv = new System.Windows.Forms.GroupBox();
            this.cbSkipHeader = new System.Windows.Forms.CheckBox();
            this.btnLoadCsv = new System.Windows.Forms.Button();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvPerson = new ADGV.AdvancedDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.bsPerson = new System.Windows.Forms.BindingSource(this.components);
            this.pnlButtons.SuspendLayout();
            this.gbLoadCsv.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.gbLoadCsv);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(747, 75);
            this.pnlButtons.TabIndex = 0;
            // 
            // gbLoadCsv
            // 
            this.gbLoadCsv.Controls.Add(this.cbSkipHeader);
            this.gbLoadCsv.Controls.Add(this.btnLoadCsv);
            this.gbLoadCsv.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLoadCsv.Location = new System.Drawing.Point(0, 0);
            this.gbLoadCsv.Name = "gbLoadCsv";
            this.gbLoadCsv.Size = new System.Drawing.Size(301, 75);
            this.gbLoadCsv.TabIndex = 0;
            this.gbLoadCsv.TabStop = false;
            this.gbLoadCsv.Text = "Загрузка из Csv";
            // 
            // cbSkipHeader
            // 
            this.cbSkipHeader.AutoSize = true;
            this.cbSkipHeader.Location = new System.Drawing.Point(27, 49);
            this.cbSkipHeader.Name = "cbSkipHeader";
            this.cbSkipHeader.Size = new System.Drawing.Size(139, 17);
            this.cbSkipHeader.TabIndex = 1;
            this.cbSkipHeader.Text = "пропустить заголовок";
            this.cbSkipHeader.UseVisualStyleBackColor = true;
            // 
            // btnLoadCsv
            // 
            this.btnLoadCsv.Location = new System.Drawing.Point(27, 20);
            this.btnLoadCsv.Name = "btnLoadCsv";
            this.btnLoadCsv.Size = new System.Drawing.Size(233, 23);
            this.btnLoadCsv.TabIndex = 0;
            this.btnLoadCsv.Text = "Загрузить из Csv";
            this.btnLoadCsv.UseVisualStyleBackColor = true;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvPerson);
            this.pnlDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGridView.Location = new System.Drawing.Point(0, 75);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(747, 343);
            this.pnlDataGridView.TabIndex = 1;
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowUserToAddRows = false;
            this.dgvPerson.AllowUserToDeleteRows = false;
            this.dgvPerson.AllowUserToOrderColumns = true;
            this.dgvPerson.AutoGenerateContextFilters = true;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerson.DateWithTime = false;
            this.dgvPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerson.Location = new System.Drawing.Point(0, 0);
            this.dgvPerson.MultiSelect = false;
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.Size = new System.Drawing.Size(747, 343);
            this.dgvPerson.TabIndex = 0;
            this.dgvPerson.TimeFilter = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 75);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(747, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 418);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDataGridView);
            this.Controls.Add(this.pnlButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Воробьев Юрий (kf1975@mail.ru) - тестовое задание Nevlabs";
            this.pnlButtons.ResumeLayout(false);
            this.gbLoadCsv.ResumeLayout(false);
            this.gbLoadCsv.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.Splitter splitter1;
        private ADGV.AdvancedDataGridView dgvPerson;
        private System.Windows.Forms.BindingSource bsPerson;
        private System.Windows.Forms.GroupBox gbLoadCsv;
        private System.Windows.Forms.Button btnLoadCsv;
        private System.Windows.Forms.CheckBox cbSkipHeader;
    }
}


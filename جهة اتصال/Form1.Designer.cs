namespace جهة_اتصال
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // تعريف جميع العناصر
        private System.Windows.Forms.GroupBox grpStorageType;
        private System.Windows.Forms.Button btnSQL;
        private System.Windows.Forms.Button btnArray;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.GroupBox grpOperations;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ====== تعريف جميع العناصر ======
            this.grpStorageType = new System.Windows.Forms.GroupBox();
            this.btnSQL = new System.Windows.Forms.Button();
            this.btnArray = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            this.grpOperations = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();

            // ====== إعداد النموذج ======
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "إدارة جهات الاتصال";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ====== 1. GroupBox: نوع قاعدة البيانات ======
            this.grpStorageType.Location = new System.Drawing.Point(12, 12);
            this.grpStorageType.Name = "grpStorageType";
            this.grpStorageType.Size = new System.Drawing.Size(776, 70);
            this.grpStorageType.TabIndex = 0;
            this.grpStorageType.TabStop = false;
            this.grpStorageType.Text = "نوع قاعدة البيانات";

            // ====== أزرار اختيار التخزين ======
            // زر SQL
            this.btnSQL.Location = new System.Drawing.Point(20, 30);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(100, 30);
            this.btnSQL.TabIndex = 0;
            this.btnSQL.Text = "SQL";
            this.btnSQL.UseVisualStyleBackColor = true;
this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // زر Array
            this.btnArray.Location = new System.Drawing.Point(140, 30);
            this.btnArray.Name = "btnArray";
            this.btnArray.Size = new System.Drawing.Size(100, 30);
            this.btnArray.TabIndex = 1;
            this.btnArray.Text = "Array";
            this.btnArray.UseVisualStyleBackColor = true;
            this.btnArray.Click += new System.EventHandler(this.btnArray_Click);
            // زر List
            this.btnList.Location = new System.Drawing.Point(260, 30);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 30);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);

            // زر Text File
            this.btnText.Location = new System.Drawing.Point(380, 30);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(100, 30);
            this.btnText.TabIndex = 3;
            this.btnText.Text = "Text File";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);

            // ملصق الحالة
            this.lblStatus.Location = new System.Drawing.Point(500, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(260, 30);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "🟡 لم يتم اختيار نوع التخزين بعد";
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // إضافة الأزرار إلى GroupBox
            this.grpStorageType.Controls.Add(this.btnSQL);
            this.grpStorageType.Controls.Add(this.btnArray);
            this.grpStorageType.Controls.Add(this.btnList);
            this.grpStorageType.Controls.Add(this.btnText);
            this.grpStorageType.Controls.Add(this.lblStatus);

            // ====== 2. GroupBox: بيانات جهة الاتصال ======
            this.grpOperations.Location = new System.Drawing.Point(12, 90);
            this.grpOperations.Name = "grpOperations";
            this.grpOperations.Size = new System.Drawing.Size(776, 150);
            this.grpOperations.TabIndex = 1;
            this.grpOperations.TabStop = false;
            this.grpOperations.Text = "بيانات جهة الاتصال";

            // ملصق الاسم
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "الاسم:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // حقل الاسم
            this.txtName.Location = new System.Drawing.Point(120, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 1;

            // ملصق الرقم
            this.lblPhone.Location = new System.Drawing.Point(350, 30);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(80, 25);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "رقم الهاتف:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // حقل الرقم
            this.txtPhone.Location = new System.Drawing.Point(440, 30);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 25);
            this.txtPhone.TabIndex = 3;

            // ====== أزرار العمليات ======
            // زر إضافة
            this.btnAdd.Location = new System.Drawing.Point(30, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "➕ إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // زر تعديل
            this.btnUpdate.Location = new System.Drawing.Point(200, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "✏️ تعديل";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // زر حذف
            this.btnDelete.Location = new System.Drawing.Point(370, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "🗑️ حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // زر تحديث
            this.btnRefresh.Location = new System.Drawing.Point(540, 85);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "🔄 تحديث";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // إضافة العناصر إلى GroupBox
            this.grpOperations.Controls.Add(this.lblName);
            this.grpOperations.Controls.Add(this.txtName);
            this.grpOperations.Controls.Add(this.lblPhone);
            this.grpOperations.Controls.Add(this.txtPhone);
            this.grpOperations.Controls.Add(this.btnAdd);
            this.grpOperations.Controls.Add(this.btnUpdate);
            this.grpOperations.Controls.Add(this.btnDelete);
            this.grpOperations.Controls.Add(this.btnRefresh);

            // ====== 3. DataGridView لعرض البيانات ======
            this.dataGridView1.Location = new System.Drawing.Point(12, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 300);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // ====== 4. ملصق عدد السجلات ======
            this.lblCount.Location = new System.Drawing.Point(12, 560);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(200, 25);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "عدد جهات الاتصال: 0";

            // ====== إضافة جميع العناصر إلى النموذج ======
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpOperations);
            this.Controls.Add(this.grpStorageType);

            this.ResumeLayout(false);
        }
    }
}
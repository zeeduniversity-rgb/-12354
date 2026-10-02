using System;
using System.Linq;
using System.Windows.Forms;

namespace جهة_اتصال
{
    public partial class MainForm : Form
    {
        // إنشاء كائن من مدير البيانات
        private data_choos dataManager = new data_choos();

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        // ===== عند تحميل النموذج =====
        private void MainForm_Load(object sender, EventArgs e)
        {
            ref_show_box();
            UpdateStatus("لم يتم اختيار نوع التخزين بعد");
            lblCount.Text = "عدد جهات الاتصال: 0";
        }

        // ===== أزرار اختيار نوع التخزين =====
        private void btnSQL_Click(object sender, EventArgs e)
        {
            dataManager.Choos("1");
            UpdateStatus("✅ قاعدة بيانات SQL");
            ref_show_box();
        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            dataManager.Choos("2");
            UpdateStatus("✅ مصفوفة (Array)");
            ref_show_box();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataManager.Choos("3");
            UpdateStatus("✅ قائمة (List)");
            ref_show_box();
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            dataManager.Choos("4");
            UpdateStatus("✅ ملف نصي (Text File)");
            ref_show_box();
        }

        // ===== عمليات CRUD =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("⚠️ الرجاء إدخال الاسم والرقم!", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataManager.Add(txtName.Text, txtPhone.Text);
            ref_show_box();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ الرجاء تحديد جهة الاتصال المراد تعديلها!", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("⚠️ الرجاء إدخال البيانات الجديدة!", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            dataManager.Update(oldName, txtName.Text, txtPhone.Text);
            ref_show_box();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ الرجاء تحديد جهة الاتصال المراد حذفها!", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذه الجهة؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                dataManager.Delete(name);
                ref_show_box();
                ClearFields();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ref_show_box();
            MessageBox.Show("✅ تم تحديث البيانات!", "تحديث",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== عند النقر على صف في الـ DataGridView =====
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void ref_show_box()
        {
            var cont = dataManager.GetAll();

            // ربط البيانات بـ DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cont.Select(c => new
            {
                Name = c.Name,
                Phone = c.Phone
            }).ToList();

            // تحديث عدد السجلات
            lblCount.Text = $"عدد جهات الاتصال: {cont.Count}";

            // تنسيق الأعمدة
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Name"].HeaderText = "الاسم";
                dataGridView1.Columns["Name"].Width = 300;
                dataGridView1.Columns["Phone"].HeaderText = "رقم الهاتف";
                dataGridView1.Columns["Phone"].Width = 300;
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtName.Focus();
        }

        private void UpdateStatus(string status)
        {
            lblStatus.Text = status;
        }
    }
}
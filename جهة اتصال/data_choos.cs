using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace جهة_اتصال
{
    public class data_choos
    {
        public data_bes choos { get; private set; }

        public void Choos(string choice)
        {
            switch (choice)
            {
                case "1":
                    choos = new SQL();
                    MessageBox.Show(" تم التبديل إلى قاعدة بيانات SQL", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "2":
                    choos = new Masfofe();
                    MessageBox.Show("تم التبديل إلى المصفوفة (Array)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "3":
                    choos = new List();
                    MessageBox.Show(" تم التبديل إلى القائمة (List)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "4":
                    choos = new text_file();
                    MessageBox.Show(" تم التبديل إلى ملف النص (Text File)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                default:
                    MessageBox.Show(" خيار غير صحيح!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public void Add(string name, string phone)
        {
            if (choos == null)
            {
                MessageBox.Show(" الرجاء اختيار نوع قاعدة البيانات أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            choos.add(name, phone);
            MessageBox.Show(" تمت الإضافة بنجاح!", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Delete(string name)
        {
            if (choos == null)
            {
                MessageBox.Show(" الرجاء اختيار نوع قاعدة البيانات أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            choos.delet(name);
            MessageBox.Show(" تم الحذف بنجاح!", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Update(string oldName, string newName, string newPhone)
        {
            if (choos == null)
            {
                MessageBox.Show(" الرجاء اختيار نوع قاعدة البيانات أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            choos.update(oldName, newName, newPhone);
            MessageBox.Show(" تم التعديل بنجاح!", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<(string Name, string Phone)> GetAll()
        {
            if (choos == null)
            {
                MessageBox.Show("⚠️ الرجاء اختيار نوع قاعدة البيانات أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<(string, string)>();
            }
            return choos.get_all();
        }
    }

    // ===== تعريف الواجهة data_bes =====
    public interface data_bes
    {
        void add(string name, string phone);
        void delet(string name);
        void update(string oldName, string newName, string newPhone);
        List<(string Name, string Phone)> get_all();
    }

    // ===== مستودع SQL =====
    public class SQL : data_bes
    {
        string sql_data_nem = @"Server= .\ZIED ; Database=MXMSSS ; User Id= sa ;Password= 123 ;";
        static SqlConnection conn_sql;

        public void add(string name, string phone)
        {
            SqlConnection conn = new SqlConnection(sql_data_nem);
            
                conn.Open();
                string query = "INSERT INTO PHONE_BOOK (Name, Phone) VALUES (@Name, @Phone)";
            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.ExecuteNonQuery();
                
            
        }

        public void delet(string name)
        {
            SqlConnection conn = new SqlConnection(sql_data_nem);
            
                conn.Open();
                string query = "DELETE FROM PHONE_BOOK WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.ExecuteNonQuery();
                
            
        }

        public void update(string oldName, string newName, string newPhone)
        {
            SqlConnection conn = new SqlConnection(sql_data_nem);
            
                conn.Open();
                string query = "UPDATE PHONE_BOOK SET Name = @NewName, Phone = @NewPhone WHERE Name = @OldName";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@OldName", oldName);
                    cmd.Parameters.AddWithValue("@NewName", newName);
                    cmd.Parameters.AddWithValue("@NewPhone", newPhone);
                    cmd.ExecuteNonQuery();
                
            
        }

        public List<(string Name, string Phone)> get_all()
        {
            List<(string, string)> 
                comt = new List<(string, string)>();
            SqlConnection conn = new SqlConnection(sql_data_nem);
            
                conn.Open();
                string query = "SELECT Name, Phone FROM PHONE_BOOK";

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            comt.Add((reader["Name"].ToString(), reader["Phone"].ToString()));
                        }
                    
                
            
            return comt;
        }
    }

    // ===== مستودع Array =====
    public class Masfofe : data_bes
    {
        private string[] names = new string[1000];
        private string[] phones = new string[1000];
        private int count = 0;

        public void add(string name, string phone)
        {
            if (count < 1000)
            {
                names[count] = name;
                phones[count] = phone;
                count++;
            }
            else
            {
                MessageBox.Show("المصفوفة ممتلئة! الحد الأقصى 1000 جهة اتصال.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void delet(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (names[i] == name)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        names[j] = names[j + 1];
                        phones[j] = phones[j + 1];
                    }
                    count--;
                    break;
                }
            }
        }

        public void update(string oldName, string newName, string newPhone)
        {
            for (int i = 0; i < count; i++)
            {
                if (names[i] == oldName)
                {
                    names[i] = newName;
                    phones[i] = newPhone;
                    break;
                }
            }
        }

        public List<(string Name, string Phone)> get_all()
        {
            List<(string, string)>
                comt = new List<(string, string)>();
            for (int i = 0; i < count; i++)
            {
                comt.Add((names[i], phones[i]));
            }
            return comt;
        }
    }

    // ===== مستودع List =====
    public class List : data_bes
    {
        private List<(string Name, string Phone)> 
            comt = new List<(string, string)>();

        public void add(string name, string phone)
        {
            comt.Add((name, phone));
        }

        public void delet(string name)
        {
            comt.RemoveAll(c => c.Name == name);
        }

        public void update(string oldName, string newName, string newPhone)
        {
            for (int i = 0; i < comt.Count; i++)
            {
                if (comt[i].Name == oldName)
                {
                    comt[i] = (newName, newPhone);
                    break;
                }
            }
        }

        public List<(string Name, string Phone)> get_all()
        {
            return new List<(string, string)>(comt);
        }
    }

    // ===== مستودع Text File =====
    public class text_file : data_bes
    {
        private string txt = "comt.txt";

        public void add(string name, string phone)
        {
            using (StreamWriter sw = File.AppendText(txt))
            {
                sw.WriteLine($"{name}|{phone}");
            };

        }

        public void delet(string name)
        {
            if (File.Exists(txt))
            {
                List<string>
                    lines = new List<string>(File.ReadAllLines(txt));
                lines.RemoveAll(line => line.StartsWith(name + "|"));
                File.WriteAllLines(txt, lines);
            }
        }

        public void update(string oldName, string newName, string newPhone)
        {
            if (File.Exists(txt))
            {
                List<string> 
                    lines = new List<string>(File.ReadAllLines(txt));
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith(oldName + "|"))
                    {
                        lines[i] = $"{newName}|{newPhone}";
                        break;
                    }
                }
                File.WriteAllLines(txt, lines);
            }
        }

        public List<(string Name, string Phone)> get_all()
        {
            List<(string, string)> comt = new List<(string, string)>();
            if (File.Exists(txt))
            {
                foreach (string line in File.ReadAllLines(txt))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        comt.Add((parts[0], parts[1])); 
                    }
                }
            }
            return comt; 
        }
    }
}
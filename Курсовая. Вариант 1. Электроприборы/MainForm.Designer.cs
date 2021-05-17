namespace Курсовая.Вариант_1.Электроприборы
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Create = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Query = new System.Windows.Forms.Button();
            this.Edit_Form = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(12, 12);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(157, 50);
            this.Create.TabIndex = 0;
            this.Create.Text = "Добавить новую запись в БД";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(11, 68);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(158, 50);
            this.Search.TabIndex = 2;
            this.Search.Text = "Просмотр записей";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(9, 180);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(159, 50);
            this.Query.TabIndex = 3;
            this.Query.Text = "Перейти к перечню запросов из задания";
            this.Query.UseVisualStyleBackColor = true;
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // Edit_Form
            // 
            this.Edit_Form.Location = new System.Drawing.Point(10, 124);
            this.Edit_Form.Name = "Edit_Form";
            this.Edit_Form.Size = new System.Drawing.Size(158, 50);
            this.Edit_Form.TabIndex = 4;
            this.Edit_Form.Text = "Редактирование записей";
            this.Edit_Form.UseVisualStyleBackColor = true;
            this.Edit_Form.Click += new System.EventHandler(this.Edit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 240);
            this.Controls.Add(this.Edit_Form);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Create);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Электроприборы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Query;
        private System.Windows.Forms.Button Edit_Form;
    }
}


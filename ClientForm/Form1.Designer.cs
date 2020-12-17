
namespace ClientForm
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_ipserver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_porta = new System.Windows.Forms.TextBox();
            this.btn_Connetti = new System.Windows.Forms.Button();
            this.lst_messaggi = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_messaggio = new System.Windows.Forms.TextBox();
            this.btn_invia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_ipserver
            // 
            resources.ApplyResources(this.txt_ipserver, "txt_ipserver");
            this.txt_ipserver.Name = "txt_ipserver";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txt_porta
            // 
            resources.ApplyResources(this.txt_porta, "txt_porta");
            this.txt_porta.Name = "txt_porta";
            // 
            // btn_Connetti
            // 
            resources.ApplyResources(this.btn_Connetti, "btn_Connetti");
            this.btn_Connetti.Name = "btn_Connetti";
            this.btn_Connetti.UseVisualStyleBackColor = true;
            this.btn_Connetti.Click += new System.EventHandler(this.btn_Connetti_Click);
            // 
            // lst_messaggi
            // 
            this.lst_messaggi.FormattingEnabled = true;
            resources.ApplyResources(this.lst_messaggi, "lst_messaggi");
            this.lst_messaggi.Name = "lst_messaggi";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txt_messaggio
            // 
            resources.ApplyResources(this.txt_messaggio, "txt_messaggio");
            this.txt_messaggio.Name = "txt_messaggio";
            // 
            // btn_invia
            // 
            resources.ApplyResources(this.btn_invia, "btn_invia");
            this.btn_invia.Name = "btn_invia";
            this.btn_invia.UseVisualStyleBackColor = true;
            this.btn_invia.Click += new System.EventHandler(this.btn_invia_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_invia);
            this.Controls.Add(this.txt_messaggio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_messaggi);
            this.Controls.Add(this.btn_Connetti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_porta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ipserver);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ipserver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_porta;
        private System.Windows.Forms.Button btn_Connetti;
        private System.Windows.Forms.ListBox lst_messaggi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_messaggio;
        private System.Windows.Forms.Button btn_invia;
    }
}


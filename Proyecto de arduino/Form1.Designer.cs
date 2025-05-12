namespace Proyecto_de_arduino
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            comboBox1 = new ComboBox();
            aguaBox = new TextBox();
            button2 = new Button();
            humedadAmbienteBox = new TextBox();
            humedadTierraBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            temperaturaBox = new TextBox();
            label4 = new Label();
            paroEmergencia = new Button();
            bombaManual = new Button();
            label6 = new Label();
            botonReincio = new Button();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(281, 336);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 0;
            button1.Text = "Conectar al Arduino";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Interval = 250;
            timer1.Tick += timer;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 164);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 1;
            label1.Text = "Sensor Agua";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(55, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 28);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Selecciona puerto COM";
            // 
            // aguaBox
            // 
            aguaBox.Location = new Point(67, 161);
            aguaBox.Name = "aguaBox";
            aguaBox.Size = new Size(156, 27);
            aguaBox.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(281, 78);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Refrescar puerto COM";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // humedadAmbienteBox
            // 
            humedadAmbienteBox.Location = new Point(67, 223);
            humedadAmbienteBox.Name = "humedadAmbienteBox";
            humedadAmbienteBox.Size = new Size(156, 27);
            humedadAmbienteBox.TabIndex = 5;
            // 
            // humedadTierraBox
            // 
            humedadTierraBox.Location = new Point(67, 280);
            humedadTierraBox.Name = "humedadTierraBox";
            humedadTierraBox.Size = new Size(156, 27);
            humedadTierraBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 226);
            label2.Name = "label2";
            label2.Size = new Size(190, 20);
            label2.TabIndex = 7;
            label2.Text = "Sensor Humedad ambiente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 287);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 8;
            label3.Text = "Sensor Humedad Tierra";
            // 
            // temperaturaBox
            // 
            temperaturaBox.Location = new Point(445, 164);
            temperaturaBox.Name = "temperaturaBox";
            temperaturaBox.Size = new Size(156, 27);
            temperaturaBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(623, 167);
            label4.Name = "label4";
            label4.Size = new Size(160, 20);
            label4.TabIndex = 11;
            label4.Text = "Sensor de temperatura";
            // 
            // paroEmergencia
            // 
            paroEmergencia.Location = new Point(460, 336);
            paroEmergencia.Name = "paroEmergencia";
            paroEmergencia.Size = new Size(151, 29);
            paroEmergencia.TabIndex = 13;
            paroEmergencia.Text = "Paro manual";
            paroEmergencia.UseVisualStyleBackColor = true;
            paroEmergencia.Click += button3_Click;
            // 
            // bombaManual
            // 
            bombaManual.Location = new Point(55, 336);
            bombaManual.Name = "bombaManual";
            bombaManual.Size = new Size(202, 29);
            bombaManual.TabIndex = 14;
            bombaManual.Text = "Inicio de bomba manual";
            bombaManual.UseVisualStyleBackColor = true;
            bombaManual.Click += bombaManual_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 38);
            label6.Name = "label6";
            label6.Size = new Size(199, 20);
            label6.TabIndex = 15;
            label6.Text = "Seleccionar Arduino monitor";
            // 
            // botonReincio
            // 
            botonReincio.Location = new Point(632, 336);
            botonReincio.Name = "botonReincio";
            botonReincio.Size = new Size(151, 29);
            botonReincio.TabIndex = 16;
            botonReincio.Text = "Reiniciar arduino";
            botonReincio.UseVisualStyleBackColor = true;
            botonReincio.Click += botonReincio_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(445, 82);
            label7.Name = "label7";
            label7.Size = new Size(215, 20);
            label7.TabIndex = 17;
            label7.Text = "Estado del arduino: EN ESPERA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(445, 118);
            label8.Name = "label8";
            label8.Size = new Size(276, 20);
            label8.TabIndex = 18;
            label8.Text = "Estado de la conexión: DESCONECTADO";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(botonReincio);
            Controls.Add(label6);
            Controls.Add(bombaManual);
            Controls.Add(paroEmergencia);
            Controls.Add(label4);
            Controls.Add(temperaturaBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(humedadTierraBox);
            Controls.Add(humedadAmbienteBox);
            Controls.Add(button2);
            Controls.Add(aguaBox);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox aguaBox;
        private Button button2;
        private TextBox humedadAmbienteBox;
        private TextBox humedadTierraBox;
        private Label label2;
        private Label label3;
        private TextBox temperaturaBox;
        private Label label4;
        private Button paroEmergencia;
        private Button bombaManual;
        private Label label6;
        private Button botonReincio;
        private Label label7;
        private Label label8;
    }
}

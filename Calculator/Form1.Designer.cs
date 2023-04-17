using System;

namespace Calculator
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.calculationHandler = new CalculationHandler();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(202, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button1.Click += new EventHandler(Write);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(292, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button2.Click += new EventHandler(Write);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(383, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button3.Click += new EventHandler(Write);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button4.Click += new EventHandler(Write);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(292, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 55);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button5.Click += new EventHandler(Write);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(383, 197);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button6.Click += new EventHandler(Write);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(202, 274);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 55);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button7.Click += new EventHandler(Write);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(292, 274);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 55);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button8.Click += new EventHandler(Write);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(383, 274);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 55);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button9.Click += new EventHandler(Write);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(292, 344);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(70, 55);
            this.button10.TabIndex = 9;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button10.Click += new EventHandler(Write);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(475, 124);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(70, 55);
            this.button11.TabIndex = 10;
            this.button11.Text = "/";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button11.Click += new EventHandler(Write);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(475, 197);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(70, 55);
            this.button12.TabIndex = 11;
            this.button12.Text = "*";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button12.Click += new EventHandler(Write);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(475, 274);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(70, 55);
            this.button13.TabIndex = 12;
            this.button13.Text = "-";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button13.Click += new EventHandler(Write);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(475, 344);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(70, 55);
            this.button14.TabIndex = 13;
            this.button14.Text = "+";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button14.Click += new EventHandler(Write);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(202, 344);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(70, 55);
            this.button15.TabIndex = 14;
            this.button15.Text = ",";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button15.Click += new EventHandler(Write);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(383, 345);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(70, 55);
            this.button16.TabIndex = 15;
            this.button16.Text = "=";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button16.Click += new EventHandler(Write);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 76);
            this.label1.Name = "label1";
            this.label1.Text = "0";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 16;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(566, 345);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(79, 55);
            this.button17.TabIndex = 17;
            this.button17.Text = "C";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new EventHandler(calculationHandler.CalculationProcess);
            this.button17.Click += new EventHandler(Write);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Label label1;
        private Button button17;
        private CalculationHandler calculationHandler;
    }
}
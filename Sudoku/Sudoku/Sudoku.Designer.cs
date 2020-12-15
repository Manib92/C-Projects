
namespace Sudoku
{
    partial class Sudoku
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
            this.gridPanel = new System.Windows.Forms.Panel();
            this.hintsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.pencilButton = new System.Windows.Forms.Button();
            this.levelLabel = new System.Windows.Forms.Label();
            this.beginnerRadio = new System.Windows.Forms.RadioButton();
            this.intermediateRadio = new System.Windows.Forms.RadioButton();
            this.advancedRadio = new System.Windows.Forms.RadioButton();
            this.timerLabel = new System.Windows.Forms.Label();
            this.mistakesLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.Location = new System.Drawing.Point(40, 40);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(545, 545);
            this.gridPanel.TabIndex = 0;
            // 
            // hintsButton
            // 
            this.hintsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hintsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintsButton.Location = new System.Drawing.Point(660, 160);
            this.hintsButton.Name = "hintsButton";
            this.hintsButton.Size = new System.Drawing.Size(160, 50);
            this.hintsButton.TabIndex = 1;
            this.hintsButton.Text = "# of hints: 10";
            this.hintsButton.UseVisualStyleBackColor = true;
            this.hintsButton.Click += new System.EventHandler(this.hintsButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(660, 230);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(160, 50);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear Input";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // pencilButton
            // 
            this.pencilButton.BackColor = System.Drawing.Color.White;
            this.pencilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pencilButton.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pencilButton.Image = global::Sudoku.Properties.Resources.pencil2;
            this.pencilButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pencilButton.Location = new System.Drawing.Point(686, 300);
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pencilButton.Size = new System.Drawing.Size(110, 60);
            this.pencilButton.TabIndex = 8;
            this.pencilButton.Text = "Off";
            this.pencilButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pencilButton.UseVisualStyleBackColor = false;
            this.pencilButton.Click += new System.EventHandler(this.pencilButton_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.Location = new System.Drawing.Point(655, 379);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(81, 25);
            this.levelLabel.TabIndex = 4;
            this.levelLabel.Text = "Levels:";
            // 
            // beginnerRadio
            // 
            this.beginnerRadio.AutoSize = true;
            this.beginnerRadio.Checked = true;
            this.beginnerRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginnerRadio.Location = new System.Drawing.Point(660, 418);
            this.beginnerRadio.Name = "beginnerRadio";
            this.beginnerRadio.Size = new System.Drawing.Size(91, 24);
            this.beginnerRadio.TabIndex = 5;
            this.beginnerRadio.TabStop = true;
            this.beginnerRadio.Text = "Beginner";
            this.beginnerRadio.UseVisualStyleBackColor = true;
            // 
            // intermediateRadio
            // 
            this.intermediateRadio.AutoSize = true;
            this.intermediateRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intermediateRadio.Location = new System.Drawing.Point(660, 453);
            this.intermediateRadio.Name = "intermediateRadio";
            this.intermediateRadio.Size = new System.Drawing.Size(117, 24);
            this.intermediateRadio.TabIndex = 6;
            this.intermediateRadio.TabStop = true;
            this.intermediateRadio.Text = "Intermediate";
            this.intermediateRadio.UseVisualStyleBackColor = true;
            // 
            // advancedRadio
            // 
            this.advancedRadio.AutoSize = true;
            this.advancedRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedRadio.Location = new System.Drawing.Point(660, 488);
            this.advancedRadio.Name = "advancedRadio";
            this.advancedRadio.Size = new System.Drawing.Size(98, 24);
            this.advancedRadio.TabIndex = 7;
            this.advancedRadio.TabStop = true;
            this.advancedRadio.Text = "Advanced";
            this.advancedRadio.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(660, 40);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(164, 42);
            this.timerLabel.TabIndex = 9;
            this.timerLabel.Text = "00:00:00";
            // 
            // mistakesLabel
            // 
            this.mistakesLabel.AutoSize = true;
            this.mistakesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mistakesLabel.Location = new System.Drawing.Point(660, 108);
            this.mistakesLabel.Name = "mistakesLabel";
            this.mistakesLabel.Size = new System.Drawing.Size(163, 25);
            this.mistakesLabel.TabIndex = 10;
            this.mistakesLabel.Text = "# of mistakes: 0";
            // 
            // newGameButton
            // 
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameButton.Location = new System.Drawing.Point(660, 535);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(160, 50);
            this.newGameButton.TabIndex = 3;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(877, 628);
            this.Controls.Add(this.mistakesLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.advancedRadio);
            this.Controls.Add(this.intermediateRadio);
            this.Controls.Add(this.beginnerRadio);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.pencilButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.hintsButton);
            this.Controls.Add(this.gridPanel);
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Button hintsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button pencilButton;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.RadioButton beginnerRadio;
        private System.Windows.Forms.RadioButton intermediateRadio;
        private System.Windows.Forms.RadioButton advancedRadio;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label mistakesLabel;
        private System.Windows.Forms.Timer timer1;
    }
}


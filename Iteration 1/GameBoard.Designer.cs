namespace Iteration_1
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.infoBoxContainer = new System.Windows.Forms.Panel();
            this.DebugAddMoney = new System.Windows.Forms.Button();
            this.DebugAddHealth = new System.Windows.Forms.Button();
            this.DebugDamageAllEnemies = new System.Windows.Forms.Button();
            this.DebugTestWinScreen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SellLabel = new System.Windows.Forms.Label();
            this.SellButton = new System.Windows.Forms.Button();
            this.upgradeLabel = new System.Windows.Forms.Label();
            this.CurrentTowerPictureBox = new System.Windows.Forms.PictureBox();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.FireRateLabel = new System.Windows.Forms.Label();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.lblWave = new System.Windows.Forms.Label();
            this.playPauseContainer = new System.Windows.Forms.TableLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.towerSelectionContainer = new System.Windows.Forms.TableLayoutPanel();
            this.GrayTowerButton = new System.Windows.Forms.Button();
            this.GreenTowerButton = new System.Windows.Forms.Button();
            this.BlueTowerButton = new System.Windows.Forms.Button();
            this.RedTowerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BoardTbl = new System.Windows.Forms.TableLayoutPanel();
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.infoBoxContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTowerPictureBox)).BeginInit();
            this.playPauseContainer.SuspendLayout();
            this.towerSelectionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.61709F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.38291F));
            this.tableLayoutPanel1.Controls.Add(this.infoBoxContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.playPauseContainer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.towerSelectionContainer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoardTbl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.97357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.02643F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // infoBoxContainer
            // 
            this.infoBoxContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.infoBoxContainer.Controls.Add(this.pictureBox1);
            this.infoBoxContainer.Controls.Add(this.DebugAddMoney);
            this.infoBoxContainer.Controls.Add(this.DebugAddHealth);
            this.infoBoxContainer.Controls.Add(this.DebugDamageAllEnemies);
            this.infoBoxContainer.Controls.Add(this.DebugTestWinScreen);
            this.infoBoxContainer.Controls.Add(this.panel2);
            this.infoBoxContainer.Controls.Add(this.MoneyLabel);
            this.infoBoxContainer.Controls.Add(this.HealthLabel);
            this.infoBoxContainer.Controls.Add(this.lblWave);
            this.infoBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoBoxContainer.Location = new System.Drawing.Point(0, 531);
            this.infoBoxContainer.Margin = new System.Windows.Forms.Padding(0);
            this.infoBoxContainer.Name = "infoBoxContainer";
            this.infoBoxContainer.Size = new System.Drawing.Size(1019, 150);
            this.infoBoxContainer.TabIndex = 0;
            // 
            // DebugAddMoney
            // 
            this.DebugAddMoney.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DebugAddMoney.Location = new System.Drawing.Point(240, 77);
            this.DebugAddMoney.Name = "DebugAddMoney";
            this.DebugAddMoney.Size = new System.Drawing.Size(48, 48);
            this.DebugAddMoney.TabIndex = 12;
            this.DebugAddMoney.Text = "DBG: Add $$$";
            this.DebugAddMoney.UseVisualStyleBackColor = true;
            this.DebugAddMoney.Click += new System.EventHandler(this.DebugAddMoney_Click);
            // 
            // DebugAddHealth
            // 
            this.DebugAddHealth.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DebugAddHealth.Location = new System.Drawing.Point(169, 77);
            this.DebugAddHealth.Name = "DebugAddHealth";
            this.DebugAddHealth.Size = new System.Drawing.Size(48, 48);
            this.DebugAddHealth.TabIndex = 11;
            this.DebugAddHealth.Text = "DBG: Heal";
            this.DebugAddHealth.UseVisualStyleBackColor = true;
            this.DebugAddHealth.Click += new System.EventHandler(this.DebugAddHealth_Click);
            // 
            // DebugDamageAllEnemies
            // 
            this.DebugDamageAllEnemies.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DebugDamageAllEnemies.Location = new System.Drawing.Point(240, 17);
            this.DebugDamageAllEnemies.Name = "DebugDamageAllEnemies";
            this.DebugDamageAllEnemies.Size = new System.Drawing.Size(48, 48);
            this.DebugDamageAllEnemies.TabIndex = 10;
            this.DebugDamageAllEnemies.Text = "DBG: Dmg All";
            this.DebugDamageAllEnemies.UseVisualStyleBackColor = true;
            this.DebugDamageAllEnemies.Click += new System.EventHandler(this.DebugDamageAllEnemies_Click);
            // 
            // DebugTestWinScreen
            // 
            this.DebugTestWinScreen.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DebugTestWinScreen.Location = new System.Drawing.Point(169, 17);
            this.DebugTestWinScreen.Name = "DebugTestWinScreen";
            this.DebugTestWinScreen.Size = new System.Drawing.Size(48, 48);
            this.DebugTestWinScreen.TabIndex = 9;
            this.DebugTestWinScreen.Text = "DBG: Test Win";
            this.DebugTestWinScreen.UseVisualStyleBackColor = true;
            this.DebugTestWinScreen.Click += new System.EventHandler(this.DebugTestWinScreen_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.SellLabel);
            this.panel2.Controls.Add(this.SellButton);
            this.panel2.Controls.Add(this.upgradeLabel);
            this.panel2.Controls.Add(this.CurrentTowerPictureBox);
            this.panel2.Controls.Add(this.upgradeButton);
            this.panel2.Controls.Add(this.RangeLabel);
            this.panel2.Controls.Add(this.FireRateLabel);
            this.panel2.Controls.Add(this.DamageLabel);
            this.panel2.Location = new System.Drawing.Point(317, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 150);
            this.panel2.TabIndex = 8;
            // 
            // SellLabel
            // 
            this.SellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SellLabel.AutoSize = true;
            this.SellLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellLabel.Location = new System.Drawing.Point(270, 0);
            this.SellLabel.Name = "SellLabel";
            this.SellLabel.Size = new System.Drawing.Size(54, 32);
            this.SellLabel.TabIndex = 7;
            this.SellLabel.Text = "Sell";
            this.SellLabel.Visible = false;
            // 
            // SellButton
            // 
            this.SellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SellButton.Location = new System.Drawing.Point(235, 35);
            this.SellButton.Name = "SellButton";
            this.SellButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.SellButton.Size = new System.Drawing.Size(128, 100);
            this.SellButton.TabIndex = 6;
            this.SellButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SellButton.UseVisualStyleBackColor = true;
            this.SellButton.Visible = false;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // upgradeLabel
            // 
            this.upgradeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.upgradeLabel.AutoSize = true;
            this.upgradeLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeLabel.Location = new System.Drawing.Point(375, 0);
            this.upgradeLabel.Name = "upgradeLabel";
            this.upgradeLabel.Size = new System.Drawing.Size(112, 32);
            this.upgradeLabel.TabIndex = 5;
            this.upgradeLabel.Text = "Upgrade";
            this.upgradeLabel.Visible = false;
            // 
            // CurrentTowerPictureBox
            // 
            this.CurrentTowerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CurrentTowerPictureBox.Location = new System.Drawing.Point(534, 16);
            this.CurrentTowerPictureBox.Name = "CurrentTowerPictureBox";
            this.CurrentTowerPictureBox.Size = new System.Drawing.Size(128, 119);
            this.CurrentTowerPictureBox.TabIndex = 4;
            this.CurrentTowerPictureBox.TabStop = false;
            this.CurrentTowerPictureBox.Click += new System.EventHandler(this.CurrentTowerPictureBox_Click);
            // 
            // upgradeButton
            // 
            this.upgradeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upgradeButton.Location = new System.Drawing.Point(369, 35);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.upgradeButton.Size = new System.Drawing.Size(128, 100);
            this.upgradeButton.TabIndex = 3;
            this.upgradeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgradeButton.UseVisualStyleBackColor = true;
            this.upgradeButton.Visible = false;
            this.upgradeButton.Click += new System.EventHandler(this.upgradeButton_Click);
            // 
            // RangeLabel
            // 
            this.RangeLabel.AutoSize = true;
            this.RangeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeLabel.Location = new System.Drawing.Point(18, 89);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(61, 21);
            this.RangeLabel.TabIndex = 2;
            this.RangeLabel.Text = "Range: ";
            this.RangeLabel.Visible = false;
            // 
            // FireRateLabel
            // 
            this.FireRateLabel.AutoSize = true;
            this.FireRateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FireRateLabel.Location = new System.Drawing.Point(18, 61);
            this.FireRateLabel.Name = "FireRateLabel";
            this.FireRateLabel.Size = new System.Drawing.Size(78, 21);
            this.FireRateLabel.TabIndex = 1;
            this.FireRateLabel.Text = "Fire Rate: ";
            this.FireRateLabel.Visible = false;
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageLabel.Location = new System.Drawing.Point(18, 29);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(75, 21);
            this.DamageLabel.TabIndex = 0;
            this.DamageLabel.Text = "Damage: ";
            this.DamageLabel.Visible = false;
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyLabel.Location = new System.Drawing.Point(12, 95);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(62, 30);
            this.MoneyLabel.TabIndex = 5;
            this.MoneyLabel.Text = "$:200";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLabel.Location = new System.Drawing.Point(30, 61);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(46, 30);
            this.HealthLabel.TabIndex = 3;
            this.HealthLabel.Text = "100";
            this.HealthLabel.Click += new System.EventHandler(this.HealthLabel_Click);
            // 
            // lblWave
            // 
            this.lblWave.AutoSize = true;
            this.lblWave.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWave.Location = new System.Drawing.Point(3, 20);
            this.lblWave.Name = "lblWave";
            this.lblWave.Size = new System.Drawing.Size(104, 32);
            this.lblWave.TabIndex = 1;
            this.lblWave.Text = "Wave: 1";
            this.lblWave.Click += new System.EventHandler(this.lblWave_Click);
            // 
            // playPauseContainer
            // 
            this.playPauseContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.playPauseContainer.ColumnCount = 2;
            this.playPauseContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playPauseContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playPauseContainer.Controls.Add(this.StartButton, 0, 1);
            this.playPauseContainer.Controls.Add(this.MenuButton, 1, 1);
            this.playPauseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playPauseContainer.Location = new System.Drawing.Point(1019, 531);
            this.playPauseContainer.Margin = new System.Windows.Forms.Padding(0);
            this.playPauseContainer.Name = "playPauseContainer";
            this.playPauseContainer.RowCount = 3;
            this.playPauseContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playPauseContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playPauseContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playPauseContainer.Size = new System.Drawing.Size(245, 150);
            this.playPauseContainer.TabIndex = 1;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(0, 20);
            this.StartButton.Margin = new System.Windows.Forms.Padding(0);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(122, 110);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "▶️";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.MenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButton.Location = new System.Drawing.Point(122, 20);
            this.MenuButton.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(123, 110);
            this.MenuButton.TabIndex = 1;
            this.MenuButton.Text = "⚙️";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // towerSelectionContainer
            // 
            this.towerSelectionContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.towerSelectionContainer.ColumnCount = 1;
            this.towerSelectionContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.towerSelectionContainer.Controls.Add(this.GrayTowerButton, 0, 4);
            this.towerSelectionContainer.Controls.Add(this.GreenTowerButton, 0, 3);
            this.towerSelectionContainer.Controls.Add(this.BlueTowerButton, 0, 2);
            this.towerSelectionContainer.Controls.Add(this.RedTowerButton, 0, 1);
            this.towerSelectionContainer.Controls.Add(this.label1, 0, 0);
            this.towerSelectionContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.towerSelectionContainer.Location = new System.Drawing.Point(1019, 0);
            this.towerSelectionContainer.Margin = new System.Windows.Forms.Padding(0);
            this.towerSelectionContainer.Name = "towerSelectionContainer";
            this.towerSelectionContainer.RowCount = 5;
            this.towerSelectionContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.towerSelectionContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.towerSelectionContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.towerSelectionContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.towerSelectionContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.towerSelectionContainer.Size = new System.Drawing.Size(245, 531);
            this.towerSelectionContainer.TabIndex = 2;
            // 
            // GrayTowerButton
            // 
            this.GrayTowerButton.AutoSize = true;
            this.GrayTowerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.GrayTowerButton.BackgroundImage = global::Iteration_1.Properties.Resources.Gray_Tower;
            this.GrayTowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GrayTowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GrayTowerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrayTowerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.GrayTowerButton.FlatAppearance.BorderSize = 0;
            this.GrayTowerButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrayTowerButton.ForeColor = System.Drawing.Color.White;
            this.GrayTowerButton.Location = new System.Drawing.Point(0, 410);
            this.GrayTowerButton.Margin = new System.Windows.Forms.Padding(0);
            this.GrayTowerButton.Name = "GrayTowerButton";
            this.GrayTowerButton.Size = new System.Drawing.Size(245, 121);
            this.GrayTowerButton.TabIndex = 4;
            this.GrayTowerButton.Text = "Gray Tower";
            this.GrayTowerButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GrayTowerButton.UseVisualStyleBackColor = false;
            this.GrayTowerButton.Click += new System.EventHandler(this.GrayTowerButton_Click);
            // 
            // GreenTowerButton
            // 
            this.GreenTowerButton.AutoSize = true;
            this.GreenTowerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.GreenTowerButton.BackgroundImage = global::Iteration_1.Properties.Resources.Green_Tower;
            this.GreenTowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GreenTowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GreenTowerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GreenTowerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.GreenTowerButton.FlatAppearance.BorderSize = 0;
            this.GreenTowerButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTowerButton.ForeColor = System.Drawing.Color.White;
            this.GreenTowerButton.Location = new System.Drawing.Point(0, 290);
            this.GreenTowerButton.Margin = new System.Windows.Forms.Padding(0);
            this.GreenTowerButton.Name = "GreenTowerButton";
            this.GreenTowerButton.Size = new System.Drawing.Size(245, 120);
            this.GreenTowerButton.TabIndex = 3;
            this.GreenTowerButton.Text = "Green Tower";
            this.GreenTowerButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GreenTowerButton.UseVisualStyleBackColor = false;
            this.GreenTowerButton.Click += new System.EventHandler(this.GreenTowerButton_Click);
            // 
            // BlueTowerButton
            // 
            this.BlueTowerButton.AutoSize = true;
            this.BlueTowerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.BlueTowerButton.BackgroundImage = global::Iteration_1.Properties.Resources.Blue_Tower;
            this.BlueTowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BlueTowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BlueTowerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlueTowerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.BlueTowerButton.FlatAppearance.BorderSize = 0;
            this.BlueTowerButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueTowerButton.ForeColor = System.Drawing.Color.White;
            this.BlueTowerButton.Location = new System.Drawing.Point(0, 170);
            this.BlueTowerButton.Margin = new System.Windows.Forms.Padding(0);
            this.BlueTowerButton.Name = "BlueTowerButton";
            this.BlueTowerButton.Size = new System.Drawing.Size(245, 120);
            this.BlueTowerButton.TabIndex = 2;
            this.BlueTowerButton.Text = "Blue Tower";
            this.BlueTowerButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BlueTowerButton.UseVisualStyleBackColor = false;
            this.BlueTowerButton.Click += new System.EventHandler(this.BlueTowerButton_Click);
            // 
            // RedTowerButton
            // 
            this.RedTowerButton.AutoSize = true;
            this.RedTowerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.RedTowerButton.BackgroundImage = global::Iteration_1.Properties.Resources.Red_Tower;
            this.RedTowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RedTowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RedTowerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedTowerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.RedTowerButton.FlatAppearance.BorderSize = 0;
            this.RedTowerButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedTowerButton.ForeColor = System.Drawing.Color.White;
            this.RedTowerButton.Location = new System.Drawing.Point(0, 50);
            this.RedTowerButton.Margin = new System.Windows.Forms.Padding(0);
            this.RedTowerButton.Name = "RedTowerButton";
            this.RedTowerButton.Size = new System.Drawing.Size(245, 120);
            this.RedTowerButton.TabIndex = 1;
            this.RedTowerButton.Text = "Red Tower";
            this.RedTowerButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RedTowerButton.UseVisualStyleBackColor = false;
            this.RedTowerButton.Click += new System.EventHandler(this.RedTowerButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Towers";
            // 
            // BoardTbl
            // 
            this.BoardTbl.ColumnCount = 15;
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.BoardTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardTbl.Location = new System.Drawing.Point(0, 0);
            this.BoardTbl.Margin = new System.Windows.Forms.Padding(0);
            this.BoardTbl.Name = "BoardTbl";
            this.BoardTbl.RowCount = 8;
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardTbl.Size = new System.Drawing.Size(1019, 531);
            this.BoardTbl.TabIndex = 3;
            // 
            // enemyTimer
            // 
            this.enemyTimer.Interval = 75;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Iteration_1.Properties.Resources.HeartSprite;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingForm);
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.infoBoxContainer.ResumeLayout(false);
            this.infoBoxContainer.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTowerPictureBox)).EndInit();
            this.playPauseContainer.ResumeLayout(false);
            this.towerSelectionContainer.ResumeLayout(false);
            this.towerSelectionContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel infoBoxContainer;
        private System.Windows.Forms.TableLayoutPanel playPauseContainer;
        private System.Windows.Forms.TableLayoutPanel towerSelectionContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Label lblWave;
        private System.Windows.Forms.TableLayoutPanel BoardTbl;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.Button RedTowerButton;
        private System.Windows.Forms.Button GrayTowerButton;
        private System.Windows.Forms.Button GreenTowerButton;
        private System.Windows.Forms.Button BlueTowerButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button upgradeButton;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label FireRateLabel;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.Button DebugAddMoney;
        private System.Windows.Forms.Button DebugAddHealth;
        private System.Windows.Forms.Button DebugDamageAllEnemies;
        private System.Windows.Forms.Button DebugTestWinScreen;
        private System.Windows.Forms.PictureBox CurrentTowerPictureBox;
        private System.Windows.Forms.Label upgradeLabel;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Label SellLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
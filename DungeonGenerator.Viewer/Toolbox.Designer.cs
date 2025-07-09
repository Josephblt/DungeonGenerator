namespace DungeonGenerator.Viewer
{
    partial class Toolbox
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxChamber = new System.Windows.Forms.GroupBox();
            this.lblSeed = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.lblColor = new System.Windows.Forms.Label();
            this.cbxColor = new System.Windows.Forms.ComboBox();
            this.nudOutterMargin = new System.Windows.Forms.NumericUpDown();
            this.lblOuterMargin = new System.Windows.Forms.Label();
            this.gbxTiers = new System.Windows.Forms.GroupBox();
            this.nudInnerMargin = new System.Windows.Forms.NumericUpDown();
            this.lblInnerMargin = new System.Windows.Forms.Label();
            this.gbxTier1 = new System.Windows.Forms.GroupBox();
            this.nudTier1CenterSize = new System.Windows.Forms.NumericUpDown();
            this.nudTier1MazeSize = new System.Windows.Forms.NumericUpDown();
            this.lblTier1CenterSize = new System.Windows.Forms.Label();
            this.lblTier1MazeSize = new System.Windows.Forms.Label();
            this.gbxTier2 = new System.Windows.Forms.GroupBox();
            this.nudTier2CenterSize = new System.Windows.Forms.NumericUpDown();
            this.nudTier2MazeSize = new System.Windows.Forms.NumericUpDown();
            this.lblTier2CenterSize = new System.Windows.Forms.Label();
            this.lblTier2MazeSize = new System.Windows.Forms.Label();
            this.gbxTier3 = new System.Windows.Forms.GroupBox();
            this.nudTier3CenterSize = new System.Windows.Forms.NumericUpDown();
            this.nudTier3MazeSize = new System.Windows.Forms.NumericUpDown();
            this.lblTier3CenterSize = new System.Windows.Forms.Label();
            this.lblTier3MazeSize = new System.Windows.Forms.Label();
            this.gbxRooms = new System.Windows.Forms.GroupBox();
            this.nudRoomQuantity = new System.Windows.Forms.NumericUpDown();
            this.nudRoomDistance = new System.Windows.Forms.NumericUpDown();
            this.lblRoomQuantity = new System.Windows.Forms.Label();
            this.lblRoomDistance = new System.Windows.Forms.Label();
            this.nudRoomMinSize = new System.Windows.Forms.NumericUpDown();
            this.lblRoomMinSize = new System.Windows.Forms.Label();
            this.nudRoomMaxSize = new System.Windows.Forms.NumericUpDown();
            this.lblRoomMaxSize = new System.Windows.Forms.Label();
            this.nudRoomConnections = new System.Windows.Forms.NumericUpDown();
            this.lblRoomConnections = new System.Windows.Forms.Label();
            this.gbxPaths = new System.Windows.Forms.GroupBox();
            this.tkbCorridorBias = new System.Windows.Forms.TrackBar();
            this.lblCorridorBias = new System.Windows.Forms.Label();
            this.gbxDeadEnds = new System.Windows.Forms.GroupBox();
            this.lblDeadEndBias = new System.Windows.Forms.Label();
            this.tkbDeadEndBias = new System.Windows.Forms.TrackBar();
            this.nudDeadEndQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblDeadEndQuantity = new System.Windows.Forms.Label();
            this.gbxChamber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutterMargin)).BeginInit();
            this.gbxTiers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerMargin)).BeginInit();
            this.gbxTier1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier1CenterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier1MazeSize)).BeginInit();
            this.gbxTier2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier2CenterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier2MazeSize)).BeginInit();
            this.gbxTier3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier3CenterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier3MazeSize)).BeginInit();
            this.gbxRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomConnections)).BeginInit();
            this.gbxPaths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbCorridorBias)).BeginInit();
            this.gbxDeadEnds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbDeadEndBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeadEndQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(178, 431);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 55);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(178, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 55);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxChamber
            // 
            this.gbxChamber.Controls.Add(this.lblSeed);
            this.gbxChamber.Controls.Add(this.nudSeed);
            this.gbxChamber.Controls.Add(this.lblColor);
            this.gbxChamber.Controls.Add(this.cbxColor);
            this.gbxChamber.Location = new System.Drawing.Point(12, 12);
            this.gbxChamber.Name = "gbxChamber";
            this.gbxChamber.Size = new System.Drawing.Size(160, 98);
            this.gbxChamber.TabIndex = 4;
            this.gbxChamber.TabStop = false;
            this.gbxChamber.Text = "Chamber";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(6, 56);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 13);
            this.lblSeed.TabIndex = 6;
            this.lblSeed.Text = "Seed";
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(6, 72);
            this.nudSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(148, 20);
            this.nudSeed.TabIndex = 7;
            this.nudSeed.ValueChanged += new System.EventHandler(this.nudSeed_ValueChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(6, 16);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 1;
            this.lblColor.Text = "Color";
            // 
            // cbxColor
            // 
            this.cbxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColor.FormattingEnabled = true;
            this.cbxColor.Items.AddRange(new object[] {
            "RED",
            "MAGENTA",
            "BLUE",
            "CYAN",
            "GREEN",
            "YELLOW"});
            this.cbxColor.Location = new System.Drawing.Point(6, 32);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(148, 21);
            this.cbxColor.TabIndex = 0;
            this.cbxColor.SelectedIndexChanged += new System.EventHandler(this.cbxColor_SelectedIndexChanged);
            // 
            // nudOutterMargin
            // 
            this.nudOutterMargin.Location = new System.Drawing.Point(6, 32);
            this.nudOutterMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudOutterMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOutterMargin.Name = "nudOutterMargin";
            this.nudOutterMargin.Size = new System.Drawing.Size(148, 20);
            this.nudOutterMargin.TabIndex = 9;
            this.nudOutterMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOutterMargin.ValueChanged += new System.EventHandler(this.nudOutterMargin_ValueChanged);
            // 
            // lblOuterMargin
            // 
            this.lblOuterMargin.AutoSize = true;
            this.lblOuterMargin.Location = new System.Drawing.Point(6, 16);
            this.lblOuterMargin.Name = "lblOuterMargin";
            this.lblOuterMargin.Size = new System.Drawing.Size(68, 13);
            this.lblOuterMargin.TabIndex = 8;
            this.lblOuterMargin.Text = "Outer Margin";
            // 
            // gbxTiers
            // 
            this.gbxTiers.Controls.Add(this.nudOutterMargin);
            this.gbxTiers.Controls.Add(this.nudInnerMargin);
            this.gbxTiers.Controls.Add(this.lblOuterMargin);
            this.gbxTiers.Controls.Add(this.lblInnerMargin);
            this.gbxTiers.Location = new System.Drawing.Point(178, 12);
            this.gbxTiers.Name = "gbxTiers";
            this.gbxTiers.Size = new System.Drawing.Size(160, 98);
            this.gbxTiers.TabIndex = 5;
            this.gbxTiers.TabStop = false;
            this.gbxTiers.Text = "Tiers";
            // 
            // nudInnerMargin
            // 
            this.nudInnerMargin.Location = new System.Drawing.Point(6, 71);
            this.nudInnerMargin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudInnerMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInnerMargin.Name = "nudInnerMargin";
            this.nudInnerMargin.Size = new System.Drawing.Size(148, 20);
            this.nudInnerMargin.TabIndex = 13;
            this.nudInnerMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInnerMargin.ValueChanged += new System.EventHandler(this.nudInnerMargin_ValueChanged);
            // 
            // lblInnerMargin
            // 
            this.lblInnerMargin.AutoSize = true;
            this.lblInnerMargin.Location = new System.Drawing.Point(6, 55);
            this.lblInnerMargin.Name = "lblInnerMargin";
            this.lblInnerMargin.Size = new System.Drawing.Size(66, 13);
            this.lblInnerMargin.TabIndex = 12;
            this.lblInnerMargin.Text = "Inner Margin";
            // 
            // gbxTier1
            // 
            this.gbxTier1.Controls.Add(this.nudTier1CenterSize);
            this.gbxTier1.Controls.Add(this.nudTier1MazeSize);
            this.gbxTier1.Controls.Add(this.lblTier1CenterSize);
            this.gbxTier1.Controls.Add(this.lblTier1MazeSize);
            this.gbxTier1.Location = new System.Drawing.Point(178, 116);
            this.gbxTier1.Name = "gbxTier1";
            this.gbxTier1.Size = new System.Drawing.Size(160, 97);
            this.gbxTier1.TabIndex = 6;
            this.gbxTier1.TabStop = false;
            this.gbxTier1.Text = "Tier 1";
            // 
            // nudTier1CenterSize
            // 
            this.nudTier1CenterSize.Location = new System.Drawing.Point(6, 32);
            this.nudTier1CenterSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier1CenterSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier1CenterSize.Name = "nudTier1CenterSize";
            this.nudTier1CenterSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier1CenterSize.TabIndex = 15;
            this.nudTier1CenterSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier1CenterSize.ValueChanged += new System.EventHandler(this.nudTier1CenterSize_ValueChanged);
            // 
            // nudTier1MazeSize
            // 
            this.nudTier1MazeSize.Location = new System.Drawing.Point(6, 71);
            this.nudTier1MazeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier1MazeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier1MazeSize.Name = "nudTier1MazeSize";
            this.nudTier1MazeSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier1MazeSize.TabIndex = 17;
            this.nudTier1MazeSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier1MazeSize.ValueChanged += new System.EventHandler(this.nudTier1MazeSize_ValueChanged);
            // 
            // lblTier1CenterSize
            // 
            this.lblTier1CenterSize.AutoSize = true;
            this.lblTier1CenterSize.Location = new System.Drawing.Point(6, 16);
            this.lblTier1CenterSize.Name = "lblTier1CenterSize";
            this.lblTier1CenterSize.Size = new System.Drawing.Size(61, 13);
            this.lblTier1CenterSize.TabIndex = 14;
            this.lblTier1CenterSize.Text = "Center Size";
            // 
            // lblTier1MazeSize
            // 
            this.lblTier1MazeSize.AutoSize = true;
            this.lblTier1MazeSize.Location = new System.Drawing.Point(6, 55);
            this.lblTier1MazeSize.Name = "lblTier1MazeSize";
            this.lblTier1MazeSize.Size = new System.Drawing.Size(56, 13);
            this.lblTier1MazeSize.TabIndex = 16;
            this.lblTier1MazeSize.Text = "Maze Size";
            // 
            // gbxTier2
            // 
            this.gbxTier2.Controls.Add(this.nudTier2CenterSize);
            this.gbxTier2.Controls.Add(this.nudTier2MazeSize);
            this.gbxTier2.Controls.Add(this.lblTier2CenterSize);
            this.gbxTier2.Controls.Add(this.lblTier2MazeSize);
            this.gbxTier2.Location = new System.Drawing.Point(178, 219);
            this.gbxTier2.Name = "gbxTier2";
            this.gbxTier2.Size = new System.Drawing.Size(160, 97);
            this.gbxTier2.TabIndex = 7;
            this.gbxTier2.TabStop = false;
            this.gbxTier2.Text = "Tier 2";
            // 
            // nudTier2CenterSize
            // 
            this.nudTier2CenterSize.Location = new System.Drawing.Point(6, 32);
            this.nudTier2CenterSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier2CenterSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier2CenterSize.Name = "nudTier2CenterSize";
            this.nudTier2CenterSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier2CenterSize.TabIndex = 15;
            this.nudTier2CenterSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier2CenterSize.ValueChanged += new System.EventHandler(this.nudTier2CenterSize_ValueChanged);
            // 
            // nudTier2MazeSize
            // 
            this.nudTier2MazeSize.Location = new System.Drawing.Point(6, 71);
            this.nudTier2MazeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier2MazeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier2MazeSize.Name = "nudTier2MazeSize";
            this.nudTier2MazeSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier2MazeSize.TabIndex = 17;
            this.nudTier2MazeSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier2MazeSize.ValueChanged += new System.EventHandler(this.nudTier2MazeSize_ValueChanged);
            // 
            // lblTier2CenterSize
            // 
            this.lblTier2CenterSize.AutoSize = true;
            this.lblTier2CenterSize.Location = new System.Drawing.Point(6, 16);
            this.lblTier2CenterSize.Name = "lblTier2CenterSize";
            this.lblTier2CenterSize.Size = new System.Drawing.Size(61, 13);
            this.lblTier2CenterSize.TabIndex = 14;
            this.lblTier2CenterSize.Text = "Center Size";
            // 
            // lblTier2MazeSize
            // 
            this.lblTier2MazeSize.AutoSize = true;
            this.lblTier2MazeSize.Location = new System.Drawing.Point(6, 55);
            this.lblTier2MazeSize.Name = "lblTier2MazeSize";
            this.lblTier2MazeSize.Size = new System.Drawing.Size(56, 13);
            this.lblTier2MazeSize.TabIndex = 16;
            this.lblTier2MazeSize.Text = "Maze Size";
            // 
            // gbxTier3
            // 
            this.gbxTier3.Controls.Add(this.nudTier3CenterSize);
            this.gbxTier3.Controls.Add(this.nudTier3MazeSize);
            this.gbxTier3.Controls.Add(this.lblTier3CenterSize);
            this.gbxTier3.Controls.Add(this.lblTier3MazeSize);
            this.gbxTier3.Location = new System.Drawing.Point(178, 322);
            this.gbxTier3.Name = "gbxTier3";
            this.gbxTier3.Size = new System.Drawing.Size(160, 97);
            this.gbxTier3.TabIndex = 8;
            this.gbxTier3.TabStop = false;
            this.gbxTier3.Text = "Tier 3";
            // 
            // nudTier3CenterSize
            // 
            this.nudTier3CenterSize.Location = new System.Drawing.Point(6, 32);
            this.nudTier3CenterSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier3CenterSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier3CenterSize.Name = "nudTier3CenterSize";
            this.nudTier3CenterSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier3CenterSize.TabIndex = 15;
            this.nudTier3CenterSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier3CenterSize.ValueChanged += new System.EventHandler(this.nudTier3CenterSize_ValueChanged);
            // 
            // nudTier3MazeSize
            // 
            this.nudTier3MazeSize.Location = new System.Drawing.Point(6, 71);
            this.nudTier3MazeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTier3MazeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier3MazeSize.Name = "nudTier3MazeSize";
            this.nudTier3MazeSize.Size = new System.Drawing.Size(148, 20);
            this.nudTier3MazeSize.TabIndex = 17;
            this.nudTier3MazeSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTier3MazeSize.ValueChanged += new System.EventHandler(this.nudTier3MazeSize_ValueChanged);
            // 
            // lblTier3CenterSize
            // 
            this.lblTier3CenterSize.AutoSize = true;
            this.lblTier3CenterSize.Location = new System.Drawing.Point(6, 16);
            this.lblTier3CenterSize.Name = "lblTier3CenterSize";
            this.lblTier3CenterSize.Size = new System.Drawing.Size(61, 13);
            this.lblTier3CenterSize.TabIndex = 14;
            this.lblTier3CenterSize.Text = "Center Size";
            // 
            // lblTier3MazeSize
            // 
            this.lblTier3MazeSize.AutoSize = true;
            this.lblTier3MazeSize.Location = new System.Drawing.Point(6, 55);
            this.lblTier3MazeSize.Name = "lblTier3MazeSize";
            this.lblTier3MazeSize.Size = new System.Drawing.Size(56, 13);
            this.lblTier3MazeSize.TabIndex = 16;
            this.lblTier3MazeSize.Text = "Maze Size";
            // 
            // gbxRooms
            // 
            this.gbxRooms.Controls.Add(this.nudRoomConnections);
            this.gbxRooms.Controls.Add(this.lblRoomConnections);
            this.gbxRooms.Controls.Add(this.nudRoomMaxSize);
            this.gbxRooms.Controls.Add(this.lblRoomMaxSize);
            this.gbxRooms.Controls.Add(this.nudRoomMinSize);
            this.gbxRooms.Controls.Add(this.lblRoomMinSize);
            this.gbxRooms.Controls.Add(this.nudRoomQuantity);
            this.gbxRooms.Controls.Add(this.nudRoomDistance);
            this.gbxRooms.Controls.Add(this.lblRoomQuantity);
            this.gbxRooms.Controls.Add(this.lblRoomDistance);
            this.gbxRooms.Location = new System.Drawing.Point(12, 116);
            this.gbxRooms.Name = "gbxRooms";
            this.gbxRooms.Size = new System.Drawing.Size(160, 214);
            this.gbxRooms.TabIndex = 18;
            this.gbxRooms.TabStop = false;
            this.gbxRooms.Text = "Rooms";
            // 
            // nudRoomQuantity
            // 
            this.nudRoomQuantity.Location = new System.Drawing.Point(6, 32);
            this.nudRoomQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomQuantity.Name = "nudRoomQuantity";
            this.nudRoomQuantity.Size = new System.Drawing.Size(148, 20);
            this.nudRoomQuantity.TabIndex = 15;
            this.nudRoomQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomQuantity.ValueChanged += new System.EventHandler(this.nudRoomQuantity_ValueChanged);
            // 
            // nudRoomDistance
            // 
            this.nudRoomDistance.Location = new System.Drawing.Point(6, 71);
            this.nudRoomDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomDistance.Name = "nudRoomDistance";
            this.nudRoomDistance.Size = new System.Drawing.Size(148, 20);
            this.nudRoomDistance.TabIndex = 17;
            this.nudRoomDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomDistance.ValueChanged += new System.EventHandler(this.nudRoomDistance_ValueChanged);
            // 
            // lblRoomQuantity
            // 
            this.lblRoomQuantity.AutoSize = true;
            this.lblRoomQuantity.Location = new System.Drawing.Point(6, 16);
            this.lblRoomQuantity.Name = "lblRoomQuantity";
            this.lblRoomQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblRoomQuantity.TabIndex = 14;
            this.lblRoomQuantity.Text = "Quantity";
            // 
            // lblRoomDistance
            // 
            this.lblRoomDistance.AutoSize = true;
            this.lblRoomDistance.Location = new System.Drawing.Point(6, 55);
            this.lblRoomDistance.Name = "lblRoomDistance";
            this.lblRoomDistance.Size = new System.Drawing.Size(49, 13);
            this.lblRoomDistance.TabIndex = 16;
            this.lblRoomDistance.Text = "Distance";
            // 
            // nudRoomMinSize
            // 
            this.nudRoomMinSize.Location = new System.Drawing.Point(6, 110);
            this.nudRoomMinSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMinSize.Name = "nudRoomMinSize";
            this.nudRoomMinSize.Size = new System.Drawing.Size(148, 20);
            this.nudRoomMinSize.TabIndex = 19;
            this.nudRoomMinSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMinSize.ValueChanged += new System.EventHandler(this.nudRoomMinSize_ValueChanged);
            // 
            // lblRoomMinSize
            // 
            this.lblRoomMinSize.AutoSize = true;
            this.lblRoomMinSize.Location = new System.Drawing.Point(6, 94);
            this.lblRoomMinSize.Name = "lblRoomMinSize";
            this.lblRoomMinSize.Size = new System.Drawing.Size(71, 13);
            this.lblRoomMinSize.TabIndex = 18;
            this.lblRoomMinSize.Text = "Minimum Size";
            // 
            // nudRoomMaxSize
            // 
            this.nudRoomMaxSize.Location = new System.Drawing.Point(6, 149);
            this.nudRoomMaxSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMaxSize.Name = "nudRoomMaxSize";
            this.nudRoomMaxSize.Size = new System.Drawing.Size(148, 20);
            this.nudRoomMaxSize.TabIndex = 21;
            this.nudRoomMaxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMaxSize.ValueChanged += new System.EventHandler(this.nudRoomMaxSize_ValueChanged);
            // 
            // lblRoomMaxSize
            // 
            this.lblRoomMaxSize.AutoSize = true;
            this.lblRoomMaxSize.Location = new System.Drawing.Point(6, 133);
            this.lblRoomMaxSize.Name = "lblRoomMaxSize";
            this.lblRoomMaxSize.Size = new System.Drawing.Size(74, 13);
            this.lblRoomMaxSize.TabIndex = 20;
            this.lblRoomMaxSize.Text = "Maximum Size";
            // 
            // nudRoomConnections
            // 
            this.nudRoomConnections.Location = new System.Drawing.Point(6, 188);
            this.nudRoomConnections.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomConnections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomConnections.Name = "nudRoomConnections";
            this.nudRoomConnections.Size = new System.Drawing.Size(148, 20);
            this.nudRoomConnections.TabIndex = 23;
            this.nudRoomConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomConnections.ValueChanged += new System.EventHandler(this.nudRoomConnections_ValueChanged);
            // 
            // lblRoomConnections
            // 
            this.lblRoomConnections.AutoSize = true;
            this.lblRoomConnections.Location = new System.Drawing.Point(6, 172);
            this.lblRoomConnections.Name = "lblRoomConnections";
            this.lblRoomConnections.Size = new System.Drawing.Size(66, 13);
            this.lblRoomConnections.TabIndex = 22;
            this.lblRoomConnections.Text = "Connections";
            // 
            // gbxPaths
            // 
            this.gbxPaths.Controls.Add(this.lblCorridorBias);
            this.gbxPaths.Controls.Add(this.tkbCorridorBias);
            this.gbxPaths.Location = new System.Drawing.Point(12, 336);
            this.gbxPaths.Name = "gbxPaths";
            this.gbxPaths.Size = new System.Drawing.Size(160, 83);
            this.gbxPaths.TabIndex = 19;
            this.gbxPaths.TabStop = false;
            this.gbxPaths.Text = "Paths";
            // 
            // tkbCorridorBias
            // 
            this.tkbCorridorBias.Location = new System.Drawing.Point(6, 32);
            this.tkbCorridorBias.Maximum = 100;
            this.tkbCorridorBias.Name = "tkbCorridorBias";
            this.tkbCorridorBias.Size = new System.Drawing.Size(148, 45);
            this.tkbCorridorBias.TabIndex = 0;
            this.tkbCorridorBias.TickFrequency = 5;
            this.tkbCorridorBias.ValueChanged += new System.EventHandler(this.tkbCorridorBias_ValueChanged);
            // 
            // lblCorridorBias
            // 
            this.lblCorridorBias.AutoSize = true;
            this.lblCorridorBias.Location = new System.Drawing.Point(6, 16);
            this.lblCorridorBias.Name = "lblCorridorBias";
            this.lblCorridorBias.Size = new System.Drawing.Size(102, 13);
            this.lblCorridorBias.TabIndex = 24;
            this.lblCorridorBias.Text = "Corridor Length Bias";
            // 
            // gbxDeadEnds
            // 
            this.gbxDeadEnds.Controls.Add(this.nudDeadEndQuantity);
            this.gbxDeadEnds.Controls.Add(this.lblDeadEndQuantity);
            this.gbxDeadEnds.Controls.Add(this.lblDeadEndBias);
            this.gbxDeadEnds.Controls.Add(this.tkbDeadEndBias);
            this.gbxDeadEnds.Location = new System.Drawing.Point(12, 425);
            this.gbxDeadEnds.Name = "gbxDeadEnds";
            this.gbxDeadEnds.Size = new System.Drawing.Size(160, 122);
            this.gbxDeadEnds.TabIndex = 25;
            this.gbxDeadEnds.TabStop = false;
            this.gbxDeadEnds.Text = "Dead Ends";
            // 
            // lblDeadEndBias
            // 
            this.lblDeadEndBias.AutoSize = true;
            this.lblDeadEndBias.Location = new System.Drawing.Point(6, 16);
            this.lblDeadEndBias.Name = "lblDeadEndBias";
            this.lblDeadEndBias.Size = new System.Drawing.Size(27, 13);
            this.lblDeadEndBias.TabIndex = 24;
            this.lblDeadEndBias.Text = "Bias";
            // 
            // tkbDeadEndBias
            // 
            this.tkbDeadEndBias.Location = new System.Drawing.Point(6, 32);
            this.tkbDeadEndBias.Maximum = 100;
            this.tkbDeadEndBias.Name = "tkbDeadEndBias";
            this.tkbDeadEndBias.Size = new System.Drawing.Size(148, 45);
            this.tkbDeadEndBias.TabIndex = 0;
            this.tkbDeadEndBias.TickFrequency = 5;
            this.tkbDeadEndBias.ValueChanged += new System.EventHandler(this.tkbDeadEndBias_ValueChanged);
            // 
            // nudDeadEndQuantity
            // 
            this.nudDeadEndQuantity.Location = new System.Drawing.Point(6, 96);
            this.nudDeadEndQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDeadEndQuantity.Name = "nudDeadEndQuantity";
            this.nudDeadEndQuantity.Size = new System.Drawing.Size(148, 20);
            this.nudDeadEndQuantity.TabIndex = 26;
            this.nudDeadEndQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDeadEndQuantity.ValueChanged += new System.EventHandler(this.nudDeadEndQuantity_ValueChanged);
            // 
            // lblDeadEndQuantity
            // 
            this.lblDeadEndQuantity.AutoSize = true;
            this.lblDeadEndQuantity.Location = new System.Drawing.Point(6, 80);
            this.lblDeadEndQuantity.Name = "lblDeadEndQuantity";
            this.lblDeadEndQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblDeadEndQuantity.TabIndex = 25;
            this.lblDeadEndQuantity.Text = "Quantity";
            // 
            // Toolbox
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 559);
            this.ControlBox = false;
            this.Controls.Add(this.gbxDeadEnds);
            this.Controls.Add(this.gbxPaths);
            this.Controls.Add(this.gbxRooms);
            this.Controls.Add(this.gbxTier3);
            this.Controls.Add(this.gbxTier2);
            this.Controls.Add(this.gbxTier1);
            this.Controls.Add(this.gbxTiers);
            this.Controls.Add(this.gbxChamber);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toolbox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dungeon Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Toolbox_FormClosed);
            this.Load += new System.EventHandler(this.Toolbox_Load);
            this.gbxChamber.ResumeLayout(false);
            this.gbxChamber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutterMargin)).EndInit();
            this.gbxTiers.ResumeLayout(false);
            this.gbxTiers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerMargin)).EndInit();
            this.gbxTier1.ResumeLayout(false);
            this.gbxTier1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier1CenterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier1MazeSize)).EndInit();
            this.gbxTier2.ResumeLayout(false);
            this.gbxTier2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier2CenterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier2MazeSize)).EndInit();
            this.gbxTier3.ResumeLayout(false);
            this.gbxTier3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier3CenterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTier3MazeSize)).EndInit();
            this.gbxRooms.ResumeLayout(false);
            this.gbxRooms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomConnections)).EndInit();
            this.gbxPaths.ResumeLayout(false);
            this.gbxPaths.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbCorridorBias)).EndInit();
            this.gbxDeadEnds.ResumeLayout(false);
            this.gbxDeadEnds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbDeadEndBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeadEndQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxChamber;
        private System.Windows.Forms.ComboBox cbxColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.NumericUpDown nudOutterMargin;
        private System.Windows.Forms.Label lblOuterMargin;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.GroupBox gbxTiers;
        private System.Windows.Forms.NumericUpDown nudInnerMargin;
        private System.Windows.Forms.Label lblInnerMargin;
        private System.Windows.Forms.GroupBox gbxTier1;
        private System.Windows.Forms.NumericUpDown nudTier1CenterSize;
        private System.Windows.Forms.NumericUpDown nudTier1MazeSize;
        private System.Windows.Forms.Label lblTier1CenterSize;
        private System.Windows.Forms.Label lblTier1MazeSize;
        private System.Windows.Forms.GroupBox gbxTier2;
        private System.Windows.Forms.NumericUpDown nudTier2CenterSize;
        private System.Windows.Forms.NumericUpDown nudTier2MazeSize;
        private System.Windows.Forms.Label lblTier2CenterSize;
        private System.Windows.Forms.Label lblTier2MazeSize;
        private System.Windows.Forms.GroupBox gbxTier3;
        private System.Windows.Forms.NumericUpDown nudTier3CenterSize;
        private System.Windows.Forms.NumericUpDown nudTier3MazeSize;
        private System.Windows.Forms.Label lblTier3CenterSize;
        private System.Windows.Forms.Label lblTier3MazeSize;
        private System.Windows.Forms.GroupBox gbxRooms;
        private System.Windows.Forms.NumericUpDown nudRoomConnections;
        private System.Windows.Forms.Label lblRoomConnections;
        private System.Windows.Forms.NumericUpDown nudRoomMaxSize;
        private System.Windows.Forms.Label lblRoomMaxSize;
        private System.Windows.Forms.NumericUpDown nudRoomMinSize;
        private System.Windows.Forms.Label lblRoomMinSize;
        private System.Windows.Forms.NumericUpDown nudRoomQuantity;
        private System.Windows.Forms.NumericUpDown nudRoomDistance;
        private System.Windows.Forms.Label lblRoomQuantity;
        private System.Windows.Forms.Label lblRoomDistance;
        private System.Windows.Forms.GroupBox gbxPaths;
        private System.Windows.Forms.Label lblCorridorBias;
        private System.Windows.Forms.TrackBar tkbCorridorBias;
        private System.Windows.Forms.GroupBox gbxDeadEnds;
        private System.Windows.Forms.Label lblDeadEndBias;
        private System.Windows.Forms.TrackBar tkbDeadEndBias;
        private System.Windows.Forms.NumericUpDown nudDeadEndQuantity;
        private System.Windows.Forms.Label lblDeadEndQuantity;
    }
}
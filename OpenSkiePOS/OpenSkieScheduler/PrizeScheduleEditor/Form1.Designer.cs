//using BingoGameCore3;

namespace PrizeScheduleEditor
{
    partial class Form1
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
			this.gameList1 = new OpenSkieScheduler3.Controls.Lists.GameList();
			this.sessionList1 = new OpenSkieScheduler3.Controls.Lists.SessionList();
			this.sessionMacroList1 = new OpenSkieScheduler3.Controls.Lists.SessionMacroList();
			this.currrentSessionList1 = new OpenSkieScheduler3.Controls.Lists.CurrrentSessionMacroSessionList();
			this.gameGroupList1 = new OpenSkieScheduler3.Controls.Lists.PackGroupList();
			this.currentGameGroupList1 = new OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPackList();
			this.sessionGameGroupList1 = new OpenSkieScheduler3.Controls.Lists.CurrentSessionPackGroupList();
			this.currentSessionGameOrderList1 = new OpenSkieScheduler3.Controls.Lists.CurrentSessionGameOrderList();
			this.gameOrderMoveUp1 = new OpenSkieScheduler3.Controls.Buttons.GameOrderMoveUp2();
			this.gameOrderMoveDown1 = new OpenSkieScheduler3.Controls.Buttons.GameOrderMoveDown2();
			this.currentGameGroupPackList1 = new OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPackList();
			this.packList1 = new OpenSkieScheduler3.Controls.Lists.PackList();
			this.enableEdit1 = new OpenSkieScheduler3.Controls.Buttons.EnableEdit();
			this.newSessionGroup1 = new OpenSkieScheduler3.Controls.Buttons.NewSessionGroup();
			this.newSession1 = new OpenSkieScheduler3.Controls.Buttons.NewSession();
			this.newGameGroup1 = new OpenSkieScheduler3.Controls.Buttons.NewGameGroup();
			this.newGame1 = new OpenSkieScheduler3.Controls.Buttons.NewGame();
			this.editPack1 = new OpenSkieScheduler3.Controls.Buttons.EditPack();
			this.newPack1 = new OpenSkieScheduler3.Controls.Buttons.NewPack();
			this.newCardset1 = new OpenSkieScheduler3.Controls.Buttons.NewCardset();
			this.newCardsetRange1 = new OpenSkieScheduler3.Controls.Buttons.NewCardsetRange();
			this.editCardsets1 = new OpenSkieScheduler3.Controls.Buttons.EditCardsets();
			this.editCardsetRanges1 = new OpenSkieScheduler3.Controls.Buttons.EditCardsetRanges();
			this.editDealers1 = new OpenSkieScheduler3.Controls.Buttons.EditDealers();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.editPatterns1 = new OpenSkieScheduler3.Controls.Buttons.EditPatterns();
			this.textBoxGameGroupName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxGameGroupName();
			this.textBoxSessionName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxSessionName();
			this.textBoxGameName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxGameName();
			this.textBoxPackName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxPackName();
			this.textBoxSessionGroupName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxSessionGroupName();
			this.patternList1 = new OpenSkieScheduler3.Controls.Lists.PatternList();
			this.currentGamePatternList1 = new OpenSkieScheduler3.Controls.Lists.CurrentGamePatternList();
			this.deleteSession1 = new OpenSkieScheduler3.Controls.Buttons.DeleteSession();
			this.deleteSessionGroup1 = new OpenSkieScheduler3.Controls.Buttons.DeleteSessionGroup();
			this.currentPatternScroller1 = new BingoGameCore4.Controls.Patterns.CurrentPatternScroller();
			this.editSessionMacroSchedule1 = new OpenSkieScheduler3.Controls.Buttons.EditSessionMacroSchedule();
			this.editPatterns2 = new OpenSkieScheduler3.Controls.Buttons.EditPatterns();
			this.editSessionGroupSessionName1 = new OpenSkieScheduler3.Controls.Buttons.EditSessionGroupSessionName();
			this.prizeLevelList1 = new OpenSkieScheduler3.Controls.Lists.PrizeLevelList();
			this.newPrizeLevel1 = new OpenSkieScheduler3.Controls.Buttons.NewPrizeLevel();
			this.currentGameGroupPrizeList1 = new OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPrizeList();
			this.editGame1 = new OpenSkieScheduler3.Controls.Buttons.EditGame();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.deleteGameGroup1 = new OpenSkieScheduler3.Controls.Buttons.DeleteGameGroup();
			this.deleteGame1 = new OpenSkieScheduler3.Controls.Buttons.DeleteGame();
			this.deletePack1 = new OpenSkieScheduler3.Controls.Buttons.DeletePack();
			this.editGameGroupGame1 = new OpenSkieScheduler3.Controls.Buttons.EditGameGroup();
			this.deletePrizeLevel1 = new OpenSkieScheduler3.Controls.Buttons.DeletePrizeLevel();
			this.sessionOrderMoveUp1 = new OpenSkieScheduler3.Controls.Buttons.SessionOrderMoveUp();
			this.sessionOrderMoveDown1 = new OpenSkieScheduler3.Controls.Buttons.SessionOrderMoveDown();
			this.saveSchedule1 = new OpenSkieScheduler3.Controls.Buttons.SaveSchedule();
			this.loadSchedule1 = new OpenSkieScheduler3.Controls.Buttons.LoadSchedule();
			this.editPrizes1 = new OpenSkieScheduler3.Controls.Buttons.EditPrizes();
			this.textBoxPrizeLevelName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxPrizeLevelName();
			this.label20 = new System.Windows.Forms.Label();
			this.prizeLevelOrderMoveDown1 = new OpenSkieScheduler3.Controls.Buttons.GameGroupPrizeLevelOrderMoveDown();
			this.prizeLevelOrderMoveUp1 = new OpenSkieScheduler3.Controls.Buttons.GameGroupPrizeLevelOrderMoveUp();
			this.bundleList1 = new OpenSkieScheduler3.Controls.Lists.BundleList();
			this.currentSessionBundleList1 = new OpenSkieScheduler3.Controls.Lists.CurrentSessionBundleList();
			this.newBundle1 = new OpenSkieScheduler3.Controls.Buttons.NewBundle();
			this.sessionPackList1 = new OpenSkieScheduler3.Controls.Lists.CurrentSessionPackOrderList();
			this.deleteBundle1 = new OpenSkieScheduler3.Controls.Buttons.DeleteBundle();
			this.textBoxBundleName1 = new OpenSkieScheduler3.Controls.TextBoxes.TextBoxBundleName();
			this.label15 = new System.Windows.Forms.Label();
			this.currentBundlePackList1 = new OpenSkieScheduler3.Controls.Lists.CurrentSessionBundlePackList();
			this.packListTargetBundle1 = new OpenSkieScheduler3.Controls.Lists.PackListTargetBundle();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gameList1
			// 
			this.gameList1.BlockDoubleClick = true;
			this.gameList1.DisplayMember = "game_name";
			this.gameList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.gameList1.FormattingEnabled = true;
			this.gameList1.Location = new System.Drawing.Point(139, 301);
			this.gameList1.Name = "gameList1";
			this.gameList1.Size = new System.Drawing.Size(120, 95);
			this.gameList1.TabIndex = 7;
			this.gameList1.TabStops = null;
			this.gameList1.TargetList = null;
			// 
			// sessionList1
			// 
			this.sessionList1.BlockDoubleClick = true;
			this.sessionList1.DisplayMember = "session_name";
			this.sessionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionList1.FormattingEnabled = true;
			this.sessionList1.Location = new System.Drawing.Point(139, 38);
			this.sessionList1.Name = "sessionList1";
			this.sessionList1.Size = new System.Drawing.Size(120, 95);
			this.sessionList1.TabIndex = 6;
			this.sessionList1.TabStops = null;
			this.sessionList1.TargetList = null;
			// 
			// sessionMacroList1
			// 
			this.sessionMacroList1.BlockDoubleClick = true;
			this.sessionMacroList1.DisplayMember = "session_macro_name";
			this.sessionMacroList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionMacroList1.FormattingEnabled = true;
			this.sessionMacroList1.Location = new System.Drawing.Point(12, 38);
			this.sessionMacroList1.Name = "sessionMacroList1";
			this.sessionMacroList1.Size = new System.Drawing.Size(120, 95);
			this.sessionMacroList1.TabIndex = 5;
			this.sessionMacroList1.TabStops = null;
			this.sessionMacroList1.TargetList = null;
			// 
			// currrentSessionList1
			// 
			this.currrentSessionList1.BlockDoubleClick = true;
			this.currrentSessionList1.DisplayMember = "current_session_macro_session_name";
			this.currrentSessionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currrentSessionList1.FormattingEnabled = true;
			this.currrentSessionList1.Location = new System.Drawing.Point(140, 169);
			this.currrentSessionList1.Name = "currrentSessionList1";
			this.currrentSessionList1.Size = new System.Drawing.Size(120, 95);
			this.currrentSessionList1.TabIndex = 9;
			this.currrentSessionList1.TabStops = null;
			this.currrentSessionList1.TargetList = null;
			// 
			// gameGroupList1
			// 
			this.gameGroupList1.BlockDoubleClick = true;
			this.gameGroupList1.DisplayMember = "pack_group_name";
			this.gameGroupList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.gameGroupList1.FormattingEnabled = true;
			this.gameGroupList1.Location = new System.Drawing.Point(13, 301);
			this.gameGroupList1.Name = "gameGroupList1";
			this.gameGroupList1.Size = new System.Drawing.Size(120, 95);
			this.gameGroupList1.TabIndex = 11;
			this.gameGroupList1.TabStops = null;
			this.gameGroupList1.TargetList = null;
			// 
			// currentGameGroupList1
			// 
			this.currentGameGroupList1.BlockDoubleClick = true;
			this.currentGameGroupList1.DisplayMember = "current_game_group_game_name";
			this.currentGameGroupList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentGameGroupList1.FormattingEnabled = true;
			this.currentGameGroupList1.Location = new System.Drawing.Point(10, 438);
			this.currentGameGroupList1.Name = "currentGameGroupList1";
			this.currentGameGroupList1.Size = new System.Drawing.Size(120, 95);
			this.currentGameGroupList1.TabIndex = 12;
			this.currentGameGroupList1.TabStops = null;
			this.currentGameGroupList1.TargetList = null;
			// 
			// sessionGameGroupList1
			// 
			this.sessionGameGroupList1.BlockDoubleClick = true;
			this.sessionGameGroupList1.DisplayMember = "current_session_game_group_name";
			this.sessionGameGroupList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionGameGroupList1.FormattingEnabled = true;
			this.sessionGameGroupList1.Location = new System.Drawing.Point(264, 38);
			this.sessionGameGroupList1.Name = "sessionGameGroupList1";
			this.sessionGameGroupList1.Size = new System.Drawing.Size(120, 95);
			this.sessionGameGroupList1.TabIndex = 13;
			this.sessionGameGroupList1.TabStops = null;
			this.sessionGameGroupList1.TargetList = null;
			// 
			// currentSessionGameOrderList1
			// 
			this.currentSessionGameOrderList1.BlockDoubleClick = true;
			this.currentSessionGameOrderList1.DisplayMember = "current_session_game_group_game_name";
			this.currentSessionGameOrderList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentSessionGameOrderList1.FormattingEnabled = true;
			this.currentSessionGameOrderList1.Location = new System.Drawing.Point(390, 38);
			this.currentSessionGameOrderList1.Name = "currentSessionGameOrderList1";
			this.currentSessionGameOrderList1.Size = new System.Drawing.Size(333, 95);
			this.currentSessionGameOrderList1.TabIndex = 14;
			this.currentSessionGameOrderList1.TabStops = new int[] {
        90,
        190,
        210,
        230};
			this.currentSessionGameOrderList1.TargetList = null;
			// 
			// gameOrderMoveUp1
			// 
			this.gameOrderMoveUp1.Location = new System.Drawing.Point(764, 38);
			this.gameOrderMoveUp1.Name = "gameOrderMoveUp1";
			this.gameOrderMoveUp1.Size = new System.Drawing.Size(134, 23);
			this.gameOrderMoveUp1.TabIndex = 15;
			this.gameOrderMoveUp1.Text = "gameOrderMoveUp1";
			this.gameOrderMoveUp1.UseVisualStyleBackColor = true;
			// 
			// gameOrderMoveDown1
			// 
			this.gameOrderMoveDown1.Location = new System.Drawing.Point(764, 67);
			this.gameOrderMoveDown1.Name = "gameOrderMoveDown1";
			this.gameOrderMoveDown1.Size = new System.Drawing.Size(134, 23);
			this.gameOrderMoveDown1.TabIndex = 16;
			this.gameOrderMoveDown1.Text = "gameOrderMoveDown1";
			this.gameOrderMoveDown1.UseVisualStyleBackColor = true;
			// 
			// currentGameGroupPackList1
			// 
			this.currentGameGroupPackList1.BlockDoubleClick = true;
			this.currentGameGroupPackList1.DisplayMember = "current_game_group_pack_name";
			this.currentGameGroupPackList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentGameGroupPackList1.FormattingEnabled = true;
			this.currentGameGroupPackList1.Location = new System.Drawing.Point(391, 169);
			this.currentGameGroupPackList1.Name = "currentGameGroupPackList1";
			this.currentGameGroupPackList1.Size = new System.Drawing.Size(120, 95);
			this.currentGameGroupPackList1.TabIndex = 17;
			this.currentGameGroupPackList1.TabStops = null;
			this.currentGameGroupPackList1.TargetList = null;
			// 
			// packList1
			// 
			this.packList1.BlockDoubleClick = true;
			this.packList1.DisplayMember = "pack_name";
			this.packList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.packList1.FormattingEnabled = true;
			this.packList1.Location = new System.Drawing.Point(392, 302);
			this.packList1.Name = "packList1";
			this.packList1.Size = new System.Drawing.Size(120, 95);
			this.packList1.TabIndex = 18;
			this.packList1.TabStops = null;
			this.packList1.TargetList = null;
			// 
			// enableEdit1
			// 
			this.enableEdit1.AutoSize = true;
			this.enableEdit1.Location = new System.Drawing.Point(729, 140);
			this.enableEdit1.Name = "enableEdit1";
			this.enableEdit1.Size = new System.Drawing.Size(80, 17);
			this.enableEdit1.TabIndex = 19;
			this.enableEdit1.Text = "Enable Edit";
			this.enableEdit1.UseVisualStyleBackColor = true;
			// 
			// newSessionGroup1
			// 
			this.newSessionGroup1.Location = new System.Drawing.Point(650, 302);
			this.newSessionGroup1.Name = "newSessionGroup1";
			this.newSessionGroup1.Size = new System.Drawing.Size(116, 23);
			this.newSessionGroup1.TabIndex = 20;
			this.newSessionGroup1.Text = "newSessionGroup1";
			this.newSessionGroup1.UseVisualStyleBackColor = true;
			// 
			// newSession1
			// 
			this.newSession1.Location = new System.Drawing.Point(695, 326);
			this.newSession1.Name = "newSession1";
			this.newSession1.Size = new System.Drawing.Size(116, 23);
			this.newSession1.TabIndex = 21;
			this.newSession1.Text = "newSession1";
			this.newSession1.UseVisualStyleBackColor = true;
			// 
			// newGameGroup1
			// 
			this.newGameGroup1.Location = new System.Drawing.Point(732, 350);
			this.newGameGroup1.Name = "newGameGroup1";
			this.newGameGroup1.Size = new System.Drawing.Size(155, 23);
			this.newGameGroup1.TabIndex = 22;
			this.newGameGroup1.Text = "newGameGroup1";
			this.newGameGroup1.UseVisualStyleBackColor = true;
			// 
			// newGame1
			// 
			this.newGame1.Location = new System.Drawing.Point(777, 373);
			this.newGame1.Name = "newGame1";
			this.newGame1.Size = new System.Drawing.Size(110, 23);
			this.newGame1.TabIndex = 23;
			this.newGame1.Text = "newGame1";
			this.newGame1.UseVisualStyleBackColor = true;
			// 
			// editPack1
			// 
			this.editPack1.Location = new System.Drawing.Point(777, 727);
			this.editPack1.Name = "editPack1";
			this.editPack1.Size = new System.Drawing.Size(75, 23);
			this.editPack1.TabIndex = 24;
			this.editPack1.Text = "editPack1";
			this.editPack1.UseVisualStyleBackColor = true;
			// 
			// newPack1
			// 
			this.newPack1.Location = new System.Drawing.Point(776, 420);
			this.newPack1.Name = "newPack1";
			this.newPack1.Size = new System.Drawing.Size(75, 23);
			this.newPack1.TabIndex = 25;
			this.newPack1.Text = "newPack1";
			this.newPack1.UseVisualStyleBackColor = true;
			// 
			// newCardset1
			// 
			this.newCardset1.Location = new System.Drawing.Point(821, 467);
			this.newCardset1.Name = "newCardset1";
			this.newCardset1.Size = new System.Drawing.Size(138, 23);
			this.newCardset1.TabIndex = 26;
			this.newCardset1.Text = "newCardset1";
			this.newCardset1.UseVisualStyleBackColor = true;
			// 
			// newCardsetRange1
			// 
			this.newCardsetRange1.Location = new System.Drawing.Point(821, 443);
			this.newCardsetRange1.Name = "newCardsetRange1";
			this.newCardsetRange1.Size = new System.Drawing.Size(129, 23);
			this.newCardsetRange1.TabIndex = 27;
			this.newCardsetRange1.Text = "newCardsetRange1";
			this.newCardsetRange1.UseVisualStyleBackColor = true;
			// 
			// editCardsets1
			// 
			this.editCardsets1.Location = new System.Drawing.Point(19, 38);
			this.editCardsets1.Name = "editCardsets1";
			this.editCardsets1.Size = new System.Drawing.Size(100, 23);
			this.editCardsets1.TabIndex = 28;
			this.editCardsets1.Text = "editCardsets1";
			this.editCardsets1.UseVisualStyleBackColor = true;
			// 
			// editCardsetRanges1
			// 
			this.editCardsetRanges1.Location = new System.Drawing.Point(19, 62);
			this.editCardsetRanges1.Name = "editCardsetRanges1";
			this.editCardsetRanges1.Size = new System.Drawing.Size(125, 23);
			this.editCardsetRanges1.TabIndex = 29;
			this.editCardsetRanges1.Text = "editCardsetRanges1";
			this.editCardsetRanges1.UseVisualStyleBackColor = true;
			// 
			// editDealers1
			// 
			this.editDealers1.Location = new System.Drawing.Point(19, 15);
			this.editDealers1.Name = "editDealers1";
			this.editDealers1.Size = new System.Drawing.Size(75, 23);
			this.editDealers1.TabIndex = 30;
			this.editDealers1.Text = "editDealers1";
			this.editDealers1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.editDealers1);
			this.groupBox1.Controls.Add(this.editCardsetRanges1);
			this.groupBox1.Controls.Add(this.editCardsets1);
			this.groupBox1.Location = new System.Drawing.Point(523, 141);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 94);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// editPatterns1
			// 
			this.editPatterns1.Location = new System.Drawing.Point(777, 751);
			this.editPatterns1.Name = "editPatterns1";
			this.editPatterns1.Size = new System.Drawing.Size(75, 23);
			this.editPatterns1.TabIndex = 32;
			this.editPatterns1.Text = "editPatterns1";
			this.editPatterns1.UseVisualStyleBackColor = true;
			// 
			// textBoxGameGroupName1
			// 
			this.textBoxGameGroupName1.Location = new System.Drawing.Point(26, 228);
			this.textBoxGameGroupName1.Name = "textBoxGameGroupName1";
			this.textBoxGameGroupName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxGameGroupName1.TabIndex = 33;
			// 
			// textBoxSessionName1
			// 
			this.textBoxSessionName1.Location = new System.Drawing.Point(26, 192);
			this.textBoxSessionName1.Name = "textBoxSessionName1";
			this.textBoxSessionName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxSessionName1.TabIndex = 34;
			// 
			// textBoxGameName1
			// 
			this.textBoxGameName1.Location = new System.Drawing.Point(26, 263);
			this.textBoxGameName1.Name = "textBoxGameName1";
			this.textBoxGameName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxGameName1.TabIndex = 35;
			// 
			// textBoxPackName1
			// 
			this.textBoxPackName1.Location = new System.Drawing.Point(430, 282);
			this.textBoxPackName1.Name = "textBoxPackName1";
			this.textBoxPackName1.Size = new System.Drawing.Size(84, 20);
			this.textBoxPackName1.TabIndex = 36;
			this.textBoxPackName1.Text = "Blue";
			// 
			// textBoxSessionGroupName1
			// 
			this.textBoxSessionGroupName1.Location = new System.Drawing.Point(26, 155);
			this.textBoxSessionGroupName1.Name = "textBoxSessionGroupName1";
			this.textBoxSessionGroupName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxSessionGroupName1.TabIndex = 37;
			// 
			// patternList1
			// 
			this.patternList1.BlockDoubleClick = true;
			this.patternList1.DisplayMember = "pattern_name";
			this.patternList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.patternList1.FormattingEnabled = true;
			this.patternList1.Location = new System.Drawing.Point(140, 438);
			this.patternList1.Name = "patternList1";
			this.patternList1.Size = new System.Drawing.Size(120, 95);
			this.patternList1.TabIndex = 38;
			this.patternList1.TabStops = null;
			this.patternList1.TargetList = null;
			// 
			// currentGamePatternList1
			// 
			this.currentGamePatternList1.BlockDoubleClick = true;
			this.currentGamePatternList1.DisplayMember = "current_game_pattern_name";
			this.currentGamePatternList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentGamePatternList1.FormattingEnabled = true;
			this.currentGamePatternList1.Location = new System.Drawing.Point(261, 337);
			this.currentGamePatternList1.Name = "currentGamePatternList1";
			this.currentGamePatternList1.Size = new System.Drawing.Size(120, 95);
			this.currentGamePatternList1.TabIndex = 39;
			this.currentGamePatternList1.TabStops = null;
			this.currentGamePatternList1.TargetList = null;
			// 
			// deleteSession1
			// 
			this.deleteSession1.Location = new System.Drawing.Point(16, 569);
			this.deleteSession1.Name = "deleteSession1";
			this.deleteSession1.Size = new System.Drawing.Size(98, 23);
			this.deleteSession1.TabIndex = 40;
			this.deleteSession1.Text = "deleteSession1";
			this.deleteSession1.UseVisualStyleBackColor = true;
			// 
			// deleteSessionGroup1
			// 
			this.deleteSessionGroup1.Location = new System.Drawing.Point(16, 545);
			this.deleteSessionGroup1.Name = "deleteSessionGroup1";
			this.deleteSessionGroup1.Size = new System.Drawing.Size(128, 23);
			this.deleteSessionGroup1.TabIndex = 41;
			this.deleteSessionGroup1.Text = "deleteSessionGroup1";
			this.deleteSessionGroup1.UseVisualStyleBackColor = true;
			// 
			// currentPatternScroller1
			// 
			this.currentPatternScroller1.BackColor = System.Drawing.Color.Transparent;
			this.currentPatternScroller1.Composite = false;
			this.currentPatternScroller1.Location = new System.Drawing.Point(150, 538);
			this.currentPatternScroller1.Movable = false;
			this.currentPatternScroller1.Name = "currentPatternScroller1";
			this.currentPatternScroller1.Pattern = null;
			this.currentPatternScroller1.Rate = 250;
			this.currentPatternScroller1.Size = new System.Drawing.Size(86, 78);
			this.currentPatternScroller1.TabIndex = 42;
			// 
			// editSessionMacroSchedule1
			// 
			this.editSessionMacroSchedule1.Location = new System.Drawing.Point(536, 243);
			this.editSessionMacroSchedule1.Name = "editSessionMacroSchedule1";
			this.editSessionMacroSchedule1.Size = new System.Drawing.Size(207, 23);
			this.editSessionMacroSchedule1.TabIndex = 43;
			this.editSessionMacroSchedule1.Text = "editSessionMacroSchedule1";
			this.editSessionMacroSchedule1.UseVisualStyleBackColor = true;
			// 
			// editPatterns2
			// 
			this.editPatterns2.Location = new System.Drawing.Point(821, 396);
			this.editPatterns2.Name = "editPatterns2";
			this.editPatterns2.Size = new System.Drawing.Size(75, 23);
			this.editPatterns2.TabIndex = 44;
			this.editPatterns2.Text = "editPatterns2";
			this.editPatterns2.UseVisualStyleBackColor = true;
			// 
			// editSessionGroupSessionName1
			// 
			this.editSessionGroupSessionName1.Location = new System.Drawing.Point(745, 176);
			this.editSessionGroupSessionName1.Name = "editSessionGroupSessionName1";
			this.editSessionGroupSessionName1.Size = new System.Drawing.Size(196, 23);
			this.editSessionGroupSessionName1.TabIndex = 45;
			this.editSessionGroupSessionName1.Text = "editSessionGroupSessionName1";
			this.editSessionGroupSessionName1.UseVisualStyleBackColor = true;
			// 
			// prizeLevelList1
			// 
			this.prizeLevelList1.BlockDoubleClick = true;
			this.prizeLevelList1.DisplayMember = "prize_level_name";
			this.prizeLevelList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.prizeLevelList1.FormattingEnabled = true;
			this.prizeLevelList1.Location = new System.Drawing.Point(287, 481);
			this.prizeLevelList1.Name = "prizeLevelList1";
			this.prizeLevelList1.Size = new System.Drawing.Size(120, 95);
			this.prizeLevelList1.TabIndex = 47;
			this.prizeLevelList1.TabStops = null;
			this.prizeLevelList1.TargetList = null;
			// 
			// newPrizeLevel1
			// 
			this.newPrizeLevel1.Location = new System.Drawing.Point(776, 490);
			this.newPrizeLevel1.Name = "newPrizeLevel1";
			this.newPrizeLevel1.Size = new System.Drawing.Size(102, 23);
			this.newPrizeLevel1.TabIndex = 48;
			this.newPrizeLevel1.Text = "newPrizeLevel1";
			this.newPrizeLevel1.UseVisualStyleBackColor = true;
			// 
			// currentGameGroupPrizeList1
			// 
			this.currentGameGroupPrizeList1.BlockDoubleClick = true;
			this.currentGameGroupPrizeList1.DisplayMember = "pack_group_prize_level_name";
			this.currentGameGroupPrizeList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentGameGroupPrizeList1.FormattingEnabled = true;
			this.currentGameGroupPrizeList1.Location = new System.Drawing.Point(410, 703);
			this.currentGameGroupPrizeList1.Name = "currentGameGroupPrizeList1";
			this.currentGameGroupPrizeList1.Size = new System.Drawing.Size(120, 95);
			this.currentGameGroupPrizeList1.TabIndex = 49;
			this.currentGameGroupPrizeList1.TabStops = null;
			this.currentGameGroupPrizeList1.TargetList = null;
			// 
			// editGame1
			// 
			this.editGame1.Location = new System.Drawing.Point(777, 775);
			this.editGame1.Name = "editGame1";
			this.editGame1.Size = new System.Drawing.Size(75, 23);
			this.editGame1.TabIndex = 24;
			this.editGame1.Text = "editGame1";
			this.editGame1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 13);
			this.label1.TabIndex = 50;
			this.label1.Text = "Session Macros(day)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(136, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 51;
			this.label2.Text = "Sessions";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(261, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 13);
			this.label3.TabIndex = 52;
			this.label3.Text = "Session\'s Game Groups";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(388, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 13);
			this.label4.TabIndex = 53;
			this.label4.Text = "Session\'s Games(Order)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(137, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(132, 13);
			this.label5.TabIndex = 54;
			this.label5.Text = "Daily Sessions(SessName)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(387, 153);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 13);
			this.label6.TabIndex = 55;
			this.label6.Text = "Game Group\'s Packs";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 285);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 13);
			this.label7.TabIndex = 56;
			this.label7.Text = "Game Groups";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(136, 285);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 57;
			this.label8.Text = "Games";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(387, 286);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 58;
			this.label9.Text = "Packs";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(265, 321);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 13);
			this.label10.TabIndex = 59;
			this.label10.Text = "Game\'s Patterns";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 419);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(110, 13);
			this.label11.TabIndex = 60;
			this.label11.Text = "Game Group\'s Games";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(137, 422);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 13);
			this.label12.TabIndex = 61;
			this.label12.Text = "Patterns";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(284, 462);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 13);
			this.label13.TabIndex = 62;
			this.label13.Text = "Prize Levels";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(409, 683);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 13);
			this.label14.TabIndex = 63;
			this.label14.Text = "Game Group\'s Prizes";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(10, 141);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(108, 13);
			this.label16.TabIndex = 65;
			this.label16.Text = "Session Macro Name";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(10, 176);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(75, 13);
			this.label17.TabIndex = 66;
			this.label17.Text = "Session Name";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(13, 212);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(98, 13);
			this.label18.TabIndex = 67;
			this.label18.Text = "Game Group Name";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(13, 248);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(66, 13);
			this.label19.TabIndex = 68;
			this.label19.Text = "Game Name";
			// 
			// deleteGameGroup1
			// 
			this.deleteGameGroup1.Location = new System.Drawing.Point(16, 593);
			this.deleteGameGroup1.Name = "deleteGameGroup1";
			this.deleteGameGroup1.Size = new System.Drawing.Size(118, 23);
			this.deleteGameGroup1.TabIndex = 69;
			this.deleteGameGroup1.Text = "deleteGameGroup1";
			this.deleteGameGroup1.UseVisualStyleBackColor = true;
			// 
			// deleteGame1
			// 
			this.deleteGame1.Location = new System.Drawing.Point(16, 617);
			this.deleteGame1.Name = "deleteGame1";
			this.deleteGame1.Size = new System.Drawing.Size(88, 23);
			this.deleteGame1.TabIndex = 70;
			this.deleteGame1.Text = "deleteGame1";
			this.deleteGame1.UseVisualStyleBackColor = true;
			// 
			// deletePack1
			// 
			this.deletePack1.Location = new System.Drawing.Point(16, 641);
			this.deletePack1.Name = "deletePack1";
			this.deletePack1.Size = new System.Drawing.Size(86, 23);
			this.deletePack1.TabIndex = 71;
			this.deletePack1.Text = "deletePack1";
			this.deletePack1.UseVisualStyleBackColor = true;
			// 
			// editGameGroupGame1
			// 
			this.editGameGroupGame1.Location = new System.Drawing.Point(764, 92);
			this.editGameGroupGame1.Name = "editGameGroupGame1";
			this.editGameGroupGame1.Size = new System.Drawing.Size(138, 23);
			this.editGameGroupGame1.TabIndex = 72;
			this.editGameGroupGame1.Text = "editGameGroupGame1";
			this.editGameGroupGame1.UseVisualStyleBackColor = true;
			// 
			// deletePrizeLevel1
			// 
			this.deletePrizeLevel1.Location = new System.Drawing.Point(16, 665);
			this.deletePrizeLevel1.Name = "deletePrizeLevel1";
			this.deletePrizeLevel1.Size = new System.Drawing.Size(102, 23);
			this.deletePrizeLevel1.TabIndex = 73;
			this.deletePrizeLevel1.Text = "deletePrizeLevel1";
			this.deletePrizeLevel1.UseVisualStyleBackColor = true;
			// 
			// sessionOrderMoveUp1
			// 
			this.sessionOrderMoveUp1.Location = new System.Drawing.Point(261, 169);
			this.sessionOrderMoveUp1.Name = "sessionOrderMoveUp1";
			this.sessionOrderMoveUp1.Size = new System.Drawing.Size(112, 23);
			this.sessionOrderMoveUp1.TabIndex = 74;
			this.sessionOrderMoveUp1.Text = "sessionOrderMoveUp1";
			this.sessionOrderMoveUp1.UseVisualStyleBackColor = true;
			// 
			// sessionOrderMoveDown1
			// 
			this.sessionOrderMoveDown1.Location = new System.Drawing.Point(261, 198);
			this.sessionOrderMoveDown1.Name = "sessionOrderMoveDown1";
			this.sessionOrderMoveDown1.Size = new System.Drawing.Size(139, 23);
			this.sessionOrderMoveDown1.TabIndex = 75;
			this.sessionOrderMoveDown1.Text = "sessionOrderMoveDown1";
			this.sessionOrderMoveDown1.UseVisualStyleBackColor = true;
			// 
			// saveSchedule1
			// 
			this.saveSchedule1.Location = new System.Drawing.Point(875, 785);
			this.saveSchedule1.Name = "saveSchedule1";
			this.saveSchedule1.Size = new System.Drawing.Size(103, 23);
			this.saveSchedule1.TabIndex = 76;
			this.saveSchedule1.Text = "saveSchedule1";
			this.saveSchedule1.UseVisualStyleBackColor = true;
			// 
			// loadSchedule1
			// 
			this.loadSchedule1.Location = new System.Drawing.Point(875, 809);
			this.loadSchedule1.Name = "loadSchedule1";
			this.loadSchedule1.Size = new System.Drawing.Size(103, 23);
			this.loadSchedule1.TabIndex = 77;
			this.loadSchedule1.Text = "loadSchedule1";
			this.loadSchedule1.UseVisualStyleBackColor = true;
			// 
			// editPrizes1
			// 
			this.editPrizes1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.editPrizes1.Location = new System.Drawing.Point(668, 809);
			this.editPrizes1.Name = "editPrizes1";
			this.editPrizes1.Size = new System.Drawing.Size(75, 23);
			this.editPrizes1.TabIndex = 79;
			this.editPrizes1.Text = "editPrizes1";
			this.editPrizes1.UseVisualStyleBackColor = false;
			// 
			// textBoxPrizeLevelName1
			// 
			this.textBoxPrizeLevelName1.Location = new System.Drawing.Point(287, 593);
			this.textBoxPrizeLevelName1.Name = "textBoxPrizeLevelName1";
			this.textBoxPrizeLevelName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrizeLevelName1.TabIndex = 81;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(283, 581);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(61, 13);
			this.label20.TabIndex = 82;
			this.label20.Text = "Prize Name";
			// 
			// prizeLevelOrderMoveDown1
			// 
			this.prizeLevelOrderMoveDown1.Location = new System.Drawing.Point(538, 732);
			this.prizeLevelOrderMoveDown1.Name = "prizeLevelOrderMoveDown1";
			this.prizeLevelOrderMoveDown1.Size = new System.Drawing.Size(157, 23);
			this.prizeLevelOrderMoveDown1.TabIndex = 83;
			this.prizeLevelOrderMoveDown1.Text = "prizeLevelOrderMoveDown1";
			this.prizeLevelOrderMoveDown1.UseVisualStyleBackColor = true;
			// 
			// prizeLevelOrderMoveUp1
			// 
			this.prizeLevelOrderMoveUp1.Location = new System.Drawing.Point(538, 703);
			this.prizeLevelOrderMoveUp1.Name = "prizeLevelOrderMoveUp1";
			this.prizeLevelOrderMoveUp1.Size = new System.Drawing.Size(157, 23);
			this.prizeLevelOrderMoveUp1.TabIndex = 84;
			this.prizeLevelOrderMoveUp1.Text = "prizeLevelOrderMoveUp1";
			this.prizeLevelOrderMoveUp1.UseVisualStyleBackColor = true;
			// 
			// bundleList1
			// 
			this.bundleList1.BlockDoubleClick = true;
			this.bundleList1.DisplayMember = "bundle_name";
			this.bundleList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.bundleList1.FormattingEnabled = true;
			this.bundleList1.Location = new System.Drawing.Point(603, 545);
			this.bundleList1.Name = "bundleList1";
			this.bundleList1.Size = new System.Drawing.Size(120, 95);
			this.bundleList1.TabIndex = 85;
			this.bundleList1.TabStops = null;
			this.bundleList1.TargetList = null;
			// 
			// currentSessionBundleList1
			// 
			this.currentSessionBundleList1.BlockDoubleClick = true;
			this.currentSessionBundleList1.DisplayMember = "current_session_bundle_name";
			this.currentSessionBundleList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentSessionBundleList1.FormattingEnabled = true;
			this.currentSessionBundleList1.Location = new System.Drawing.Point(440, 564);
			this.currentSessionBundleList1.Name = "currentSessionBundleList1";
			this.currentSessionBundleList1.Size = new System.Drawing.Size(120, 95);
			this.currentSessionBundleList1.TabIndex = 86;
			this.currentSessionBundleList1.TabStops = null;
			this.currentSessionBundleList1.TargetList = null;
			// 
			// newBundle1
			// 
			this.newBundle1.Location = new System.Drawing.Point(777, 513);
			this.newBundle1.Name = "newBundle1";
			this.newBundle1.Size = new System.Drawing.Size(75, 23);
			this.newBundle1.TabIndex = 87;
			this.newBundle1.Text = "newBundle1";
			this.newBundle1.UseVisualStyleBackColor = true;
			// 
			// sessionPackList1
			// 
			this.sessionPackList1.BlockDoubleClick = true;
			this.sessionPackList1.DisplayMember = "Name";
			this.sessionPackList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionPackList1.FormattingEnabled = true;
			this.sessionPackList1.Location = new System.Drawing.Point(523, 273);
			this.sessionPackList1.Name = "sessionPackList1";
			this.sessionPackList1.Size = new System.Drawing.Size(120, 95);
			this.sessionPackList1.TabIndex = 89;
			this.sessionPackList1.TabStops = null;
			this.sessionPackList1.TargetList = null;
			// 
			// deleteBundle1
			// 
			this.deleteBundle1.Location = new System.Drawing.Point(124, 641);
			this.deleteBundle1.Name = "deleteBundle1";
			this.deleteBundle1.Size = new System.Drawing.Size(92, 23);
			this.deleteBundle1.TabIndex = 90;
			this.deleteBundle1.Text = "deleteBundle1";
			this.deleteBundle1.UseVisualStyleBackColor = true;
			// 
			// textBoxBundleName1
			// 
			this.textBoxBundleName1.Location = new System.Drawing.Point(623, 519);
			this.textBoxBundleName1.Name = "textBoxBundleName1";
			this.textBoxBundleName1.Size = new System.Drawing.Size(100, 20);
			this.textBoxBundleName1.TabIndex = 91;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(600, 503);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(54, 13);
			this.label15.TabIndex = 92;
			this.label15.Text = "Bundles...";
			// 
			// currentBundlePackList1
			// 
			this.currentBundlePackList1.BlockDoubleClick = true;
			this.currentBundlePackList1.DisplayMember = "current_bundle_pack_name";
			this.currentBundlePackList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.currentBundlePackList1.FormattingEnabled = true;
			this.currentBundlePackList1.Location = new System.Drawing.Point(732, 569);
			this.currentBundlePackList1.Name = "currentBundlePackList1";
			this.currentBundlePackList1.Size = new System.Drawing.Size(120, 95);
			this.currentBundlePackList1.TabIndex = 94;
			this.currentBundlePackList1.TabStops = null;
			this.currentBundlePackList1.TargetList = null;
			// 
			// packListTargetBundle1
			// 
			this.packListTargetBundle1.BlockDoubleClick = true;
			this.packListTargetBundle1.DisplayMember = "pack_name";
			this.packListTargetBundle1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.packListTargetBundle1.FormattingEnabled = true;
			this.packListTargetBundle1.Location = new System.Drawing.Point(858, 538);
			this.packListTargetBundle1.Name = "packListTargetBundle1";
			this.packListTargetBundle1.Size = new System.Drawing.Size(120, 95);
			this.packListTargetBundle1.TabIndex = 95;
			this.packListTargetBundle1.TabStops = null;
			this.packListTargetBundle1.TargetList = null;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(875, 683);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 96;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1226, 885);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.packListTargetBundle1);
			this.Controls.Add(this.currentBundlePackList1);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.textBoxBundleName1);
			this.Controls.Add(this.deleteBundle1);
			this.Controls.Add(this.sessionPackList1);
			this.Controls.Add(this.newBundle1);
			this.Controls.Add(this.currentSessionBundleList1);
			this.Controls.Add(this.bundleList1);
			this.Controls.Add(this.prizeLevelOrderMoveUp1);
			this.Controls.Add(this.prizeLevelOrderMoveDown1);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.textBoxPrizeLevelName1);
			this.Controls.Add(this.editPrizes1);
			this.Controls.Add(this.loadSchedule1);
			this.Controls.Add(this.saveSchedule1);
			this.Controls.Add(this.sessionOrderMoveDown1);
			this.Controls.Add(this.sessionOrderMoveUp1);
			this.Controls.Add(this.deletePrizeLevel1);
			this.Controls.Add(this.editGameGroupGame1);
			this.Controls.Add(this.deletePack1);
			this.Controls.Add(this.deleteGame1);
			this.Controls.Add(this.deleteGameGroup1);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.currentGameGroupPrizeList1);
			this.Controls.Add(this.newPrizeLevel1);
			this.Controls.Add(this.prizeLevelList1);
			this.Controls.Add(this.editSessionGroupSessionName1);
			this.Controls.Add(this.editPatterns2);
			this.Controls.Add(this.editSessionMacroSchedule1);
			this.Controls.Add(this.currentPatternScroller1);
			this.Controls.Add(this.deleteSessionGroup1);
			this.Controls.Add(this.deleteSession1);
			this.Controls.Add(this.currentGamePatternList1);
			this.Controls.Add(this.patternList1);
			this.Controls.Add(this.textBoxSessionGroupName1);
			this.Controls.Add(this.textBoxPackName1);
			this.Controls.Add(this.textBoxGameName1);
			this.Controls.Add(this.textBoxSessionName1);
			this.Controls.Add(this.textBoxGameGroupName1);
			this.Controls.Add(this.editPatterns1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.newCardsetRange1);
			this.Controls.Add(this.newCardset1);
			this.Controls.Add(this.newPack1);
			this.Controls.Add(this.editGame1);
			this.Controls.Add(this.editPack1);
			this.Controls.Add(this.newGame1);
			this.Controls.Add(this.newGameGroup1);
			this.Controls.Add(this.newSession1);
			this.Controls.Add(this.newSessionGroup1);
			this.Controls.Add(this.enableEdit1);
			this.Controls.Add(this.packList1);
			this.Controls.Add(this.currentGameGroupPackList1);
			this.Controls.Add(this.gameOrderMoveDown1);
			this.Controls.Add(this.gameOrderMoveUp1);
			this.Controls.Add(this.currentSessionGameOrderList1);
			this.Controls.Add(this.sessionGameGroupList1);
			this.Controls.Add(this.currentGameGroupList1);
			this.Controls.Add(this.gameGroupList1);
			this.Controls.Add(this.currrentSessionList1);
			this.Controls.Add(this.gameList1);
			this.Controls.Add(this.sessionList1);
			this.Controls.Add(this.sessionMacroList1);
			this.Name = "Form1";
			this.Text = "Prize Schedule Editor";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

		private OpenSkieScheduler3.Controls.Lists.SessionMacroList sessionMacroList1;
		private OpenSkieScheduler3.Controls.Lists.SessionList sessionList1;
		private OpenSkieScheduler3.Controls.Lists.GameList gameList1;
		private OpenSkieScheduler3.Controls.Lists.CurrrentSessionMacroSessionList currrentSessionList1;
		private OpenSkieScheduler3.Controls.Lists.PackGroupList gameGroupList1;
		private OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPackList currentGameGroupList1;
		private OpenSkieScheduler3.Controls.Lists.CurrentSessionPackGroupList sessionGameGroupList1;
		private OpenSkieScheduler3.Controls.Lists.CurrentSessionGameOrderList currentSessionGameOrderList1;
		private OpenSkieScheduler3.Controls.Buttons.GameOrderMoveUp2 gameOrderMoveUp1;
		private OpenSkieScheduler3.Controls.Buttons.GameOrderMoveDown2 gameOrderMoveDown1;
		private OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPackList currentGameGroupPackList1;
		private OpenSkieScheduler3.Controls.Lists.PackList packList1;
		private OpenSkieScheduler3.Controls.Buttons.EnableEdit enableEdit1;
		private OpenSkieScheduler3.Controls.Buttons.NewSessionGroup newSessionGroup1;
		private OpenSkieScheduler3.Controls.Buttons.NewSession newSession1;
		private OpenSkieScheduler3.Controls.Buttons.NewGameGroup newGameGroup1;
		private OpenSkieScheduler3.Controls.Buttons.NewGame newGame1;
		private OpenSkieScheduler3.Controls.Buttons.EditPack editPack1;
		private OpenSkieScheduler3.Controls.Buttons.NewPack newPack1;
		private OpenSkieScheduler3.Controls.Buttons.NewCardset newCardset1;
		private OpenSkieScheduler3.Controls.Buttons.NewCardsetRange newCardsetRange1;
		private OpenSkieScheduler3.Controls.Buttons.EditCardsets editCardsets1;
		private OpenSkieScheduler3.Controls.Buttons.EditCardsetRanges editCardsetRanges1;
		private OpenSkieScheduler3.Controls.Buttons.EditDealers editDealers1;
		private System.Windows.Forms.GroupBox groupBox1;
		private OpenSkieScheduler3.Controls.Buttons.EditPatterns editPatterns1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxGameGroupName textBoxGameGroupName1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxSessionName textBoxSessionName1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxGameName textBoxGameName1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxPackName textBoxPackName1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxSessionGroupName textBoxSessionGroupName1;
		private OpenSkieScheduler3.Controls.Lists.PatternList patternList1;
		private OpenSkieScheduler3.Controls.Lists.CurrentGamePatternList currentGamePatternList1;
		private OpenSkieScheduler3.Controls.Buttons.DeleteSession deleteSession1;
		private OpenSkieScheduler3.Controls.Buttons.DeleteSessionGroup deleteSessionGroup1;
		private BingoGameCore4.Controls.Patterns.CurrentPatternScroller currentPatternScroller1;
		private OpenSkieScheduler3.Controls.Buttons.EditSessionMacroSchedule editSessionMacroSchedule1;
		private OpenSkieScheduler3.Controls.Buttons.EditPatterns editPatterns2;
		private OpenSkieScheduler3.Controls.Buttons.EditSessionGroupSessionName editSessionGroupSessionName1;
		private OpenSkieScheduler3.Controls.Lists.PrizeLevelList prizeLevelList1;
		private OpenSkieScheduler3.Controls.Buttons.NewPrizeLevel newPrizeLevel1;
		private OpenSkieScheduler3.Controls.Lists.CurrentGameGroupPrizeList currentGameGroupPrizeList1;
		private OpenSkieScheduler3.Controls.Buttons.EditGame editGame1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private OpenSkieScheduler3.Controls.Buttons.DeleteGameGroup deleteGameGroup1;
		private OpenSkieScheduler3.Controls.Buttons.DeleteGame deleteGame1;
		private OpenSkieScheduler3.Controls.Buttons.DeletePack deletePack1;
		private OpenSkieScheduler3.Controls.Buttons.EditGameGroup editGameGroupGame1;
		private OpenSkieScheduler3.Controls.Buttons.DeletePrizeLevel deletePrizeLevel1;
		private OpenSkieScheduler3.Controls.Buttons.SessionOrderMoveUp sessionOrderMoveUp1;
		private OpenSkieScheduler3.Controls.Buttons.SessionOrderMoveDown sessionOrderMoveDown1;
		private OpenSkieScheduler3.Controls.Buttons.SaveSchedule saveSchedule1;
		private OpenSkieScheduler3.Controls.Buttons.LoadSchedule loadSchedule1;
		private OpenSkieScheduler3.Controls.Buttons.EditPrizes editPrizes1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxPrizeLevelName textBoxPrizeLevelName1;
		private System.Windows.Forms.Label label20;
		private OpenSkieScheduler3.Controls.Buttons.GameGroupPrizeLevelOrderMoveDown prizeLevelOrderMoveDown1;
		private OpenSkieScheduler3.Controls.Buttons.GameGroupPrizeLevelOrderMoveUp prizeLevelOrderMoveUp1;
		private OpenSkieScheduler3.Controls.Lists.BundleList bundleList1;
		private OpenSkieScheduler3.Controls.Lists.CurrentSessionBundleList currentSessionBundleList1;
		private OpenSkieScheduler3.Controls.Buttons.NewBundle newBundle1;
		private OpenSkieScheduler3.Controls.Lists.CurrentSessionPackOrderList sessionPackList1;
		private OpenSkieScheduler3.Controls.Buttons.DeleteBundle deleteBundle1;
		private OpenSkieScheduler3.Controls.TextBoxes.TextBoxBundleName textBoxBundleName1;
		private System.Windows.Forms.Label label15;
		private OpenSkieScheduler3.Controls.Lists.CurrentSessionBundlePackList currentBundlePackList1;
        //private OpenSkieScheduler3.Controls.Buttons.DumpSessionToBlob dumpSessionToBlob1;
		private OpenSkieScheduler3.Controls.Lists.PackListTargetBundle packListTargetBundle1;
		private System.Windows.Forms.Button button1;
    }
}


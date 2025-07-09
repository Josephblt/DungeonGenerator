using DungeonGenerator.Base.Creators;
using System;
using System.Windows.Forms;
using static DungeonGenerator.Base.Creators.AlchromistCreator;

namespace DungeonGenerator.Viewer
{
    public partial class Toolbox : Form
    {
        #region Constructor

        public Toolbox()
        {
            _creator = new AlchromistCreator();
            InitializeComponent();
        }

        #endregion

        #region Delegate

        public delegate void CreateCalledHandler(AlchromistCreator creator);
        public delegate void SaveCalledHandler();

        #endregion

        #region Events

        public event CreateCalledHandler CreateCalled;
        public event SaveCalledHandler SaveCalled;

        #endregion

        #region Private Fields

        private AlchromistCreator _creator;

        #endregion

        #region Private Methods

        private void UpdateColor()
        {
            switch (_creator.Chamber)
            {
                case Chambers.CYAN:
                    cbxColor.SelectedItem = "CYAN";
                    break;
                case Chambers.RED:
                    cbxColor.SelectedItem = "RED";
                    break;
                case Chambers.MAGENTA:
                    cbxColor.SelectedItem = "MAGENTA";
                    break;
                case Chambers.GREEN:
                    cbxColor.SelectedItem = "GREEN";
                    break;
                case Chambers.YELLOW:
                    cbxColor.SelectedItem = "YELLOW";
                    break;
                case Chambers.BLUE:
                    cbxColor.SelectedItem = "BLUE";
                    break;
            }
        }

        private void UpdateSeed()
        {
            nudSeed.Value = _creator.Seed;
        }

        private void UpdateTiersOutterMargin()
        {
            nudOutterMargin.Value = _creator.TiersOutterMargin;
        }

        private void UpdateTiersInnerMargin()
        {
            nudInnerMargin.Value = _creator.TiersInnerMargin;
        }

        private void UpdateTier1CenterSize()
        {
            nudTier1CenterSize.Value = _creator.Tier1CenterSize;
        }

        private void UpdateTier1MazeSize()
        {
            nudTier1MazeSize.Value = _creator.Tier1MazeSize;
        }

        private void UpdateTier2CenterSize()
        {
            nudTier2CenterSize.Value = _creator.Tier2CenterSize;
        }

        private void UpdateTier2MazeSize()
        {
            nudTier2MazeSize.Value = _creator.Tier2MazeSize;
        }

        private void UpdateTier3CenterSize()
        {
            nudTier3CenterSize.Value = _creator.Tier3CenterSize;
        }

        private void UpdateTier3MazeSize()
        {
            nudTier3MazeSize.Value = _creator.Tier3MazeSize;
        }

        private void UpdateRoomQuantity()
        {
            nudRoomQuantity.Value = _creator.RoomQuantity;
        }

        private void UpdateRoomDistance()
        {
            nudRoomDistance.Value = _creator.RoomDistance;
        }

        private void UpdateRoomMinSize()
        {
            nudRoomMinSize.Value = _creator.RoomMinSize;
        }

        private void UpdateRoomMaxSize()
        {
            nudRoomMaxSize.Value = _creator.RoomMaxSize;
        }

        private void UpdateRoomConnections()
        {
            nudRoomConnections.Value = _creator.RoomConnections;
        }

        private void UpdateCorridorBias()
        {
            lblCorridorBias.Text = $"Corridor Length Bias: {_creator.CorridorBias}%";
            tkbCorridorBias.Value = _creator.CorridorBias;
        }

        private void UpdateDeadEndBias()
        {
            lblDeadEndBias.Text = $"Dead End Bias: {_creator.DeadEndBias}%";
            tkbDeadEndBias.Value = _creator.DeadEndBias;
        }

        private void UpdateDeadEndQuantity()
        {
            nudDeadEndQuantity.Value = _creator.DeadEndQuantity;
        }

        private void UpdateToolbox()
        {
            UpdateColor();
            UpdateSeed();
            UpdateTiersOutterMargin();
            UpdateTiersInnerMargin();
            UpdateTier1CenterSize();
            UpdateTier1MazeSize();
            UpdateTier2CenterSize();
            UpdateTier2MazeSize();
            UpdateTier3CenterSize();
            UpdateTier3MazeSize();
            UpdateRoomQuantity();
            UpdateRoomDistance();
            UpdateRoomMinSize();
            UpdateRoomMaxSize();
            UpdateRoomConnections();
            UpdateCorridorBias();
            UpdateDeadEndBias();
            UpdateDeadEndQuantity();
        }

        private void OnCreateCalled()
        {
            if (CreateCalled == null) return;
            CreateCalled(_creator);
        }

        private void OnSaveCalled()
        {
            if (SaveCalled == null) return;
            SaveCalled();
        }

        #endregion

        #region Signed Events Methods

        private void Toolbox_Load(object sender, EventArgs e)
        {
            UpdateToolbox();
        }

        private void Toolbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxColor.SelectedItem)
            {
                case "RED":
                    _creator.Chamber = Chambers.RED;
                    break;
                case "MAGENTA":
                    _creator.Chamber = Chambers.MAGENTA;
                    break;
                case "BLUE":
                    _creator.Chamber = Chambers.BLUE;
                    break;
                case "CYAN":
                    _creator.Chamber = Chambers.CYAN;
                    break;
                case "GREEN":
                    _creator.Chamber = Chambers.GREEN;
                    break;
                case "YELLOW":
                    _creator.Chamber = Chambers.YELLOW;
                    break;
            }
        }

        private void nudSeed_ValueChanged(object sender, EventArgs e)
        {
            _creator.Seed = (int)nudSeed.Value;
        }

        private void nudOutterMargin_ValueChanged(object sender, EventArgs e)
        {
            _creator.TiersOutterMargin = (int)nudOutterMargin.Value;
        }

        private void nudInnerMargin_ValueChanged(object sender, EventArgs e)
        {
            _creator.TiersInnerMargin = (int)nudInnerMargin.Value;
        }

        private void nudTier1CenterSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier1CenterSize = (int)nudTier1CenterSize.Value;
        }

        private void nudTier1MazeSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier1MazeSize = (int)nudTier1MazeSize.Value;
        }

        private void nudTier2CenterSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier2CenterSize = (int)nudTier2CenterSize.Value;
        }

        private void nudTier2MazeSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier2MazeSize = (int)nudTier2MazeSize.Value;
        }

        private void nudTier3CenterSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier3CenterSize = (int)nudTier3CenterSize.Value;
        }

        private void nudTier3MazeSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.Tier3MazeSize = (int)nudTier3MazeSize.Value;
        }

        private void nudRoomQuantity_ValueChanged(object sender, EventArgs e)
        {
            _creator.RoomQuantity = (int)nudRoomQuantity.Value;
        }

        private void nudRoomDistance_ValueChanged(object sender, EventArgs e)
        {
            _creator.RoomDistance = (int)nudRoomDistance.Value;
        }

        private void nudRoomMinSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.RoomMinSize = (int)nudRoomMinSize.Value;
        }

        private void nudRoomMaxSize_ValueChanged(object sender, EventArgs e)
        {
            _creator.RoomMaxSize = (int)nudRoomMaxSize.Value;
        }

        private void nudRoomConnections_ValueChanged(object sender, EventArgs e)
        {
            _creator.RoomConnections = (int)nudRoomConnections.Value;
        }

        private void tkbCorridorBias_ValueChanged(object sender, EventArgs e)
        {
            _creator.CorridorBias = tkbCorridorBias.Value;
            lblCorridorBias.Text = $"Corridor Length Bias: {_creator.CorridorBias}%";
        }

        private void tkbDeadEndBias_ValueChanged(object sender, EventArgs e)
        {
            _creator.DeadEndBias = tkbDeadEndBias.Value;
            lblDeadEndBias.Text = $"Dead End Bias: {_creator.DeadEndBias}%";
        }

        private void nudDeadEndQuantity_ValueChanged(object sender, EventArgs e)
        {
            _creator.DeadEndQuantity = (int)nudDeadEndQuantity.Value;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OnCreateCalled();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveCalled();
        }

        #endregion
    }
}

using DungeonGenerator.Base;
using DungeonGenerator.Base.Creators;
using DungeonGenerator.Serializer;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DungeonGenerator.Viewer
{
    public partial class MainWindow : Form
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        #endregion

        #region Constants

        const string FILEPATH = "saved_dungeon.json";

        #endregion

        #region Private Fields

        private Toolbox _toolbox;

        private Dungeon _dungeon;

        private RectangleF _mazeBorderRectangle;
        private RectangleF _mazeInnerRectangle;
        private RectangleF _mazeOutterRectangle;

        private float _cellSize;

        private float _centerFactorX;
        private float _centerFactorY;

        private string _stats;

        private SolidBrush _tier1Brush;
        private SolidBrush _tier2Brush;
        private SolidBrush _tier3Brush;
        private SolidBrush _pathBrush;
        private SolidBrush _roomBrush;
        private SolidBrush _deadEndBrush;
        private Pen _wallsPen;

        #endregion

        #region Private Methods

        private void InitializeWindow()
        {
            _toolbox = new Toolbox();
            _toolbox.CreateCalled += new Toolbox.CreateCalledHandler(_toolbox_CreateCalled);
            _toolbox.SaveCalled += new Toolbox.SaveCalledHandler(_toolbox_SaveCalled);
            _toolbox.Show(this);
            _toolbox.Focus();

            RefreshWindow();
        }

        private void RefreshWindow()
        {
            _mazeInnerRectangle = new RectangleF(18f, 18f, ClientRectangle.Width - 36f, ClientRectangle.Height - 36f);
            _mazeOutterRectangle = new RectangleF(12f, 12f, ClientRectangle.Width - 24f, ClientRectangle.Height - 24f);
            _mazeBorderRectangle = new RectangleF(11f, 11f, ClientRectangle.Width - 24f + 1f, ClientRectangle.Height - 24f + 1f);

            if (_dungeon != null)
            {
                if (_dungeon.Width > _dungeon.Height)
                {
                    _cellSize = _mazeInnerRectangle.Width / _dungeon.Width;
                    if (_cellSize * _dungeon.Height > _mazeInnerRectangle.Height)
                        _cellSize = _mazeInnerRectangle.Height / _dungeon.Height;
                }
                else
                {
                    _cellSize = _mazeInnerRectangle.Height / _dungeon.Height;
                    if (_cellSize * _dungeon.Width > _mazeInnerRectangle.Width)
                        _cellSize = _mazeInnerRectangle.Width / _dungeon.Width;
                }

                _centerFactorX = _mazeInnerRectangle.Width / 2f - _dungeon.Width * _cellSize / 2f + _mazeInnerRectangle.X;
                _centerFactorY = _mazeInnerRectangle.Height / 2f - _dungeon.Height * _cellSize / 2f + _mazeInnerRectangle.Y;
            }
        }

        private void Create(AlchromistCreator creator)
        {
            _dungeon = creator.Create();
            _stats = creator.Stats;
            Refresh();
        }

        private void Save()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Dungeon";
                dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                dialog.DefaultExt = "json";
                dialog.FileName = FILEPATH;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = dialog.FileName;
                    bool overwrite = true;

                    if (File.Exists(filepath))
                    {
                        var result = MessageBox.Show(
                            $"The file \"{Path.GetFileName(filepath)}\" already exists.\nDo you want to overwrite it?",
                            "Confirm Overwrite",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        overwrite = result == DialogResult.Yes;
                    }

                    DungeonSerializer.SaveToFile(_dungeon, filepath, overwrite);
                }
            }
        }

        private void DrawCanvas(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.DimGray, _mazeOutterRectangle);
            graphics.DrawRectangle(Pens.Black, _mazeBorderRectangle.X, _mazeBorderRectangle.Y, _mazeBorderRectangle.Width, _mazeBorderRectangle.Height);
        }

        private void DrawMaze(Graphics graphics)
        {
            if (_dungeon == null) return;

            for (int x = 0; x < _dungeon.Width; x++)
                for (int y = 0; y < _dungeon.Height; y++)
                {
                    PointF tlPosition = new PointF((x * _cellSize) + _centerFactorX, y * _cellSize + _centerFactorY);
                    PointF trPosition = new PointF((x * _cellSize) + _cellSize + _centerFactorX, (y * _cellSize) + _centerFactorY);
                    PointF blPosition = new PointF((x * _cellSize) + _centerFactorX, (y * _cellSize) + _cellSize + _centerFactorY);
                    PointF brPosition = new PointF((x * _cellSize) + _cellSize + _centerFactorX, (y * _cellSize) + _cellSize + _centerFactorY);

                    if (_dungeon[x, y] == Dungeon.DungeonFlags.NONE) continue;

                    var start = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.START);

                    var room = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.ROOM);
                    var tier1Room = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.TIER1ROOM);
                    var tier2Room = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.TIER2ROOM);
                    var tier3Room = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.TIER3ROOM);
                    var path = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.PATH);
                    var unused = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.UNUSED);
                    var deadEnd = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.DEADEND);

                    var topWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.TOP);
                    var bottomWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BOTTOM);
                    var leftWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.LEFT);
                    var rightWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RIGHT);

                    if (deadEnd)
                    {
                        if (_deadEndBrush == null)
                            _deadEndBrush = FindDeadEndBrush(x, y);
                        graphics.FillRectangle(_deadEndBrush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    } 
                    else if (tier1Room)
                    {
                        if (_tier1Brush == null)
                            _tier1Brush = FindTier1Brush(x, y);
                        graphics.FillRectangle(_tier1Brush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    }
                    else if (tier2Room)
                    {
                        if (_tier2Brush == null)
                            _tier2Brush = FindTier2Brush(x, y);
                        graphics.FillRectangle(_tier2Brush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    }
                    else if (tier3Room)
                    {
                        if (_tier3Brush == null)
                            _tier3Brush = FindTier3Brush(x, y);
                        graphics.FillRectangle(_tier3Brush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    }
                    else if (room)
                    {
                        if (_roomBrush == null)
                            _roomBrush = FindRoomBrush(x, y);
                        graphics.FillRectangle(_roomBrush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    }
                    else if (path)
                    {
                        if (_pathBrush == null)
                            _pathBrush = FindPathBrush(x, y);
                        graphics.FillRectangle(_pathBrush, tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    }
                    else if (unused)
                        graphics.FillRectangle(new SolidBrush(Color.Gray), tlPosition.X, tlPosition.Y, _cellSize, _cellSize);


                    if (start)
                        graphics.FillRectangle(new HatchBrush(HatchStyle.SmallCheckerBoard, Color.White, Color.Black),
                                               tlPosition.X + (_cellSize / 6f),
                                               tlPosition.Y + (_cellSize / 6f),
                                               _cellSize - (_cellSize / 3f),
                                               _cellSize - (_cellSize / 3f));

                    
                    if (_wallsPen == null)
                        _wallsPen = FindWallsPen(x, y);
                    if (topWall)
                        graphics.DrawLine(_wallsPen, tlPosition, trPosition);

                    if (bottomWall)
                        graphics.DrawLine(_wallsPen, blPosition, brPosition);

                    if (leftWall)
                        graphics.DrawLine(_wallsPen, tlPosition, blPosition);

                    if (rightWall)
                        graphics.DrawLine(_wallsPen, trPosition, brPosition);
                }
        }

        private void DrawStats(Graphics graphics)
        {
            if (_dungeon == null) return;
            var string_size = graphics.MeasureString(_stats, new Font("Arial", 10));
            var x = _mazeOutterRectangle.Right - string_size.Width - 25;
            var y = _mazeOutterRectangle.Bottom - string_size.Height - 25;

            graphics.DrawRectangle(_wallsPen, x - 11, y - 10, string_size.Width + 21, string_size.Height + 20);
            graphics.FillRectangle(FindStatsFillColor(), x - 10, y - 10, string_size.Width + 20, string_size.Height + 20);
            graphics.DrawString(_stats, new Font("Arial", 10), _roomBrush, new PointF(x, y));
        }

        private SolidBrush FindTier1Brush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(255, 128, 128));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(0, 128, 128));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(128, 255, 128));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(128, 0, 128));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(128, 128, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(128, 128, 0));
            return new SolidBrush(Color.SlateGray);
        }

        private SolidBrush FindTier2Brush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(128, 0, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(128, 255, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(0, 128, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(255, 128, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(0, 0, 128));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(255, 255, 128));
            return new SolidBrush(Color.SlateGray);
        }

        private SolidBrush FindTier3Brush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(255, 0, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(0, 255, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(0, 255, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(255, 0, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(0, 0, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(255, 255, 0));
            return new SolidBrush(Color.SlateGray);
        }

        private SolidBrush FindPathBrush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(255, 224, 224));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(224, 255, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(224, 255, 224));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(255, 224, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(224, 224, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(255, 255, 224));
            return new SolidBrush(Color.SlateGray);
        }

        private SolidBrush FindRoomBrush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(255, 192, 192));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(192, 255, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(192, 255, 192));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(255, 192, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(192, 192, 255));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(255, 255, 192));
            return new SolidBrush(Color.SlateGray);
        }

        private SolidBrush FindDeadEndBrush(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new SolidBrush(Color.FromArgb(64, 0, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new SolidBrush(Color.FromArgb(0, 64, 64));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new SolidBrush(Color.FromArgb(0, 64, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new SolidBrush(Color.FromArgb(64, 0, 64));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new SolidBrush(Color.FromArgb(0, 0, 64));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new SolidBrush(Color.FromArgb(64, 64, 0));
            return new SolidBrush(Color.SlateGray);
        }

        private Pen FindWallsPen(int x, int y)
        {
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.RED))
                return new Pen(Color.FromArgb(32, 0, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.CYAN))
                return new Pen(Color.FromArgb(0, 32, 32));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.GREEN))
                return new Pen(Color.FromArgb(0, 32, 0));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.MAGENTA))
                return new Pen(Color.FromArgb(32, 0, 32));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.BLUE))
                return new Pen(Color.FromArgb(0, 0, 32));
            if (_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.YELLOW))
                return new Pen(Color.FromArgb(32, 32, 0));
            return Pens.Black;
        }

        private SolidBrush FindStatsFillColor()
        {
            var invertedColor = Color.FromArgb(64, 255 - _roomBrush.Color.R, 255 - _roomBrush.Color.G, 255 - _roomBrush.Color.B);
            return new SolidBrush(invertedColor);
        }

        #endregion

        #region Signed Events Methods

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            RefreshWindow();
            DrawCanvas(e.Graphics);
            DrawMaze(e.Graphics);
            DrawStats(e.Graphics);
            _tier1Brush = null;
            _tier2Brush = null;
            _tier3Brush = null;
            _pathBrush = null;
            _roomBrush = null;
            _deadEndBrush = null;
            _wallsPen = null;
        }

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void _toolbox_CreateCalled(AlchromistCreator creator)
        {
            Create(creator);
        }

        private void _toolbox_SaveCalled()
        {
            Save();
        }

        #endregion

    }
}
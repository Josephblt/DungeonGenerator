using DungeonGenerator.Base;
using DungeonGenerator.Base.Creators;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public const int MARGIN = 12;

        #endregion

        #region Private Fields

        private Dungeon _dungeon;

        private RectangleF _mazeBorderRectangle;
        private RectangleF _mazeInnerRectangle;
        private RectangleF _mazeOutterRectangle;

        private float _cellSize;

        private float _centerFactorX;
        private float _centerFactorY;

        #endregion

        #region Private Methods

        private void InitializeWindow()
        {
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

        private void Create()
        {
            _dungeon = DefaultCreator.Create();
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

                    if (_dungeon[x, y] == Dungeon.DungeonFlags.None) continue;

                    var start = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Start);
                    var finish = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Finish);

                    var room = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Room);
                    var path = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Path);
                    var unused = _dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Unused);

                    var topWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Top);
                    var bottomWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Bottom);
                    var leftWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Left);
                    var rightWall = !_dungeon[x, y].HasFlag(Dungeon.DungeonFlags.Right);

                    if (room)
                        graphics.FillRectangle(new SolidBrush(Color.SlateGray), tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    else if (path)
                        graphics.FillRectangle(new SolidBrush(Color.Gray), tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
                    else if (unused)
                        graphics.FillRectangle(new SolidBrush(Color.Maroon), tlPosition.X, tlPosition.Y, _cellSize, _cellSize);

                    if (start)
                        graphics.FillRectangle(new HatchBrush(HatchStyle.SmallCheckerBoard, Color.White, Color.Black), 
                                               tlPosition.X + (_cellSize / 6f), 
                                               tlPosition.Y + (_cellSize / 6f), 
                                               _cellSize - (_cellSize / 3f), 
                                               _cellSize - (_cellSize / 3f));
                    else if (finish)
                        graphics.FillRectangle(new SolidBrush(Color.Green),
                                               tlPosition.X + (_cellSize / 6f),
                                               tlPosition.Y + (_cellSize / 6f),
                                               _cellSize - (_cellSize / 3f),
                                               _cellSize - (_cellSize / 3f));
                    
                    if (topWall)
                        graphics.DrawLine(Pens.Blue, tlPosition, trPosition);

                    if (bottomWall)
                        graphics.DrawLine(Pens.Blue, blPosition, brPosition);

                    if (leftWall)
                        graphics.DrawLine(Pens.Blue, tlPosition, blPosition);

                    if (rightWall)
                        graphics.DrawLine(Pens.Blue, trPosition, brPosition);
                    
                }
        }

        #endregion

        #region Signed Events Methods

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            Create();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            RefreshWindow();
            DrawCanvas(e.Graphics);
            DrawMaze(e.Graphics);
        }

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            Refresh();
        }

        #endregion

    }
}
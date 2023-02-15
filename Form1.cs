using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTreeViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
			this.MouseWheel += new MouseEventHandler(this.Form1_MouseWheel);
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls) // disables navigation with arrows
				control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
			Timer_Ticker.Start();
			Data.NEW();
        }
		// disables navigation with arrows
		void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
				e.IsInputKey = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
			// vars
			Graphics g = e.Graphics;
			ViewPort.windX = e.ClipRectangle.Width; ViewPort.windY = e.ClipRectangle.Height;
			
			//g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


			SolidBrush sb = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.Red);


			/*
			g.FillRectangle(sb,Tools.ToScreenRect(20,20, new Size(10,10)));
			double r = 40;
            for (int i = 0; i < 314*2; i++)
            {
				double x = r * Math.Sin(i/100.0);
				double y = r * Math.Cos(i/100.0);
				g.FillRectangle(sb, Tools.ToScreenRect((int)x, (int)y, new Size(2, 2)));
			}
			*/

			// rendering of objects
			if (Data.People != null)
            {
				// arrows
				List<Person> listParents = new List<Person>();
				for (int i = 0; i < Data.People.Length; i++)
				{
					Person p = Data.People[i];
					if (p == null) break;
					if (p.ParentMom != null) listParents.Add(p.ParentMom);
					if (p.ParentDad != null) listParents.Add(p.ParentDad);
					foreach (var parent in listParents)
					{
						Point p1 = new Point(parent.Pos.X, parent.Pos.Y), p2 = new Point(p.Pos.X, p.Pos.Y);
						PointF dV = new PointF(p2.X - p1.X, p2.Y - p1.Y);
						float vLen = (float)Tools.GetVectLength(dV.X, dV.Y);
						if (vLen == 0) continue;
						dV.X /= vLen; dV.Y /= vLen;
						vLen -= Data._size / 2 + 10;
						dV.X *= vLen; dV.Y *= vLen;
						p2.X = p1.X + (int)dV.X; p2.Y = p1.Y + (int)dV.Y;
						Tools.Meth.DrawArrow(g, pen, p1, p2);
					}
					listParents.Clear();
				}
				// nodes
				for (int i = 0; i < Data.People.Length; i++)
				{
					Person p = Data.People[i];
					if (p == null) break;
					g.FillEllipse(Brushes.White, Tools.ToScreenRect(p.Pos.X, p.Pos.Y, new Size(Data._size, Data._size)));

					Pen cpen;
					if (nUD_Id.Value == -1 || Data.People == null)
						cpen = new Pen(Color.Black);
					else if (nUD_Id.Value == i)
						cpen = new Pen(Color.Green,3);
					else if (Data.GetIdMother(i) == nUD_Id.Value || Data.GetIdFather(i) == nUD_Id.Value)
						cpen = new Pen(Color.Yellow,3);
					else if (Data.GetIdMother((int)nUD_Id.Value) == i)
						cpen = new Pen(Color.Purple,3);
					else if (Data.GetIdFather((int)nUD_Id.Value) == i)
						cpen = new Pen(Color.Blue,3);
					else
						cpen = Pens.Black;
					g.DrawEllipse(cpen, Tools.ToScreenRect(p.Pos.X, p.Pos.Y, new Size(Data._size, Data._size)));
					
					g.DrawString(p.FirstName+" "+p.FullName, SystemFonts.DefaultFont, sb, Tools.ToScreenPoint(p.Pos.X, p.Pos.Y));
					//g.DrawString(string.Join(",", p.numConnecting), SystemFonts.DefaultFont, sb, Tools.ToScreenPoint(p.Pos.X, p.Pos.Y - 30));
					//g.DrawString("C=" + p.centrality.ToString("00.0"), SystemFonts.DefaultFont, sb, Tools.ToScreenPoint(p.Pos.X, p.Pos.Y - 40));
				}

				if (nUD_Id.Value != -1 && nUD_Id.Value < Data.People.Length)
				{
					var pos = Data.People[(int)nUD_Id.Value].Pos;
					g.FillEllipse(Brushes.Green, Tools.ToScreenRect(0,0, new Size(25,25)));
					g.DrawLine(Pens.Green, Tools.ToScreenPoint(0, 0), Tools.ToScreenPoint(pos.X, pos.Y));
				}
			}
			
			// crossline
			//G.DrawLine(Pens.Black, ViewPort.windX / 2, 0, ViewPort.windX / 2, ViewPort.windY);
			//G.DrawLine(Pens.Black, 0, ViewPort.windY / 2, ViewPort.windX, ViewPort.windY / 2);

			// meta display
			string displayText =
				"scale(" + ViewPort.scaleX.ToString("0.000") + "|" + ViewPort.scaleY.ToString("0.000") + ")"
				+ "tps(" + ViewPort.fpsReal + "/" + (int)(1000.0/Timer_Ticker.Interval) + ")"
				+ "updateindic(" + (DateTime.Now.Millisecond%100).ToString("00") + ")"
				+ "seed("+seedCount+")";
			SizeF displayTextSize = g.MeasureString(displayText, SystemFonts.DefaultFont);
			g.FillRectangle(Brushes.LightGray, 0, 0, (int)displayTextSize.Width + 1, (int)displayTextSize.Height + 1);
			g.DrawString(displayText, SystemFonts.DefaultFont, Brushes.Black, new Point(0, 0));

			// fps counting related
			ViewPort.fpsFrames += 1;
			if (DateTime.Now.Second != ViewPort.fpsSecond)
			{
				ViewPort.fpsReal = ViewPort.fpsFrames;
				ViewPort.fpsFrames = 0;
				ViewPort.fpsSecond = DateTime.Now.Second;
			}
		}
		private byte ButtonFlags = 0x00;
		private void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			ViewPort.scaleX *= e.Delta > 0 ? 1f + Config.scaleAccelerator : 1f - Config.scaleAccelerator;
			ViewPort.scaleY *= e.Delta > 0 ? 1f + Config.scaleAccelerator : 1f - Config.scaleAccelerator;
			if (ViewPort.scaleX < 0.1f) { ViewPort.scaleX = 0.1f; ViewPort.scaleY = 0.1f; }
			else if (ViewPort.scaleX > 2.5f) { ViewPort.scaleX = 2.5f; ViewPort.scaleY = 2.5f; }
			Config.playerMoveStep = (int)(Config._constPlayerMoveStep / ViewPort.scaleX);
			if (e.Delta > 0)
			{
				ViewPort.cameraPosX += (int)((ViewPort.player1.X - ViewPort.cameraPosX) * Config.scaleAccelerator);
				ViewPort.cameraPosY += (int)((ViewPort.player1.Y - ViewPort.cameraPosY) * Config.scaleAccelerator);
			}
			CanvasToBeChanged = true;
		}
		private void Form1_Leave(object sender, EventArgs e)
		{
			ButtonFlags = 0x0;
		}
		private bool CanvasToBeChanged = true;
        private void Timer_Ticker_Tick(object sender, EventArgs e)
        {
			
			if (ButtonFlags != 0x00)
            {
				double x, y;
				
				double smallstepsize = 1 / ViewPort.scaleX;
				x = smallstepsize *
						(((ButtonFlags & 0b00010000) != 0x0 ? 1 : 0)
						- ((ButtonFlags & 0b01000000) != 0x0 ? 1 : 0));
				y = smallstepsize *
						(((ButtonFlags & 0b10000000) != 0x0 ? 1 : 0)
						- ((ButtonFlags & 0b00100000) != 0x0 ? 1 : 0));
                x = Math.Abs(x) >= 1 ? x : x == 0 ? 0 : 1;
				y = Math.Abs(y) >= 1 ? y : y == 0 ? 0 : 1;
				x += Config.playerMoveStep *
						(((ButtonFlags & 0b00000001) != 0x0 ? 1 : 0)
						- ((ButtonFlags & 0b00000100) != 0x0 ? 1 : 0));
				y += Config.playerMoveStep *
						(((ButtonFlags & 0b00001000) != 0x0 ? 1 : 0)
						- ((ButtonFlags & 0b00000010) != 0x0 ? 1 : 0));
				ViewPort.player1MoveVect.X = (int)x;
				ViewPort.player1MoveVect.Y = (int)y;

				ViewPort.player1.X += (int)(ViewPort.player1MoveVect.X * ViewPort._globalStepFactor);
				ViewPort.player1.Y += (int)(ViewPort.player1MoveVect.Y * ViewPort._globalStepFactor);
				Rectangle windowFreeWalkArea = new Rectangle(
					(int)(ViewPort.windX * Config.windowFreeWalkAreaPerc / 100),
					(int)(ViewPort.windY * Config.windowFreeWalkAreaPerc / 100),
					(int)(ViewPort.windX - ViewPort.windX * Config.windowFreeWalkAreaPerc / 100 * 2),
					(int)(ViewPort.windY - ViewPort.windY * Config.windowFreeWalkAreaPerc / 100 * 2)
					);

				//Point center = new Point(windowFreeWalkArea.X + windowFreeWalkArea.Width / 2, windowFreeWalkArea.Y + windowFreeWalkArea.Height / 2);
				//Rectangle rect = Tools.ToScreenRect(ViewPort.player1.X, ViewPort.player1.Y, new Size());
				//if (!windowFreeWalkArea.Contains(new Point(rect.Location.X, center.Y)))
					ViewPort.cameraPosX += (int)(ViewPort.player1MoveVect.X * ViewPort._globalStepFactor);
				//if (!windowFreeWalkArea.Contains(new Point(center.X, rect.Location.Y)))
					ViewPort.cameraPosY += (int)(ViewPort.player1MoveVect.Y * ViewPort._globalStepFactor);
				CanvasToBeChanged = true;
            }
			if (dragSelectedObject && dragSelectedObjectId != -1 && dragSelectedObjectId < Data.GetAmountPeople()
				&& timeToStartDragging < DateTime.Now)
            {
				var pp = PointToClient(Cursor.Position);
				var p = Tools.ToDigitalPoint(pp.X, pp.Y);
				Data.People[dragSelectedObjectId].Pos = (p.X, p.Y);
				CanvasToBeChanged = true;
            }
			
			if (!CanvasToBeChanged) return;
			CanvasToBeChanged = false;
			Invalidate();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
			CanvasToBeChanged = true;
		}
		int seedCount = 1337;
        private void btnNewLayout_Click(object sender, EventArgs e)
        {
			Data.rand = new Random(seedCount++);
			Data.CalculatePositioning();
			nUD_Id.Maximum = Data.GetAmountPeople() - 1;
			CanvasToBeChanged = true;
		}
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			switch (e.KeyCode)
			{
				case Keys.W:
					ButtonFlags |= 0b00001000; break;
				case Keys.A:
					ButtonFlags |= 0b00000100; break;
				case Keys.S:
					ButtonFlags |= 0b00000010; break;
				case Keys.D:
					ButtonFlags |= 0b00000001; break;
				case Keys.Up:
					ButtonFlags |= 0b10000000; break;
				case Keys.Left:
					ButtonFlags |= 0b01000000; break;
				case Keys.Down:
					ButtonFlags |= 0b00100000; break;
				case Keys.Right:
					ButtonFlags |= 0b00010000; break;
			}
		}
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
			switch (e.KeyCode)
			{
				case Keys.W:
					ButtonFlags &= 0b11110111; break;
				case Keys.A:
					ButtonFlags &= 0b11111011; break;
				case Keys.S:
					ButtonFlags &= 0b11111101; break;
				case Keys.D:
					ButtonFlags &= 0b11111110; break;
				case Keys.Up:
					ButtonFlags &= 0b01111111; break;
				case Keys.Left:
					ButtonFlags &= 0b10111111; break;
				case Keys.Down:
					ButtonFlags &= 0b11011111; break;
				case Keys.Right:
					ButtonFlags &= 0b11101111; break;
			}
		}
        private void nUD_Id_ValueChanged(object sender, EventArgs e)
        {
			if (Data.GetAmountPeople() <= nUD_Id.Value) return;
			lblIdSelected.Text = nUD_Id.Value == -1 ? "< not selected >"
				: Data.People[(int)nUD_Id.Value].FirstName + " "+ Data.People[(int)nUD_Id.Value].FullName;
			CanvasToBeChanged = true;
        }
        private void btnIdReset_Click(object sender, EventArgs e)
        {
			nUD_Id.Value = -1;
        }
        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
			var result = saveFileDialog1.ShowDialog();
			if (result != DialogResult.OK) return;
            string s = saveFileDialog1.FileName;
			Data.WriteCSV(s);
        }
        private void btnLoadLayout_Click(object sender, EventArgs e)
        {
			if (false)
            {
				Data.NEW();
				Data.DEPRECATEDReadManualData();
                return;
            }

            var result = openFileDialog1.ShowDialog();
			if (result != DialogResult.OK) return;
			string s = openFileDialog1.FileName;
			Data.ReadCSV(s);

			nUD_Id.Maximum = Data.GetAmountPeople() - 1;
			CanvasToBeChanged = true;
		}

		private DateTime timeToStartDragging = DateTime.MinValue;
		private bool dragSelectedObject = false;
		private int dragSelectedObjectId = -1;
		private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
			if (e.Button != MouseButtons.Left) return;
			
			Point p = Tools.ToDigitalPoint(e.X, e.Y);
		    int selected = -1;
			for (int i = 0; i < Data.GetAmountPeople(); i++)
			{
				var p2 = Data.People[i].Pos;
				if (Tools.GetVectLength(p.X - p2.X, p.Y - p2.Y) < Data._size * 0.5)
				{
					selected = i;
					break;
				}
			}
			if (selected == -1)
            {
				nUD_Id.Value = -1;
			}
            else
            {
				nUD_Id.Value = selected;
				CanvasToBeChanged = true;
				timeToStartDragging = DateTime.Now.AddSeconds(0.35);
				dragSelectedObject = true;
				dragSelectedObjectId = selected;
			}		
		}
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
			dragSelectedObject = false;
        }
    }
    static class Config
	{
		public static int
			maxObjs = 120,

			playerSize = 50,
			targetFPS = 100, // standard 40
			gameTicksPS = 60, // standard 60 | influences the smoothness of steps (lower = less smooth ; higher = more smooth & maybe more CPU)
			gameTickBase = 30, // the base speed of the game
			playerMoveStep = 60,
			_constPlayerMoveStep = 60, // is not modified

			// TODO --> Add vertical and horizontal percent / or pxl or smth like that

			windowFreeWalkAreaPerc = 30; // size of the edge area in percent of the width & height

		public static float
			scaleAccelerator = 0.1f;

		public static Random rand = new Random(1337);

	}
	static class ViewPort
	{
		public static double _globalStepFactor = 1; // constant after load
		public static float scaleX = 1f, scaleY = 1f, fpsReal = 0;
		public static int fpsFrames = 0, fpsSecond = 0;
		public static int windX = 0, windY = 0;
		public static int cameraPosX = 0, cameraPosY = 0;
		public static Point mousePos = new Point(0,0); // is updated
		public static Point player1MoveVect = new Point(0, 0);
		public static Point player1 = new Point(0, 0), player2 = new Point(0, 0);
	}
	public static class Tools
	{
		public static class Meth
        {
			public static void DrawArrow(Graphics g, Pen pen, Point pStart, Point pEnd)
			{
				(double X, double Y) dV = (pEnd.X - pStart.X, pEnd.Y - pStart.Y);
				double phi = GetPhi(dV.X, dV.Y);
				g.DrawLine(pen, Tools.ToScreenPoint(pStart.X, pStart.Y), Tools.ToScreenPoint(pEnd.X, pEnd.Y));
				
				double full = 2 * Math.PI;

				double phi2 = AddPhi(phi, 0.05 * full);
				PointF p = new PointF((float)(Math.Cos(phi2) * Data._size / 4.0), (float)(Math.Sin(phi2) * Data._size / 4.0));
				g.DrawLine(pen, Tools.ToScreenPoint(pEnd.X - p.X, pEnd.Y - p.Y), Tools.ToScreenPoint(pEnd.X, pEnd.Y));

				phi2 = AddPhi(phi, -0.05 * full);
				p = new PointF((float)(Math.Cos(phi2) * Data._size / 4.0), (float)(Math.Sin(phi2) * Data._size / 4.0));
				g.DrawLine(pen, Tools.ToScreenPoint(pEnd.X - p.X, pEnd.Y - p.Y), Tools.ToScreenPoint(pEnd.X, pEnd.Y));
			}
		}
		public static Rectangle ToScreenRect(int posX, int posY, Size size, bool sizeX_IsCentralized = true, bool sizeY_IsCentralized = true)
		{
			double digitalX = ViewPort.cameraPosX - posX, digitalY = ViewPort.cameraPosY - posY;
			double
				endSizeX = size.Width * ViewPort.scaleX,
				endSizeY = size.Height * ViewPort.scaleY;
			double
				endPosX = ViewPort.windX / 2 - digitalX * ViewPort.scaleX,
				endPosY = ViewPort.windY / 2 + digitalY * ViewPort.scaleY;
			return new Rectangle(
				(int)(endPosX - (sizeX_IsCentralized ? endSizeX / 2 : 0)),
				(int)(endPosY - (sizeY_IsCentralized ? endSizeY / 2 : 0)),
				(int)endSizeX, (int)endSizeY
				);
		}
		public static RectangleF ToScreenRectF(int posX, int posY, Size size, bool sizeX_IsCentralized = true, bool sizeY_IsCentralized = true)
		{
			double digitalX = ViewPort.cameraPosX - posX, digitalY = ViewPort.cameraPosY - posY;
			double
				endSizeX = size.Width * ViewPort.scaleX,
				endSizeY = size.Height * ViewPort.scaleY;
			double
				endPosX = ViewPort.windX / 2 - digitalX * ViewPort.scaleX,
				endPosY = ViewPort.windY / 2 + digitalY * ViewPort.scaleY;
			return new RectangleF(
				(float)(endPosX - (sizeX_IsCentralized ? endSizeX / 2 : 0)),
				(float)(endPosY - (sizeY_IsCentralized ? endSizeY / 2 : 0)),
				(float)endSizeX, (float)endSizeY
				);
		}
		public static Size ToScreenSize(double sizeX = 0, double sizeY = 0)
		{
			return new Size((int)(sizeX * ViewPort.scaleX), (int)(sizeY * ViewPort.scaleY));
		}
		public static SizeF ToScreenSizeF(double sizeX = 0, double sizeY = 0)
		{
			return new SizeF((float)sizeX * ViewPort.scaleX, (float)sizeY * ViewPort.scaleY);
		}
		// same thing as ToScreenRect, but with removed size parameter
		public static Point ToScreenPoint(int posX, int posY)
		{
			double digitalX = ViewPort.cameraPosX - posX, digitalY = ViewPort.cameraPosY - posY;
			double
				endPosX = ViewPort.windX / 2 - digitalX * ViewPort.scaleX,
				endPosY = ViewPort.windY / 2 + digitalY * ViewPort.scaleY;
			return new Point(
				(int)(endPosX),
				(int)(endPosY)
				);
		}
		public static PointF ToScreenPoint(float posX, float posY)
		{
			double digitalX = ViewPort.cameraPosX - posX, digitalY = ViewPort.cameraPosY - posY;
			float
				endPosX = (float)(ViewPort.windX / 2 - digitalX * ViewPort.scaleX),
				endPosY = (float)(ViewPort.windY / 2 + digitalY * ViewPort.scaleY);
			return new PointF(
				endPosX,
				endPosY
				);
		}
		public static Point ToDigitalPoint(int posX, int posY)
		{
			double
				endPosX = (-ViewPort.windX / 2 + posX) / ViewPort.scaleX + ViewPort.cameraPosX,
				endPosY = (-ViewPort.windY / 2 + posY) / (-ViewPort.scaleY) + ViewPort.cameraPosY;
			return new Point(
				(int)endPosX,
				(int)endPosY
				);
		}
		public static double GetVectLength(Point a)
		{
			return Math.Sqrt(a.X * a.X + a.Y * a.Y);
		}
		public static double GetVectLength(double x, double y, double z = 0)
		{
			return Math.Sqrt(x * x + y * y + z * z);
		}
		private static double GetPhi(double x, double y)
		{
			double full = 2 * Math.PI;
			if (x == 0)
			{
				if (y == 0) throw new Exception();
				else if (y < 0) return full * 0.75;
				else if (y > 0) return full * 0.25;
			}
			else if (x > 0 && y > 0)
			{
				return Math.Atan(y / x);
			}
			else if (x < 0 && y > 0)
			{
				return full * 0.5 + Math.Atan(y / x);
			}
			else if (x < 0 && y < 0)
			{
				return full * 0.5 + Math.Atan(y / x);
			}
			else if (x > 0 && y < 0)
			{
				return full + Math.Atan(y / x);
			}
			return 0.0;
		}
		private static double AddPhi(double phi, double addition)
        {
			double full = 2 * Math.PI;
			if (addition > 0)
				return (phi + addition) % full;
			else if (addition < 0)
				return Math.Abs(phi + addition) % full;
			return phi;
		}
	}
}

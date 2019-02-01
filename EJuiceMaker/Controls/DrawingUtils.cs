using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Svg;

namespace EJuiceMaker.Controls
{
    internal static class DrawingUtils
    {
        #region SVG

        public static void DrawSvg(this Graphics g, byte[] iconData, Color foreColor, Rectangle bounds)
        {
            using (var stream = new MemoryStream(iconData))
            {
                var svg = SvgDocument.Open<SvgDocument>(stream);
                svg.Fill = new SingleColorPaintServer(foreColor);
                svg.X = new SvgUnit(SvgUnitType.Pixel, bounds.X);
                svg.Y = new SvgUnit(SvgUnitType.Pixel, bounds.Y);
                svg.Width = new SvgUnit(SvgUnitType.Pixel, bounds.Width);
                svg.Height = new SvgUnit(SvgUnitType.Pixel, bounds.Height);
                svg.Draw(g);
            }
        }

        public static Bitmap RenderSvg(byte[] iconData, Color foreColor, Size size)
        {
            var bm = new Bitmap(size.Width, size.Height);
            using (var g = Graphics.FromImage(bm))
            {
                g.DrawSvg(iconData, foreColor, new Rectangle(new Point(0, 0), size));
            }
            return bm;
        }

        #endregion

        public static GraphicsPath RoundedRectangle(RectangleF bounds, Padding fromPadding)
        {
            var topLeft = Math.Max(fromPadding.Top, fromPadding.Left);
            var topRight = Math.Max(fromPadding.Top, fromPadding.Right);
            var bottomLeft = Math.Max(fromPadding.Bottom, fromPadding.Left);
            var bottomRight = Math.Max(fromPadding.Bottom, fromPadding.Right);
            return RoundedRectangle(bounds, topLeft, topRight, bottomLeft, bottomRight);
        }

        public static GraphicsPath RoundedRectangle(RectangleF bounds, int radius)
        {
            return RoundedRectangle(bounds, radius, radius, radius, radius);
        }

        public static GraphicsPath RoundedRectangle(RectangleF bounds, int radiusTopLeft, int radiusTopRight, int radiusBottomLeft, int radiusBottomRight)
        {
            GraphicsPath path = new GraphicsPath();

            // Short-circuit for no rounding
            if (radiusTopLeft == 0 && radiusTopRight == 0 && radiusBottomLeft == 0 && radiusBottomRight == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc
            if (radiusTopLeft > 0)
            {
                path.AddArc(new RectangleF(bounds.Left, bounds.Top, radiusTopLeft * 2, radiusTopLeft * 2), 180, 90);
            }
            else
            {
                path.AddLine(new PointF(bounds.Left, bounds.Top), new PointF(bounds.Left, bounds.Top));
            }

            // top right arc
            if (radiusTopRight > 0)
            {
                path.AddArc(new RectangleF(bounds.Right - radiusTopRight * 2, bounds.Top, radiusTopRight * 2, radiusTopRight * 2), 270, 90);
            }
            else
            {
                path.AddLine(new PointF(bounds.Right, bounds.Top), new PointF(bounds.Right, bounds.Top));
            }

            // bottom right arc
            if (radiusBottomRight > 0)
            {
                path.AddArc(new RectangleF(bounds.Right - radiusBottomRight * 2, bounds.Bottom - radiusBottomRight * 2, radiusBottomRight * 2, radiusBottomRight * 2), 0, 90);
            }
            else
            {
                path.AddLine(new PointF(bounds.Right, bounds.Bottom), new PointF(bounds.Right, bounds.Bottom));
            }

            // bottom left arc
            if (radiusBottomLeft > 0)
            {
                path.AddArc(new RectangleF(bounds.Left, bounds.Bottom - radiusBottomLeft * 2, radiusBottomLeft * 2, radiusBottomLeft * 2), 90, 90);
            }
            else
            {
                path.AddLine(new PointF(bounds.Left, bounds.Bottom), new PointF(bounds.Left, bounds.Bottom));
            }

            path.CloseFigure();
            return path;
        }
    }

    internal class SingleColorPaintServer : SvgPaintServer
    {
        private readonly Color _Color;

        public SingleColorPaintServer(Color color)
        {
            _Color = color;
        }

        public override SvgElement DeepCopy()
        {
            return new SingleColorPaintServer(_Color);
        }

        public override Brush GetBrush(SvgVisualElement styleOwner, ISvgRenderer renderer, float opacity, bool forStroke = false)
        {
            return new SolidBrush(_Color);
        }
    }
}

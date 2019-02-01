using EJuiceMaker.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using R = EJuiceMaker.Properties.Resources;

namespace EJuiceMaker.Controls
{
    internal class TagItem : Control
    {
        private static readonly Size _IconSize;

        private SizeF _TextSize;

        static TagItem()
        {
            _IconSize = R.delete.Size;
        }

        public TagItem()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }
        
        private RecipeTag _TagValue;
        public RecipeTag TagValue
        {
            get => _TagValue;
            set
            {
                if (_TagValue != value)
                {
                    if (_TagValue != null) _TagValue.PropertyChanged -= OnTagPropertyChanged;
                    _TagValue = value;
                    if (_TagValue != null) _TagValue.PropertyChanged += OnTagPropertyChanged;
                    Size = GetPreferredSize(Size.Empty);
                }
            }
        }

        private void OnTagPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Size = GetPreferredSize(Size.Empty);
        }

        public event EventHandler Removed;

        protected override void OnPaddingChanged(EventArgs e)
        {
            Size = GetPreferredSize(Size.Empty);
            base.OnPaddingChanged(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var iconRect = new Rectangle(new Point(Width - Padding.Right - _IconSize.Width, Padding.Top), _IconSize);
            Cursor = iconRect.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            var iconRect = new Rectangle(new Point(Width - Padding.Right - _IconSize.Width, Padding.Top), _IconSize);
            if (iconRect.Contains(e.Location))
            {
                Removed?.Invoke(this, EventArgs.Empty);
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            using (var g = CreateGraphics())
            {
                if (!MaximumSize.IsEmpty) _TextSize = g.MeasureString(TagValue.Tag, Font, MaximumSize);
                else _TextSize = g.MeasureString(TagValue.Tag, Font);
                return new Size((int)_TextSize.Width + Padding.Horizontal + /* icon spacing: */ 2 + _IconSize.Width, Math.Max((int)_TextSize.Height + Padding.Vertical, _IconSize.Height));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var bounds = new RectangleF(0, 0, Width - 1, Height - 1);
            var borderPath = DrawingUtils.RoundedRectangle(bounds, Padding);
            e.Graphics.FillPath(new SolidBrush(BackColor), borderPath);
            e.Graphics.DrawPath(new Pen(ForeColor), borderPath);
            e.Graphics.DrawString(TagValue.Tag, Font, new SolidBrush(ForeColor), bounds.Left + Padding.Left, bounds.Top + Padding.Top);
            e.Graphics.DrawImage(R.delete, bounds.Right - _IconSize.Width, bounds.Top + 1);
        }
    }
}

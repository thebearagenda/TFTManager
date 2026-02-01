using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TFTCustomControls
{
    public partial class FillBar : UserControl
    {
        private double _minValue = 0;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public double MinValue
        {
            get => _minValue;
            set
            {
                if (value == _minValue)
                {
                    return;
                }
                _minValue = value;
                UpdateColor();
                UpdateFill();
            }
        }

        private double _maxValue = 100;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public double MaxValue
        {
            get => _maxValue;
            set
            {
                if (value == _maxValue)
                {
                    return;
                }
                _maxValue = value;
                UpdateColor();
                UpdateFill();
            }
        }

        private double _value = 0;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public double Value
        {
            get => _value;
            set
            {
                if (value == _value)
                {
                    return;
                }

                if (value < _minValue)
                {
                    _value = _minValue;
                }
                else if (value > _maxValue)
                {
                    _value = _maxValue;
                }
                else 
                {
                    _value = value; 
                }

                UpdateColor();
                UpdateFill();
            }
        }

        private Color _minColor = Color.Red;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color MinColor
        {
            get => _minColor;
            set
            {
                if (value.R == _backColor.R &&
                    value.G == _backColor.G &&
                    value.B == _backColor.B &&
                    value.A == _backColor.A)
                {
                    return;
                }
                _minColor = value;
                UpdateColor();
            }
        }

        private Color _maxColor = Color.FromArgb(255,0,176,80);

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color MaxColor
        {
            get => _maxColor;
            set
            {
                if (value.R == _backColor.R &&
                    value.G == _backColor.G &&
                    value.B == _backColor.B &&
                    value.A == _backColor.A)
                {
                    return;
                }
                _maxColor = value;
                UpdateColor();
            }
        }

        private Color _fillColor = Color.Red;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FillColor
        {
            get => _fillColor;
            private set
            {
                if (value.R == _backColor.R &&
                    value.G == _backColor.G &&
                    value.B == _backColor.B &&
                    value.A == _backColor.A)
                {
                    return;
                }

                _fillColor = value;
                fillPanel.BackColor = value;
            }
        }

        private Color _backColor;

        [Browsable(true)]
        [Category("Design")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color BackColor
        {
            get => _backColor;
            set
            {
                if (value.R == _backColor.R &&
                    value.G == _backColor.G &&
                    value.B == _backColor.B &&
                    value.A == _backColor.A)
                {
                    return;
                }
                _backColor = value;
                BackColor = value;
            }
        }

        public FillBar()
        {
            InitializeComponent();
        }

        private void UpdateFill()
        {
            Size size = new Size(Size.Width - Padding.Left - Padding.Right, Size.Height - Padding.Top - Padding.Bottom);
            size.Width = (int)(size.Width * Percentage());
            fillPanel.Size = size;
        }

        private void UpdateColor()
        {
            if (_value <= _minValue)
            {
                FillColor = _minColor;
            }

            if (_value >= _maxValue)
            {
                FillColor = _maxColor;
            }

            double red = _minColor.R + (_maxColor.R - _minColor.R) * Percentage();
            double green = _minColor.G + (_maxColor.G - _minColor.G) * Percentage();
            double blue = _minColor.B + (_maxColor.B - _minColor.B) * Percentage();
            double alpha = _minColor.A + (_maxColor.A - _minColor.A) * Percentage();

            red = Math.Min(Math.Max(red, 0), 255);
            green = Math.Min(Math.Max(green, 0), 255);
            blue = Math.Min(Math.Max(blue, 0), 255);
            alpha = Math.Min(Math.Max(alpha, 0), 255);


            try
            {
                FillColor = Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
            }
            catch (ArgumentException)
            {
                FillColor = BackColor;
            }
        }

        private double Percentage()
        {
            double range = _maxValue - _minValue;
            double relativeValue = _value - _minValue;

            if( range <= 0 || relativeValue < 0 )
            {
                return 0;
            }

            return relativeValue / range;
        }

        private void FillBar_SizeChanged(object sender, EventArgs e)
        {
            UpdateFill();
        }
    }
}

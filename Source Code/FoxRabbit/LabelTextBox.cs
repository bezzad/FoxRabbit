using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FoxRabbit
{
    public class LabelTextBox : TextBox
    {
        private System.ComponentModel.Container components = new System.ComponentModel.Container();

        private System.Windows.Forms.ToolTip textToolTip = new ToolTip();
        private string lblText;
        private System.Drawing.Color lblColor = Color.DarkGray;
        private System.Drawing.Color textColor = Color.Black;
        private TextBoxFormat format = TextBoxFormat.Text;
        private System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.ToString(), true);
        private bool okKeyChar = true;

        [Category("Properties"), Description("Written label text's that is inside the TextBox.")]
        public string LabelText
        {
            get { return lblText; }
            set
            {
                lblText = value; this.Text = value;
                textToolTip.RemoveAll();
                textToolTip.SetToolTip(this, lblText);
            }
        }

        [Category("Properties"), Description("Written label color's that is inside the TextBox.")]
        public Color LabelColor
        { get { return lblColor; } set { lblColor = value; this.ForeColor = value; } }

        [Category("Properties"), Description("Written text color's that is inside the TextBox.")]
        public Color TextColor
        { get { return textColor; } set { textColor = value; } }

        [Category("Properties"), Description("Written label toolTip's that is inside the TextBox.")]
        public ToolTip TextToolTip 
        { get { return textToolTip; } set { textToolTip = value; } }

        [Category("Properties"), Description("Set text Format for TextBox.")]
        public TextBoxFormat Format 
        { get { return format; } set { format = value; } }

        [Category("Properties"), Description("Set text CultureInfo for TextBox.")]
        public System.Globalization.CultureInfo Culture 
        { get { return culture; } set { culture = value; } }

        public LabelTextBox()
        {
            textToolTip.IsBalloon = true;
            textToolTip.ShowAlways = true;

            this.MouseDown += new MouseEventHandler(LabelTextBox_MouseDown);
            this.MouseLeave += new EventHandler(LabelTextBox_MouseLeave);
            this.KeyDown += new KeyEventHandler(LabelTextBox_KeyDown);
            this.KeyUp += new KeyEventHandler(LabelTextBox_KeyUp);
            this.Leave += new EventHandler(LabelTextBox_Leave);
            this.KeyPress += new KeyPressEventHandler(LabelTextBox_KeyPress);

            if (lblText != string.Empty)
            {
                this.ForeColor = lblColor;
                this.Text = lblText;
            }

            textToolTip.RemoveAll();
            textToolTip.SetToolTip(this, lblText);
        }

        void LabelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+") && !okKeyChar)
                e.Handled = true;
        }

        void LabelTextBox_Leave(object sender, EventArgs e)
        {
            if (format == TextBoxFormat.Currency)
            {
                double num;
                if (double.TryParse(this.Text, System.Globalization.NumberStyles.Currency | System.Globalization.NumberStyles.Number, culture, out num))
                {
                    this.Text = num.ToString("C", culture);
                }
            }
        }

        void LabelTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Text == string.Empty)
            {
                this.ForeColor = lblColor;
                this.Text = lblText;
            }
        }

        void LabelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Text == lblText && this.ForeColor == lblColor)
            {
                this.ForeColor = textColor;
                this.Text = string.Empty;
            }
            else this.ForeColor = textColor;

            if (format == TextBoxFormat.Currency || format == TextBoxFormat.Numeric)
            {
                if (e.KeyData == Keys.Delete || e.KeyData == Keys.Clear || 
                    e.KeyCode == Keys.OemMinus || e.KeyData == Keys.OemBackslash || 
                    e.KeyData == Keys.Back || e.KeyData == Keys.Decimal ||
                    e.KeyCode == Keys.Subtract)
                    okKeyChar = true;
                else okKeyChar = false;
            }
            else okKeyChar = true;
        }

        void LabelTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (this.Text == string.Empty)
            {
                this.ForeColor = lblColor;
                this.Text = lblText;
            }
        }

        void LabelTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Text == lblText && this.ForeColor == lblColor)
            {
                this.ForeColor = textColor;
                this.Text = string.Empty;
            }
        }

        public void clearByLabelText()
        {
            this.Clear();
            this.ForeColor = lblColor;
            this.Text = lblText;
        }
    }

    // Summary:
    //     Specifies the formats used with text-related methods of the System.Windows.Forms.Clipboard
    //     and System.Windows.Forms.DataObject classes.
    public enum TextBoxFormat { Numeric, Text, Currency }
}

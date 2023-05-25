namespace FindSecond;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private int _NumberOfRows;

    private ButtonHandler buttonHandler;
    private Button _PreviousButton;
    private Button _LastButton;
    private TableLayoutPanel TableLayoutPannel;

    public Form1(string[] args)
    {
        Random random = new Random();

        var isNumber = Int32.TryParse(args[0], out _NumberOfRows);
        if (!isNumber || _NumberOfRows % 2 == 1 || _NumberOfRows > 20)
        {
            throw new ArgumentException("incorrect intput");
        }

        buttonHandler = new ButtonHandler();

        TableLayoutPannel = new TableLayoutPanel();
        TableLayoutPannel.Dock = DockStyle.Fill;
        TableLayoutPannel.AutoSize = true;
        for (var i = 0; i < _NumberOfRows; ++i)
        {
            TableLayoutPannel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / _NumberOfRows));
            TableLayoutPannel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / _NumberOfRows));
        }
        this.Controls.Add(TableLayoutPannel);

        var size = _NumberOfRows * _NumberOfRows;

        int[] values = new int[size / 2];
        for (var i = 0; i < size /2; ++i)
        {
            values[i] = 2;
        }

        int row = 0;

        for (var i = 0; i < size; ++i)
        {
            Button button = new Button();
            var number = random.Next() % size / 2;
            while (values[number] == 0)
            {
                number = random.Next() % size / 2;
            }
            button.Name = (number + 1).ToString();
            --values[number];

            button.Click += ButtonOnClick;

            TableLayoutPannel.Controls.Add(button, i % _NumberOfRows, row);
            button.Dock = DockStyle.Fill;
            if (i % _NumberOfRows == _NumberOfRows - 1)
            {
                ++row;
            }
        }
    }

    private void ButtonOnClick(object sender, EventArgs eventArgs)
    {
        var button = sender as Button;
        button.Text = button.Name;
        _PreviousButton = _LastButton;
        _LastButton = button;
        buttonHandler.Click(Int32.Parse(button.Text));
        if (_PreviousButton != null && buttonHandler.IsMatch())
        {
            TableLayoutPannel.Controls.Remove(_PreviousButton);
            TableLayoutPannel.Controls.Remove(_PreviousButton);
            _PreviousButton.Dispose();
            _PreviousButton = null;
            _LastButton.Dispose();
            _LastButton = null;
        } else if (_PreviousButton != null)
        {
            _PreviousButton.Text = String.Empty;
        }
    }

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";
    }

    #endregion
}
using System;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class MainForm : Form
{
	OpenFileDialog open_file;
	SaveFileDialog save_file;

	Label source_label;
	Label encrypted_label;
	Label key_label;


	TextBox SourceMessage;
	TextBox EncryptedMessage;
	TextBox Key;

	Button DoButton;
	Button OpenButton;
	Button SaveButton;

	public MainForm()
	{
		source_label = new Label ();
		source_label.Text = "Исходный текст";
		source_label.Location = new Point (20, 10);

		SourceMessage = new TextBox ();
		SourceMessage.Multiline = true;
		SourceMessage.ScrollBars = ScrollBars.Vertical;
		SourceMessage.BorderStyle = BorderStyle.FixedSingle;
		SourceMessage.Location = new Point (20, 30);
		SourceMessage.Width = 525;
		SourceMessage.Height = 125;

		encrypted_label = new Label ();
		encrypted_label.Width += 40;
		encrypted_label.Text = "Обработанный текст";
		encrypted_label.Location = new Point (20, 180);

		EncryptedMessage = new TextBox ();
		EncryptedMessage.Multiline = true;
		EncryptedMessage.ScrollBars = ScrollBars.Vertical;
		EncryptedMessage.BorderStyle = BorderStyle.FixedSingle;
		EncryptedMessage.Location = new Point (20, 200);
		EncryptedMessage.Width = 525;
		EncryptedMessage.Height = 125;

		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.Text = "Encrypter";
		this.MaximizeBox = false;
		this.BackColor = Color.LightGray;
		this.Width = 600;
		this.Height = 410;
	
		key_label = new Label ();
		key_label.Text = "Ключ";
		key_label.Width = 40;
		key_label.Location = new Point (20, 350);

		Key = new TextBox ();
		Key.Width += 150;
		Key.Location = new Point (60, 347);

		DoButton = new Button ();
		DoButton.Text = "Выполнить";
		DoButton.Click += DoButton_Click;
		DoButton.Location = new Point (325, 345);

		OpenButton = new Button ();
		OpenButton.Text = "Открыть";
		OpenButton.Click += OpenButton_Click;
		OpenButton.Location = new Point (405, 345);
		open_file = new OpenFileDialog ();
		open_file.Filter = "txtfile (*.txt) | *.txt";

		SaveButton = new Button ();
		SaveButton.Text = "Сохранить";
		SaveButton.Width += 10;
		SaveButton.Click += SaveButton_Click;
		SaveButton.Location = new Point (485, 345);
		save_file = new SaveFileDialog ();
		save_file.Filter = "txtfile (*.txt) | *.txt";

		Controls.Add (SourceMessage);
		Controls.Add (source_label);
		Controls.Add (EncryptedMessage);
		Controls.Add (encrypted_label);
		Controls.Add (key_label);
		Controls.Add (Key);
		Controls.Add (DoButton);
		Controls.Add (OpenButton);
		Controls.Add (SaveButton);



	}

	void SaveButton_Click (object sender, EventArgs e)
	{
		
		DialogResult result = save_file.ShowDialog ();
		if (result != DialogResult.OK)
		{
			return;
		}

		File.WriteAllLines (save_file.FileName, EncryptedMessage.Lines);
	}

	void OpenButton_Click (object sender, EventArgs e)
	{
		
		DialogResult result =  open_file.ShowDialog ();

		if (result != DialogResult.OK)
		{
			return;
		}

		SourceMessage.Lines = File.ReadAllLines(open_file.FileName);
	}

	void DoButton_Click (object sender, EventArgs e)
	{
		string[] AllLines = new string[SourceMessage.Lines.Length];


		if (SourceMessage.Text == "") 
		{
			MessageBox.Show ("Исходный текст не может быть пустым");
			return;
		}



		if (Key.Text.Length == 0)
		{
			MessageBox.Show ("Ключ не может быть пустым");
			return;
		}

		if (Key.Text.Length >= 20)
		{
			MessageBox.Show ("Ключ не может быть больше 20 символов");
			return;
		}
		for (int i = 0; i < SourceMessage.Lines.Length; i++) 
		{
			AllLines[i] = Encrypter.ApplyXOR (SourceMessage.Lines[i], Key.Text);
		}
		EncryptedMessage.Lines = AllLines;
	}

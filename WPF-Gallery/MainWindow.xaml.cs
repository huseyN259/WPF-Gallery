using Microsoft.Win32;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPF_Gallery.UserControls;

namespace WPF_Gallery;

public partial class MainWindow : Window
{
	public ObservableCollection<Image> Photos { get; set; }

	public MainWindow()
	{
		InitializeComponent();

		this.DataContext = this;
		
		Photos = new ObservableCollection<Image>();
	}

	private void AddFile_MenuItem_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog op = new OpenFileDialog();
		op.Title = "Select a picture";
		op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
		  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
		  "Portable Network Graphic (*.png)|*.png";

		if (op.ShowDialog() == true)
		{
			UserControl userControl = new UserControl();
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog op = new OpenFileDialog();
		op.Title = "Select a picture";
		op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
		  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
		  "Portable Network Graphic (*.png)|*.png";

		if (op.ShowDialog() == true)
		{
			if (op.CheckFileExists == true)
			{
				Image newPhoto = new Image();
				newPhoto.Source = new BitmapImage(new Uri(op.FileName));
				newPhoto.Height = 200;
				newPhoto.Width = 200;
				Photos.Add(newPhoto);
			}
		}
	}

	private void MainListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		var photo = MainListBox.SelectedItem as Image;
		UserControl2 userControl2 = new UserControl2();
		userControl2.Img1 = photo;
		userControl2.Photos = Photos;
		MainGrid.Children.Add(userControl2);
	}
}
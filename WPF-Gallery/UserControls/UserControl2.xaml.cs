using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Gallery.UserControls;

public partial class UserControl2 : UserControl
{
	public ObservableCollection<Image> Photos { get; set; }

	public static readonly DependencyProperty Img1Property = DependencyProperty.Register("Img1", typeof(Image), typeof(UserControl2));

	public Image Img1
	{
		get { return (Image)GetValue(Img1Property); }
		set { SetValue(Img1Property, value); }
	}

	public UserControl2()
	{
		InitializeComponent();

		this.DataContext = this;
	}

	private void BackButton_Click(object sender, RoutedEventArgs e)
	{
		this.Visibility = Visibility.Collapsed;
	}

	private void PrevBtn_Click(object sender, RoutedEventArgs e)
	{
		int index = Photos.IndexOf(Img1);
		
		if (index > 0)
			Img1 = Photos[index - 1];
	}

	private void NextBtn_Click(object sender, RoutedEventArgs e)
	{
		int index = Photos.IndexOf(Img1);

		if (index < Photos.Count - 1)
			Img1 = Photos[index + 1];
	}
}
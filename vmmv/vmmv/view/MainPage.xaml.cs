using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;


namespace vmmvvvv
{
    public partial class MainPage : UserControl
    {
        private Storyboard myStoryboard;
        public MainPage()
        {
            InitializeComponent();

            Binding binding = new Binding("Value");
            binding.Source = slider;
            binding.Mode = BindingMode.OneWay;
            binding.Converter = new converterSlider2TextBox();
            tb.SetBinding(TextBox.TextProperty, binding);


            stulist.ItemsSource = new StudentsVM().Students;
            stulist.DisplayMemberPath = "Name";

            sId.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.StuNum"){ Source = stulist});
            sAge.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Age") { Source = stulist });


            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50.0;
            myDoubleAnimation.To = 60.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            Storyboard.SetTarget(myDoubleAnimation, b);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.WidthProperty));
            b.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            b.Loaded += new RoutedEventHandler(myButtonLoaded);
        }

        private void myButtonLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin();
        }
    }
}

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace comiket2013winter
{
    public partial class MainPage : PhoneApplicationPage
    {

        // コンストラクター
        public MainPage()
        {
            InitializeComponent();

            // ApplicationBar をローカライズするためのサンプル コード
            //BuildLocalizedApplicationBar();

            Canvas grid = new Canvas()
            {
                Margin = new Thickness(0, 0, 0, 0),
                Name = "hoge"
            };

            TextBlock textBlock = new TextBlock()
            {
                Text = "どーまんせーまん",
                FontSize = 40,
                Foreground = new SolidColorBrush() { Color = Colors.White },
                FontWeight = FontWeights.Bold,
                Opacity = 1.0,
                Margin = new Thickness(0, 0, 0, 0)
            };

            TextBlock textBlock2 = new TextBlock()
            {
                FontSize = 40,
                Text = "どーまんせーまん",
                Foreground = new SolidColorBrush() { Color = Colors.Black },
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(1, 1, 0, 0),
                Opacity = 1.0
            };

            grid.Children.Add(textBlock2);
            grid.Children.Add(textBlock);
            panel.Children.Add(grid);



            DoubleAnimation myDoubleAnimation = new DoubleAnimation()
            {
                From = 768,//画面の右端
                To = 0 - textBlock.ActualWidth//コメントの右端が画面の左端に行くまで
            };

            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(4000));//表示は4,000ミリ秒

            Storyboard.SetTargetName(myDoubleAnimation, grid.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Canvas.LeftProperty));
            Storyboard sb = new Storyboard();
            sb.Children.Add(myDoubleAnimation);
            sb.Completed += ((sender, e) =>
            {
                panel.Children.Remove(grid);
                panel.Resources.Remove(grid.Name);
            });

            panel.Resources.Add(grid.Name, sb);
            sb.Begin();

        }

        // ローカライズされた ApplicationBar を作成するためのサンプル コード
        //private void BuildLocalizedApplicationBar()
        //{
        //    // ページの ApplicationBar を ApplicationBar の新しいインスタンスに設定します。
        //    ApplicationBar = new ApplicationBar();

        //    // 新しいボタンを作成し、テキスト値を AppResources のローカライズされた文字列に設定します。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // AppResources のローカライズされた文字列で、新しいメニュー項目を作成します。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}
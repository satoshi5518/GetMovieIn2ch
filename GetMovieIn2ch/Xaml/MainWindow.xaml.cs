using GetMovieIn2ch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetMovieIn2ch.Xaml
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        #region コンストラクタ
        public MainWindow()
        {
            this.mainViewModel = new MainWindowViewModel();
            this.DataContext = mainViewModel;
            InitializeComponent();
        }
        #endregion

        #region フィールド変数
        private MainWindowViewModel mainViewModel;
        #endregion

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // if()
        }

        private void addUrl_Click(object sender, RoutedEventArgs e)
        {
            UrlInfo addUrlInfo = new UrlInfo();
            addUrlInfo.Name = this.mainViewModel.AddName;
            addUrlInfo.Url = this.mainViewModel.AddUrl;
            addUrlInfo.IdFront = this.mainViewModel.AddIdFront;
            this.mainViewModel.UrlInfoList.Add(addUrlInfo);
        }
    }
}

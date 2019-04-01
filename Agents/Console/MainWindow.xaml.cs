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
using Exhibition.Core.Configuration;
using Exhibition.Core.Models;
using Exhibition.Core;
using Exhibition.Core.Utilities;
using System.Net;
namespace Console
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int btnListCount = 0;//获取库中对应内容的个数
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
            this.Loaded += MainWindow_Loaded;
        }
        
        Endpoint.OperationServiceClient client = new Endpoint.OperationServiceClient();
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


            setGrid();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                this.Close();
            }
        }

        #region 司法课件
        private void sfkj_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid();
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");//FFD2D2D2
            g1.Visibility = Visibility.Visible;

        }
        private void setButton()
        {
            sfcj.Background = Brushes.Transparent;
            fzxsp.Background = Brushes.Transparent;
            jysn.Background = Brushes.Transparent;
            qsnqy.Background = Brushes.Transparent;

            yfxyql.Background = Brushes.Transparent;
            yfxq.Background = Brushes.Transparent;
            yfdpfz.Background = Brushes.Transparent;
            yfwlfz.Background = Brushes.Transparent;
            qtfzxc.Background = Brushes.Transparent;
            yasf.Background = Brushes.Transparent;
            wyzx.Background = Brushes.Transparent;
            wyyz.Background = Brushes.Transparent;
            wyjb.Background = Brushes.Transparent;
        }
        private void setGrid()
        {
            g1.Visibility = Visibility.Collapsed;
            g2.Visibility = Visibility.Collapsed;
            g3.Visibility = Visibility.Collapsed;
            g4.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 法制课件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegalCourseware_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            var resources = QueryResources(btn.Tag.ToString());

            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();

            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g1_1.Visibility = Visibility.Visible;

            btnListCount = 51;
            g1Panel.Children.Clear();
            DrawBtn(resources);
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        private Resource[] QueryResources(string name)
        {
            try
            {
                var resources = client.Query(name);
                return resources;
            }
            catch(Exception ex)
            {
                return new Resource[] { };
            }
            
        }
        private void SendCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                var resource = ((Button)sender).Tag as Resource;
                
                //client.PlayAsync(resource);
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// 绘制按钮
        /// </summary>
        /// <param name="page"></param>
        void DrawBtn(Resource[] resources)
        {
            try
            {
                g1Panel.Columns = 2;
                foreach (var resource in resources)
                {
                    Button btn = new Button();
                    btn.Width = 489;
                    btn.Height = 60;
                    btn.Content = resource.DisplayName;
                    btn.SetResourceReference(ContentControl.StyleProperty, "myBtn");
                    btn.Tag = resource;
                    btn.Click += SendCommand;
                    g1Panel.Children.Add(btn);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString() + "DrawNameBtn");
            }
        }
        #region old code
        /// <summary>
        /// 预防校园欺凌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yfxyql_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var url = $"http://localhost:8888/api/OperationService/Query?name={btn.Tag.ToString()}";
            var resources = url.GetUriJsonContent<Resource[]>().OrderBy(o => o.Name);

            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();

            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g1_1.Visibility = Visibility.Visible;

            btnListCount = 51;
            g1Panel.Children.Clear();
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        /// <summary>
        /// 预防性侵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yfxq_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            btnListCount = 10;
            g1Panel.Children.Clear();
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        /// <summary>
        /// 预防毒品犯罪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yfdpfz_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            btnListCount = 20;
            g1Panel.Children.Clear();
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        /// <summary>
        /// 预防网络犯罪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yfwlfz_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            btnListCount = 2;
            g1Panel.Children.Clear();
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        /// <summary>
        /// 其他法制宣传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qtfzxc_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            g1Panel.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            btnListCount = 3;
            g1Panel.Children.Clear();
            //if (btnListCount > 0)
            //    DrawBtn(btnListCount);
        }
        #endregion
        /// <summary>
        /// 法制课件 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ButtonFzkj_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Controls.Button bt = sender as System.Windows.Controls.Button;
        //    string btTag = bt.Tag.ToString().Trim();
        //    MessageBox.Show("法制课件 发送指令");
        //}


        #endregion
        #region 法制小视频
        private void fzxsp_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            var resources = QueryResources(btn.Tag.ToString());

            setButton();
            setGrid();
            g1Panel.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();

            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g2.Visibility = Visibility.Visible;
            g2Panel.Children.Clear();
            DrawVideoButton(resources);
        }
        /// <summary>
        /// 法制小视频 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button bt = sender as System.Windows.Controls.Button;
            string btTag = bt.Tag.ToString().Trim();
            MessageBox.Show("法制小视频 发送指令");
        }
        /// <summary>
        /// 绘制按钮
        /// </summary>
        /// <param name="page"></param>
        void DrawVideoButton(Resource[] resources)
        {
            foreach (var resource in resources)
            {
                Button btn = new Button();
                btn.Margin = new Thickness(0, 0, 50, 50);
                btn.Width = 384;
                btn.Height = 216;
                btn.Tag = resources;//定义一个类似ID值，用于发送正确指令
                btn.Click += SendCommand;
                string btnImgPath = string.IsNullOrEmpty(resource.ImageUrl) ? "Images/视频窗口 拷贝 2.png" : resource.ImageUrl;
                if (!string.IsNullOrEmpty(btnImgPath))
                {
                    Image img = new Image();
                    img.Stretch = Stretch.Uniform;
                    img.Width = 384;
                    img.Height = 216;
                    img.Source = new BitmapImage(new Uri(btnImgPath, UriKind.RelativeOrAbsolute));
                    btn.Content = img;
                }
                g2Panel.Children.Add(btn);
            }

        }
        #endregion
        #region 少年司法
        private void jysn_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid();
            g1Panel.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g3.Visibility = Visibility.Visible;

            btnListCount = 12;
            g3Panel.Children.Clear();
            if (btnListCount > 0)
                DrawWrapPanel();
        }
        /// <summary>
        /// 少年司法 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSf_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button bt = sender as System.Windows.Controls.Button;
            string btTag = bt.Tag.ToString().Trim();
            MessageBox.Show("少年司法 发送指令");
        }
        /// <summary>
        /// 绘制WrapPanel
        /// </summary>
        /// <param name="page"></param>
        void DrawWrapPanel()
        {
            try
            {
                int num = 21;
                g3Panel.Columns = 2;

                for (int i = 1; i < num; i++)
                {
                    WrapPanel wPanel = new WrapPanel();
                    wPanel.Width = 640;
                    wPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    wPanel.VerticalAlignment = VerticalAlignment.Center;

                    Button btn = new Button();
                    btn.Margin = new Thickness(0, 0, 0, 0);
                    btn.Width = 640;
                    btn.Height = 317;

                    btn.Tag = i;//定义一个类似ID值，用于发送正确指令
                    btn.Click += ButtonSf_Click;

                    string btnImgPath = "Images/图层 28.png";

                    if (!string.IsNullOrEmpty(btnImgPath))
                    {
                        Image img = new Image();
                        img.Stretch = Stretch.Uniform;
                        img.Width = 640;
                        img.Height = 317;
                        img.Source = new BitmapImage(new Uri(btnImgPath, UriKind.RelativeOrAbsolute));
                        btn.Content = img;
                    }
                    TextBlock tBlock = new TextBlock();
                    tBlock.Width = 640;
                    tBlock.FontSize = 36;
                    tBlock.TextAlignment = TextAlignment.Center;
                    tBlock.IsHyphenationEnabled = true;
                    tBlock.TextWrapping = TextWrapping.Wrap;
                    tBlock.Text = "zll";
                    wPanel.Children.Add(btn);
                    wPanel.Children.Add(tBlock);
                    g3Panel.Children.Add(wPanel);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString() + "DrawNameBtn");
            }
        }
        #endregion
        #region 青少年权益保护
        private void qsnqy_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid();
            setGrid4();
            g1Panel.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g4.Visibility = Visibility.Visible;
            imgG4.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 以案说法点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yasf_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid4();
            imgG4.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
        }
        /// <summary>
        /// 我要咨询点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wyzx_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid4();
            imgG4.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g4_1.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// 我要援助点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wyyz_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid4();
            imgG4.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g4_2.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// 我要举报点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wyjb_Click(object sender, RoutedEventArgs e)
        {
            setButton();
            setGrid4();
            var bc = new BrushConverter();
            Button btn = sender as Button;
            btn.Background = (Brush)bc.ConvertFrom("#FF60666E");
            g4_3.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// 我要咨询提交 txtWyzx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWyzx_Click(object sender, RoutedEventArgs e)
        {
            string Wyzx = txtWyzx.Text.ToString().Trim();//填写的要提交的内容
            if (string.IsNullOrWhiteSpace(Wyzx))
                MessageBox.Show("请填写内容");
        }
        /// <summary>
        /// 我要援助提交 txtWyyz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWyyz_Click(object sender, RoutedEventArgs e)
        {
            string Wyyz = txtWyyz.Text.ToString().Trim();//填写的要提交的内容
            if (string.IsNullOrWhiteSpace(Wyyz))
                MessageBox.Show("请填写内容");
        }
        /// <summary>
        /// 我要举报提交 txtWyjb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWyjb_Click(object sender, RoutedEventArgs e)
        {
            string Wyjb = txtWyjb.Text.ToString().Trim();//填写的要提交的内容
            if (string.IsNullOrWhiteSpace(Wyjb))
                MessageBox.Show("请填写内容");
        }
        private void setGrid4()
        {
            g4_1.Visibility = Visibility.Collapsed;
            g4_2.Visibility = Visibility.Collapsed;
            g4_3.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            VirtualKeyboard.ShowInputPanel();
        }
        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            VirtualKeyboard.HideInputPanel();
        }
    }
}

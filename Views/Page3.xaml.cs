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

namespace Wpf_TestCode.Views
{
    /// <summary>
    /// Page3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Buttton1_Click(object sender, RoutedEventArgs e)
        { 
            //합계 호출
            object[] numParams = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Utils.Mediator.NotifyColleagues("Page1ViewModel.AddNumbers", numParams);
        }

        private void Buttton2_Click(object sender, RoutedEventArgs e)
        {
            //인사 호출            
            Utils.Mediator.NotifyColleagues("Page2ViewModel.Greeting", "골드러쉬");
        }
    }
}

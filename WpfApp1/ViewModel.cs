using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace WpfApp1
{
    public class ViewModel : UIModelBase
    {
        private string testFindBingding = $"测试找到Binding的元素";

        /// <summary>
        /// 测试找到binding
        /// </summary>
        public string TestFindBingding
        {
            get => testFindBingding; set
            {
                testFindBingding = value;
                OnPropertyChanged();
            }
        }
    }
}

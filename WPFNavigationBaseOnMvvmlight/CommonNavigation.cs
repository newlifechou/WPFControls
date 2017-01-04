using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace WPFNavigationBaseOnMvvmlight
{
    public static class CommonNavigation
    {
        /// <summary>
        /// 通用导航，通过viewName来区分导航页面，不考虑参数传递
        /// </summary>
        /// <param name="viewName"></param>
        public static void GoToNavigation(string viewName)
        {
            Messenger.Default.Send<string>(viewName, NavigationEnum.Navigate);
        }
    }
}

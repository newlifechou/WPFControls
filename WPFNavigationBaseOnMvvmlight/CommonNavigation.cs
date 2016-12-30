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
        public static void GoToNavigation(string viewName)
        {
            Messenger.Default.Send<string>(viewName, NavigationEnum.Navigate);
        }
    }
}

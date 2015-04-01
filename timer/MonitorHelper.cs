using System.Linq;
using System.Windows.Forms;

namespace Timer
{
    /// <summary>
    /// Класс для получения работы с мониторами
    /// </summary>
    internal static class MonitorHelper
    {
        /// <summary>
        /// Возвращает основной мониторв, если его нет, то возвращается первый из списка доступных мониторов
        /// </summary>
        /// <returns>Основной монитор</returns>
        public static Screen GetPrimaryScreen()
        {
            var returnedScreen = Screen.AllScreens.FirstOrDefault(x => x.Equals(Screen.PrimaryScreen));
            return returnedScreen ?? Screen.AllScreens[0];
        }

        /// <summary>
        /// Возвращает второстепенный монтор, если его нет, то возвращается первый из списка доступных мониторов
        /// </summary>
        /// <returns>Второстепенный монитор</returns>
        public static Screen GetSecondaryScreen()
        {
            var returnedScreen = Screen.AllScreens.FirstOrDefault(x => !x.Equals(Screen.PrimaryScreen));
            return returnedScreen ?? Screen.AllScreens[0];
        }
    }
}

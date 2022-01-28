using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OblikConfigurator
{
    internal static class EventsDecoder
    {
        public static string Decode(int evnt)
        {
            string result;
            switch (evnt)
            {
                case 1:
                    result = "Отключение питания счетчика";
                    break;
                case 2:
                    result = "Включение питания счетчика";
                    break;
                case 3:
                    result = "Служебное соопщение АП";
                    break;
                case 4:
                    result = "Служебное соопщение ЛП";
                    break;
                case 5:
                    result = "Восстановление фазы напряжения";
                    break;
                case 6:
                    result = "Обрыв фазы напряжения";
                    break;
                case 7:
                    result = "Восстановление фазы тока";
                    break;
                case 8:
                    result = "Обрыв фазы тока";
                    break;
                case 9:
                    result = "Запись времени в счетчик (старое время)";
                    break;
                case 10:
                    result = "Запись времени в счетчик (измененное время)";
                    break;
                case 11:
                    result = "Включение режима проверки";
                    break;
                case 12:
                    result = "Отключение режима проверки";
                    break;
                default:
                    result = "Неизвестное событие";
                    break;
            }
            return result;
        }
    }
}

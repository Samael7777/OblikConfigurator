using Oblik;
using System;
using System.Threading.Tasks;

namespace OblikConfigurator
{
    internal class InfoUpdater
    {
        private readonly FormMain mainForm;

        internal InfoUpdater(FormMain form)
        {
            mainForm = form;
        }

        /// <summary>
        /// Асинхронное получение данных со счетчика
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="MeterAction">Метод счетчика</param>
        /// <param name="FormAction">етод формы для обновления данных</param>
        internal async void UpdateAsync<T>(Func<T> MeterAction, Action<T> FormAction = default)
        {
            await Task.Factory.StartNew(() => SafeActionTask(mainForm, MeterAction, FormAction));
        }

        /// <summary>
        /// Получение данных со счетчика
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MeterAction"></param>
        /// <param name="FormAction"></param>
        internal void Update<T>(Func<T> MeterAction, Action<T> FormAction = default)
        {
            SafeActionTask(mainForm, MeterAction, FormAction);
        }

        /// <summary>
        /// Асинхронное выполнение процедуры счетчика
        /// </summary>
        /// <param name="MeterAction">Метод void счетчика</param>
        internal async void ExecuteAsync(Action MeterAction)
        {
            await Task.Factory.StartNew(() => SafeActionTask(mainForm, () => VoidAction(MeterAction)));
        }

        /// <summary>
        /// Выполнение процедуры счетчика
        /// </summary>
        /// <param name="MeterAction">Метод void счетчика</param>
        internal void Execute(Action MeterAction)
        {
            SafeActionTask(mainForm, () => VoidAction(MeterAction));
        }

        /// <summary>
        /// Задача получения данных со счетчика
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="MainForm">Ссылка на главную фому</param>
        /// <param name="MeterAction">Метод счетчика</param>
        /// <param name="FormAction">Метод формы для обновления данных</param>
        private void SafeActionTask<T>(FormMain MainForm, Func<T> MeterAction, Action<T> FormAction = default)
        {
            void dummy<D>(D dum) { }    //Заглушка

            FormAction += dummy;

            T result = default;

            Action<ConnectionStatus> SetConStatus = MainForm.SetConnectionStatus;
            Action<string> Log = MainForm.AddLog;

            int repeats = Settings.Repeats;
            bool status = false;
            while ((repeats > 0) && !status)
            {
                try
                {
                    MainForm.BeginInvoke(SetConStatus, ConnectionStatus.Wait);
                    result = MeterAction();
                    MainForm.BeginInvoke(SetConStatus, ConnectionStatus.OK);
                    status = true;
                }
                catch (OblikIOException ex)
                {
                    status = false;
                    MainForm.BeginInvoke(SetConStatus, ConnectionStatus.Error);
                    if (ex.ErrorCode == Error.OpenPortError)
                    {
                        repeats = 0;
                    }
                    else
                    {
                        repeats--;
                    }
                    if (repeats == 0)
                    {
                        MainForm.BeginInvoke(Log, ex.Message);
                        //Отключение автообновления текущих показаний
                        MainForm.BeginInvoke(new Action(() => MainForm.SetAutoUpdate(false)));
                    }
                }
            }
            if (status)
            {
                MainForm.BeginInvoke(FormAction, result);
            }
        }

        /// <summary>
        /// Заглушка для Func<T>
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool VoidAction(Action action)
        {
            action.Invoke();
            return true;
        }
    }
}
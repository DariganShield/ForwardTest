using ForwardTest.Models;

namespace ForwardTest.Controls
{
    interface ITest
    {
        /// <summary>
        /// Запуск теста двигателя
        /// </summary>
        /// <param name="model">Двигатель</param>
        /// <param name="temperature">Температура окружающей среды</param>
        void Test(AbstractEngine model, double temperature);
    }
}

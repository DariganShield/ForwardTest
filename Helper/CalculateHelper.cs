using System;

namespace ForwardTest.Helper
{
    static class CalculateHelper
    {
        /// <summary>
        /// Расчет крутящего момента в зависимости от скорости вращения каленвала исходя из графика
        /// </summary>
        /// <param name="speed">Скорость вращения каленвала</param>
        /// <param name="dependence">Соответствие момента и скорости</param>
        /// <returns></returns>
        public static double CalculateMoment(double speed, double[,] dependence)
        {
            double k = 0;
            double b = 0;
            int lenth = dependence.Length / dependence.Rank;
            for (int i = 0; i < lenth; i++)
            {
                if (speed == dependence[1, i] || Math.Round(speed, 2) == dependence[1, i])
                {
                    return dependence[0, i];
                }

                else if (speed <= dependence[1, i] && i != 0)
                {
                    k = (dependence[0, i] - dependence[0, i - 1]) / (dependence[1, i] - dependence[1, i - 1]);
                    b = dependence[0, i] - dependence[1, i] * k;
                    return k * speed + b;
                }
            }
            return k * dependence[1, lenth - 1] + b;
        }
    }
}

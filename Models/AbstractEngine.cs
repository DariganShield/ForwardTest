namespace ForwardTest.Models
{
    class AbstractEngine
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Температура перегрева
        /// </summary>
        public double OverTemperature { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        /// </summary>
        public double RatioTemperatureDependancy { get; set; }
    }
}

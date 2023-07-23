namespace ForwardTest.Controls
{
    class HeatingTest : BaseInternalCombustionTest
    {
        /// <summary>
        /// Конечное время теста
        /// </summary>
        public double Time { get => sec; }
        /// <summary>
        /// Момент на конец теста
        /// </summary>
        public double Moment { get => moment; }
        /// <summary>
        /// Температура на конец теста
        /// </summary>
        public double Temperature { get => temperature; }
    }
}

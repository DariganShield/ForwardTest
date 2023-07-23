namespace ForwardTest.Models
{
    class InternalCombustionEngine : AbstractEngine
    {
        /// <summary>
        /// Момент инерции двигателя
        /// </summary>
        public double InertiaMoment { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от крутящего момента
        /// </summary>
        public double HeatingSpeedDependencyTorque { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от вращения коленвала
        /// </summary>
        public double HeatingSpeedDependencyRotation { get; set; }
        /// <summary>
        /// Кусочно линейная зависимость крутящего момента от скорости вращения коленвала
        /// Ввод параметров: Момент, Скорость
        /// </summary>
        public double [,] PiecewiseLinearDependence { get; set; }

    }
}

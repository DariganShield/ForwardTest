using ForwardTest.Helper;
using ForwardTest.Models;

namespace ForwardTest.Controls
{
    class BaseInternalCombustionTest : ITest
    {
        const int factor = 1000;

        protected int sec = 0;
        protected double temperature;
        protected double moment;
        protected double rotationSpeed = 0d;
        protected double acceleration;
        protected double heatingSpeed;
        protected double coolingSpeed;
        protected double power;

        protected double maxPower;
        protected double maxPowerRotation;

        /// <summary>
        /// Запуск теста двигателя
        /// </summary>
        /// <param name="model">Двигатель</param>
        /// <param name="ambientTemperature">Температура окружающей среды</param>
        void ITest.Test(AbstractEngine model, double ambientTemperature)
        {
            if (model is InternalCombustionEngine)
            {
                InternalCombustionEngine engine = (InternalCombustionEngine)model;
                temperature = ambientTemperature;

                while (temperature < engine.OverTemperature)
                {
                    sec++;
                    moment = CalculateHelper.CalculateMoment(rotationSpeed, engine.PiecewiseLinearDependence);
                    if (moment == 0)
                    {
                        break;
                    }
                    heatingSpeed = moment * engine.HeatingSpeedDependencyTorque +
                        rotationSpeed * rotationSpeed * engine.HeatingSpeedDependencyRotation;
                    coolingSpeed = engine.RatioTemperatureDependancy * (ambientTemperature - temperature);
                    acceleration = moment / engine.InertiaMoment;
                    rotationSpeed += acceleration;
                    temperature += (heatingSpeed + coolingSpeed);
                    power = moment * rotationSpeed / factor;

                    if (power > maxPower)
                    {
                        maxPower = power;
                        maxPowerRotation = rotationSpeed;
                    }
                }
            }
        }
    }
}

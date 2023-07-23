using ForwardTest.Controls;
using ForwardTest.Models;
using System;

namespace ForwardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите температуру окружающей среды");
            var console = Console.ReadLine().Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            var result = double.TryParse(console, out double temperature);
            if (result)
            {
                InternalCombustionEngine engine = new InternalCombustionEngine() { Name = "Двигатель внутреннего сгорания", 
                OverTemperature = 110, RatioTemperatureDependancy = 0.1, HeatingSpeedDependencyTorque = 0.01, 
                HeatingSpeedDependencyRotation = 0.0001, InertiaMoment = 10, 
                PiecewiseLinearDependence = new double [,]{ { 20, 75, 100, 105, 75, 0 }, { 0, 75, 150, 200, 250, 300 } }};

                HeatingTest heatTest = new HeatingTest();
                MaxPowerTest powerTest = new MaxPowerTest();

                ITest test1 = (ITest)heatTest;
                ITest test2 = (ITest)powerTest;
                test1.Test(engine, temperature);
                test2.Test(engine, temperature);

                Console.WriteLine(heatTest.Moment != 0 ? string.Format("Перегрев двигателя наступил спустя {0} секунд", heatTest.Time) : 
                    string.Format("Крутящий момент достиг нуля при температуре {0} за время {1}", heatTest.Temperature, heatTest.Time));
                Console.WriteLine(string.Format("Максимальная мощность двигателя {0} кВт была достигнута " +
                    "при скорости вращения каленвала {1} радиан/сек", powerTest.MaxPower, powerTest.MaxPowerRotation));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Данные введены неверно");
                Console.ReadKey();
            }
        }

        
    }
}

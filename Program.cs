using System;
using WeatherData_Observer;

namespace WeatherData_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Requirement

           Develop a application which reads the weather data from Weather Station (Temprature, Hummidity and Pressure)
           Dont' worry reading part, just assume that you can call weather data using getter methods
           And update the current conditions, statistics and forecast dislay.

           There are currenty three display units want get notified when the WeatherData measurement changed.
           CurrentDisplay, StatisticsDisplay and Forecast Display
               
            */

            // var weatherData = new InitialApproach.WeatherData();
            // weatherData.MeasurementChanged(50, 60, 80);

            /*
                Problem: Whenever we need to add new display we have to change the WeatherData class implementation.
                WeatherData object and Display objects are tightly coupled.
             */


             /*
                Right Approach: 
                
                The news paper agency selling the news papers.
                You subscribe the new papers and as longs you subscribed, you get the paper delivered.
                And once unsubscibe, you don't get he paper delivered.

              */

            
            var weatherData1 = new RightApproach.WeatherData();
            weatherData1.SetMeasurements(50, 60, 80);
            weatherData1.AddDisplay(new RightApproach.CurrentDislay());
            weatherData1.AddDisplay(new RightApproach.ForecastDisplay());
           // weatherData1.AddDisplay(new RightApproach.StatisticsDislay());
            weatherData1.MeasurementChanged();



        }
    }
}

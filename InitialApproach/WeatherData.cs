using System;

namespace WeatherData_Observer.InitialApproach
{

    public interface IWeatherData
    {
        void MeasurementChanged(int temprature, int pressure, int humidity);
    }

    public class WeatherData : IWeatherData
    {
        private int temprature  = 0;
        private int pressure = 0;
        private int humidity = 0;

        private CurrentDislay currentDislay = new CurrentDislay();
        private StatisticsDislay statisticsDislay = new StatisticsDislay();
        private ForecastDisplay forecastDisplay = new ForecastDisplay();

        public int GetTemprature()
        {
            return this.temprature;
        }

        public int GetPressure()
        {
            return this.pressure;
        }

        public int GetHumidity()
        {
            return this.humidity;
        }

        public void MeasurementChanged(int temprature, int pressure, int humidity)
        {
            this.temprature = temprature;
            this.pressure = pressure;
            this.humidity = humidity;

            //Issue: Tightly coupling the Display objects
            currentDislay.Update(temprature, pressure, humidity);
            statisticsDislay.Update(temprature, pressure, humidity);
            forecastDisplay.Update(temprature, pressure, humidity);

        }

    }

    interface IDisplay
    {
        void Update(int temprature, int humidity, int pressure);
    }

    public class CurrentDislay : IDisplay
    {
        public void Update(int temprature, int humidity, int pressure)
        {
            Console.WriteLine($"Current Display updated Temprature: {temprature}, Humidity: {humidity}, Pressure: {pressure}");
        }


    }

    public class StatisticsDislay : IDisplay
    {
        public void Update(int temprature, int humidity, int pressure)
        {
            Console.WriteLine($"Statistics Display updated Temprature: {temprature}, Humidity: {humidity}, Pressure: {pressure}");
        }
    }

    public class ForecastDisplay : IDisplay
    {
        public void Update(int temprature, int humidity, int pressure)
        {
            Console.WriteLine($"Forecast Display updated Temprature: {temprature}, Humidity: {humidity}, Pressure: {pressure}");
        }
    }
}
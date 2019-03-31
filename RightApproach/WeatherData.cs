using System;
using System.Collections.Generic;

namespace WeatherData_Observer.RightApproach
{

    public interface IDisplay
    {
        void Update(int temprature, int pressure, int humidity);
    }

    //subject Interface
    public interface IWeatherData
    {
        void MeasurementChanged(); //notifiy the observers when the subject changed (any changes detected)
        void SetMeasurements(int temprature, int pressure, int humidity);

        void AddDisplay(IDisplay display); //add observers
        void RemoveDisplay(IDisplay display); //remove observers
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

    public class WeatherData : IWeatherData
    {

        private int temprature = 0;
        private int pressure = 0;
        private int humidity = 0;
        private List<IDisplay> displayList = new List<IDisplay>();

        public void AddDisplay(IDisplay display)
        {
            displayList.Add(display);
        }

        public void MeasurementChanged()
        {
            foreach(var display in displayList)
            {
                display.Update(temprature, pressure, humidity);
            }
        }

        public void RemoveDisplay(IDisplay display)
        {
            displayList.Remove(display);
        }

            public void AddDisplay()
        {
            throw new NotImplementedException();
        }
    


        public void SetMeasurements(int temprature, int pressure, int humidity)
        {
            this.temprature = temprature;
            this.pressure = pressure;
            this.humidity = humidity;
        }
    }
}
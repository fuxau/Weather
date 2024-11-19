using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using weather;
using static System.Net.WebRequestMethods;

namespace Weather
{
    public partial class MainWindow : Window
    {
        private const string CitiesFilePath = "ville.txt";
        public MainWindow()
        {
            InitializeComponent();
            PopulateCityComboBox();
            GetWeatherDetails("Annecy");

        }

        private void PopulateCityComboBox()
        {
            if (System.IO.File.Exists("../../ville.txt"))
            {
                var ville = System.IO.File.ReadAllLines("../../ville.txt");

                foreach (var city in ville)
                {
                    if (!string.IsNullOrWhiteSpace(city))
                    {
                        cityComboBox.Items.Add(city.Trim());
                    }
                }
            }
        }

        // Gestionnaire d'événement pour le changement de sélection dans la ComboBox
        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCity = cityComboBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedCity))
            {
                GetWeatherDetails(selectedCity);
            }
        }

        // Méthode pour obtenir les détails météorologiques et les afficher
        private async Task GetWeatherDetails(string city)
        {
            string result = await GetWeatherDataAsync(city);
            if (!string.IsNullOrEmpty(result))
            {
                // Désérialisation de la réponse JSON en objet WeatherRoot avec Newtonsoft.Json
                WeatherRoot weatherData = JsonConvert.DeserializeObject<WeatherRoot>(result);

                // Mise à jour de l'interface utilisateur avec les informations météorologiques
                if (weatherData != null)
                {
                    tempLabel.Content = $" {weatherData.current_condition.tmp} °C";
                    temp1Label.Content = $"{weatherData.fcst_day_0.tmax} °C / {weatherData.fcst_day_0.tmin}";
                    temp2Label.Content = $"{weatherData.fcst_day_1.tmax} °C / {weatherData.fcst_day_1.tmin}";
                    temp3Label.Content = $"{weatherData.fcst_day_2.tmax} °C / {weatherData.fcst_day_2.tmin}";
                    temp4Label.Content = $"{weatherData.fcst_day_3.tmax} °C / {weatherData.fcst_day_3.tmin}";
                    temp5Label.Content = $"{weatherData.fcst_day_4.tmax} °C / {weatherData.fcst_day_4.tmin}";
                    dateLabel.Content = $" {weatherData.fcst_day_0.date} ";
                    date1Label.Content = $" {weatherData.fcst_day_1.day_long} ";
                    date2Label.Content = $" {weatherData.fcst_day_2.day_long} ";
                    date3Label.Content = $" {weatherData.fcst_day_3.day_long} ";
                    date4Label.Content = $" {weatherData.fcst_day_4.day_long} ";
                    conditionLabel.Content = $" {weatherData.fcst_day_0.condition} ";
                    condition2Label.Content = $" {weatherData.fcst_day_1.condition} ";
                    condition3Label.Content = $" {weatherData.fcst_day_2.condition} ";
                    condition4Label.Content = $" {weatherData.fcst_day_3.condition} ";
                    condition5Label.Content = $" {weatherData.fcst_day_4.condition} ";
                    NameLabel.Content = $"{weatherData.city_info.name}";


                    string iconUrl = weatherData.current_condition.icon;
                    if (!string.IsNullOrEmpty(iconUrl))
                    {
                        weatherIcon.Source = new BitmapImage(new Uri(iconUrl));
                        weather2Icon.Source = new BitmapImage(new Uri(iconUrl));

                    }
                    string icon2Url = weatherData.fcst_day_1.icon;
                    if (!string.IsNullOrEmpty(icon2Url))
                    {
                        weather3Icon.Source = new BitmapImage(new Uri(icon2Url));
                        ;
                    }
                    string icon3Url = weatherData.fcst_day_2.icon;
                    if (!string.IsNullOrEmpty(icon3Url))
                    {
                        weather4Icon.Source = new BitmapImage(new Uri(icon3Url));
                        
                    }
                    string icon4Url = weatherData.fcst_day_3.icon;
                    if (!string.IsNullOrEmpty(icon4Url))
                    {
                        weather5Icon.Source = new BitmapImage(new Uri(icon4Url));
                        
                    }
                    string icon5Url = weatherData.fcst_day_4.icon_big;
                    if (!string.IsNullOrEmpty(icon5Url))
                    {
                        weather6Icon.Source = new BitmapImage(new Uri(icon5Url));

                    }
                }
            }
        }


        // Méthode asynchrone pour appeler l'API météo
        private async Task<string> GetWeatherDataAsync(string city)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(
                $"https://www.prevision-meteo.ch/services/json/{city}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    // Classes pour les réponses de l'API
    
}

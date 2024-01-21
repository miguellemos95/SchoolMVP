namespace API.CommonAPI;

public static class APIRoutes
{
    public const string Base = "api/";
    public static class WeatherForecast
    {
        public const string Get = $"{Base}get";
        public const string Add = $"{Base}add";
    }

    public static class School
    {
        private const string Endpoint = "school";

        public const string GetAll = $"{Endpoint}/all";
        public const string Get = $"{Endpoint}/get";
        public const string Add = $"{Endpoint}/add";
        public const string Update = $"{Endpoint}/update";
        public const string Remove = $"{Endpoint}/remove";
    }
}
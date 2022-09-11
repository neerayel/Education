using Lab_13.Models;

namespace Lab_13
{
    public static class SampleData
    {
        public static void Initialize(MonitorContext context)
        {
            if (!context.Monitors.Any())
            {
                context.Monitors.AddRange(
                    new Models.Monitor
                    {
                        Manufacturer = "LG",
                        Model = "UltraGear",
                        Code = "24GN600-B",
                        Price = 899.0,
                        AspectRatio = "16:9",
                        Resolution = "1920 × 1080",
                        Diagonal = 23.8,
                        FrameRate = 144,
                        Matrix = "IPS"
                    },
                    new Models.Monitor
                    {
                        Manufacturer = "AOC",
                        Model = "24G2AE",
                        Code = "BK",
                        Price = 669.0,
                        AspectRatio = "16:9",
                        Resolution = "1920×1080",
                        Diagonal = 23.8,
                        FrameRate = 144,
                        Matrix = "IPS"
                    },
                    new Models.Monitor
                    {
                        Manufacturer = "Samsung",
                        Model = "C24F390FHI",
                        Code = "LC24F390FHIX",
                        Price = 675.0,
                        AspectRatio = "16:9",
                        Resolution = "1920 x 1080",
                        Diagonal = 23.5,
                        FrameRate = 60,
                        Matrix = "VA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

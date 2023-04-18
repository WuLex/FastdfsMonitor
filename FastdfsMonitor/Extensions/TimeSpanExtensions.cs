namespace FastdfsMonitor.Extensions
{
    public static class TimeSpanExtensions
    {
        public static double TotalSeconds(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds / 1000;
        }
    }
}

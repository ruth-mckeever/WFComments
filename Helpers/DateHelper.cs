namespace WFComments.Helpers
{
    public class DateHelper
    {
        public string FormatDate(DateTime timestamp)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime oneWeekAgo = DateTime.Today.AddDays(-7);

            if (timestamp >= today)
            {
                return timestamp.ToShortTimeString();
            }
            else if (timestamp >= yesterday)
            {
                return $"Yesterday at {timestamp.ToString("h:mmtt")}";
            }
            else if (timestamp > oneWeekAgo)
            {
                return timestamp.ToString("ddd h:mmtt");
            }

            return timestamp.ToString("dd/MM/yyyy");
        }
    }
}

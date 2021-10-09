using SmartAdmin.WebUI.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartAdmin.WebUI.Extensions
{
    public static class EnumerableExtensions
    {
        public static List<T> ToSafeList<T>(this IEnumerable<T> source) => new List<T>(source);

        public static List<GroupedMyEventsViewModel> groupEvents(this List<MyEventViewModel> events)
        {
            return events.GroupBy(
                q => q.StartDate.ToShortDateString(),
                q => q,
                (key, g) => new GroupedMyEventsViewModel { Date = key, DayEvents = g.ToList() })
                .ToList();
        }
    }
}

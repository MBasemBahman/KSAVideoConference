using System.Collections.Generic;
using System.Linq;

namespace KSAVideoConference.ServiceModel
{
    public static class OrderBy<T>
    {
        public static IEnumerable<T> OrderData(IEnumerable<T> items, string OrderString)
        {
            if (!string.IsNullOrEmpty(OrderString))
            {
                string[] OrderByProp = OrderString.Split(",");

                foreach (string item in OrderByProp)
                {
                    string Prop = item;
                    bool Desc = (Prop.Contains("desc")) ? true : false;

                    Prop = Prop.Replace("desc", "");
                    Prop = Prop.Replace(",", "");
                    Prop = Prop.Trim();

                    System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty(Prop);

                    if (propertyInfo != null)
                    {
                        items = (Desc == true) ?
                            items.OrderByDescending(x => propertyInfo.GetValue(x, null)) :
                            items.OrderBy(x => propertyInfo.GetValue(x, null));
                    }
                }
            }

            return items;
        }
    }
}

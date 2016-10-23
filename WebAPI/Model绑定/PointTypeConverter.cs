using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model绑定
{
    public class PointTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return ParsePoint(value as string);
            }
            return base.ConvertFrom(context, culture, value);
        }

        static Point ParsePoint(string value)
        {
            var point = new Point();
            var split = value.Split(',');
            point.X = double.Parse(split[0]);
            point.Y = double.Parse(split[1]);
            return point;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
    }

    [TypeConverter(typeof(PointTypeConverter))]
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

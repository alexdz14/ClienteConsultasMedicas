using System;
using System.Globalization;
using System.Windows.Data;

namespace ClienteConsultasMedicas.Utils
{
    public class EstadoToTextoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var estado = value?.ToString()?.ToLower();
            return estado == "cancelada" ? "Sí" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == "Sí" ? "cancelada" : "programada";
        }
    }
}

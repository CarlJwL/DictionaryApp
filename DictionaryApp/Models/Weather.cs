using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DictionaryApp.Models
{
    class Weather
    {
        public double Temperture { get; set; }
        public Symbol Symbol { get; set; }
        public char SymbolAsChar => (char)this.Symbol;
        /// <summary>
        /// <para>sun=0</para>
        /// <para>Rain=1</para>
        /// <para>Snow=2</para>
        /// <para>Cloudy=3</para>
        /// </summary>
        public string WeatherType { get; set; }
    }
}

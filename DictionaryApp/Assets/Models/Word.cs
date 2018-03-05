using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Assets.Models
{
    class Word
    {
        String Name { get; set; }
        String Explantion { get; set; }
        public Word(String name,String explantion)
        {
            this.Name = name;
            this.Explantion = explantion;
        }
    }
}

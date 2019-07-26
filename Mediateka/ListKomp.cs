using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka
{
    class ListKomp
    {
        public ListKomp(int id,string Виконавець,string Композиція, string Автор, System.TimeSpan Тривалість, string Слова, float Обсяг_файлу, System.DateTime Дата_створення)
        {
            this.id = id;
            this.Виконавець = Виконавець;
            this.Композиція = Композиція;
            this.Автор = Автор;
            this.Тривалість = Тривалість;
            this.Слова = Слова;
            this.Обсяг_файлу = Обсяг_файлу;
            this.Дата_створення = Дата_створення; 
        }

        public int id { get; set; }
        public string Виконавець { get; set; }
        public string Композиція { get; set; }
        public string Автор { get; set; }
        public System.TimeSpan Тривалість { get; set; }
        public string Слова { get; set; }
        public float Обсяг_файлу { get; set; }
        public System.DateTime Дата_створення { get; set; }

    }
}

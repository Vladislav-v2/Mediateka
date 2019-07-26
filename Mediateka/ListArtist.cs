using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka
{
    class ListArtist
    {
        public ListArtist(int id, string Виконавець,Nullable<System.DateTime> Дата_народження, string Країна, string id_музичний_жанр)
        {
            this.id = id;
            this.Виконавець = Виконавець;
            this.Дата_народження = Дата_народження;
            this.Країна = Країна;
            this.id_музичний_жанр = id_музичний_жанр;
        }

        public int id { get; set; }
        public string Виконавець { get; set; }
        public Nullable<System.DateTime> Дата_народження { get; set; }
        public string Країна { get; set; }
        public string id_музичний_жанр { get; set; }
    }
}

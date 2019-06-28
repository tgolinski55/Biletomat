﻿using Biletomat.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat.Logic
{
    public static class ViewProvider
    {
        private static WyszukajKoncert wyszukajKoncert;
        private static Koncerty listaKoncertów;

        public static WyszukajKoncert GetWyszukajKoncertView()
        {
            if (wyszukajKoncert == null)
                wyszukajKoncert = new WyszukajKoncert();
            return wyszukajKoncert;
        }
        public static Koncerty GetKoncerty()
        {
            if (listaKoncertów == null)
                listaKoncertów = new Koncerty();
            return listaKoncertów;
        }
    }
}

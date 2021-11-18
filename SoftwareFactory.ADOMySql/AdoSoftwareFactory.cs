using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;

namespace SoftwareFactory.ADOMySql
{
    public class AdoSoftwareFactory
    {
        public AdoAGBD Ado { get; set; }
        public AdoSoftwareFactory(AdoAGBD ado)
        {
            Ado = ado;
        }
    }
}

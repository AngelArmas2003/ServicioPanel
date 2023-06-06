using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClassLibraryPC.Business
{
    public class MinGraciaM
    {
        public List<MinGracia> CatalogoCombo(MinGracia entC)
        {
            List<MinGracia> lstMin = new List<MinGracia>();
            MinGracia entM = new MinGracia();
            lstMin = entM.CatalogoMinGracia(entC);
            return lstMin;
        }

        public int MinGraciaAct(string obj)
        {
            int reg = 0;
            MinGracia entM = new MinGracia();
            var myDeserializedClass = JsonConvert.DeserializeObject<MinGracia>(obj);
            entM = myDeserializedClass;
            reg = entM.MinGraciaAct(entM);
            return reg;
        }
    }
}

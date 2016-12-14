using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartagenaZuyd5LayerDemo.BU;
using CartagenaZuyd5LayerDemo.Util;

namespace CartagenaZuyd5LayerDemo.CC
{
    public class CCSpelAanmaken
    {
        public Dictionary<string, object> MaakSpel(Dictionary<String, Object> spelData)
        {
            Spelbord mijnSpelbord = new Spelbord();

            CartagenaUtil.UpdateTypeFromDictionary(mijnSpelbord, spelData);

            return CartagenaUtil.DictionaryFromType(mijnSpelbord);
        }
    }
}
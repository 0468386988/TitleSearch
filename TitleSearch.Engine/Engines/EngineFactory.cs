using System;
using System.Collections.Generic;
using System.Text;

namespace TitleSearch.Engine.Engines
{
    public class EngineFactory
    {
        public BaseEngine GetEngine(string in_strEngineName)
        {
            if (in_strEngineName == null)
            {
                return null;
            }

            string engineName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(in_strEngineName.ToLower());

            Type type = Type.GetType($"TitleSearch.Engine.Engines.{engineName}");
            var obj = Activator.CreateInstance(type);

            return (BaseEngine)obj;
        }
    }
}
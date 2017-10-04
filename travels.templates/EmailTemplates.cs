using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travels.template;

namespace travels.templates
{
    public class EmailTemplates
    {
        static string viewPathTemplate = "EmailTemplates.{0}";      

        public string getTemplate<T>(TempalteType template, T model)
        {
            IRazorLightEngine engine = EngineFactory.CreateEmbedded(typeof(T));

            string templatePath = string.Format(viewPathTemplate, template);           

            string result = engine.Parse(templatePath, model);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace travels.templates
{
    public class TemplateConfiguration
    {
        static string viewPathTemplate = "travels.templates.EmailTemplates.{0}";

       /* public static void Init()
        {
            TemplateServiceConfiguration templateConfig = new TemplateServiceConfiguration();
            templateConfig.TemplateManager = new DelegateTemplateManager(name =>
            {
                string resourcePath = string.Format(viewPathTemplate, name);
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            });
            Engine.Razor = RazorEngineService.Create(templateConfig);

        }*/

        public static string GetStreamContent(string resource)
        {
            var asm = Assembly.GetExecutingAssembly();
            //var resource = string.Format(ResourcePath, folderAndFileInProjectPath);

            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}

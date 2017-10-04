using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace travels.template
{
   /* public class RazorView
    {
        private ExecuteContext context = new ExecuteContext();

        public string TemplateName { get; set; }
        public string Template { get; set; }
        public object Model { get; set; }
       public dynamic ViewBag
        {
            get
            {
                return context.ViewBag;
            }
        

        public RazorView()
        {
        }

        public RazorView(string templateName)
        {
            this.TemplateName = templateName;
        }

        public RazorView(string templateName, object model): this(templateName)
        {
            this.Model = model;
        }

        public string Run()
        {
            string content = null;
            if (!string.IsNullOrEmpty(this.TemplateName))
            {
                content =
                    Engine.Razor.Run(TemplateName, null, Model);
            }
            else if (!string.IsNullOrEmpty(this.Template))
            {
                content =
                                        Engine.Razor.Run(Template, null, Model);

            }

            return content;
        }
    }*/
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Zammers.Models.ViewModels;

namespace Zammers.Infastructure
{
    [HtmlTargetElement("div", Attributes ="page-modeler")]
    public class PaginationTagHelper : TagHelper
    {

        private IUrlHelperFactory uhf;

        public PaginationTagHelper (IUrlHelperFactory holder)
        {
            uhf = holder;
        }
        [ViewContext]
        public ViewContext viewcontext { get; set; }

        public PageHolder PageModeler   { get; set; }
        public string PageAction { get; set; }
        //Each of the PageClasses are used for css styling in the page
        public bool PageClassesEnabled    { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uhelp = uhf.GetUrlHelper(viewcontext);

            TagBuilder finalout = new TagBuilder("div");
            
            for (int i =1; i <= PageModeler.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uhelp.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {//adds css styling to specific classes above
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModeler.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.AddCssClass(PageClass);
                tb.InnerHtml.Append(i.ToString());

                finalout.InnerHtml.AppendHtml(tb);
            }
            tho.Content.AppendHtml(finalout.InnerHtml);
        }
    }
}

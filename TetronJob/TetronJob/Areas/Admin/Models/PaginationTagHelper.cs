using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TetronJob.Areas.Admin.Models
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement("tag-name")]
    public class PaginationTagHelper : TagHelper
    {
        public int PageCount { set; get; }
        public int? CurrentPage { set; get; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.Attributes.SetAttribute("aria-label", "Page navigation");

            int startPage = 1;

            int endPage = 0;

            int basePage = 10;

            if (PageCount > 10)
            {
                
            }
           
            output.PostContent.SetContent($"<ul class=\"pagination pagination-primary\"></ul>");
        }
    }
}

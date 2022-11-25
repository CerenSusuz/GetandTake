using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace GetandTake.Helpers;

[HtmlTargetElement("getandtake-image-link", Attributes = CustomAttributeName )]
public class ImageLinkTagHelper : TagHelper
{
    private const string CustomAttributeName = "category-image-id";

    [HtmlAttributeName(CustomAttributeName)]
    public string CategoryID { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.Add("asp-page", "Image");
        output.AddClass("btn btn-outline-success", HtmlEncoder.Default);
        output.Content.SetContent("Show Image");
        output.Attributes.Add("asp-route-id", $"@category.{CategoryID}");
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GetandTake.Core.Helper;

[HtmlTargetElement("getandtake-link", Attributes = "category-image-id")]
public class ImageLinkTagHelper : TagHelper
{
    [HtmlAttributeName("category-image-id")]
    public string CategoryID { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("class", "btn btn-outline-success");
        output.Attributes.SetAttribute("asp-page", "Image");
        output.Attributes.SetAttribute("asp-route-id", $"@category.{CategoryID}");
    }
}
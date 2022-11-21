using System.Web.Mvc;

namespace GetandTake.Core.Helper;

public static class ImageLinkHtmlHelperExtension
{
    public static MvcHtmlString ProduceImageLink(this HtmlHelper helper, int categoryImageId, string linkText)
    {
        var anchorBuilder = new TagBuilder("a");
        anchorBuilder.MergeAttribute("src", "@imagePath");
        anchorBuilder.MergeAttribute("class", "btn btn-outline-success");
        anchorBuilder.MergeAttribute("asp-page", "Image");
        anchorBuilder.MergeAttribute("asp-route-id", $"@category.{categoryImageId}");

        return new MvcHtmlString(anchorBuilder.ToString());
    }
}

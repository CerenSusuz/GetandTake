using System.Web.Mvc;

namespace GetandTake.Helpers;

public static class ImageLinkHtmlHelperExtension
{
    public static MvcHtmlString ProduceImageLink(int categoryImageId, string linkText)
    {
        var anchorBuilder = new TagBuilder("a");
        anchorBuilder.MergeAttribute("src", "@imagePath");
        anchorBuilder.MergeAttribute("class", "btn btn-outline-success");
        anchorBuilder.MergeAttribute("asp-page", "Image");
        anchorBuilder.MergeAttribute("asp-route-id", $"@category.{categoryImageId}");

        return new MvcHtmlString(anchorBuilder.ToString());
    }
}
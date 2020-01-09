using System.Text;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Demo.SinjulMSBH.TagHelpers
{
	[HtmlTargetElement("section", Attributes = "fsl-filesystem")]
	public class FileSystemTagHelper : TagHelper
	{
		[HtmlAttributeName("fsl-filesystem")]
		public string Id { get; set; }

		[HtmlAttributeName("fsl-filesystem-full-name")]
		public string FullName { get; set; }

		[HtmlAttributeName("fsl-filesystem-full-height")]
		public int? Height { get; set; }

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.Attributes.Add("style",
				$"overflow-y:auto;overflow-x:hidden;height:{Height ?? 400}px");

			StringBuilder sb = new StringBuilder();
			sb.Append($"<div id=\"{Id}0\"></div>");
			sb.Append("<script type=\"text/javascript\">");
			sb.Append("$(document).ready(function () {");
			sb.Append($"fileSystem.build('{(FullName ?? "").Replace(@"\", @"\\")}', '{Id}', 0, 0);");
			sb.Append("});");
			sb.Append("</script>");
			string result = sb.ToString();

			output.Content.SetHtmlContent(result);
		}
	}
}

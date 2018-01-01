﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SiiTrainingProject.Code.TagHelpers
{

    [HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]
    public class ButtonTagHelper : TagHelper
    {
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", $"btn btn-{BsButtonColor}");
        }
    }
}

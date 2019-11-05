using Life.Application.Services.Exercises.DTO;
using Life.Core.Domain.Exercises;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life.TagHelpers
{
    //[HtmlTargetElement("set-renderer")]
    public class SetRendererTagHelper : TagHelper
    {
        public ExerciseType ExerciseType { get; set; }
        public SetDTO Set { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if(ExerciseType == ExerciseType.Strength)
            {
                output.Attributes.Add("class", "col-md-2 col-lg-4");
                output.Content.AppendHtml(
                        $"<div class='card '>" +
                        $"<div class='card-body'>" +
                        $"<h5 class='card-title'>{ExerciseType}</h5>" +
                        $"<div class='card-text'>" +
                        $"<p> <strong>{nameof(Set.Reps)}: </strong>" +
                        $"{Set.Reps} <br>" +
                        $"<strong>{nameof(Set.Weight)}: </strong>" +
                        $"{Set.Weight} </p>" +
                        $"</div>" +
                        $"</div>" +
                        $"<div class='card-footer'>" +
                        $"<small class='text-muted'>Last updated 3 mins ago</small>" +
                        $"</div>" +
                        $"</div>"
                    );
            }
            else
            { 
                output.Attributes.Add("class", "col-md-2 col-lg-4");
                output.Content.AppendHtml(
                        $"<div class='card '>" +
                        $"<div class='card-body'>" +
                        $"<h5 class='card-title'>{ExerciseType}</h5>" +
                        $"<p class='card-text'>{Set.SetDescription}</p>" +
                        $"</div>" +
                        $"<div class='card-footer'>" +
                        $"<small class='text-muted'>{nameof(Set.Duration)}:{Set.Duration}</small>" +
                        $"</div>" +
                        $"</div>" 
                    );
            }
            return Task.CompletedTask;
        }
    }
}

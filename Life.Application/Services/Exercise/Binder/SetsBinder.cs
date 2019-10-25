using Life.Application.Services.Exercise.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Exercise.Binder
{
    public class SetsBinder : IModelBinder
    {
        private List<SetDTO> _sets;
        public SetsBinder()
        {
            _sets = new List<SetDTO>();
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType.Equals(typeof(List<SetDTO>)))
            {
                // ChangeHardcoded attributes to DTO model attributes.
                var list = bindingContext.HttpContext.Request.Form;
                if (list.ContainsKey("Duration") && list.ContainsKey("SetDescription"))
                {
                    CreateDurationSets(bindingContext.HttpContext.Request);
                }
                else
                {
                    CreateWeightSets(bindingContext.HttpContext.Request);
                }
            ((List<SetDTO>)bindingContext.Model).AddRange(_sets);
            }

            return Task.CompletedTask;
        }

        private void CreateDurationSets(HttpRequest request)
        {
            StringValues durationList;
            StringValues setDescriptionList;

            request.Form.TryGetValue("Duration", out durationList);
            request.Form.TryGetValue("SetDescription", out setDescriptionList);

            var durationValuesArray = durationList.ToArray();
            var setDescriptionValuesArray = setDescriptionList.ToArray();

            for (var i = 0; i < durationValuesArray.Length; i++)
            {
                int result;
                var set = new SetDTO
                {
                    Duration = int.TryParse(durationValuesArray[i], out result) ? result : 0, // should trow invalid model error...
                    SetDescription = setDescriptionValuesArray[i]
                };
                _sets.Add(set);
            }
        }

        private void CreateWeightSets(HttpRequest request)
        {
            StringValues weightList;
            StringValues repsList;

            request.Form.TryGetValue("Weight", out weightList);
            request.Form.TryGetValue("Reps", out repsList);

            var weightValuesArray = weightList.ToArray();
            var repsValuesArray = repsList.ToArray();

            for (var i = 0; i < weightValuesArray.Length; i++)
            {
                int weightresult, repsresult;
                var set = new SetDTO
                {
                    Weight = int.TryParse(weightValuesArray[i], out weightresult) ? weightresult : 0, // should trow invalid model error...
                    Reps = int.TryParse(repsValuesArray[i], out repsresult) ? repsresult : 0, // should trow invalid model error...
                };
                _sets.Add(set);
            }
        }

    }
}

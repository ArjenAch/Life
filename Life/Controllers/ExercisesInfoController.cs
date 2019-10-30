using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Life.Application.Services.Interfaces.Exercise;
using Life.Application.Services.Exercise.DTO;

namespace Life.Controllers
{
    public class ExercisesInfoController : Controller
    {
        private readonly IExerciseInfoService _exerciseService;

        public ExercisesInfoController(IExerciseInfoService exerciseService)
        {
            this._exerciseService = exerciseService;
        }

        // GET: ExercisesInfo
        public async Task<IActionResult> Index()
        {
            return View(await _exerciseService.GetAllAsync());
        }

        // GET: ExercisesInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInfo = await _exerciseService.GetByIdAsync((int)id);

            if (exerciseInfo == null)
            {
                return NotFound();
            }

            return View(exerciseInfo);
        }

        // GET: ExercisesInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExercisesInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ExerciseType,Description")] ExerciseInfoDTO exerciseInfo)
        {
            if (ModelState.IsValid)
            {
                await _exerciseService.AddAsync(exerciseInfo);
                await _exerciseService.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(exerciseInfo);
        }

        // GET: ExercisesInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInfo = await _exerciseService.GetByIdAsync((int)id);

            if (exerciseInfo == null)
            {
                return NotFound();
            }
            return View(exerciseInfo);
        }

        // POST: ExercisesInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ExerciseType,Description")] ExerciseInfoDTO exerciseInfo)
        {
            if (id != exerciseInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _exerciseService.Update(exerciseInfo);
                    await _exerciseService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _exerciseService.Exists(exerciseInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseInfo);
        }

        // GET: ExercisesInfo/Delete/5
        public async Task<IActionResult> Delete(int? id, string message = "")
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInfo = await _exerciseService.GetByIdAsync((int)id);

            if (exerciseInfo == null)
            {
                return NotFound();
            }

            if(!string.IsNullOrEmpty(message))
            {
                ViewData["ErrorMessage"] = message;
            }

            return View(exerciseInfo);
        }

        // POST: ExercisesInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _exerciseService.RemoveAsync(id);
            var response = await _exerciseService.SaveAsync();
            if (response.Succes)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete), new { id, message = response.ToString("ExerciseInfo")});
        }
    }
}

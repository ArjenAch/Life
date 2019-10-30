using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Life.Core.Domain.Exercise;
using Life.Data;
using Life.Application.Services.Interfaces.Exercise;
using Life.Application.Services.Exercise;
using Life.Application.Services.Exercise.DTO;

namespace Life.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            return View(await _exerciseService.GetAllAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync((int)id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View(new ExerciseDTO());
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseDTO exerciseDTO) 
        {
            if (ModelState.IsValid)
            {
                await _exerciseService.AddAsync(exerciseDTO);
                await _exerciseService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseDTO); 
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync((int)id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ExerciseDTO exercise)
        {
            if (id != exercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _exerciseService.Update(exercise);
                    await _exerciseService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _exerciseService.Exists(exercise.Id))
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
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync((int)id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _exerciseService.RemoveAsync(id);
            await _exerciseService.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetSetPartial(int typeId)
        {
            if(typeId == (int)ExerciseType.Strength)
            {
                return PartialView("_WeightSetPartial");
            }

            return PartialView("_DurationSetPartial");
        }

    }
}

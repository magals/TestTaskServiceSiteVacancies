using Microsoft.AspNetCore.Mvc;
using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacanciesController : ControllerBase
{
    private readonly IVacanciesRepository vacanciesRepository;

    public VacanciesController(IVacanciesRepository vacanciesRepository)
    {
        this.vacanciesRepository = vacanciesRepository;
    }

    [HttpGet]
    public ActionResult<List<VacancieEntity>> GetAll()
    {
        return Ok(vacanciesRepository.GetAll());
    }

    [HttpPost]
    public ActionResult CreateVacancy([FromBody] VacancieEntity vacancieEntity)
    {
        vacanciesRepository.CreateVacancie(vacancieEntity);
        return Ok();
    }
}

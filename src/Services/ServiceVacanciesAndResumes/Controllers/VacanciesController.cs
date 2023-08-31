using Microsoft.AspNetCore.Mvc;
using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacanciesController : ControllerBase
{
    private readonly ILogger<VacanciesController> logger;
    private readonly IVacanciesRepository vacanciesRepository;

    public VacanciesController(ILogger<VacanciesController> logger,
                               IVacanciesRepository vacanciesRepository)
    {
        this.logger = logger;
        this.vacanciesRepository = vacanciesRepository;
    }

    [HttpGet]
    public ActionResult<List<VacancieEntity>> Get()
    {
        return Ok(vacanciesRepository.GetAll());
    }
}

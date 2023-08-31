using Microsoft.AspNetCore.Mvc;
using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using ServiceVacanciesAndResumes.Infrastructure.Entities;

namespace ServiceVacanciesAndResumes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumesCotroller : ControllerBase
{
    private readonly IResumesRepository resumesRepository;

    public ResumesCotroller(IResumesRepository resumesRepository)
    {
        this.resumesRepository = resumesRepository;
    }

    [HttpGet]
    public ActionResult<List<ResumeEntity>> GetAll()
    {
        return Ok(resumesRepository.GetAll());
    }

    [HttpPost]
    public ActionResult CreateVacancy([FromBody] ResumeEntity resumeEntity)
    {
        resumesRepository.CreateResume(resumeEntity);
        return Ok();
    }
}

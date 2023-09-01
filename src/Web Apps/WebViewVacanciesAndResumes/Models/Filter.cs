using ServiceVacanciesAndResumes.Models;

namespace WebViewVacanciesAndResumes.Models;

public class FilterRequest
{
    public List<ScheduleWork> ScheduleWorks { get; set; } = new List<ScheduleWork>();
    public List<WorkingPosition> WorkingPositions{ get; set; } = new List<WorkingPosition>();
}

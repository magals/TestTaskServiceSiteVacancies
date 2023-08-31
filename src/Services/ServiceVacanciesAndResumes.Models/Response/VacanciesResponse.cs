using ProtoBuf;
namespace ServiceVacanciesAndResumes.Models.Response;

[ProtoContract]
public class VacanciesResponse
{
    [ProtoMember(1)]
    public IReadOnlyList<Vacancy> Vacancies { get; set; }
}


[ProtoContract]
public class Vacancy
{
    [ProtoMember(1)]
    public long VacancieId { get; set; }
    [ProtoMember(2)]
    public string Title { get; set; }
    [ProtoMember(3)]
    public string Text { get; set; }
    [ProtoMember(4)]
    public Models.Vacancy Vacancie { get; set; }
    [ProtoMember(5)]
    public ScheduleWork ScheduleWork { get; set; }
    [ProtoMember(6)]
    public WorkingPosition WorkingPosition { get; set; }
}
using ProtoBuf;
namespace ServiceVacanciesAndResumes.Models.Response;

[ProtoContract]
public class ResumesResponse
{
    [ProtoMember(1)]
    public IReadOnlyList<Resume> Resumes{ get; set; }
}

[ProtoContract]
public class Resume
{
    [ProtoMember(1)]
    public long ResumeId { get; set; }
    [ProtoMember(2)]
    public string Name { get; set; }
    [ProtoMember(3)]
    public string Text { get; set; }
    [ProtoMember(4)]
    public Models.Vacancy Vacancie{ get; set; }
    [ProtoMember(5)]
    public ScheduleWork ScheduleWork{ get; set; }
    [ProtoMember(6)]
    public WorkingPosition WorkingPosition{ get; set; }
}

using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class ResumeCreateRequest
{
    [ProtoMember(1)]
    public string Name { get; set; }
    [ProtoMember(2)]
    public string Text { get; set; }
    [ProtoMember(3)]
    public long VacancieId { get; set; }
    [ProtoMember(4)]
    public string ScheduleWorkTitle { get; set; }
    [ProtoMember(5)]
    public string WorkingPositionTitle { get; set; }
}

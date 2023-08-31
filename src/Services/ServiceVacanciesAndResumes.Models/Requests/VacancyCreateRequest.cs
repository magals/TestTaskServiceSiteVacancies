using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class VacancyCreateRequest
{
    [ProtoMember(1)]
    public string Title { get; set; }
    [ProtoMember(2)]
    public string Text { get; set; }
    [ProtoMember(3)]
    public long VacancieId { get; set; }
    [ProtoMember(4)]
    public long ScheduleWorkId { get; set; }
    [ProtoMember(5)]
    public long WorkingPositionId { get; set; }
}

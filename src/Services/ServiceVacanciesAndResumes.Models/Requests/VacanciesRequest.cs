using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class VacanciesRequest
{

    [ProtoMember(1)]
    public bool Enable { get; set; }
    [ProtoMember(2)]
    public List<ScheduleWork> ScheduleWorks { get; set; }
    [ProtoMember(3)]
    public List<WorkingPosition> WorkingPositions { get; set; }
}
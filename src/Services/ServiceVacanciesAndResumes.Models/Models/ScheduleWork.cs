using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models;

[ProtoContract]
public class ScheduleWork
{
    [ProtoMember(1)]
    public string Title { get; set; }
}

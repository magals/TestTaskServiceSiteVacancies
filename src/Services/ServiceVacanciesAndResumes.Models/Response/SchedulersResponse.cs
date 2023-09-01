using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Response;

[ProtoContract]
public class SchedulersResponse
{
    [ProtoMember(1)]
    public List<ScheduleWork> ScheduleWorks{ get; set; }
}

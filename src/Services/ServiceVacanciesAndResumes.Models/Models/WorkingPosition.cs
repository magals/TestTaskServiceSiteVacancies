using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models;

[ProtoContract]
public class WorkingPosition
{
    [ProtoMember(1)]
    public string Title { get; set; }
}
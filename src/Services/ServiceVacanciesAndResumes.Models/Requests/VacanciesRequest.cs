using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class VacanciesRequest
{
    [ProtoMember(1)]
    public bool Enable { get; set; }
}
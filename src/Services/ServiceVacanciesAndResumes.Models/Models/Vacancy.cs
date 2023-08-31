using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models;

[ProtoContract]
public class Vacancy
{
    [ProtoMember(1)]
    public string Title { get; set; }
}

using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Requests;

[ProtoContract]
public class GetVacationByIdRequest
{
    [ProtoMember(1)]
    public int VacancieId { get; set; }
}

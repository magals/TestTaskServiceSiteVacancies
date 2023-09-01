using ProtoBuf;

namespace ServiceVacanciesAndResumes.Models.Response;

[ProtoContract]
public class WorkingPositionsResponse
{
    [ProtoMember(1)]
    public List<WorkingPosition> WorkingPositions{ get; set; }
}

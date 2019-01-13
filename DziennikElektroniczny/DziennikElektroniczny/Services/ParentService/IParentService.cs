using DziennikElektroniczny.DTO;

namespace DziennikElektroniczny.Services.ParentService
{
    public interface IParentService
    {
        void SendExcuse(AddUsprawiedliwienieDTO addDto);
    }
}
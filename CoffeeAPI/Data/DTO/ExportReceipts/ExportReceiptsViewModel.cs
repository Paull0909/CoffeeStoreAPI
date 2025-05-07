using AutoMapper;

namespace Data.DTO.ExportReceipts
{
    public class ExportReceiptsViewModel
    {
        public int ExportID { get; set; }
        public DateTime ExportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Entities.ExportReceipts, ExportReceiptsViewModel>();
            }
        }
    }
}

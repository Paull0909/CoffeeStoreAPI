using AutoMapper;

namespace Data.DTO.ImportReceipts
{
    public class ImportReceiptsViewModel
    {
        public int ImportID { get; set; }
        public int SupplierID { get; set; }
        public DateTime ImportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Entities.ImportReceipts, ImportReceiptsViewModel>();
            }
        }
    }
}

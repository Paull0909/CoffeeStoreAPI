using AutoMapper;

namespace Data.DTO.Suppliers
{
    public class SuppliersCreateUpdateRequest
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<SuppliersCreateUpdateRequest, Entities.Suppliers>();
            }
        }
    }
}

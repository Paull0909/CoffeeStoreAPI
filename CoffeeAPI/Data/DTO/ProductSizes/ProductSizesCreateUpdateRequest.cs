using AutoMapper;

namespace Data.DTO.ProductSizes
{
    public class ProductSizesCreateUpdateRequest
    {
        public int ProductSizeID { get; set; }
        public int ProductID { get; set; }
        public string SizeName { get; set; }
        public decimal AdditionalPrice { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<ProductSizesCreateUpdateRequest, Entities.ProductSizes>();
            }
        }
    }
}

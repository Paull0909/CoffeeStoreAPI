using AutoMapper;

namespace Data.DTO.Categories_Products
{
    public class Categories_ProductsCreateUpdateRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Categories_ProductsCreateUpdateRequest, Entities.Categories_Products>();
            }
        }
    }
}

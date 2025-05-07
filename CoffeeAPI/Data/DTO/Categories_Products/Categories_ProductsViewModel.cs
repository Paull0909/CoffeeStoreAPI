using AutoMapper;

namespace Data.DTO.Categories_Products
{
    public class Categories_ProductsViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Entities.Categories_Products, Categories_ProductsViewModel>();
            }
        }
    }
}

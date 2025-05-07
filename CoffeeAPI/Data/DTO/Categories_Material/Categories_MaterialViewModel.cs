using AutoMapper;

namespace Data.DTO.Categories_Material
{
    public class Categories_MaterialViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Entities.Categories_Material, Categories_MaterialViewModel>();
            }
        }
    }
}

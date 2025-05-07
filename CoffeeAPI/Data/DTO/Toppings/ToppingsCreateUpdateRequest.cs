using AutoMapper;

namespace Data.DTO.Toppings
{
    public class ToppingsCreateUpdateRequest
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<ToppingsCreateUpdateRequest, Entities.Toppings>();
            }
        }
    }
}

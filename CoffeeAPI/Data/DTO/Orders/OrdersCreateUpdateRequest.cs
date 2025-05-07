using AutoMapper;
using Data.Enum;

namespace Data.DTO.Orders
{
    public class OrdersCreateUpdateRequest
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public string TableNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public TransactionStatus PaymentStatus { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<OrdersCreateUpdateRequest, Entities.Orders>();
            }
        }
    }
}

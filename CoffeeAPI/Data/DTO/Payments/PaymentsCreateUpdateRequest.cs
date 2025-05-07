using AutoMapper;
using Data.Enum;

namespace Data.DTO.Payments
{
    public class PaymentsCreateUpdateRequest
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public TransactionStatus PaymentMethod { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string content { get; set; }
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<PaymentsCreateUpdateRequest, Entities.Payments>();
            }
        }
    }
}

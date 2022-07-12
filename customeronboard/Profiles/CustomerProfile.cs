using AutoMapper;
using customeronboard.Dtos;
using customeronboard.Models;

namespace customeronboard.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<Customer, CustomerCreateDto>();
        }
    }
}

using AutoMapper;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;

namespace StoreProgram_lab4.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMapperClient();
            CreateMapperBasket();
        }
        //У методі CreateMapperClient створюються маппінги між об'єктами Client, ClientRequest і ClientResponse.
        //Видно, що ви дозволяєте автоматичному мапперу AutoMapper виконувати зворотній маппінг з об'єкту ClientResponse до Client та з
        //ClientRequest до Client.
        private void CreateMapperClient()
        {
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientResponse, Client>();
            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientRequest>();

        }
        //У методі CreateMapperBasket ви створюєте маппінг для об'єктів Basket, BasketRequestcs, BasketResponse та
        //BasketWithClientInfoResponse. Здавалося б, це означає, що ви мапите властивості між об'єктами цих класів,
        //а також ви використовуєте ForMember для налаштування відображення певних властивостей, таких як ClientId, ClientName
        //і NumberPhone, з одного об'єкта на інший.
        private void CreateMapperBasket()
        {
            CreateMap<Basket, BasketWithClientInfoResponse>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.ClientID))
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.ClientName))
            .ForMember(dest => dest.NumberPhone, opt => opt.MapFrom(src => src.Client.NumberPhone));
            CreateMap<BasketWithClientInfoResponse, Basket>();

            CreateMap<Basket, BasketResponse>();
            CreateMap<BasketResponse, Basket>();

            CreateMap<BasketRequestcs, Basket>();
            CreateMap<Basket, BasketRequestcs>();
        }
    }
}

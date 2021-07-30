using catalog.Dtos;
using catalog.Entities;

namespace catalog
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item){
            try
            {
               return new ItemDto{
                Id=item.Id,
                Name=item.Name,
                Price=item.Price,
                CreateDate=item.CreateDate
            }; 
            }
            catch (System.Exception exp)
            {
                
                throw;
            }
            
        }
    }
}
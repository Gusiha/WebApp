using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Services
{
    public interface IApartmentDataService
    {
        List<ApartmentModel> GetAllApartments();
        bool InsertApartment(ApartmentModel model);
        int Delete(int id);
        int InsertPayment(ApartmentModel model);
    }
}

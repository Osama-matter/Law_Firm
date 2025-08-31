using Law_Firm.Models.ClsDatabase;

namespace Law_Firm.Reosertiry.Interface
{
    public interface Iservicees
    {


        void Add(ServiceModel OBJ_Course);
        void Edit(ServiceModel OBJ_Course);
        bool Delete(int ID);


        List<ServiceModel> Get_All();

        ServiceModel Find_Using_ID(int ID);
        public void Save(); 
    }
}

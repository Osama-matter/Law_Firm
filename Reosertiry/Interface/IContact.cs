using Law_Firm.Models.ClsDatabase;

namespace Law_Firm.Reosertiry.Interface
{
    public interface IContact
    {


        void Add(ContactFormModel  contactFormModel);
        void Edit(ContactFormModel contactFormModel );
        bool Delete(int ID);


        List<ContactFormModel> Get_All();

        ContactFormModel Find_Using_ID(int ID);
        public void Save(); 
    }
}

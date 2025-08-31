using Law_Firm.Models.ClsDatabase;
using Law_Firm.Models.dbContext;
using Law_Firm.Reosertiry.Interface;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Law_Firm.Reosertiry
{
    public class ContactRepostriy :IContact
    {

        LawFirmdbContext dbcontect; 

        public ContactRepostriy(LawFirmdbContext _dbcontect)
        {
            this.dbcontect=_dbcontect;
        }

        public void Add(ContactFormModel contactFormModel)
        {
            dbcontect.ContactForms.Add(contactFormModel);   
        }

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public void Edit(ContactFormModel contactFormModel)
        {
            dbcontect.Update(contactFormModel); 
        }

        public ContactFormModel Find_Using_ID(int ID)
        {
            return dbcontect.ContactForms.FirstOrDefault(e => e.ID == ID);   
        }

        public List<ContactFormModel> Get_All()
        {
            return dbcontect.ContactForms.ToList();
        }

        public void Save()
        {
            dbcontect.SaveChanges();
        }
    }
}
